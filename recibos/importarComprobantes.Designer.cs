namespace SOCIOS
{
    partial class importarComprobantes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbConexion = new System.Windows.Forms.Label();
            this.gbCajasAnteriores = new System.Windows.Forms.GroupBox();
            this.dgCajasAnteriores = new System.Windows.Forms.DataGridView();
            this.gbCajasAnteriores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCajasAnteriores)).BeginInit();
            this.SuspendLayout();
            // 
            // lbConexion
            // 
            this.lbConexion.AutoSize = true;
            this.lbConexion.Location = new System.Drawing.Point(20, 16);
            this.lbConexion.Name = "lbConexion";
            this.lbConexion.Size = new System.Drawing.Size(169, 13);
            this.lbConexion.TabIndex = 0;
            this.lbConexion.Text = "BASE DE DATOS: Desconectada";
            // 
            // gbCajasAnteriores
            // 
            this.gbCajasAnteriores.Controls.Add(this.dgCajasAnteriores);
            this.gbCajasAnteriores.Location = new System.Drawing.Point(12, 40);
            this.gbCajasAnteriores.Name = "gbCajasAnteriores";
            this.gbCajasAnteriores.Size = new System.Drawing.Size(665, 200);
            this.gbCajasAnteriores.TabIndex = 83;
            this.gbCajasAnteriores.TabStop = false;
            this.gbCajasAnteriores.Text = "CAJAS ANTERIORES";
            // 
            // dgCajasAnteriores
            // 
            this.dgCajasAnteriores.AllowUserToAddRows = false;
            this.dgCajasAnteriores.AllowUserToDeleteRows = false;
            this.dgCajasAnteriores.AllowUserToResizeColumns = false;
            this.dgCajasAnteriores.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgCajasAnteriores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCajasAnteriores.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgCajasAnteriores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgCajasAnteriores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCajasAnteriores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgCajasAnteriores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCajasAnteriores.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgCajasAnteriores.Location = new System.Drawing.Point(10, 21);
            this.dgCajasAnteriores.Margin = new System.Windows.Forms.Padding(5);
            this.dgCajasAnteriores.Name = "dgCajasAnteriores";
            this.dgCajasAnteriores.ReadOnly = true;
            this.dgCajasAnteriores.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCajasAnteriores.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgCajasAnteriores.RowHeadersVisible = false;
            this.dgCajasAnteriores.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(1);
            this.dgCajasAnteriores.RowTemplate.ReadOnly = true;
            this.dgCajasAnteriores.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCajasAnteriores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCajasAnteriores.Size = new System.Drawing.Size(645, 168);
            this.dgCajasAnteriores.TabIndex = 77;
            // 
            // importarComprobantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 273);
            this.Controls.Add(this.gbCajasAnteriores);
            this.Controls.Add(this.lbConexion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "importarComprobantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.importarComprobantes_Load);
            this.gbCajasAnteriores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCajasAnteriores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbConexion;
        private System.Windows.Forms.GroupBox gbCajasAnteriores;
        private System.Windows.Forms.DataGridView dgCajasAnteriores;
    }
}