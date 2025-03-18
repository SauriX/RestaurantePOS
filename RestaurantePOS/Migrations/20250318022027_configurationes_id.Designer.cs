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
    [Migration("20250318022027_configurationes_id")]
    partial class configurationes_id
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantePOS.Domain.Configuracion.Configurations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AbrirCaja")
                        .HasColumnType("bit");

                    b.Property<string>("AlertaCorte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AutoBackup")
                        .HasColumnType("bit");

                    b.Property<bool>("AutoPrint")
                        .HasColumnType("bit");

                    b.Property<string>("BkpAlias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailNotificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EnviarSMS")
                        .HasColumnType("bit");

                    b.Property<string>("EstablecimientoNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImpresoraCobros")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImpresoraCortes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImpresoraCuentas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImpresoraDomicilio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RFC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Representante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Configurations");
                });

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
