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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgLlamadas = new System.Windows.Forms.DataGridView();
            this.NUMERO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dgLlamadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgLlamadas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgLlamadas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(177)))), ((int)(((byte)(83)))));
            this.dgLlamadas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgLlamadas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgLlamadas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(177)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(177)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgLlamadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgLlamadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLlamadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NUMERO,
            this.NOMBRE,
            this.PUESTO});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(177)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(177)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgLlamadas.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgLlamadas.EnableHeadersVisualStyles = false;
            this.dgLlamadas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(177)))), ((int)(((byte)(83)))));
            this.dgLlamadas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgLlamadas.Location = new System.Drawing.Point(12, 12);
            this.dgLlamadas.MultiSelect = false;
            this.dgLlamadas.Name = "dgLlamadas";
            this.dgLlamadas.ReadOnly = true;
            this.dgLlamadas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(177)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(177)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgLlamadas.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgLlamadas.RowHeadersVisible = false;
            this.dgLlamadas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgLlamadas.RowTemplate.Height = 42;
            this.dgLlamadas.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgLlamadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgLlamadas.ShowCellErrors = false;
            this.dgLlamadas.ShowCellToolTips = false;
            this.dgLlamadas.ShowEditingIcon = false;
            this.dgLlamadas.ShowRowErrors = false;
            this.dgLlamadas.Size = new System.Drawing.Size(1342, 526);
            this.dgLlamadas.TabIndex = 0;
            this.dgLlamadas.TabStop = false;
            // 
            // NUMERO
            // 
            this.NUMERO.HeaderText = "";
            this.NUMERO.Name = "NUMERO";
            this.NUMERO.ReadOnly = true;
            this.NUMERO.Width = 27;
            // 
            // NOMBRE
            // 
            this.NOMBRE.HeaderText = "NOMBRE Y APELLIDO";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            this.NOMBRE.Width = 334;
            // 
            // PUESTO
            // 
            this.PUESTO.HeaderText = "PUESTO";
            this.PUESTO.Name = "PUESTO";
            this.PUESTO.ReadOnly = true;
            this.PUESTO.Width = 162;
            // 
            // Turnero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(177)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(1366, 550);
            this.Controls.Add(this.dgLlamadas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Turnero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turnero";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Turnero_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Turnero_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgLlamadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgLlamadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUESTO;
    }
}