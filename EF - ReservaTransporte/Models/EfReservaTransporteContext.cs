using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF___ReservaTransporte.Models;

public partial class EfReservaTransporteContext : DbContext
{
    public EfReservaTransporteContext()
    {
    }

    public EfReservaTransporteContext(DbContextOptions<EfReservaTransporteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Conductor> Conductors { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=LAPTOP-79UDIT5H\\SQLEXPRESS;database=EF_ReservaTransporte;Trusted_Connection=True;TrustServerCertificate=True; Encrypt=false;");
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conductor>(entity =>
        {
            entity.HasKey(e => e.ConductorId).HasName("PK__Conducto__BDDAB680CA7952E7");

            entity.ToTable("Conductor");

            entity.Property(e => e.Licencia).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("PK__Reserva__C3993763015BAFB3");

            entity.ToTable("Reserva");

            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.UbicacionDestino).HasMaxLength(255);
            entity.Property(e => e.UbicacionOrigen).HasMaxLength(255);

            entity.HasOne(d => d.Conductor).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ConductorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reserva__Conduct__4E88ABD4");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.VehiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reserva__Vehicul__4D94879B");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.VehiculoId).HasName("PK__Vehiculo__AA088600E7726097");

            entity.ToTable("Vehiculo");

            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.Modelo).HasMaxLength(50);
            entity.Property(e => e.Placa).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
