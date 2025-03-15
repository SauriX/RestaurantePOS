using Microsoft.EntityFrameworkCore;
using RestaurantePOS.context;
using RestaurantePOS.Respository;
using RestaurantePOS.Respository.IRespository;
using RestaurantePOS.Services;
using RestaurantePOS.Services.IServices;

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
    builder.WithOrigins("*")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .WithExposedHeaders("*");

    // U Can Filter Here
}));

//Repositorys
builder.Services.AddScoped<IUserTypeRepository,UserTypeRepository>();
//Services
builder.Services.AddScoped<IUserTypeService,UserTypeService>();
var app = builder.Build();

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
