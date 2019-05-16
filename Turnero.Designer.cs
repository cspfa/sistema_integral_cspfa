namespace SOCIOS
{
    partial class Turnero
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
            this.dgLlamadas = new System.Windows.Forms.DataGridView();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PUESTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgLlamadas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgLlamadas
            // 
            this.dgLlamadas.AllowUserToAddRows = false;
            this.dgLlamadas.AllowUserToDeleteRows = false;
            this.dgLlamadas.AllowUserToResizeColumns = false;
            this.dgLlamadas.AllowUserToResizeRows = false;
            this.dgLlamadas.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgLlamadas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgLlamadas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgLlamadas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgLlamadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgLlamadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NOMBRE,
            this.NUMERO,
            this.PUESTO});
            this.dgLlamadas.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgLlamadas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgLlamadas.Location = new System.Drawing.Point(350, 12);
            this.dgLlamadas.MultiSelect = false;
            this.dgLlamadas.Name = "dgLlamadas";
            this.dgLlamadas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgLlamadas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgLlamadas.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgLlamadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLlamadas.ShowCellErrors = false;
            this.dgLlamadas.ShowCellToolTips = false;
            this.dgLlamadas.ShowEditingIcon = false;
            this.dgLlamadas.ShowRowErrors = false;
            this.dgLlamadas.Size = new System.Drawing.Size(438, 426);
            this.dgLlamadas.TabIndex = 0;
            this.dgLlamadas.TabStop = false;
            // 
            // NOMBRE
            // 
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.Width = 230;
            // 
            // NUMERO
            // 
            this.NUMERO.HeaderText = "NUMERO";
            this.NUMERO.Name = "NUMERO";
            // 
            // PUESTO
            // 
            this.PUESTO.HeaderText = "PUESTO";
            this.PUESTO.Name = "PUESTO";
            this.PUESTO.Width = 70;
            // 
            // Turnero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgLlamadas);
            this.Name = "Turnero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turnero";
            this.Load += new System.EventHandler(this.Turnero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLlamadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgLlamadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUESTO;
    }
}