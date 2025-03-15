using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RestaurantePOS.Domain.Users;
using System;
using System.Reflection;

namespace RestaurantePOS.context
{
    public class ContextDb : DbContext
    {
        private readonly NoTrackingInterceptor _noTrackingInterceptor;
        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }

        public DbSet<UserType> UserTypes{ get; set; }  // Agregar modelos aquí
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Agregar el interceptor al contexto
            optionsBuilder.AddInterceptors(new NoTrackingInterceptor());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    
        }
    }
}
