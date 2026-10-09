# exploracion-submarina

Aplicación Windows Forms para consultar expediciones submarinas.

## Configuración rápida

La app usa una cadena de conexión SQL Server desde la variable de entorno:

- `EXPEDICIONES_DB_CONNECTION`

Si no está definida, usa por defecto:

`Server=.;Database=exploracion_submarina;Trusted_Connection=True;TrustServerCertificate=True;`