using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models;

public partial class BibliotecaDbContext : DbContext
{
    public BibliotecaDbContext()
    {
    }

    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<LibroAutor> LibroAutors { get; set; }

    public virtual DbSet<LibroCategorium> LibroCategoria { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=BibliotecaConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.AutorId).HasName("PK__Autor__F58AE9299A7C78B9");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1E5D2627649");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.LibroId).HasName("PK__Libro__35A1ECEDF49FFDCA");
        });

        modelBuilder.Entity<LibroAutor>(entity =>
        {
            entity.HasKey(e => e.LibroAutorId).HasName("PK__LibroAut__CA86AC3B36E4DC31");

            entity.HasOne(d => d.Autor).WithMany(p => p.LibroAutors).HasConstraintName("FK__LibroAuto__Autor__440B1D61");

            entity.HasOne(d => d.Libro).WithMany(p => p.LibroAutors).HasConstraintName("FK__LibroAuto__Libro__4222D4EF");
        });

        modelBuilder.Entity<LibroCategorium>(entity =>
        {
            entity.HasKey(e => e.LibroCategoriaId).HasName("PK__LibroCat__7279BB83280AF9FF");

            entity.HasOne(d => d.Categoria).WithMany(p => p.LibroCategoria).HasConstraintName("FK__LibroCate__Categ__4316F928");

            entity.HasOne(d => d.Libro).WithMany(p => p.LibroCategoria).HasConstraintName("FK__LibroCate__Libro__412EB0B6");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__usuario__2B3DE7B80F88CD64");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
