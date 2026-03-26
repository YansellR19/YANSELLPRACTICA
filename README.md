# Práctica API UNICDA - RAE 7 y 8

**Autor:** Yansell Rafael Rosario Siri

## 🚀 Descripción

API RESTful desarrollada en ASP.NET Core (.NET 9) con base de datos en memoria (Entity Framework Core). Incluye un cliente web frontend para consumir los datos.

## 🛠️ Tecnologías

- **Backend:** C#, .NET 9, ASP.NET Core Web API
- **Base de Datos:** Entity Framework Core (In-Memory)
- **Documentación:** Swagger UI con comentarios XML
- **Frontend:** HTML, Bootstrap, JavaScript (Fetch API con async/await)

## ⚙️ Cómo ejecutar el proyecto

1. Clona este repositorio.
2. Abre la terminal en la carpeta del proyecto.
3. Ejecuta el comando: `dotnet run`
4. Abre la URL que te da la terminal (ej. `http://localhost:5019`) para ver Swagger.
5. Para probar el cliente, simplemente abre el archivo `index.html` en tu navegador.

## 📡 Endpoints Principales

- `GET /api/Libros` - Lista todos los libros.
- `GET /api/Libros/{id}` - Busca un libro específico.
- `POST /api/Libros` - Registra un libro nuevo (Implementa DTO).
- `DELETE /api/Libros/{id}` - Elimina un registro.
