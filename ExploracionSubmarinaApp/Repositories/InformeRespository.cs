using System.Data;
using ExploracionSubmarinaApp.Data;
using MySqlConnector;

namespace ExploracionSubmarinaApp.Repositories;

public class InformeRepository
{
    public async Task<DataTable> EjecutarConsultaAsync(
        string codigo,
        DateTime? fechaDesde = null)
    {
        string sql = codigo switch
        {
            "expediciones_join" => @" 
                SELECT 
                    e.id_expedicion, 
                    e.nombre AS expedicion, 
                    e.fecha_salida, 
                    e.duracion_horas, 
                    z.nombre AS zona, 
                    s.nombre AS sumergible 
                FROM expedicion e 
                INNER JOIN zona z ON e.id_zona = z.id_zona 
                INNER JOIN sumergible s ON e.id_sumergible = s.id_sumergible 
                ORDER BY e.fecha_salida DESC;",

                            "muestras_join" => @" 
                SELECT 
                    m.id_muestra, 
                    m.tipo, 
                    m.profundidad_m, 
                    m.masa_kg, 
                    e.nombre AS expedicion 
                FROM muestra m 
                INNER JOIN expedicion e ON m.id_expedicion = e.id_expedicion 
                ORDER BY e.nombre, m.profundidad_m DESC;",

                            "zonas_count" => @" 
                SELECT 
                    z.nombre AS zona, 
                    COUNT(e.id_expedicion) AS numero_expediciones 
                FROM zona z 
                LEFT JOIN expedicion e ON z.id_zona = e.id_zona 
                GROUP BY z.id_zona, z.nombre 
                ORDER BY numero_expediciones DESC, z.nombre;",

                            "investigadores_count" => @" 
                SELECT 
                    i.nombre AS investigador, 
                    i.especialidad, 
                    COUNT(p.id_expedicion) AS numero_expediciones 
                FROM investigador i 
                LEFT JOIN participacion p ON i.id_investigador = p.id_investigador 
                GROUP BY i.id_investigador, i.nombre, i.especialidad 
                ORDER BY numero_expediciones DESC, i.nombre;",

                            "muestras_por_expedicion" => @" 
                SELECT 
                    e.nombre AS expedicion, 
                    COUNT(m.id_muestra) AS numero_muestras, 
                    COALESCE(SUM(m.masa_kg), 0) AS masa_total_kg, 
                    AVG(m.profundidad_m) AS profundidad_media_m, 
                    MAX(m.profundidad_m) AS profundidad_maxima_m, 
 
                    MIN(m.profundidad_m) AS profundidad_minima_m 
                FROM expedicion e 
                LEFT JOIN muestra m ON e.id_expedicion = m.id_expedicion 
                GROUP BY e.id_expedicion, e.nombre 
                ORDER BY numero_muestras DESC;",

                            "resumen_global" => @" 
                SELECT 
                    COUNT(*) AS total_muestras, 
                    COALESCE(SUM(masa_kg), 0) AS masa_total_kg, 
                    AVG(profundidad_m) AS profundidad_media_m, 
                    MAX(profundidad_m) AS profundidad_maxima_m, 
                    MIN(profundidad_m) AS profundidad_minima_m 
                FROM muestra;",

                            "having_muestras" => @" 
                SELECT 
                    e.nombre AS expedicion, 
                    COUNT(m.id_muestra) AS numero_muestras, 
                    COALESCE(SUM(m.masa_kg), 0) AS masa_total_kg 
                FROM expedicion e 
                LEFT JOIN muestra m ON e.id_expedicion = m.id_expedicion 
                GROUP BY e.id_expedicion, e.nombre 
                HAVING COUNT(m.id_muestra) > 2 
                ORDER BY numero_muestras DESC;",

                            "profundidad_por_zona" => @" 
                SELECT 
                    z.nombre AS zona, 
                    AVG(m.profundidad_m) AS profundidad_media_m, 
                    MAX(m.profundidad_m) AS profundidad_maxima_m 
                FROM zona z 
                LEFT JOIN expedicion e ON z.id_zona = e.id_zona 
                LEFT JOIN muestra m ON e.id_expedicion = m.id_expedicion 
                GROUP BY z.id_zona, z.nombre 
                ORDER BY profundidad_media_m DESC;",

                            "zonas_having" => @" 
                SELECT 
                    z.nombre AS zona, 
                    COUNT(e.id_expedicion) AS numero_expediciones 
                FROM zona z 
                INNER JOIN expedicion e ON z.id_zona = e.id_zona 
                GROUP BY z.id_zona, z.nombre 
                HAVING COUNT(e.id_expedicion) >= 2 
                ORDER BY numero_expediciones DESC;",

                            "desde_fecha" => @" 
                SELECT 
                    e.id_expedicion, 
                    e.nombre AS expedicion, 
                    e.fecha_salida, 
                    e.duracion_horas, 
                    z.nombre AS zona, 
                    s.nombre AS sumergible 
                FROM expedicion e 
                INNER JOIN zona z ON e.id_zona = z.id_zona 
                INNER JOIN sumergible s ON e.id_sumergible = s.id_sumergible 
                WHERE e.fecha_salida >= @fecha 
                ORDER BY e.fecha_salida DESC;",

            _ => throw new ArgumentException(
                "El tipo de consulta seleccionado no existe.",
                nameof(codigo)
            )
        };

        using var conexion = DatabaseConnection.CrearConexion();
        await conexion.OpenAsync();
        using var comando = new MySqlCommand(sql, conexion);
        if (codigo == "desde_fecha")
        {
            if (!fechaDesde.HasValue)
            {
                throw new ArgumentException(
                "Debe indicarse una fecha para esta consulta."
                );
            }
            comando.Parameters.Add(
            "@fecha",
            MySqlDbType.Date
            ).Value = fechaDesde.Value.Date;
        }
        using var lector = await comando.ExecuteReaderAsync();
        return await DataTableHelper.LeerAsync(lector);
    }
}