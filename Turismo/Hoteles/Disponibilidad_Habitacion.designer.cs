namespace SOCIOS.Turismo.Hoteles
{
    partial class Disponibilidad_Habitacion
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
            this.cbHotel = new System.Windows.Forms.ComboBox();
            this.lbTipoViaje = new System.Windows.Forms.Label();
            this.lbPlaza = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            this.dgvHabitaciones = new System.Windows.Forms.DataGridView();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.Confirmacion = new System.Windows.Forms.Button();
            this.cbBloqueo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // cbHotel
            // 
            this.cbHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHotel.FormattingEnabled = true;
            this.cbHotel.Location = new System.Drawing.Point(72, 56);
            this.cbHotel.Name = "cbHotel";
            this.cbHotel.Size = new System.Drawing.Size(242, 21);
            this.cbHotel.TabIndex = 135;
            // 
            // lbTipoViaje
            // 
            this.lbTipoViaje.AutoSize = true;
            this.lbTipoViaje.Location = new System.Drawing.Point(11, 64);
            this.lbTipoViaje.Name = "lbTipoViaje";
            this.lbTipoViaje.Size = new System.Drawing.Size(32, 13);
            this.lbTipoViaje.TabIndex = 134;
            this.lbTipoViaje.Text = "Hotel";
            // 
            // lbPlaza
            // 
            this.lbPlaza.AutoSize = true;
            this.lbPlaza.Location = new System.Drawing.Point(12, 30);
            this.lbPlaza.Name = "lbPlaza";
            this.lbPlaza.Size = new System.Drawing.Size(42, 13);
            this.lbPlaza.TabIndex = 136;
            this.lbPlaza.Text = "PLazas";
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Location = new System.Drawing.Point(277, 30);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(37, 13);
            this.lbFecha.TabIndex = 137;
            this.lbFecha.Text = "Fecha";
            // 
            // dgvHabitaciones
            // 
            this.dgvHabitaciones.AllowUserToAddRows = false;
            this.dgvHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitaciones.Location = new System.Drawing.Point(12, 88);
            this.dgvHabitaciones.Name = "dgvHabitaciones";
            this.dgvHabitaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHabitaciones.Size = new System.Drawing.Size(472, 328);
            this.dgvHabitaciones.TabIndex = 138;
            this.dgvHabitaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHabitaciones_CellClick);
            this.dgvHabitaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHabitaciones_CellContentClick);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(408, 54);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 139;
            this.btnFiltrar.Text = "Buscar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // Confirmacion
            // 
            this.Confirmacion.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Confirmacion.Location = new System.Drawing.Point(391, 422);
            this.Confirmacion.Name = "Confirmacion";
            this.Confirmacion.Size = new System.Drawing.Size(93, 23);
            this.Confirmacion.TabIndex = 140;
            this.Confirmacion.Text = "Confirmacion";
            this.Confirmacion.UseVisualStyleBackColor = true;
            this.Confirmacion.Visible = false;
            this.Confirmacion.Click += new System.EventHandler(this.Confirmacion_Click);
            // 
            // cbBloqueo
            // 
            this.cbBloqueo.AutoSize = true;
            this.cbBloqueo.Location = new System.Drawing.Point(15, 428);
            this.cbBloqueo.Name = "cbBloqueo";
            this.cbBloqueo.Size = new System.Drawing.Size(122, 17);
            this.cbBloqueo.TabIndex = 141;
            this.cbBloqueo.Text = "Bloquear Habitacion";
            this.cbBloqueo.UseVisualStyleBackColor = true;
            // 
            // Disponibilidad_Habitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 450);
            this.Controls.Add(this.cbBloqueo);
            this.Controls.Add(this.Confirmacion);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.dgvHabitaciones);
            this.Controls.Add(this.lbFecha);
            this.Controls.Add(this.lbPlaza);
            this.Controls.Add(this.cbHotel);
            this.Controls.Add(this.lbTipoViaje);
            this.Name = "Disponibilidad_Habitacion";
            this.Text = "Disponibilidad_Habitacion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbHotel;
        private System.Windows.Forms.Label lbTipoViaje;
        private System.Windows.Forms.Label lbPlaza;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.DataGridView dgvHabitaciones;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button Confirmacion;
        private System.Windows.Forms.CheckBox cbBloqueo;
    }
}