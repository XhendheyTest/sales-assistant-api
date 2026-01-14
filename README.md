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
   - git clone https://github.com/XhendheyTest/sales-assistant-api.git
cd sales-assistant-api

2. Restaurar paquetes NuGet:
   - dotnet restore
4. Configurar cadena de conexión en appsettings.json:
    -  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=SalesAssistantDb;Trusted_Connection=True;"
  }
5. Ejecutar el Proyecto
   - dotnet ef database update
6. Ejecutar el Proyecto
   - dotnet run

---

## 🔹 Uso de Swagger

1. Abrir Swagger UI en el navegador

2. Registrarse o iniciar sesión para obtener token JWT

3. Hacer click en Authorize

4. Ingresar el token JWT (solo el token, Swagger agrega Bearer)

5. Probar endpoints protegidos por rol Seller:

  - POST /api/sales → Crear venta

  - GET /api/sales → Listar ventas del usuario autenticado

🔹 Captura de Swagger con endpoints protegidos

    Los endpoints con candado 🔒 requieren JWT válido

---

## 🔹 Estructura del proyecto

  SalesAssistantAPI/
  
  │
  
  ├─ Controllers/        # Endpoints de API
    
  ├─ Services/           # Lógica de negocio
 
  ├─ Models/             # Entidades EF Core
 
  ├─ Dtos/               # Data Transfer Objects
 
  ├─ Exceptions/         # Excepciones personalizadas
 
  ├─ Mappings/           # AutoMapper profiles
 
  ├─ Program.cs          # Configuración de pipeline y servicios
 
  ├─ appsettings.json    # Configuración de la aplicación


