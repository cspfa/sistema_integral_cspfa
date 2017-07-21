namespace SOCIOS
{
    partial class abmAsambleas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgAsambleas = new System.Windows.Forms.DataGridView();
            this.ELECCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CERRADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_TOPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEleccion = new System.Windows.Forms.TextBox();
            this.tbTipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.dpFechaTope = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNuevaAsamblea = new System.Windows.Forms.Button();
            this.btnModificaAsamblea = new System.Windows.Forms.Button();
            this.tbCerrada = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgAsambleas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgAsambleas
            // 
            this.dgAsambleas.AllowUserToAddRows = false;
            this.dgAsambleas.AllowUserToDeleteRows = false;
            this.dgAsambleas.AllowUserToResizeColumns = false;
            this.dgAsambleas.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgAsambleas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgAsambleas.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgAsambleas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgAsambleas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAsambleas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgAsambleas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAsambleas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ELECCION,
            this.TIPO,
            this.FECHA,
            this.CERRADA,
            this.FECHA_TOPE,
            this.USUARIO});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgAsambleas.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgAsambleas.Location = new System.Drawing.Point(14, 14);
            this.dgAsambleas.Margin = new System.Windows.Forms.Padding(5);
            this.dgAsambleas.MultiSelect = false;
            this.dgAsambleas.Name = "dgAsambleas";
            this.dgAsambleas.ReadOnly = true;
            this.dgAsambleas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAsambleas.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgAsambleas.RowHeadersVisible = false;
            this.dgAsambleas.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgAsambleas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAsambleas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAsambleas.Size = new System.Drawing.Size(522, 264);
            this.dgAsambleas.TabIndex = 48;
            this.dgAsambleas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAsambleas_CellClick);
            // 
            // ELECCION
            // 
            this.ELECCION.HeaderText = "ELECCION";
            this.ELECCION.Name = "ELECCION";
            this.ELECCION.ReadOnly = true;
            this.ELECCION.Width = 70;
            // 
            // TIPO
            // 
            this.TIPO.HeaderText = "TIPO";
            this.TIPO.Name = "TIPO";
            this.TIPO.ReadOnly = true;
            this.TIPO.Width = 50;
            // 
            // FECHA
            // 
            this.FECHA.HeaderText = "FECHA";
            this.FECHA.Name = "FECHA";
            this.FECHA.ReadOnly = true;
            // 
            // CERRADA
            // 
            this.CERRADA.HeaderText = "CERRADA";
            this.CERRADA.Name = "CERRADA";
            this.CERRADA.ReadOnly = true;
            this.CERRADA.Width = 70;
            // 
            // FECHA_TOPE
            // 
            this.FECHA_TOPE.HeaderText = "FECHA_TOPE";
            this.FECHA_TOPE.Name = "FECHA_TOPE";
            this.FECHA_TOPE.ReadOnly = true;
            // 
            // USUARIO
            // 
            this.USUARIO.HeaderText = "USUARIO";
            this.USUARIO.Name = "USUARIO";
            this.USUARIO.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "ELECCION";
            // 
            // tbEleccion
            // 
            this.tbEleccion.Location = new System.Drawing.Point(85, 295);
            this.tbEleccion.Name = "tbEleccion";
            this.tbEleccion.Size = new System.Drawing.Size(58, 20);
            this.tbEleccion.TabIndex = 50;
            // 
            // tbTipo
            // 
            this.tbTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbTipo.Location = new System.Drawing.Point(201, 295);
            this.tbTipo.Name = "tbTipo";
            this.tbTipo.Size = new System.Drawing.Size(37, 20);
            this.tbTipo.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "TIPO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "FECHA";
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(306, 295);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(84, 20);
            this.dpFecha.TabIndex = 54;
            // 
            // dpFechaTope
            // 
            this.dpFechaTope.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaTope.Location = new System.Drawing.Point(452, 295);
            this.dpFechaTope.Name = "dpFechaTope";
            this.dpFechaTope.Size = new System.Drawing.Size(84, 20);
            this.dpFechaTope.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "TOPE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "CERRADA";
            // 
            // btnNuevaAsamblea
            // 
            this.btnNuevaAsamblea.Location = new System.Drawing.Point(159, 326);
            this.btnNuevaAsamblea.Name = "btnNuevaAsamblea";
            this.btnNuevaAsamblea.Size = new System.Drawing.Size(79, 23);
            this.btnNuevaAsamblea.TabIndex = 59;
            this.btnNuevaAsamblea.Text = "NUEVA";
            this.btnNuevaAsamblea.UseVisualStyleBackColor = true;
            this.btnNuevaAsamblea.Click += new System.EventHandler(this.btnNuevaAsamblea_Click);
            // 
            // btnModificaAsamblea
            // 
            this.btnModificaAsamblea.Enabled = false;
            this.btnModificaAsamblea.Location = new System.Drawing.Point(306, 326);
            this.btnModificaAsamblea.Name = "btnModificaAsamblea";
            this.btnModificaAsamblea.Size = new System.Drawing.Size(84, 23);
            this.btnModificaAsamblea.TabIndex = 60;
            this.btnModificaAsamblea.Text = "MODIFICA";
            this.btnModificaAsamblea.UseVisualStyleBackColor = true;
            this.btnModificaAsamblea.Click += new System.EventHandler(this.btnModificaAsamblea_Click);
            // 
            // tbCerrada
            // 
            this.tbCerrada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCerrada.Location = new System.Drawing.Point(85, 327);
            this.tbCerrada.Name = "tbCerrada";
            this.tbCerrada.Size = new System.Drawing.Size(58, 20);
            this.tbCerrada.TabIndex = 61;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(452, 326);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(84, 23);
            this.btnLimpiar.TabIndex = 62;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // abmAsambleas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 364);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.tbCerrada);
            this.Controls.Add(this.btnModificaAsamblea);
            this.Controls.Add(this.btnNuevaAsamblea);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dpFechaTope);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dpFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbEleccion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgAsambleas);
            this.Name = "abmAsambleas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Asambleas";
            ((System.ComponentModel.ISupportInitialize)(this.dgAsambleas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgAsambleas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ELECCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CERRADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_TOPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn USUARIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEleccion;
        private System.Windows.Forms.TextBox tbTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.DateTimePicker dpFechaTope;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNuevaAsamblea;
        private System.Windows.Forms.Button btnModificaAsamblea;
        private System.Windows.Forms.TextBox tbCerrada;
        private System.Windows.Forms.Button btnLimpiar;

    }
}