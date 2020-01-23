namespace SOCIOS.interior
{
    partial class Contactos
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
            this.dgContactos = new System.Windows.Forms.DataGridView();
            this.Ver_Seleccionados = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgContactos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgContactos
            // 
            this.dgContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgContactos.Location = new System.Drawing.Point(12, 30);
            this.dgContactos.Name = "dgContactos";
            this.dgContactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgContactos.Size = new System.Drawing.Size(769, 238);
            this.dgContactos.TabIndex = 0;
            this.dgContactos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgContactos_CellClick);
            // 
            // Ver_Seleccionados
            // 
            this.Ver_Seleccionados.Location = new System.Drawing.Point(346, 274);
            this.Ver_Seleccionados.Name = "Ver_Seleccionados";
            this.Ver_Seleccionados.Size = new System.Drawing.Size(75, 23);
            this.Ver_Seleccionados.TabIndex = 1;
            this.Ver_Seleccionados.Text = "Ver";
            this.Ver_Seleccionados.UseVisualStyleBackColor = true;
            this.Ver_Seleccionados.Click += new System.EventHandler(this.Ver_Seleccionados_Click);
            // 
            // Contactos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 407);
            this.Controls.Add(this.Ver_Seleccionados);
            this.Controls.Add(this.dgContactos);
            this.Name = "Contactos";
            this.Text = "Contactos";
            ((System.ComponentModel.ISupportInitialize)(this.dgContactos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgContactos;
        private System.Windows.Forms.Button Ver_Seleccionados;
    }
}