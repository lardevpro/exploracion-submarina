using System.Data;
using MySqlConnector;
namespace ExploracionSubmarinaApp.Data;

public static class DataTableHelper
{
    public static async Task<DataTable> LeerAsync(
    MySqlDataReader lector)
    {
        DataTable tabla = new DataTable();
        for (int i = 0; i < lector.FieldCount; i++)
        {
            tabla.Columns.Add(
            lector.GetName(i),
            lector.GetFieldType(i)
            );
        }
        while (await lector.ReadAsync())
        {
            object[] valores = new object[lector.FieldCount];
            lector.GetValues(valores);
            tabla.Rows.Add(valores);
        }
        return tabla;
    }
}