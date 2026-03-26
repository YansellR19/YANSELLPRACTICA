namespace PRACTICAAPI.Middleware;

/// <summary>
/// Middleware global encargado de capturar cualquier excepción no manejada y devolver una respuesta JSON uniforme.
/// </summary>
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Inicializa una nueva instancia del middleware de manejo de errores.
    /// </summary>
    /// <param name="next">El delegado que representa el siguiente componente en la tubería de peticiones.</param>
    public ErrorHandlerMiddleware(RequestDelegate next) => _next = next;

    /// <summary>
    /// Ejecuta el middleware para procesar la petición y capturar posibles errores internos.
    /// </summary>
    /// <param name="context">El contexto de la petición HTTP actual.</param>
    /// <returns>Una tarea que representa la operación asíncrona.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try 
        {
            await _next(context);
        }
        catch (Exception ex) 
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            var response = new {
                message = "Ocurrió un error interno en la API.",
                error = ex.Message,
                timestamp = DateTime.UtcNow
            };

            // Retorna el error en formato JSON estandarizado
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}