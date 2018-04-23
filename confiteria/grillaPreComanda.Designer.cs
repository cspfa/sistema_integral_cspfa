namespace Confiteria
{
    partial class grillaPreComanda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(grillaPreComanda));
            this.btnABM = new System.Windows.Forms.Button();
            this.dgMesas = new System.Windows.Forms.DataGridView();
            this.cmMesas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirMesaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarMesaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forzarCierreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarDeMesaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.dpFechaListado = new System.Windows.Forms.DateTimePicker();
            this.dpFiltroIngresos = new System.Windows.Forms.DateTimePicker();
            this.lbNotToday = new System.Windows.Forms.Label();
            this.btnImprimirListado = new System.Windows.Forms.Button();
            this.btnActualizarGrillas = new System.Windows.Forms.Button();
            this.btnBuscarComandas = new System.Windows.Forms.Button();
            this.pbMarcandoComandas = new System.Windows.Forms.ProgressBar();
            this.btnListadoControl = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbOrdenListado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBuscarIngresos = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgMesas)).BeginInit();
            this.cmMesas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnABM
            // 
            this.btnABM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnABM.Location = new System.Drawing.Point(941, 612);
            this.btnABM.Name = "btnABM";
            this.btnABM.Size = new System.Drawing.Size(97, 32);
            this.btnABM.TabIndex = 13;
            this.btnABM.Text = "SOCIOS ABM";
            this.btnABM.UseVisualStyleBackColor = true;
            this.btnABM.Click += new System.EventHandler(this.btnABM_Click);
            // 
            // dgMesas
            // 
            this.dgMesas.AllowUserToAddRows = false;
            this.dgMesas.AllowUserToDeleteRows = false;
            this.dgMesas.AllowUserToResizeColumns = false;
            this.dgMesas.AllowUserToResizeRows = false;
            this.dgMesas.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgMesas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgMesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMesas.Location = new System.Drawing.Point(710, 0);
            this.dgMesas.MultiSelect = false;
            this.dgMesas.Name = "dgMesas";
            this.dgMesas.ReadOnly = true;
            this.dgMesas.RowHeadersVisible = false;
            this.dgMesas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMesas.Size = new System.Drawing.Size(622, 604);
            this.dgMesas.TabIndex = 14;
            this.dgMesas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgMesas_MouseDown);
            // 
            // cmMesas
            // 
            this.cmMesas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirMesaToolStripMenuItem,
            this.modificarMesaToolStripMenuItem,
            this.forzarCierreToolStripMenuItem,
            this.cambiarDeMesaToolStripMenuItem});
            this.cmMesas.Name = "cmMesas";
            this.cmMesas.Size = new System.Drawing.Size(153, 114);
            // 
            // abrirMesaToolStripMenuItem
            // 
            this.abrirMesaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("abrirMesaToolStripMenuItem.Image")));
            this.abrirMesaToolStripMenuItem.Name = "abrirMesaToolStripMenuItem";
            this.abrirMesaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirMesaToolStripMenuItem.Text = "Abrir Mesa";
            this.abrirMesaToolStripMenuItem.Click += new System.EventHandler(this.abrirMesaToolStripMenuItem_Click);
            // 
            // modificarMesaToolStripMenuItem
            // 
            this.modificarMesaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificarMesaToolStripMenuItem.Image")));
            this.modificarMesaToolStripMenuItem.Name = "modificarMesaToolStripMenuItem";
            this.modificarMesaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modificarMesaToolStripMenuItem.Text = "Ver Comanda";
            this.modificarMesaToolStripMenuItem.Click += new System.EventHandler(this.modificarMesaToolStripMenuItem_Click);
            // 
            // forzarCierreToolStripMenuItem
            // 
            this.forzarCierreToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("forzarCierreToolStripMenuItem.Image")));
            this.forzarCierreToolStripMenuItem.Name = "forzarCierreToolStripMenuItem";
            this.forzarCierreToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.forzarCierreToolStripMenuItem.Text = "Forzar Cierre";
            this.forzarCierreToolStripMenuItem.Click += new System.EventHandler(this.forzarCierreToolStripMenuItem_Click);
            // 
            // cambiarDeMesaToolStripMenuItem
            // 
            this.cambiarDeMesaToolStripMenuItem.Image = global::SOCIOS.Properties.Resources.arrow_switch;
            this.cambiarDeMesaToolStripMenuItem.Name = "cambiarDeMesaToolStripMenuItem";
            this.cambiarDeMesaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cambiarDeMesaToolStripMenuItem.Text = "Cambiar a Mesa";
            this.cambiarDeMesaToolStripMenuItem.MouseHover += new System.EventHandler(this.cambiarDeMesaToolStripMenuItem_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "INGRESOS A CONFITERIA SEDE SOCIAL";
            // 
            // dpFechaListado
            // 
            this.dpFechaListado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaListado.Location = new System.Drawing.Point(15, 618);
            this.dpFechaListado.Name = "dpFechaListado";
            this.dpFechaListado.Size = new System.Drawing.Size(104, 20);
            this.dpFechaListado.TabIndex = 18;
            // 
            // dpFiltroIngresos
            // 
            this.dpFiltroIngresos.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFiltroIngresos.Location = new System.Drawing.Point(600, 13);
            this.dpFiltroIngresos.Name = "dpFiltroIngresos";
            this.dpFiltroIngresos.Size = new System.Drawing.Size(104, 20);
            this.dpFiltroIngresos.TabIndex = 20;
            this.dpFiltroIngresos.ValueChanged += new System.EventHandler(this.dpFiltroIngresos_ValueChanged);
            // 
            // lbNotToday
            // 
            this.lbNotToday.AutoSize = true;
            this.lbNotToday.ForeColor = System.Drawing.Color.Red;
            this.lbNotToday.Location = new System.Drawing.Point(255, 17);
            this.lbNotToday.Name = "lbNotToday";
            this.lbNotToday.Size = new System.Drawing.Size(310, 13);
            this.lbNotToday.TabIndex = 21;
            this.lbNotToday.Text = "LA FECHA INGRESADA NO CORRESPONDE AL DÍA DE HOY";
            this.lbNotToday.Visible = false;
            // 
            // btnImprimirListado
            // 
            this.btnImprimirListado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirListado.Location = new System.Drawing.Point(264, 612);
            this.btnImprimirListado.Name = "btnImprimirListado";
            this.btnImprimirListado.Size = new System.Drawing.Size(141, 32);
            this.btnImprimirListado.TabIndex = 22;
            this.btnImprimirListado.Text = "CERRAR CAJA";
            this.btnImprimirListado.UseVisualStyleBackColor = true;
            this.btnImprimirListado.Click += new System.EventHandler(this.btnImprimirListado_Click_1);
            // 
            // btnActualizarGrillas
            // 
            this.btnActualizarGrillas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarGrillas.Location = new System.Drawing.Point(556, 612);
            this.btnActualizarGrillas.Name = "btnActualizarGrillas";
            this.btnActualizarGrillas.Size = new System.Drawing.Size(145, 32);
            this.btnActualizarGrillas.TabIndex = 23;
            this.btnActualizarGrillas.Text = "ACTUALIZAR GRILLAS";
            this.btnActualizarGrillas.UseVisualStyleBackColor = true;
            this.btnActualizarGrillas.Click += new System.EventHandler(this.btnActualizarGrillas_Click);
            // 
            // btnBuscarComandas
            // 
            this.btnBuscarComandas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarComandas.Location = new System.Drawing.Point(706, 612);
            this.btnBuscarComandas.Name = "btnBuscarComandas";
            this.btnBuscarComandas.Size = new System.Drawing.Size(230, 32);
            this.btnBuscarComandas.TabIndex = 24;
            this.btnBuscarComandas.Text = "BUSCAR COMANDAS Y SOLICITUDES";
            this.btnBuscarComandas.UseVisualStyleBackColor = true;
            this.btnBuscarComandas.Click += new System.EventHandler(this.btnBuscarComandas_Click);
            // 
            // pbMarcandoComandas
            // 
            this.pbMarcandoComandas.Location = new System.Drawing.Point(1056, 674);
            this.pbMarcandoComandas.Name = "pbMarcandoComandas";
            this.pbMarcandoComandas.Size = new System.Drawing.Size(268, 19);
            this.pbMarcandoComandas.TabIndex = 26;
            this.pbMarcandoComandas.Visible = false;
            // 
            // btnListadoControl
            // 
            this.btnListadoControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListadoControl.Location = new System.Drawing.Point(410, 612);
            this.btnListadoControl.Name = "btnListadoControl";
            this.btnListadoControl.Size = new System.Drawing.Size(141, 32);
            this.btnListadoControl.TabIndex = 27;
            this.btnListadoControl.Text = "LISTADO DE CONTROL";
            this.btnListadoControl.UseVisualStyleBackColor = true;
            this.btnListadoControl.Click += new System.EventHandler(this.btnListadoControl_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 81);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(704, 523);
            this.dataGridView1.TabIndex = 28;
            // 
            // cbOrdenListado
            // 
            this.cbOrdenListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrdenListado.FormattingEnabled = true;
            this.cbOrdenListado.Location = new System.Drawing.Point(126, 618);
            this.cbOrdenListado.Name = "cbOrdenListado";
            this.cbOrdenListado.Size = new System.Drawing.Size(132, 21);
            this.cbOrdenListado.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "BUSCAR POR APELLIDO";
            // 
            // tbBuscarIngresos
            // 
            this.tbBuscarIngresos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBuscarIngresos.Location = new System.Drawing.Point(154, 48);
            this.tbBuscarIngresos.Name = "tbBuscarIngresos";
            this.tbBuscarIngresos.Size = new System.Drawing.Size(273, 20);
            this.tbBuscarIngresos.TabIndex = 31;
            this.tbBuscarIngresos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbBuscarIngresos_KeyUp);
            // 
            // grillaPreComanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 653);
            this.Controls.Add(this.tbBuscarIngresos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbOrdenListado);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnListadoControl);
            this.Controls.Add(this.pbMarcandoComandas);
            this.Controls.Add(this.btnBuscarComandas);
            this.Controls.Add(this.btnActualizarGrillas);
            this.Controls.Add(this.btnImprimirListado);
            this.Controls.Add(this.lbNotToday);
            this.Controls.Add(this.dpFiltroIngresos);
            this.Controls.Add(this.dpFechaListado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgMesas);
            this.Controls.Add(this.btnABM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "grillaPreComanda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONFITERIA SEDE SOCIAL";
            this.Load += new System.EventHandler(this.grillaPreComanda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMesas)).EndInit();
            this.cmMesas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnABM;
        private System.Windows.Forms.DataGridView dgMesas;
        private System.Windows.Forms.ContextMenuStrip cmMesas;
        private System.Windows.Forms.ToolStripMenuItem abrirMesaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarMesaToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpFechaListado;
        private System.Windows.Forms.DateTimePicker dpFiltroIngresos;
        private System.Windows.Forms.Label lbNotToday;
        private System.Windows.Forms.ToolStripMenuItem forzarCierreToolStripMenuItem;
        private System.Windows.Forms.Button btnImprimirListado;
        private System.Windows.Forms.Button btnActualizarGrillas;
        private System.Windows.Forms.Button btnBuscarComandas;
        private System.Windows.Forms.ToolStripMenuItem cambiarDeMesaToolStripMenuItem;
        private System.Windows.Forms.ProgressBar pbMarcandoComandas;
        private System.Windows.Forms.Button btnListadoControl;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbOrdenListado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBuscarIngresos;
    }
}