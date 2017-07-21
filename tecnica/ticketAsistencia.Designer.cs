namespace SOCIOS
{
    partial class ticketAsistencia
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnVerTickets = new System.Windows.Forms.Button();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.lbRol = new System.Windows.Forms.Label();
            this.cbPrioridad = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbDisponibles = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbProblema = new System.Windows.Forms.TextBox();
            this.lbNombreEq = new System.Windows.Forms.Label();
            this.tbNombreEq = new System.Windows.Forms.TextBox();
            this.cbPara = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(763, 266);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnVerTickets);
            this.tabPage1.Controls.Add(this.cbRol);
            this.tabPage1.Controls.Add(this.lbRol);
            this.tabPage1.Controls.Add(this.cbPrioridad);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.lbDisponibles);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbProblema);
            this.tabPage1.Controls.Add(this.lbNombreEq);
            this.tabPage1.Controls.Add(this.tbNombreEq);
            this.tabPage1.Controls.Add(this.cbPara);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(755, 240);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TÉCNICA";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnVerTickets
            // 
            this.btnVerTickets.Location = new System.Drawing.Point(587, 205);
            this.btnVerTickets.Name = "btnVerTickets";
            this.btnVerTickets.Size = new System.Drawing.Size(140, 23);
            this.btnVerTickets.TabIndex = 8;
            this.btnVerTickets.Text = "VER TICKETS";
            this.btnVerTickets.UseVisualStyleBackColor = true;
            this.btnVerTickets.Click += new System.EventHandler(this.btnVerTickets_Click);
            // 
            // cbRol
            // 
            this.cbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Location = new System.Drawing.Point(586, 52);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(140, 21);
            this.cbRol.TabIndex = 4;
            this.cbRol.Visible = false;
            // 
            // lbRol
            // 
            this.lbRol.AutoSize = true;
            this.lbRol.Location = new System.Drawing.Point(508, 56);
            this.lbRol.Name = "lbRol";
            this.lbRol.Size = new System.Drawing.Size(29, 13);
            this.lbRol.TabIndex = 10;
            this.lbRol.Text = "ROL";
            this.lbRol.Visible = false;
            // 
            // cbPrioridad
            // 
            this.cbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrioridad.FormattingEnabled = true;
            this.cbPrioridad.Location = new System.Drawing.Point(236, 52);
            this.cbPrioridad.Name = "cbPrioridad";
            this.cbPrioridad.Size = new System.Drawing.Size(140, 21);
            this.cbPrioridad.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "PRIORIDAD:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(438, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "ENVIAR SOLICITUD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbDisponibles
            // 
            this.lbDisponibles.AutoSize = true;
            this.lbDisponibles.Location = new System.Drawing.Point(23, 205);
            this.lbDisponibles.Name = "lbDisponibles";
            this.lbDisponibles.Size = new System.Drawing.Size(177, 13);
            this.lbDisponibles.TabIndex = 6;
            this.lbDisponibles.Text = "CARACTERES DISPONIBLES: 300";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "DESCRIPCION DEL PROBLEMA:";
            // 
            // tbProblema
            // 
            this.tbProblema.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbProblema.Location = new System.Drawing.Point(25, 103);
            this.tbProblema.MaxLength = 300;
            this.tbProblema.Multiline = true;
            this.tbProblema.Name = "tbProblema";
            this.tbProblema.Size = new System.Drawing.Size(701, 91);
            this.tbProblema.TabIndex = 5;
            this.tbProblema.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbProblema_KeyUp);
            // 
            // lbNombreEq
            // 
            this.lbNombreEq.AutoSize = true;
            this.lbNombreEq.Location = new System.Drawing.Point(384, 29);
            this.lbNombreEq.Name = "lbNombreEq";
            this.lbNombreEq.Size = new System.Drawing.Size(194, 13);
            this.lbNombreEq.TabIndex = 3;
            this.lbNombreEq.Text = "NOMBRE DE EQUIPO O IMPRESORA";
            this.lbNombreEq.Visible = false;
            // 
            // tbNombreEq
            // 
            this.tbNombreEq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombreEq.Location = new System.Drawing.Point(586, 25);
            this.tbNombreEq.Name = "tbNombreEq";
            this.tbNombreEq.Size = new System.Drawing.Size(140, 20);
            this.tbNombreEq.TabIndex = 2;
            this.tbNombreEq.Visible = false;
            // 
            // cbPara
            // 
            this.cbPara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPara.FormattingEnabled = true;
            this.cbPara.Location = new System.Drawing.Point(236, 25);
            this.cbPara.Name = "cbPara";
            this.cbPara.Size = new System.Drawing.Size(140, 21);
            this.cbPara.TabIndex = 1;
            this.cbPara.SelectionChangeCommitted += new System.EventHandler(this.cbPara_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SOLICITO ASISTENCIA TÉCNICA PARA:";
            // 
            // ticketAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 292);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ticketAsistencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASISTENCIA TÉCNICA Y PEDIDO DE INSUMOS";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbPara;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNombreEq;
        private System.Windows.Forms.TextBox tbNombreEq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbProblema;
        private System.Windows.Forms.Label lbDisponibles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbPrioridad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.Label lbRol;
        private System.Windows.Forms.Button btnVerTickets;

    }
}