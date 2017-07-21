namespace SOCIOS
{
    partial class abmPersonas
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
            this.cbCargo = new System.Windows.Forms.ComboBox();
            this.cbEscalafon = new System.Windows.Forms.ComboBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dgPersonas = new System.Windows.Forms.DataGridView();
            this.lbID = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE_APELLIDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESCALAFON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CARGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBaja = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCargo
            // 
            this.cbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCargo.FormattingEnabled = true;
            this.cbCargo.Location = new System.Drawing.Point(339, 12);
            this.cbCargo.Name = "cbCargo";
            this.cbCargo.Size = new System.Drawing.Size(217, 21);
            this.cbCargo.TabIndex = 1;
            // 
            // cbEscalafon
            // 
            this.cbEscalafon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEscalafon.FormattingEnabled = true;
            this.cbEscalafon.Location = new System.Drawing.Point(186, 12);
            this.cbEscalafon.Name = "cbEscalafon";
            this.cbEscalafon.Size = new System.Drawing.Size(143, 21);
            this.cbEscalafon.TabIndex = 3;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(12, 12);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(164, 20);
            this.tbNombre.TabIndex = 4;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(566, 11);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(86, 23);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dgPersonas
            // 
            this.dgPersonas.AllowUserToAddRows = false;
            this.dgPersonas.AllowUserToDeleteRows = false;
            this.dgPersonas.AllowUserToResizeColumns = false;
            this.dgPersonas.AllowUserToResizeRows = false;
            this.dgPersonas.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgPersonas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPersonas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NOMBRE_APELLIDO,
            this.ESCALAFON,
            this.CARGO});
            this.dgPersonas.Location = new System.Drawing.Point(12, 45);
            this.dgPersonas.MultiSelect = false;
            this.dgPersonas.Name = "dgPersonas";
            this.dgPersonas.ReadOnly = true;
            this.dgPersonas.RowHeadersVisible = false;
            this.dgPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPersonas.Size = new System.Drawing.Size(641, 513);
            this.dgPersonas.TabIndex = 29;
            this.dgPersonas.Click += new System.EventHandler(this.dgPersonas_Click);
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(12, 45);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(13, 13);
            this.lbID.TabIndex = 30;
            this.lbID.Text = "1";
            this.lbID.Visible = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // NOMBRE_APELLIDO
            // 
            this.NOMBRE_APELLIDO.HeaderText = "NOMBRE Y APELLIDO";
            this.NOMBRE_APELLIDO.Name = "NOMBRE_APELLIDO";
            this.NOMBRE_APELLIDO.ReadOnly = true;
            this.NOMBRE_APELLIDO.Width = 270;
            // 
            // ESCALAFON
            // 
            this.ESCALAFON.HeaderText = "ESCALAFON";
            this.ESCALAFON.Name = "ESCALAFON";
            this.ESCALAFON.ReadOnly = true;
            this.ESCALAFON.Width = 145;
            // 
            // CARGO
            // 
            this.CARGO.HeaderText = "CARGO";
            this.CARGO.Name = "CARGO";
            this.CARGO.ReadOnly = true;
            this.CARGO.Width = 145;
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(566, 567);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(86, 23);
            this.btnBaja.TabIndex = 31;
            this.btnBaja.Text = "BAJA";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // abmPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 602);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.dgPersonas);
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.cbEscalafon);
            this.Controls.Add(this.cbCargo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "abmPersonas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM PERSONAS";
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCargo;
        private System.Windows.Forms.ComboBox cbEscalafon;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView dgPersonas;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE_APELLIDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESCALAFON;
        private System.Windows.Forms.DataGridViewTextBoxColumn CARGO;
        private System.Windows.Forms.Button btnBaja;
    }
}