using System.Data;
using Microsoft.Data.SqlClient;

namespace ExploracionSubmarina;

public partial class Form1 : Form
{
    private static readonly string ConnectionString =
        Environment.GetEnvironmentVariable("EXPEDICIONES_DB_CONNECTION")
        ?? "Server=.;Database=exploracion_submarina;Trusted_Connection=True;TrustServerCertificate=True;";

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        CargarExpediciones();
    }

    private void btnFiltrar_Click(object sender, EventArgs e)
    {
        CargarExpediciones(txtZonaFiltro.Text);
    }

    private void txtZonaFiltro_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter)
        {
            return;
        }

        CargarExpediciones(txtZonaFiltro.Text);
        e.Handled = true;
        e.SuppressKeyPress = true;
    }

    private void CargarExpediciones(string? zona = null)
    {
        const string query = """
            SELECT e.*, z.nombre AS zona, s.nombre AS sumergible
            FROM [expedición] AS e
            INNER JOIN zona AS z ON z.id = e.id_zona
            INNER JOIN sumergible AS s ON s.id = e.id_sumergible
            WHERE (@zona = '' OR z.nombre LIKE '%' + @zona + '%')
            """;

        var tabla = new DataTable();

        using var conexion = new SqlConnection(ConnectionString);
        using var comando = new SqlCommand(query, conexion);
        comando.Parameters.AddWithValue("@zona", zona?.Trim() ?? string.Empty);
        using var adaptador = new SqlDataAdapter(comando);

        conexion.Open();
        adaptador.Fill(tabla);

        dgvExpediciones.DataSource = tabla;
    }
}
