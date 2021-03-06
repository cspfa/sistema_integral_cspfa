﻿namespace SOCIOS
{
    partial class Consulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consulta));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnFiltros = new System.Windows.Forms.Button();
            this.dtpFdesde = new System.Windows.Forms.DateTimePicker();
            this.dtpFhasta = new System.Windows.Forms.DateTimePicker();
            this.lblFdesde = new System.Windows.Forms.Label();
            this.lblFhasta = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.limpiar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.btnBono = new System.Windows.Forms.Button();
            this.btnLlamar = new System.Windows.Forms.Button();
            this.btnEnEspera = new System.Windows.Forms.Button();
            this.btnAtendido = new System.Windows.Forms.Button();
            this.comboRoles = new System.Windows.Forms.ComboBox();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.comboDestinos = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnAusente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(10, 102);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1056, 348);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // btnFiltros
            // 
            this.btnFiltros.Location = new System.Drawing.Point(683, 41);
            this.btnFiltros.Name = "btnFiltros";
            this.btnFiltros.Size = new System.Drawing.Size(147, 23);
            this.btnFiltros.TabIndex = 8;
            this.btnFiltros.Text = "FILTRAR";
            this.btnFiltros.UseVisualStyleBackColor = true;
            this.btnFiltros.Click += new System.EventHandler(this.btnFiltros_Click);
            // 
            // dtpFdesde
            // 
            this.dtpFdesde.CustomFormat = "dd \'.\' MM \'.\' yyyy";
            this.dtpFdesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFdesde.Location = new System.Drawing.Point(71, 14);
            this.dtpFdesde.Name = "dtpFdesde";
            this.dtpFdesde.Size = new System.Drawing.Size(91, 20);
            this.dtpFdesde.TabIndex = 1;
            this.dtpFdesde.ValueChanged += new System.EventHandler(this.dtpFdesde_ValueChanged);
            // 
            // dtpFhasta
            // 
            this.dtpFhasta.CustomFormat = "dd \'.\' MM \'.\' yyyy";
            this.dtpFhasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFhasta.Location = new System.Drawing.Point(231, 14);
            this.dtpFhasta.Name = "dtpFhasta";
            this.dtpFhasta.Size = new System.Drawing.Size(91, 20);
            this.dtpFhasta.TabIndex = 3;
            this.dtpFhasta.ValueChanged += new System.EventHandler(this.dtpFhasta_ValueChanged);
            // 
            // lblFdesde
            // 
            this.lblFdesde.AutoSize = true;
            this.lblFdesde.BackColor = System.Drawing.Color.Transparent;
            this.lblFdesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFdesde.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFdesde.Location = new System.Drawing.Point(14, 18);
            this.lblFdesde.Name = "lblFdesde";
            this.lblFdesde.Size = new System.Drawing.Size(44, 13);
            this.lblFdesde.TabIndex = 39;
            this.lblFdesde.Text = "DESDE";
            // 
            // lblFhasta
            // 
            this.lblFhasta.AutoSize = true;
            this.lblFhasta.BackColor = System.Drawing.Color.Transparent;
            this.lblFhasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFhasta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFhasta.Location = new System.Drawing.Point(175, 18);
            this.lblFhasta.Name = "lblFhasta";
            this.lblFhasta.Size = new System.Drawing.Size(43, 13);
            this.lblFhasta.TabIndex = 40;
            this.lblFhasta.Text = "HASTA";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(836, 41);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(100, 23);
            this.btnImprimir.TabIndex = 41;
            this.btnImprimir.Text = "IMPRIMIR";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(335, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "ROLE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(615, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "DESTINO";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(384, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(218, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(836, 70);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(100, 23);
            this.limpiar.TabIndex = 10;
            this.limpiar.Text = "LIMPIAR";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(942, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 44;
            this.button1.Text = "CARGA DATOS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(942, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 23);
            this.button2.TabIndex = 45;
            this.button2.Text = "ACTUALIZAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(683, 14);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(377, 21);
            this.comboBox3.TabIndex = 6;
            // 
            // btnBono
            // 
            this.btnBono.Location = new System.Drawing.Point(683, 70);
            this.btnBono.Name = "btnBono";
            this.btnBono.Size = new System.Drawing.Size(147, 23);
            this.btnBono.TabIndex = 46;
            this.btnBono.Text = "BONO ODONTOLÓGICO";
            this.btnBono.UseVisualStyleBackColor = true;
            this.btnBono.Visible = false;
            this.btnBono.Click += new System.EventHandler(this.btnBono_Click);
            // 
            // btnLlamar
            // 
            this.btnLlamar.Location = new System.Drawing.Point(10, 70);
            this.btnLlamar.Name = "btnLlamar";
            this.btnLlamar.Size = new System.Drawing.Size(93, 23);
            this.btnLlamar.TabIndex = 47;
            this.btnLlamar.Text = "LLAMAR";
            this.btnLlamar.UseVisualStyleBackColor = true;
            this.btnLlamar.Click += new System.EventHandler(this.btnLlamar_Click);
            // 
            // btnEnEspera
            // 
            this.btnEnEspera.Location = new System.Drawing.Point(109, 70);
            this.btnEnEspera.Name = "btnEnEspera";
            this.btnEnEspera.Size = new System.Drawing.Size(118, 23);
            this.btnEnEspera.TabIndex = 48;
            this.btnEnEspera.Text = "EN ESPERA";
            this.btnEnEspera.UseVisualStyleBackColor = true;
            this.btnEnEspera.Click += new System.EventHandler(this.btnEnEspera_Click);
            // 
            // btnAtendido
            // 
            this.btnAtendido.Location = new System.Drawing.Point(231, 70);
            this.btnAtendido.Name = "btnAtendido";
            this.btnAtendido.Size = new System.Drawing.Size(118, 23);
            this.btnAtendido.TabIndex = 49;
            this.btnAtendido.Text = "ATENDIDO";
            this.btnAtendido.UseVisualStyleBackColor = true;
            this.btnAtendido.Click += new System.EventHandler(this.btnAtendido_Click);
            // 
            // comboRoles
            // 
            this.comboRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRoles.FormattingEnabled = true;
            this.comboRoles.Location = new System.Drawing.Point(49, 468);
            this.comboRoles.Name = "comboRoles";
            this.comboRoles.Size = new System.Drawing.Size(294, 21);
            this.comboRoles.TabIndex = 50;
            this.comboRoles.SelectedIndexChanged += new System.EventHandler(this.ComboRoles_SelectedIndexChanged);
            // 
            // btnIngreso
            // 
            this.btnIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngreso.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnIngreso.Location = new System.Drawing.Point(897, 467);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(167, 23);
            this.btnIngreso.TabIndex = 54;
            this.btnIngreso.Text = "REGISTRAR INGRESO";
            this.btnIngreso.UseVisualStyleBackColor = true;
            this.btnIngreso.Click += new System.EventHandler(this.BtnIngreso_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 472);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 52;
            this.label15.Text = "ROL:";
            // 
            // comboDestinos
            // 
            this.comboDestinos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDestinos.FormattingEnabled = true;
            this.comboDestinos.Location = new System.Drawing.Point(419, 468);
            this.comboDestinos.Name = "comboDestinos";
            this.comboDestinos.Size = new System.Drawing.Size(469, 21);
            this.comboDestinos.TabIndex = 51;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(352, 472);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 53;
            this.label16.Text = "DESTINO:";
            // 
            // btnAusente
            // 
            this.btnAusente.Location = new System.Drawing.Point(355, 70);
            this.btnAusente.Name = "btnAusente";
            this.btnAusente.Size = new System.Drawing.Size(118, 23);
            this.btnAusente.TabIndex = 55;
            this.btnAusente.Text = "AUSENTE";
            this.btnAusente.UseVisualStyleBackColor = true;
            this.btnAusente.Click += new System.EventHandler(this.BtnAusente_Click);
            // 
            // Consulta
            // 
            this.AutoDeleteMessage = "Business_AutoDeleteMessage";
            this.AutoDeleteTitle = "Business_AutoDeleteTitle";
            this.AutoSaveChangesMessage = "Business_AutoSaveChangesMessage";
            this.AutoSaveChangesTitle = "Business_AutoSaveChangesTitle";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BrokenRulesAlertText = "Business_BrokenRulesAlertText";
            this.BrokenRulesAlertTextAdditionalRows = "Business_BrokenRulesAlertTextAdditionalRows";
            this.BrokenRulesAlertTitle = "Business_BrokenRulesAlertTitle";
            this.ClientSize = new System.Drawing.Size(1074, 510);
            this.Controls.Add(this.btnAusente);
            this.Controls.Add(this.comboRoles);
            this.Controls.Add(this.btnIngreso);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.comboDestinos);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnAtendido);
            this.Controls.Add(this.btnEnEspera);
            this.Controls.Add(this.btnLlamar);
            this.Controls.Add(this.btnBono);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblFhasta);
            this.Controls.Add(this.lblFdesde);
            this.Controls.Add(this.dtpFhasta);
            this.Controls.Add(this.dtpFdesde);
            this.Controls.Add(this.btnFiltros);
            this.Controls.Add(this.dataGridView1);
            this.ErrorProviderBlinkStyle = System.Windows.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.ErrorProviderIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight;
            this.ErrorProviderRequiredFieldDesc = "Business_ErrorProviderRequiredFieldDesc";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Consulta";
            this.Text = "Consultar";
            this.Load += new System.EventHandler(this.Consultar_Load);
            this.Shown += new System.EventHandler(this.Consulta_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnFiltros;
        private System.Windows.Forms.DateTimePicker dtpFhasta;
        private System.Windows.Forms.DateTimePicker dtpFdesde;
        private System.Windows.Forms.Label lblFdesde;
        private System.Windows.Forms.Label lblFhasta;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button btnBono;
        private System.Windows.Forms.Button btnLlamar;
        private System.Windows.Forms.Button btnEnEspera;
        private System.Windows.Forms.Button btnAtendido;
        private System.Windows.Forms.ComboBox comboRoles;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboDestinos;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnAusente;
    }
}

