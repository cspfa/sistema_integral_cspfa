namespace SOCIOS.Turismo.Hoteles
{
    partial class OcupacionDispo
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cbHotel = new System.Windows.Forms.ComboBox();
            this.lbTipoViaje = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.Buscar = new System.Windows.Forms.Button();
            this.gpHotelHabitacion = new System.Windows.Forms.GroupBox();
            this.lbNombreHotel = new System.Windows.Forms.Label();
            this.dpFechaHotel = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbHabitacion = new System.Windows.Forms.ComboBox();
            this.btnVer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DisponibilidadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gpHotelHabitacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisponibilidadBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.DisponibilidadBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SOCIOS.Turismo.Hoteles.Disponibilidad.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(8, 48);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(941, 382);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Visible = false;
            // 
            // cbHotel
            // 
            this.cbHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHotel.FormattingEnabled = true;
            this.cbHotel.Location = new System.Drawing.Point(66, 12);
            this.cbHotel.Name = "cbHotel";
            this.cbHotel.Size = new System.Drawing.Size(193, 21);
            this.cbHotel.TabIndex = 137;
            // 
            // lbTipoViaje
            // 
            this.lbTipoViaje.AutoSize = true;
            this.lbTipoViaje.Location = new System.Drawing.Point(5, 20);
            this.lbTipoViaje.Name = "lbTipoViaje";
            this.lbTipoViaje.Size = new System.Drawing.Size(32, 13);
            this.lbTipoViaje.TabIndex = 136;
            this.lbTipoViaje.Text = "Hotel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 138;
            this.label1.Text = "Fecha";
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFecha.Location = new System.Drawing.Point(351, 13);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(85, 20);
            this.dpFecha.TabIndex = 139;
            // 
            // Buscar
            // 
            this.Buscar.Location = new System.Drawing.Point(542, 12);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(75, 23);
            this.Buscar.TabIndex = 140;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // gpHotelHabitacion
            // 
            this.gpHotelHabitacion.Controls.Add(this.lbNombreHotel);
            this.gpHotelHabitacion.Controls.Add(this.dpFechaHotel);
            this.gpHotelHabitacion.Controls.Add(this.label4);
            this.gpHotelHabitacion.Controls.Add(this.cbHabitacion);
            this.gpHotelHabitacion.Controls.Add(this.btnVer);
            this.gpHotelHabitacion.Controls.Add(this.label3);
            this.gpHotelHabitacion.Controls.Add(this.label2);
            this.gpHotelHabitacion.Location = new System.Drawing.Point(232, 441);
            this.gpHotelHabitacion.Name = "gpHotelHabitacion";
            this.gpHotelHabitacion.Size = new System.Drawing.Size(407, 154);
            this.gpHotelHabitacion.TabIndex = 141;
            this.gpHotelHabitacion.TabStop = false;
            this.gpHotelHabitacion.Text = " DETALLE";
            this.gpHotelHabitacion.Visible = false;
            // 
            // lbNombreHotel
            // 
            this.lbNombreHotel.AutoSize = true;
            this.lbNombreHotel.Location = new System.Drawing.Point(149, 31);
            this.lbNombreHotel.Name = "lbNombreHotel";
            this.lbNombreHotel.Size = new System.Drawing.Size(93, 13);
            this.lbNombreHotel.TabIndex = 133;
            this.lbNombreHotel.Text = "NOMBRE HOTEL";
            // 
            // dpFechaHotel
            // 
            this.dpFechaHotel.Location = new System.Drawing.Point(149, 93);
            this.dpFechaHotel.Name = "dpFechaHotel";
            this.dpFechaHotel.Size = new System.Drawing.Size(200, 20);
            this.dpFechaHotel.TabIndex = 132;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 131;
            this.label4.Text = "HABITACION";
            // 
            // cbHabitacion
            // 
            this.cbHabitacion.BackColor = System.Drawing.Color.White;
            this.cbHabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHabitacion.FormattingEnabled = true;
            this.cbHabitacion.Location = new System.Drawing.Point(149, 59);
            this.cbHabitacion.Name = "cbHabitacion";
            this.cbHabitacion.Size = new System.Drawing.Size(233, 21);
            this.cbHabitacion.TabIndex = 130;
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(307, 119);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(75, 23);
            this.btnVer.TabIndex = 129;
            this.btnVer.Text = "VER";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 125;
            this.label3.Text = "FECHA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 124;
            this.label2.Text = "HOTEL";
            // 
            // DisponibilidadBindingSource
            // 
            this.DisponibilidadBindingSource.DataSource = typeof(SOCIOS.Turismo.Hotel.Disponibilidad);
            // 
            // OcupacionDispo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 610);
            this.Controls.Add(this.gpHotelHabitacion);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.dpFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbHotel);
            this.Controls.Add(this.lbTipoViaje);
            this.Controls.Add(this.reportViewer1);
            this.Name = "OcupacionDispo";
            this.Text = "OcupacionDispo";
            this.Load += new System.EventHandler(this.OcupacionDispo_Load);
            this.gpHotelHabitacion.ResumeLayout(false);
            this.gpHotelHabitacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisponibilidadBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DisponibilidadBindingSource;
        private System.Windows.Forms.ComboBox cbHotel;
        private System.Windows.Forms.Label lbTipoViaje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.GroupBox gpHotelHabitacion;
        private System.Windows.Forms.DateTimePicker dpFechaHotel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbHabitacion;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNombreHotel;

    }
}