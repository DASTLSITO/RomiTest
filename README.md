# RomiTest
## Descripción
ROMI es una API desarrollada en .NET 8.0 siguiendo los principios de Clean Architecture.

## Arquitectura
* Capa de Dominio (RomiCapaDominio): Contiene las entidades del negocio, DTOs y reglas de dominio puras, sin dependencias externas.
* Capa de Aplicación (RomiApiAplicacion): Maneja los casos de uso, interfaces de repositorios, mapeos y lógica de aplicación.
* Capa de Infraestructura (RomiCapaInfraestructura): Implementa los repositorios concretos, el DbContext (usando EF Core) y migraciones de base de datos.
* Capa de Presentación (RomiAPI): El proyecto API principal con controladores, configuración de DI y endpoints expuestos.

<img width="1011" height="911" alt="DiagramaROMI drawio" src="https://github.com/user-attachments/assets/afe0101c-12cf-4c6e-95a5-5d9d8d094250" />

## Requisitos Previos
* .NET SDK 8.0.
* Herramientas de EF Core (Opcional si quiere hacer migraciones, lo cual no es necesario porque ya incluye la db de SQLite)
   ```
   dotnet tool install --global dotnet-ef
   ```

## Instalación y Configuración
1. Clona el repositorio:
   ```
   git clone https://github.com/DASTLSITO/RomiTest.git
   ```
2. Navega al directorio del proyecto:
   ```
   cd RomiTest
   ```   
3. Ejecuta la api mediante su IDE o usando en la terminal:
   ```
   dotnet run --project RomiAPI
   ```
4. Ingresar al swagger para probarlo:
   ```
   http://localhost:5106/swagger/index.html
   ```
