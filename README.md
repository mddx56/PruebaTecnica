# 📌 Prueba .NET 8 - Gestión de Tareas de Mantenimiento

Este es un proyecto **API RESTful** desarrollado en **.NET 8** utilizando **Entity Framework Core** y **SQL Server** para la gestión de tareas de mantenimiento en tiendas.

## 🚀 Tecnologías Utilizadas

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **JWT para autenticación**
- **Swagger para documentación**

## 📂 Estructura del Proyecto

```
📁 Proyecto
 ├── 📂 Controllers        # Controladores de la API
 ├── 📂 DB                 # Contexto de Base de Datos
 ├── 📂 Dtos               # Data Transfer Objects
 ├── 📂 Entities           # Modelos de datos
 ├── 📂 Services           # Lógica de negocio
 ├── 📂 Utils              # Funciones y herramientas auxiliares
 ├── appsettings.json      
 ├── Program.cs            
```

## ⚙️ Configuración Inicial

### 1️⃣ Clonar el Repositorio

```bash
git clone https://github.com/mddx56/PruebaTecnica.git
```

### 2️⃣ Configurar la Base de Datos

En appsettings.Development.json, configura la cadena de conexión a SQL Server:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=<AquiTuHost>;Database=PruebaTec;Integrated Security=True;TrustServerCertificate=True"
}
```

### 3️⃣ Crea la base de datos en SQL Server

```bash
  PruebaTec
```

### 4️⃣ Ejecutar el Script Sql
```bash
  DB.sql
```

### 5️⃣ Abrir y Ejecutar el Proyecto en VisualStudio 2022 

### 6️⃣ Importar la Colecion de Apis en Postman
```bash
  PruebaCollectionPostman.json
```  


## 📖 Endpoints Principales

| Método   | Ruta                     | Descripción                    |
| -------- | ------------------------ | ------------------------------ |
| `POST`   | `/api/stores`            | Registrar una Tienda           |
| `GET`    | `/api/stores`            | Obtener todas las tiendas      |
| `GET`    | `/api/stores{id}`        | Obtener tienda por id          |
| `PUT`    | `/api/stores/{id}`       | Actualizar una tienda          |
| `DELETE` | `/api/stores/{id}`       | Eliminar una tienda            |

| Método   | Ruta                                 | Descripción                    |
| -------- | ------------------------------------ | ------------------------------ |
| `POST`   | `/api/tasks`                         | Crear una nueva tarea          |
| `GET`    | `/api/tasks?Page=1&RecordsPerPage=5` | Obtener todas las tareas       |
| `GET`    | `/api/tasks/me`                      | Obtiene las tareas de Usuario  |
| `PUT`    | `/api/tasks/{id}`                    | Actualizar una tarea           |
| `DELETE` | `/api/tasks/{id}`                    | Eliminar una tarea             |

| Método   | Ruta                     | Descripción                    |
| -------- | ------------------------ | ------------------------------ |
| `GET`    | `/api/users`             | Obtener todas las tareas       |
| `PUT`    | `/api/users`             | Actualizar Usuario             |
| `POST`   | `/api/users/signup`      | Registrar un usuario           |
| `POST`   | `/api/users/signin`      | Iniciar sesión y obtener token |
| `GET`    | `/api/users/refresh      | Renovar el access token        |
| `POST`   | `/api/users/make-admin`  | Hacer Admin a Usuario          |
| `POST`   | `/api/users/remove-admin`| Quitar Admin a Usuario         |


## 📌 Documentación con Swagger

Puedes acceder a la documentación interactiva en `https://localhost:7019/swagger` cuando el servidor esté en ejecución.
