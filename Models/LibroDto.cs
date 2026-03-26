namespace PRACTICAAPI.Models;

/// <summary> Objeto de transferencia de datos para crear un nuevo libro. </summary>
public class LibroDto {
    public string Titulo { get; set; } = "";
    public string Autor { get; set; } = "";
    public decimal Precio { get; set; }
}