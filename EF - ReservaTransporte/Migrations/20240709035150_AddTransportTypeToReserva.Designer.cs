﻿// <auto-generated />
using System;
using EF___ReservaTransporte.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF___ReservaTransporte.Migrations
{
    [DbContext(typeof(EfReservaTransporteContext))]
    [Migration("20240709035150_AddTransportTypeToReserva")]
    partial class AddTransportTypeToReserva
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF___ReservaTransporte.Models.Conductor", b =>
                {
                    b.Property<int>("ConductorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConductorId"));

                    b.Property<string>("Licencia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ConductorId")
                        .HasName("PK__Conducto__BDDAB680CA7952E7");

                    b.ToTable("Conductor", (string)null);
                });

            modelBuilder.Entity("EF___ReservaTransporte.Models.Reserva", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaId"));

                    b.Property<int>("ConductorId")
                        .HasColumnType("int");

                    b.Property<bool>("Confirmada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime");

                    b.Property<string>("TransportType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UbicacionDestino")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UbicacionOrigen")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("ReservaId")
                        .HasName("PK__Reserva__C3993763015BAFB3");

                    b.HasIndex("ConductorId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("Reserva", (string)null);
                });

            modelBuilder.Entity("EF___ReservaTransporte.Models.Vehiculo", b =>
                {
                    b.Property<int>("VehiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehiculoId"));

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("VehiculoId")
                        .HasName("PK__Vehiculo__AA088600E7726097");

                    b.ToTable("Vehiculo", (string)null);
                });

            modelBuilder.Entity("EF___ReservaTransporte.Models.Reserva", b =>
                {
                    b.HasOne("EF___ReservaTransporte.Models.Conductor", "Conductor")
                        .WithMany("Reservas")
                        .HasForeignKey("ConductorId")
                        .IsRequired()
                        .HasConstraintName("FK__Reserva__Conduct__4E88ABD4");

                    b.HasOne("EF___ReservaTransporte.Models.Vehiculo", "Vehiculo")
                        .WithMany("Reservas")
                        .HasForeignKey("VehiculoId")
                        .IsRequired()
                        .HasConstraintName("FK__Reserva__Vehicul__4D94879B");

                    b.Navigation("Conductor");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("EF___ReservaTransporte.Models.Conductor", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("EF___ReservaTransporte.Models.Vehiculo", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
