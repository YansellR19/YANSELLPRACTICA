using Microsoft.EntityFrameworkCore;
using PRACTICAAPI.Data;
using System.Reflection;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using PRACTICAAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configuración de JSON (camelCase y referencias circulares)
builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Base de datos en memoria
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("LibrosDb"));

// Configuración de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "API Gestión de Libros", 
        Version = "v1",
        Description = "API RESTful documentada para RAE 7 y 8" 
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Habilitar CORS para el frontend
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Middleware global de manejo de errores
app.UseMiddleware<ErrorHandlerMiddleware>();

// Activar Swagger UI en la raíz
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();
app.UseCors(); 
app.UseAuthorization();
app.MapControllers(); 

app.Run();