namespace SOCIOS.cuentaSocio
{
    partial class Reporte_Plan_Cuenta
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
            this.dgPLanes = new System.Windows.Forms.DataGridView();
            this.Ver_DETALLE_Planes = new System.Windows.Forms.Button();
            this.tbDepuracion_Tit = new MicroFour.StrataFrame.UI.Windows.Forms.MaskedTextbox();
            this.tbSocio_Tit = new MicroFour.StrataFrame.UI.Windows.Forms.MaskedTextbox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.cbSinCeros = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgPLanes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPLanes
            // 
            this.dgPLanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPLanes.Location = new System.Drawing.Point(12, 112);
            this.dgPLanes.Name = "dgPLanes";
            this.dgPLanes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPLanes.Size = new System.Drawing.Size(762, 193);
            this.dgPLanes.TabIndex = 0;
            this.dgPLanes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPLanes_CellContentClick);
            // 
            // Ver_DETALLE_Planes
            // 
            this.Ver_DETALLE_Planes.Location = new System.Drawing.Point(278, 311);
            this.Ver_DETALLE_Planes.Name = "Ver_DETALLE_Planes";
            this.Ver_DETALLE_Planes.Size = new System.Drawing.Size(165, 23);
            this.Ver_DETALLE_Planes.TabIndex = 1;
            this.Ver_DETALLE_Planes.Text = "VER PLANES";
            this.Ver_DETALLE_Planes.UseVisualStyleBackColor = true;
            this.Ver_DETALLE_Planes.Click += new System.EventHandler(this.Ver_DETALLE_Planes_Click);
            // 
            // tbDepuracion_Tit
            // 
            this.tbDepuracion_Tit.BusinessObjectEvaluated = true;
            this.tbDepuracion_Tit.DisabledBackColor = System.Drawing.Color.White;
            this.tbDepuracion_Tit.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tbDepuracion_Tit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDepuracion_Tit.Location = new System.Drawing.Point(274, 66);
            this.tbDepuracion_Tit.Mask = "999";
            this.tbDepuracion_Tit.Name = "tbDepuracion_Tit";
            this.tbDepuracion_Tit.Size = new System.Drawing.Size(27, 20);
            this.tbDepuracion_Tit.TabIndex = 119;
            this.tbDepuracion_Tit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbSocio_Tit
            // 
            this.tbSocio_Tit.BusinessObjectEvaluated = true;
            this.tbSocio_Tit.DisabledBackColor = System.Drawing.Color.White;
            this.tbSocio_Tit.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tbSocio_Tit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSocio_Tit.Location = new System.Drawing.Point(99, 66);
            this.tbSocio_Tit.Mask = "99999";
            this.tbSocio_Tit.Name = "tbSocio_Tit";
            this.tbSocio_Tit.Size = new System.Drawing.Size(44, 20);
            this.tbSocio_Tit.TabIndex = 118;
            this.tbSocio_Tit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSocio_Tit.ValidatingType = typeof(int);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(150, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 13);
            this.label17.TabIndex = 121;
            this.label17.Text = "DEPURACIÓN(Tit):";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(16, 70);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 13);
            this.label18.TabIndex = 120;
            this.label18.Text = "N° SOCIO(Tit):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(340, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 117;
            this.label10.Text = "NOMBRE:";
            // 
            // tbNombre
            // 
            this.tbNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.Location = new System.Drawing.Point(414, 17);
            this.tbNombre.MaxLength = 20;
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(294, 20);
            this.tbNombre.TabIndex = 115;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 116;
            this.label6.Text = "APELLIDO:";
            // 
            // tbApellido
            // 
            this.tbApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbApellido.Location = new System.Drawing.Point(80, 18);
            this.tbApellido.MaxLength = 20;
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(221, 20);
            this.tbApellido.TabIndex = 114;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(414, 43);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(131, 23);
            this.btnBuscar.TabIndex = 122;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 124;
            this.label1.Text = "DNI:";
            // 
            // tbDNI
            // 
            this.tbDNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDNI.Location = new System.Drawing.Point(217, 40);
            this.tbDNI.MaxLength = 20;
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(84, 20);
            this.tbDNI.TabIndex = 123;
            // 
            // cbSinCeros
            // 
            this.cbSinCeros.AutoSize = true;
            this.cbSinCeros.Location = new System.Drawing.Point(414, 73);
            this.cbSinCeros.Name = "cbSinCeros";
            this.cbSinCeros.Size = new System.Drawing.Size(96, 17);
            this.cbSinCeros.TabIndex = 125;
            this.cbSinCeros.Text = "Solo Deudores";
            this.cbSinCeros.UseVisualStyleBackColor = true;
            // 
            // Reporte_Plan_Cuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 389);
            this.Controls.Add(this.cbSinCeros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDNI);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.tbDepuracion_Tit);
            this.Controls.Add(this.tbSocio_Tit);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbApellido);
            this.Controls.Add(this.Ver_DETALLE_Planes);
            this.Controls.Add(this.dgPLanes);
            this.Name = "Reporte_Plan_Cuenta";
            this.Text = "Reporte_Plan_Cuenta";
            ((System.ComponentModel.ISupportInitialize)(this.dgPLanes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPLanes;
        private System.Windows.Forms.Button Ver_DETALLE_Planes;
        private MicroFour.StrataFrame.UI.Windows.Forms.MaskedTextbox tbDepuracion_Tit;
        private MicroFour.StrataFrame.UI.Windows.Forms.MaskedTextbox tbSocio_Tit;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDNI;
        private System.Windows.Forms.CheckBox cbSinCeros;
    }
}