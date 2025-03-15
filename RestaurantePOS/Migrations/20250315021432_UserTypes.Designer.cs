﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantePOS.context;

#nullable disable

namespace RestaurantePOS.Migrations
{
    [DbContext(typeof(ContextDb))]
    [Migration("20250315021432_UserTypes")]
    partial class UserTypes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantePOS.Domain.Users.UserType", b =>
                {
                    b.Property<int>("Id_UserType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_UserType"));

                    b.Property<string>("NameType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_UserType");

                    b.ToTable("UserTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
