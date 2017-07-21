namespace SOCIOS.bono
{
    partial class ParticipativoBono
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
            this.DgvGrupo = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGrupo)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvGrupo
            // 
            this.DgvGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGrupo.Location = new System.Drawing.Point(21, 23);
            this.DgvGrupo.Name = "DgvGrupo";
            this.DgvGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvGrupo.Size = new System.Drawing.Size(905, 365);
            this.DgvGrupo.TabIndex = 0;
            this.DgvGrupo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvGrupo_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Seleccionar.Location = new System.Drawing.Point(356, 394);
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Size = new System.Drawing.Size(180, 37);
            this.Seleccionar.TabIndex = 2;
            this.Seleccionar.Text = "Seleccionar Personas";
            this.Seleccionar.UseVisualStyleBackColor = true;
            this.Seleccionar.Click += new System.EventHandler(this.Seleccionar_Click);
            // 
            // ParticipativoBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 471);
            this.Controls.Add(this.Seleccionar);
            this.Controls.Add(this.DgvGrupo);
            this.Name = "ParticipativoBono";
            this.Text = "ParticipativoBono";
            this.Load += new System.EventHandler(this.ParticipativoBono_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvGrupo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvGrupo;
        private System.Windows.Forms.Button Seleccionar;

    }
}