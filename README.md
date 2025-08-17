# RomiTest
## Descripción
ROMI es una API desarrollada en .NET 8.0 siguiendo los principios de Clean Architecture. El proyecto está dividido en capas independientes para promover la mantenibilidad, escalabilidad y testabilidad.

## Arquitectura
* Capa de Dominio (RomiCapaDominio): Contiene las entidades del negocio, DTOs y reglas de dominio puras, sin dependencias externas.
* Capa de Aplicación (RomiApiAplicacion): Maneja los casos de uso, interfaces de repositorios, mapeos y lógica de aplicación.
* Capa de Infraestructura (RomiCapaInfraestructura): Implementa los repositorios concretos, el DbContext (usando EF Core) y migraciones de base de datos.
* Capa de Presentación (RomiAPI): El proyecto API principal con controladores, configuración de DI y endpoints expuestos.

## Requisitos Previos
* .NET SDK 8.0.
* Herramientas de EF Core
   ```
   dotnet tool install --global dotnet-ef
   ```

## Instalación y Configuración
1. Clona el repositorio:
   ```
   git clone https://github.com/DASTLSITO/RomiTest.git
   ```
2. Navega al directorio de la capa de infraestructura:
   ```
   cd RomiTest/RomiCapaInfraestructura
   ```   
3. Ejecuta la api mediante tu IDE o usando en la terminal:
   ```
   dotnet run --project RomiAPI
   ```
4. Ingresar al swagger para probarlo:
   ```
   http://localhost:5106/swagger/index.html
   ```
