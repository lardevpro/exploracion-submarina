using ExploracionSubmarinaApp.Models;
using ExploracionSubmarinaApp.Repositories;
using System.Data;
using System.Security.Policy;

namespace ExploracionSubmarinaApp.Forms;

public partial class MainForm : Form
{
    private readonly CatalogoRepository _catalogoRepository = new();
    private readonly ExpedicionRepository _expedicionRepository = new();
    private readonly InformeRepository _informeRepository = new();

    private int? _idSeleccionado;

    public MainForm()
    {
        InitializeComponent();

        ConfigurarControles();
        ConfigurarEventos();
    }

    private void ConfigurarControles()
    {
        ConfigurarGrid(dgvExpediciones);
        ConfigurarGrid(dgvResultados);

        cboZona.DisplayMember = nameof(Zona.Nombre);
        cboZona.ValueMember = nameof(Zona.IdZona);

        cboSumergible.DisplayMember = nameof(Sumergible.Nombre);
        cboSumergible.ValueMember = nameof(Sumergible.IdSumergible);

        cboZona.DropDownStyle = ComboBoxStyle.DropDownList;
        cboSumergible.DropDownStyle = ComboBoxStyle.DropDownList;

        cboConsulta.DisplayMember = "Value";
        cboConsulta.ValueMember = "Key";

        cboConsulta.DataSource =
            new List<KeyValuePair<string, string>>
            {
                new("expediciones_join", "Expediciones con zona y sumergible"), 
                new("muestras_join", "Muestras y expediciones"),
                new("zonas_count", "Número de expediciones por zona"),
                new("investigadores_count", "Participaciones por investigador"), 
                new("muestras_por_expedicion", "Resumen de muestras por expedición"), 
                new("resumen_global", "Resumen global de muestras"),
                new("having_muestras", "Expediciones con más de dos muestras"), 
                new("profundidad_por_zona", "Profundidad media por zona"), 
                new("zonas_having", "Zonas con dos o más expediciones"),
                new("desde_fecha", "Expediciones a partir de una fecha")
            };


        dtpFechaDesde.Enabled = false;
        lblFechaDesde.Enabled = false;
    }

    private void ConfigurarEventos()
    {
        Load += MainForm_Load;

        btnNuevo.Click += (_, _) => LimpiarFormulario();

        btnGuardar.Click += btnGuardar_Click;
        btnEliminar.Click += btnEliminar_Click;

        btnRecargar.Click += async (_, _) =>
            await CargarExpedicionesAsync();

        dgvExpediciones.CellClick += dgvExpediciones_CellClick;

        btnEjecutarInforme.Click += btnEjecutarInforme_Click;

        cboConsulta.SelectedValueChanged += (_, _) =>
            ActualizarFiltroFecha();
    }

    private static void ConfigurarGrid(DataGridView grid)
    {
        grid.ReadOnly = true;
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.MultiSelect = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.AutoGenerateColumns = true;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.RowHeadersVisible = false;
    }

    private async void MainForm_Load(object? sender, EventArgs e)
    {
        try
        {
            cboZona.DataSource =
                await _catalogoRepository.ObtenerZonasAsync();

            cboSumergible.DataSource =
                await _catalogoRepository.ObtenerSumergiblesAsync();

            await CargarExpedicionesAsync();

            lblEstadoConexion.Text =
                "Conexión correcta con MySQL.";
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No se ha podido cargar la información.\n\n" +
                "Comprueba que MySQL está iniciado, que existe la base "
+
                "de datos y que appsettings.json contiene las credenciales correctas.\n\n" + 
                ex.Message,
                "Error de conexión",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            lblEstadoConexion.Text = "Error de conexión";

        }
    }

    private async Task CargarExpedicionesAsync()
    {
        DataTable tabla = await
_expedicionRepository.ObtenerTodasAsync();

        dgvExpediciones.DataSource = tabla;

        CambiarCabecera(
            dgvExpediciones,
            "id_expedicion",
            "ID"
        );

        CambiarCabecera(
            dgvExpediciones,
            "nombre",
            "Expedición"
        );

        CambiarCabecera(
            dgvExpediciones,
            "fecha_salida",
            "Fecha de salida"
        );

        CambiarCabecera(
            dgvExpediciones,
            "duracion_horas",
            "Duración (h)"
        );

        CambiarCabecera(
            dgvExpediciones,
            "zona",
            "Zona"
        );

        CambiarCabecera(
            dgvExpediciones,
            "sumergible",
            "Sumergible"
        );

        if (dgvExpediciones.Columns.Contains("id_zona"))
        {
            dgvExpediciones.Columns["id_zona"].Visible = false;
        }

        if (dgvExpediciones.Columns.Contains("id_sumergible"))
        {
            dgvExpediciones.Columns["id_sumergible"].Visible = false;
        }

        dgvExpediciones.ClearSelection();

        int total = await
_expedicionRepository.ContarExpedicionesAsync();

        lblEstadoConexion.Text =
            $"Conexión correcta. Expediciones registradas: {total}";
    }

    private static void CambiarCabecera(
        DataGridView grid,

        string columna,
        string texto)
    {
        if (grid.Columns.Contains(columna))
        {
            grid.Columns[columna].HeaderText = texto;
        }
    }

    private void dgvExpediciones_CellClick(
        object? sender,
        DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }

        if (dgvExpediciones.Rows[e.RowIndex].DataBoundItem
            is not DataRowView fila)
        {
            return;
        }

        _idSeleccionado = Convert.ToInt32(
            fila["id_expedicion"]
        );

        txtNombre.Text =
            Convert.ToString(fila["nombre"]) ?? string.Empty;

        dtpFechaSalida.Value =
            Convert.ToDateTime(fila["fecha_salida"]);

        nudDuracion.Value = Math.Clamp(
            Convert.ToDecimal(fila["duracion_horas"]),
            nudDuracion.Minimum,
            nudDuracion.Maximum
        );

        cboZona.SelectedValue = Convert.ToInt32(
            fila["id_zona"]
        );

        cboSumergible.SelectedValue = Convert.ToInt32(
            fila["id_sumergible"]
        );

        lblModoRegistro.Text = $"Modo: editando la expedición {_idSeleccionado}";
    }

    private void LimpiarFormulario()
    {
        _idSeleccionado = null;

        txtNombre.Clear();
        dtpFechaSalida.Value = DateTime.Today;
        nudDuracion.Value = nudDuracion.Minimum;

        if (cboZona.Items.Count > 0)
        {
            cboZona.SelectedIndex = 0;
        }

        if (cboSumergible.Items.Count > 0)
        {

            cboSumergible.SelectedIndex = 0;
        }

        dgvExpediciones.ClearSelection();

        lblModoRegistro.Text = "Modo: nueva expedición";
    }

    private async void btnGuardar_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            MessageBox.Show(
                "Introduce el nombre de la expedición.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return;
        }

        var expedicion = new Expedicion
        {
            Nombre = txtNombre.Text.Trim(),
            FechaSalida = dtpFechaSalida.Value.Date,
            DuracionHoras = Convert.ToInt32(nudDuracion.Value),
            IdZona = Convert.ToInt32(cboZona.SelectedValue),
            IdSumergible = Convert.ToInt32(cboSumergible.SelectedValue)
        };

        try
        {
            if (_idSeleccionado.HasValue)
            {
                expedicion.IdExpedicion = _idSeleccionado.Value;
                await _expedicionRepository.ActualizarAsync(expedicion);
                MessageBox.Show("Expedición actualizada correctamente.");
            }
            else
            {
                await _expedicionRepository.InsertarAsync(expedicion);
                MessageBox.Show("Expedición guardada correctamente.");
            }

            await CargarExpedicionesAsync();
            LimpiarFormulario();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnEliminar_Click(object? sender, EventArgs e)
    {
        if (!_idSeleccionado.HasValue)
        {
            MessageBox.Show("Selecciona una expedición para eliminar.");
            return;
        }

        var confirm = MessageBox.Show("¿Estás seguro de eliminar la expedición?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            await _expedicionRepository.EliminarAsync(_idSeleccionado.Value);
            await CargarExpedicionesAsync();
            LimpiarFormulario();
            MessageBox.Show("Expedición eliminada.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnEjecutarInforme_Click(
        object? sender,
        EventArgs e)
    {
        string codigo = cboConsulta.SelectedValue?.ToString()
            ?? string.Empty;

        DateTime? fechaDesde = codigo == "desde_fecha"
            ? dtpFechaDesde.Value.Date
            : null;

        try
        {
            DataTable resultados =
                await _informeRepository.EjecutarConsultaAsync(
                    codigo,
                    fechaDesde
                );

            dgvResultados.DataSource = resultados;

            lblEstadoInforme.Text =
                $"Consulta ejecutada correctamente. " +
                $"Registros obtenidos: {resultados.Rows.Count}";
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No se ha podido ejecutar la consulta.\n\n" +
ex.Message,
                "Error de consulta",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            lblEstadoInforme.Text = "Error al ejecutar la consulta.";
        }
    }

    private void ActualizarFiltroFecha()
    {
        bool necesitaFecha =
            cboConsulta.SelectedValue?.ToString() == "desde_fecha";

        dtpFechaDesde.Enabled = necesitaFecha;
        lblFechaDesde.Enabled = necesitaFecha;
    }
}
