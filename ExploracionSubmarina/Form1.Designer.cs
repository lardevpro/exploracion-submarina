namespace ExploracionSubmarina;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblZona = new Label();
        txtZonaFiltro = new TextBox();
        btnFiltrar = new Button();
        dgvExpediciones = new DataGridView();
        panelFiltros = new Panel();
        ((System.ComponentModel.ISupportInitialize)dgvExpediciones).BeginInit();
        panelFiltros.SuspendLayout();
        SuspendLayout();
        // 
        // panelFiltros
        // 
        panelFiltros.Controls.Add(btnFiltrar);
        panelFiltros.Controls.Add(txtZonaFiltro);
        panelFiltros.Controls.Add(lblZona);
        panelFiltros.Dock = DockStyle.Top;
        panelFiltros.Location = new Point(0, 0);
        panelFiltros.Name = "panelFiltros";
        panelFiltros.Padding = new Padding(12);
        panelFiltros.Size = new Size(900, 56);
        panelFiltros.TabIndex = 0;
        // 
        // lblZona
        // 
        lblZona.AutoSize = true;
        lblZona.Location = new Point(12, 18);
        lblZona.Name = "lblZona";
        lblZona.Size = new Size(103, 15);
        lblZona.TabIndex = 0;
        lblZona.Text = "Nombre de zona:";
        // 
        // txtZonaFiltro
        // 
        txtZonaFiltro.Location = new Point(121, 15);
        txtZonaFiltro.Name = "txtZonaFiltro";
        txtZonaFiltro.Size = new Size(300, 23);
        txtZonaFiltro.TabIndex = 1;
        txtZonaFiltro.KeyDown += txtZonaFiltro_KeyDown;
        // 
        // btnFiltrar
        // 
        btnFiltrar.Location = new Point(427, 14);
        btnFiltrar.Name = "btnFiltrar";
        btnFiltrar.Size = new Size(90, 25);
        btnFiltrar.TabIndex = 2;
        btnFiltrar.Text = "Filtrar";
        btnFiltrar.UseVisualStyleBackColor = true;
        btnFiltrar.Click += btnFiltrar_Click;
        // 
        // dgvExpediciones
        // 
        dgvExpediciones.AllowUserToAddRows = false;
        dgvExpediciones.AllowUserToDeleteRows = false;
        dgvExpediciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvExpediciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvExpediciones.Dock = DockStyle.Fill;
        dgvExpediciones.Location = new Point(0, 56);
        dgvExpediciones.MultiSelect = false;
        dgvExpediciones.Name = "dgvExpediciones";
        dgvExpediciones.ReadOnly = true;
        dgvExpediciones.RowHeadersVisible = false;
        dgvExpediciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvExpediciones.Size = new Size(900, 464);
        dgvExpediciones.TabIndex = 1;
        // 
        // Form1
        // 
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(900, 520);
        Controls.Add(dgvExpediciones);
        Controls.Add(panelFiltros);
        Name = "Form1";
        Text = "Consulta de expediciones submarinas";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)dgvExpediciones).EndInit();
        panelFiltros.ResumeLayout(false);
        panelFiltros.PerformLayout();
        ResumeLayout(false);
    }

    private Label lblZona;
    private TextBox txtZonaFiltro;
    private Button btnFiltrar;
    private DataGridView dgvExpediciones;
    private Panel panelFiltros;

    #endregion
}
