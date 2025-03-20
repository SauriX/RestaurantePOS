using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RestaurantePOS.context;
using RestaurantePOS.Helpers;
using RestaurantePOS.Respository;
using RestaurantePOS.Respository.IRespository;
using RestaurantePOS.Services;
using RestaurantePOS.Services.IServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Agrega el contexto de la base de datos
builder.Services.AddDbContext<ContextDb>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
// Agregar servicios al contenedor
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionHandlingFilter>();  // Agregar el filtro global
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://localhost:8080")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .WithExposedHeaders("*")
           .AllowCredentials();

    // U Can Filter Here
}));

//Repositorys
builder.Services.AddScoped<IUserTypeRepository,UserTypeRepository>();
builder.Services.AddScoped<IConfigurationsRepository,ConfigurationsRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IDiscuntRepository, DiscuntRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//Services
builder.Services.AddScoped<IUserTypeService,UserTypeService>();
builder.Services.AddScoped<IConfigurationsService,ConfigurationsService>();
builder.Services.AddScoped<IUsersServices,UsersService>();
builder.Services.AddScoped<IDiscuntService, DiscuntService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


// Configurar autenticación con JWT y cookies
var key = Encryption.DeriveKey(builder.Configuration["Secrets:SecretKey"]);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var cookie = context.Request.Cookies["AuthToken"];
                if (!string.IsNullOrEmpty(cookie))
                {
                    context.Token = cookie;
                }
                return Task.CompletedTask;
            }
        };
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Cookie.HttpOnly = true; // Protege contra XSS
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Solo HTTPS
        options.Cookie.SameSite = SameSiteMode.Strict; // Protege contra CSRF
        options.Cookie.Name = "AuthToken"; // Nombre de la cookie
        options.ExpireTimeSpan = TimeSpan.FromHours(2); // Expiración del token
        options.LoginPath = "/api/User/login"; // Ruta de login
    });


builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();
// Ejecución de Seed en el arranque
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ContextDb>();
    
    // Llama al método SeedTables durante el arranque
    await Seed.SeedTables(context, false);  // Asume `false` si no es necesario actualizar
}
app.UseCors("MyPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
