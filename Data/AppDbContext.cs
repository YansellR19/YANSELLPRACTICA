using Microsoft.EntityFrameworkCore;
using PRACTICAAPI.Models;

namespace PRACTICAAPI.Data;

/// <summary> Contexto de la base de datos en memoria. </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Libro> Libros => Set<Libro>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        // 3 registros para cumplir con la rúbrica
        b.Entity<Libro>().HasData(
            new Libro { Id = 1, Titulo = "El Quijote", Autor = "Miguel de Cervantes", Precio = 25.50m },
            new Libro { Id = 2, Titulo = "Cien años de soledad", Autor = "Gabo", Precio = 20.00m },
            new Libro { Id = 3, Titulo = "1984", Autor = "George Orwell", Precio = 18.00m }
        );
    }
}