namespace SOCIOS
{
    partial class PFA_CABA
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbArchivoSeleccionado = new System.Windows.Forms.Label();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.lbResultados = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lvResultado = new MicroFour.StrataFrame.UI.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IMPORTAR DATOS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(114, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "(Formato Excel, una sola columna con cabecera DNI, nombre de hoja DNI)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "BUSCAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbArchivoSeleccionado
            // 
            this.lbArchivoSeleccionado.AutoSize = true;
            this.lbArchivoSeleccionado.Location = new System.Drawing.Point(121, 49);
            this.lbArchivoSeleccionado.Name = "lbArchivoSeleccionado";
            this.lbArchivoSeleccionado.Size = new System.Drawing.Size(187, 13);
            this.lbArchivoSeleccionado.TabIndex = 3;
            this.lbArchivoSeleccionado.Text = "NINGÚN ARCHIVO SELECCIONADO";
            // 
            // btnProcesar
            // 
            this.btnProcesar.Enabled = false;
            this.btnProcesar.Location = new System.Drawing.Point(15, 73);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(100, 23);
            this.btnProcesar.TabIndex = 4;
            this.btnProcesar.Text = "PROCESAR";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // lbResultados
            // 
            this.lbResultados.AutoSize = true;
            this.lbResultados.Location = new System.Drawing.Point(121, 78);
            this.lbResultados.Name = "lbResultados";
            this.lbResultados.Size = new System.Drawing.Size(203, 13);
            this.lbResultados.TabIndex = 5;
            this.lbResultados.Text = "NO SE ENCONTRARON RESULTADOS";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Location = new System.Drawing.Point(15, 102);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 23);
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(124, 107);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 13);
            this.progressBar.TabIndex = 7;
            this.progressBar.Visible = false;
            // 
            // lvResultado
            // 
            this.lvResultado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvResultado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvResultado.CausesValidation = false;
            this.lvResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvResultado.FullRowSelect = true;
            this.lvResultado.GridLines = true;
            this.lvResultado.HideSelection = false;
            this.lvResultado.Location = new System.Drawing.Point(494, 18);
            this.lvResultado.Margin = new System.Windows.Forms.Padding(0);
            this.lvResultado.MultiSelect = false;
            this.lvResultado.Name = "lvResultado";
            this.lvResultado.ParentContainer = null;
            this.lvResultado.ShowItemToolTips = true;
            this.lvResultado.Size = new System.Drawing.Size(780, 291);
            this.lvResultado.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvResultado.TabIndex = 16;
            this.lvResultado.UseCompatibleStateImageBehavior = false;
            this.lvResultado.View = System.Windows.Forms.View.Details;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(1146, 316);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "EXPORTAR A EXCEL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PFA_CABA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 346);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lvResultado);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lbResultados);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.lbArchivoSeleccionado);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PFA_CABA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PFA_CABA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbArchivoSeleccionado;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Label lbResultados;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ProgressBar progressBar;
        private MicroFour.StrataFrame.UI.Windows.Forms.ListView lvResultado;
        private System.Windows.Forms.Button button2;
    }
}