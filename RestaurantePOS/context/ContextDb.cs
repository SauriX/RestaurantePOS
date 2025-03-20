using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using RestaurantePOS.Domain.Configuration;
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
        public DbSet<Users> Users{ get; set; }
        public DbSet<Discunts> Discunts{ get; set; }
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
