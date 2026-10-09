using ExploracionSubmarinaApp.Data;
using ExploracionSubmarinaApp.Models;
using MySqlConnector;

namespace ExploracionSubmarinaApp.Repositories;

public class CatalogoRepository
{
    public async Task<List<Zona>> ObtenerZonasAsync()
    {
        List<Zona> zonas = new List<Zona>();

        using var conexion = DatabaseConnection.CrearConexion();

        await conexion.OpenAsync();

        const string sql = @" 
                            SELECT 
                            id_zona, 
                            nombre, 
                            ubicacion, 
                            profundidad_maxima 
                            FROM zona 
                            ORDER BY nombre;";

        using var comando = new MySqlCommand(sql, conexion);

        using var lector = await comando.ExecuteReaderAsync();

        while (await lector.ReadAsync())
        {
            Zona zona = new Zona
            {
                IdZona = lector.GetInt32(
                    lector.GetOrdinal("id_zona")
                ),
                Nombre = lector.GetString(
                    lector.GetOrdinal("nombre")
                ),
                Ubicacion = lector.GetString(
                    lector.GetOrdinal("ubicacion")
                ),
                ProfundidadMaxima = lector.GetInt32(
                    lector.GetOrdinal("profundidad_maxima")
                )
            };

            zonas.Add(zona);
        }

        return zonas;
    }

    public async Task<List<Sumergible>> ObtenerSumergiblesAsync()
    {
        List<Sumergible> sumergibles =
            new List<Sumergible>();

        using var conexion = DatabaseConnection.CrearConexion();
        
        await conexion.OpenAsync();
        
        const string sql = @" 
                            SELECT 
                            id_sumergible, 
                            nombre, 
                            modelo, 
                            autonomia_horas 
                            FROM sumergible 
                            ORDER BY nombre;";

        using var comando = new MySqlCommand(sql, conexion);
        using var lector = await comando.ExecuteReaderAsync();
        while (await lector.ReadAsync())
        {
            Sumergible sumergible = new Sumergible
            {
                IdSumergible = lector.GetInt32(
            lector.GetOrdinal("id_sumergible")
            ),
                Nombre = lector.GetString(
            lector.GetOrdinal("nombre")
            ),
                Modelo = lector.GetString(
            lector.GetOrdinal("modelo")
            ),
                AutonomiaHoras = lector.GetInt32(
            lector.GetOrdinal("autonomia_horas")
            )
            };
            sumergibles.Add(sumergible);
        }
        return sumergibles;
    }
}