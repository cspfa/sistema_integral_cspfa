namespace SOCIOS.bono
{
    partial class PersonasBono
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
            this.dgvGrupo = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrupo
            // 
            this.dgvGrupo.AllowUserToAddRows = false;
            this.dgvGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupo.Location = new System.Drawing.Point(12, 21);
            this.dgvGrupo.Name = "dgvGrupo";
            this.dgvGrupo.Size = new System.Drawing.Size(710, 434);
            this.dgvGrupo.TabIndex = 0;
            this.dgvGrupo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGrupo_CellFormatting);
            // 
            // Seleccionar
            // 
            this.Seleccionar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Seleccionar.Location = new System.Drawing.Point(293, 461);
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Size = new System.Drawing.Size(180, 37);
            this.Seleccionar.TabIndex = 1;
            this.Seleccionar.Text = "Seleccionar Personas";
            this.Seleccionar.UseVisualStyleBackColor = true;
            this.Seleccionar.Click += new System.EventHandler(this.Seleccionar_Click);
            // 
            // PersonasBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 510);
            this.Controls.Add(this.Seleccionar);
            this.Controls.Add(this.dgvGrupo);
            this.Name = "PersonasBono";
            this.Text = "PersonasBono";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrupo;
        private System.Windows.Forms.Button Seleccionar;
    }
}