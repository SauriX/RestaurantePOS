using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RestaurantePOS.Domain.Configuracion;
using RestaurantePOS.Domain.Users;
using System;
using System.Reflection;

namespace RestaurantePOS.context
{
    public class ContextDb : DbContext
    {
 
        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }

        public DbSet<UserType> UserTypes{ get; set; }  // Agregar modelos aquí
        public DbSet<Configurations> Configurations{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    
        }
    }
}
