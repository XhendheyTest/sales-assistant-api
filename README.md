# Sales Assistant API

API de ejemplo para gestión de ventas, clientes y productos, con autenticación JWT y roles.  
Construida con **.NET 9**, **Entity Framework Core** y **Swagger**.  

---

## 🔹 Funcionalidades principales

- Registro y autenticación de usuarios con **JWT**  
- Roles de usuario: `Seller`  
- CRUD de ventas, productos y clientes  
- Ventas asociadas al usuario autenticado (`CreatedByUserId`)  
- Validaciones robustas:
  - Cliente no válido
  - Producto no válido
  - Stock insuficiente
- Documentación interactiva de API con **Swagger**
- Ejecución remota y pruebas desde Swagger UI

---

## 🔹 Requisitos

- Visual Studio 2022 (64 bits)  
- .NET 9 SDK  
- SQL Server (Local o en la nube)  
- Git

---

## 🔹 Configuración del proyecto

1. Clonar el repositorio:

```bash
git clone https://github.com/XhendheyTest/sales-assistant-api.git
cd sales-assistant-api

## 🔹 Restaurar paquetes NuGet:
```bash
dotnet restore

## 🔹 Configurar cadena de conexión en appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=SalesAssistantDb;Trusted_Connection=True;"
}

## 🔹 Aplicar migraciones y crear la base de datos:

dotnet ef database update

## 🔹 Ejecutar el proyecto:
dotnet run
