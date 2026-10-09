# exploracion-submarina

# 🌊 Exploración Submarina App

Una aplicación de escritorio desarrollada en **C# con Windows Forms (.NET)** para gestionar, consultar y analizar los datos recolectados en expediciones científicas submarinas. 

El proyecto cuenta con un diseño de arquitectura limpia separando las responsabilidades de datos, lógica de negocio e interfaz gráfica.

---

## 🏗️ Estructura del Proyecto

El código está organizado bajo el patrón de diseño repositorio para asegurar la escalabilidad:

*   📂 **`Data/`**: Configuración del contexto de la base de datos y cadenas de conexión.
*   📂 **`Models/`**: Clases que representan las entidades del dominio (`Expedicion`, `Sumergible`, `Zona`, `Muestra`, `Investigador`).
*   📂 **`Repositories/`**: Capa de acceso a datos para encapsular las consultas y filtros SQL.
*   📂 **`Forms/`**: Formularios y controles de la interfaz de usuario (WinForms).

---

## 🗄️ Esquema de la Base de Datos

La aplicación consume un modelo relacional que vincula los siguientes componentes críticos:
*   **Expediciones**: Registro central de las salidas al mar, vinculando el vehículo y la zona explorada.
*   **Sumergibles**: Inventario de vehículos autónomos y tripulados con su autonomía de batería/combustible.
*   **Zonas**: Puntos geográficos específicos y sus profundidades máximas registradas.
*   **Muestras & Tripulación**: Gestión de investigadores participantes y los elementos físicos recolectados del fondo marino.

---

## 🚀 Requisitos e Instalación

1. Asegúrate de tener instalado el SDK de **.NET 8.0** (o superior).
2. Clona este repositorio en tu máquina local:
   ```bash
   git clone https://github.com
   ```
3. Configura tu cadena de conexión en el archivo `appsettings.json`.
4. Compila y ejecuta el proyecto:
   ```bash
   dotnet run
   ```
