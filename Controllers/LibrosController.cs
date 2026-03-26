using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRACTICAAPI.Data;
using PRACTICAAPI.Models;

namespace PRACTICAAPI.Controllers;

/// <summary> Controlador para gestionar el CRUD de libros. </summary>
[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{
    private readonly AppDbContext _db;

    public LibrosController(AppDbContext db) => _db = db;

    /// <summary> Obtiene la lista completa de libros. </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Get() => Ok(await _db.Libros.ToListAsync());

    /// <summary> Busca un libro por su ID. </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetById(int id)
    {
        var libro = await _db.Libros.FindAsync(id);
        return libro == null ? NotFound() : Ok(libro);
    }

    /// <summary> Crea un nuevo libro usando un DTO. </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(LibroDto dto)
    {
        var nuevo = new Libro { Titulo = dto.Titulo, Autor = dto.Autor, Precio = dto.Precio };
        _db.Libros.Add(nuevo);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
    }

    /// <summary> Elimina un libro de la base de datos. </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var libro = await _db.Libros.FindAsync(id);
        if (libro == null) return NotFound();
        _db.Libros.Remove(libro);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}