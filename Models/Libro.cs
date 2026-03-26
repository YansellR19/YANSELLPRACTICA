using System.Text.Json.Serialization;

namespace PRACTICAAPI.Models;

/// <summary> Modelo principal de Libro en la base de datos. </summary>
public class Libro {
    public int Id { get; set; }
    
    [JsonPropertyName("titulo")] 
    public string Titulo { get; set; } = "";
    
    public string Autor { get; set; } = "";
    public decimal Precio { get; set; }
}