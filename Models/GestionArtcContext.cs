using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ZZZZRegistroArticulos.Models;

public partial class GestionArtcContext : DbContext
{
    public GestionArtcContext()
    {
    }

    public GestionArtcContext(DbContextOptions<GestionArtcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.IdArticulo).HasName("PK__Articulo__D536DE36A088AF12");

            entity.Property(e => e.IdArticulo).HasColumnName("Id_Articulo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(35)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
