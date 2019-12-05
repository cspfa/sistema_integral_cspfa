namespace SOCIOS
{
    partial class GrillaPreRecibo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrillaPreRecibo));
            this.button2 = new MicroFour.StrataFrame.UI.Windows.Forms.Button();
            this.button3 = new MicroFour.StrataFrame.UI.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSociosAbm = new MicroFour.StrataFrame.UI.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarFormaDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReintegro = new MicroFour.StrataFrame.UI.Windows.Forms.Button();
            this.btnLlamar = new System.Windows.Forms.Button();
            this.btnEnEspera = new System.Windows.Forms.Button();
            this.btnAtendido = new System.Windows.Forms.Button();
            this.btnAusente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1071, 518);
            this.button2.Name = "button2";
            this.button2.ParentContainer = null;
            this.button2.Size = new System.Drawing.Size(177, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "IMPRIMIR RECIBO / BONO";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(752, 518);
            this.button3.Name = "button3";
            this.button3.ParentContainer = null;
            this.button3.Size = new System.Drawing.Size(163, 32);
            this.button3.TabIndex = 3;
            this.button3.Text = "ACTUALIZAR LISTADO";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(229, 524);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(103, 20);
            this.dtpFecha.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(607, 518);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "VER SIN IMPRIMIR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(478, 518);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(124, 32);
            this.button4.TabIndex = 6;
            this.button4.Text = "VER IMPRESOS";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 42);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1237, 470);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // btnSociosAbm
            // 
            this.btnSociosAbm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSociosAbm.Location = new System.Drawing.Point(337, 518);
            this.btnSociosAbm.Name = "btnSociosAbm";
            this.btnSociosAbm.ParentContainer = null;
            this.btnSociosAbm.Size = new System.Drawing.Size(136, 32);
            this.btnSociosAbm.TabIndex = 8;
            this.btnSociosAbm.Text = "ABRIR SOCIOS ABM";
            this.btnSociosAbm.Click += new System.EventHandler(this.btnSociosAbm_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarFormaDePagoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(209, 26);
            // 
            // modificarFormaDePagoToolStripMenuItem
            // 
            this.modificarFormaDePagoToolStripMenuItem.Image = global::SOCIOS.Properties.Resources.money;
            this.modificarFormaDePagoToolStripMenuItem.Name = "modificarFormaDePagoToolStripMenuItem";
            this.modificarFormaDePagoToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.modificarFormaDePagoToolStripMenuItem.Text = "Modificar Forma de Pago";
            // 
            // btnReintegro
            // 
            this.btnReintegro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReintegro.Location = new System.Drawing.Point(920, 518);
            this.btnReintegro.Name = "btnReintegro";
            this.btnReintegro.ParentContainer = null;
            this.btnReintegro.Size = new System.Drawing.Size(146, 32);
            this.btnReintegro.TabIndex = 9;
            this.btnReintegro.Text = "REINTEGRO";
            this.btnReintegro.Click += new System.EventHandler(this.btnReintegro_Click);
            // 
            // btnLlamar
            // 
            this.btnLlamar.Location = new System.Drawing.Point(12, 10);
            this.btnLlamar.Name = "btnLlamar";
            this.btnLlamar.Size = new System.Drawing.Size(109, 23);
            this.btnLlamar.TabIndex = 10;
            this.btnLlamar.Text = "LLAMAR";
            this.btnLlamar.UseVisualStyleBackColor = true;
            this.btnLlamar.Click += new System.EventHandler(this.btnLlamar_Click);
            // 
            // btnEnEspera
            // 
            this.btnEnEspera.Location = new System.Drawing.Point(127, 10);
            this.btnEnEspera.Name = "btnEnEspera";
            this.btnEnEspera.Size = new System.Drawing.Size(109, 23);
            this.btnEnEspera.TabIndex = 11;
            this.btnEnEspera.Text = "EN ESPERA";
            this.btnEnEspera.UseVisualStyleBackColor = true;
            this.btnEnEspera.Click += new System.EventHandler(this.btnEnEspera_Click);
            // 
            // btnAtendido
            // 
            this.btnAtendido.Location = new System.Drawing.Point(242, 10);
            this.btnAtendido.Name = "btnAtendido";
            this.btnAtendido.Size = new System.Drawing.Size(109, 23);
            this.btnAtendido.TabIndex = 12;
            this.btnAtendido.Text = "ATENDIDO";
            this.btnAtendido.UseVisualStyleBackColor = true;
            this.btnAtendido.Click += new System.EventHandler(this.btnAtendido_Click);
            // 
            // btnAusente
            // 
            this.btnAusente.Location = new System.Drawing.Point(357, 10);
            this.btnAusente.Name = "btnAusente";
            this.btnAusente.Size = new System.Drawing.Size(109, 23);
            this.btnAusente.TabIndex = 13;
            this.btnAusente.Text = "AUSENTE";
            this.btnAusente.UseVisualStyleBackColor = true;
            this.btnAusente.Click += new System.EventHandler(this.BtnAusente_Click);
            // 
            // GrillaPreRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 562);
            this.Controls.Add(this.btnAusente);
            this.Controls.Add(this.btnAtendido);
            this.Controls.Add(this.btnEnEspera);
            this.Controls.Add(this.btnLlamar);
            this.Controls.Add(this.btnReintegro);
            this.Controls.Add(this.btnSociosAbm);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GrillaPreRecibo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LISTADO DE INGRESOS";
            this.Load += new System.EventHandler(this.GrillaPreRecibo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MicroFour.StrataFrame.UI.Windows.Forms.Button button2;
        private MicroFour.StrataFrame.UI.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MicroFour.StrataFrame.UI.Windows.Forms.Button btnSociosAbm;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modificarFormaDePagoToolStripMenuItem;
        private MicroFour.StrataFrame.UI.Windows.Forms.Button btnReintegro;
        private System.Windows.Forms.Button btnLlamar;
        private System.Windows.Forms.Button btnEnEspera;
        private System.Windows.Forms.Button btnAtendido;
        private System.Windows.Forms.Button btnAusente;
    }
}