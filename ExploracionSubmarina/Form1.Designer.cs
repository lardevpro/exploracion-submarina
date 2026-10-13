namespace ExploracionSubmarinaApp
{
    partial class tabPrincipal
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
            tabControl1 = new TabControl();
            tabExpediciones = new TabPage();
            tlpExpediciones = new TableLayoutPanel();
            grpDatosExpedicion = new GroupBox();
            comboBox1 = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            dataGridView1 = new DataGridView();
            tabInformes = new TabPage();
            tabControl1.SuspendLayout();
            tabExpediciones.SuspendLayout();
            tlpExpediciones.SuspendLayout();
            grpDatosExpedicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabExpediciones);
            tabControl1.Controls.Add(tabInformes);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(984, 561);
            tabControl1.TabIndex = 0;
            // 
            // tabExpediciones
            // 
            tabExpediciones.Controls.Add(tlpExpediciones);
            tabExpediciones.Location = new Point(4, 24);
            tabExpediciones.Name = "tabExpediciones";
            tabExpediciones.Padding = new Padding(3);
            tabExpediciones.Size = new Size(976, 533);
            tabExpediciones.TabIndex = 0;
            tabExpediciones.Text = "tabPage1";
            tabExpediciones.UseVisualStyleBackColor = true;
            // 
            // tlpExpediciones
            // 
            tlpExpediciones.ColumnCount = 1;
            tlpExpediciones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpExpediciones.Controls.Add(grpDatosExpedicion, 0, 0);
            tlpExpediciones.Controls.Add(flowLayoutPanel1, 0, 1);
            tlpExpediciones.Controls.Add(dataGridView1, 0, 2);
            tlpExpediciones.Dock = DockStyle.Fill;
            tlpExpediciones.Location = new Point(3, 3);
            tlpExpediciones.Name = "tlpExpediciones";
            tlpExpediciones.RowCount = 3;
            tlpExpediciones.RowStyles.Add(new RowStyle(SizeType.Absolute, 170F));
            tlpExpediciones.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tlpExpediciones.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tlpExpediciones.Size = new Size(970, 527);
            tlpExpediciones.TabIndex = 0;
            tlpExpediciones.Paint += tlpExpediciones_Paint;
            // 
            // grpDatosExpedicion
            // 
            grpDatosExpedicion.Controls.Add(comboBox1);
            grpDatosExpedicion.Controls.Add(label5);
            grpDatosExpedicion.Controls.Add(label4);
            grpDatosExpedicion.Controls.Add(numericUpDown1);
            grpDatosExpedicion.Controls.Add(label3);
            grpDatosExpedicion.Controls.Add(dateTimePicker1);
            grpDatosExpedicion.Controls.Add(label2);
            grpDatosExpedicion.Controls.Add(textBox1);
            grpDatosExpedicion.Controls.Add(label1);
            grpDatosExpedicion.Dock = DockStyle.Fill;
            grpDatosExpedicion.Location = new Point(3, 3);
            grpDatosExpedicion.Name = "grpDatosExpedicion";
            grpDatosExpedicion.Size = new Size(964, 164);
            grpDatosExpedicion.TabIndex = 0;
            grpDatosExpedicion.TabStop = false;
            grpDatosExpedicion.Text = "Datos de la expedición ";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(547, 28);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(501, 28);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 8;
            label5.Text = "label5";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(674, 31);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 6;
            label4.Text = "label4";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(161, 108);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 116);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 4;
            label3.Text = "label3";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(161, 75);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 75);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(161, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 31);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(3, 173);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(200, 44);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 223);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 2;
            // 
            // tabInformes
            // 
            tabInformes.Location = new Point(4, 24);
            tabInformes.Name = "tabInformes";
            tabInformes.Padding = new Padding(3);
            tabInformes.Size = new Size(976, 533);
            tabInformes.TabIndex = 1;
            tabInformes.Text = "tabPage2";
            tabInformes.UseVisualStyleBackColor = true;
            // 
            // tabPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(tabControl1);
            MinimumSize = new Size(1000, 600);
            Name = "tabPrincipal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Exploración submarina - Gestión de expediciones ";
            WindowState = FormWindowState.Maximized;
            tabControl1.ResumeLayout(false);
            tabExpediciones.ResumeLayout(false);
            tlpExpediciones.ResumeLayout(false);
            grpDatosExpedicion.ResumeLayout(false);
            grpDatosExpedicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabExpediciones;
        private TabPage tabInformes;
        private TableLayoutPanel tlpExpediciones;
        private GroupBox grpDatosExpedicion;
        private TextBox textBox1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Label label5;
        private Label label4;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private Label label2;
    }
}
