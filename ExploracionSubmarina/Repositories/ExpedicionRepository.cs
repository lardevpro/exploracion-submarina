using System.Data;
using ExploracionSubmarinaApp.Data;
using ExploracionSubmarinaApp.Models;
using MySqlConnector;

namespace ExploracionSubmarinaApp.Repositories;

public class ExpedicionRepository
{
    public async Task<DataTable> ObtenerTodasAsync()
    {
        using var conexion = DatabaseConnection.CrearConexion();

        await conexion.OpenAsync();

        const string sql = @" 
SELECT 
    e.id_expedicion, 
    e.nombre, 
    e.fecha_salida, 
    e.duracion_horas, 
    e.id_zona, 
    z.nombre AS zona, 
    e.id_sumergible, 
    s.nombre AS sumergible 
FROM expedicion e 
INNER JOIN zona z 
    ON e.id_zona = z.id_zona 
INNER JOIN sumergible s 
    ON e.id_sumergible = s.id_sumergible 
ORDER BY e.fecha_salida DESC, e.id_expedicion DESC;";

        using var comando = new MySqlCommand(sql, conexion);

        using var lector = await comando.ExecuteReaderAsync();

        return await DataTableHelper.LeerAsync(lector);
    }

    public async Task InsertarAsync(Expedicion expedicion)
    {
        using var conexion = DatabaseConnection.CrearConexion();

        await conexion.OpenAsync();

        const string sql = @" 
INSERT INTO expedicion 
(nombre, fecha_salida, duracion_horas, id_zona, id_sumergible) 
VALUES 
(@nombre, @fecha_salida, @duracion_horas, @id_zona, @id_sumergible);";

        using var comando = new MySqlCommand(sql, conexion);

        AgregarParametros(comando, expedicion);

        await comando.ExecuteNonQueryAsync();
    }

    public async Task ActualizarAsync(Expedicion expedicion)
    {
        using var conexion = DatabaseConnection.CrearConexion();

        await conexion.OpenAsync();


        const string sql = @" 
UPDATE expedicion 
SET nombre = @nombre, 
    fecha_salida = @fecha_salida, 
    duracion_horas = @duracion_horas, 
    id_zona = @id_zona, 
    id_sumergible = @id_sumergible 
WHERE id_expedicion = @id_expedicion;";

        using var comando = new MySqlCommand(sql, conexion);

        AgregarParametros(comando, expedicion);

        comando.Parameters.Add(
            "@id_expedicion",
            MySqlDbType.Int32
        ).Value = expedicion.IdExpedicion;

        await comando.ExecuteNonQueryAsync();
    }

    public async Task EliminarAsync(int idExpedicion)
    {
        using var conexion = DatabaseConnection.CrearConexion();

        await conexion.OpenAsync();

        using var transaccion = await conexion.BeginTransactionAsync();

        try
        {
            await EjecutarBorradoAsync(
                conexion,
                transaccion,
                "DELETE FROM muestra WHERE id_expedicion = @id",
                idExpedicion
            );

            await EjecutarBorradoAsync(
                conexion,
                transaccion,
                "DELETE FROM participacion WHERE id_expedicion = @id",
                idExpedicion
            );

            await EjecutarBorradoAsync(
                conexion,
                transaccion,
                "DELETE FROM expedicion WHERE id_expedicion = @id",
                idExpedicion
            );

            await transaccion.CommitAsync();
        }
        catch
        {
            try
            {
                await transaccion.RollbackAsync();
            }
            catch
            {
                // Conservamos el error original. 
            }

            throw;
        }

    }

    public async Task<int> ContarExpedicionesAsync()
    {
        using var conexion = DatabaseConnection.CrearConexion();

        await conexion.OpenAsync();

        const string sql = "SELECT COUNT(*) FROM expedicion;";

        using var comando = new MySqlCommand(sql, conexion);

        object? resultado = await comando.ExecuteScalarAsync();

        return Convert.ToInt32(resultado);
    }

    private static void AgregarParametros(
        MySqlCommand comando,
        Expedicion expedicion)
    {
        comando.Parameters.Add(
            "@nombre",
            MySqlDbType.VarChar
        ).Value = expedicion.Nombre;

        comando.Parameters.Add(
            "@fecha_salida",
            MySqlDbType.Date
        ).Value = expedicion.FechaSalida.Date;

        comando.Parameters.Add(
            "@duracion_horas",
            MySqlDbType.Int32
        ).Value = expedicion.DuracionHoras;

        comando.Parameters.Add(
            "@id_zona",
            MySqlDbType.Int32
        ).Value = expedicion.IdZona;

        comando.Parameters.Add(
            "@id_sumergible",
            MySqlDbType.Int32
        ).Value = expedicion.IdSumergible;
    }

    private static async Task EjecutarBorradoAsync(
        MySqlConnection conexion,
        MySqlTransaction transaccion,
        string sql,
        int idExpedicion)
    {
        using var comando = new MySqlCommand(
            sql,
            conexion,
            transaccion
        );

        comando.Parameters.Add(
            "@id",
            MySqlDbType.Int32
        ).Value = idExpedicion;

        await comando.ExecuteNonQueryAsync();
    }
}