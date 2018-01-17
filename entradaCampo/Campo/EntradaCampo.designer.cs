namespace SOCIOS.Entrada_Campo
{
    partial class EntradaCampoIngresoTotales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntradaCampoIngresoTotales));
            this.Personas = new System.Windows.Forms.DataGridView();
            this.lnkFamiliar = new System.Windows.Forms.LinkLabel();
            this.lnk_Familiar_Pileta = new System.Windows.Forms.LinkLabel();
            this.gpFamiliares = new System.Windows.Forms.GroupBox();
            this.lnk_Familiar_Estacionamiento = new System.Windows.Forms.LinkLabel();
            this.gpInvitados = new System.Windows.Forms.GroupBox();
            this.lnk_Invitado_Estacionamiento = new System.Windows.Forms.LinkLabel();
            this.lnkInvitado = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbDatos = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Pago = new System.Windows.Forms.Button();
            this.gpInterCirculo = new System.Windows.Forms.GroupBox();
            this.lnk_InterCirculo_Estacionamiento = new System.Windows.Forms.LinkLabel();
            this.lnk_Intercirculo_Pileta = new System.Windows.Forms.LinkLabel();
            this.lnkIntercirculo = new System.Windows.Forms.LinkLabel();
            this.lb = new System.Windows.Forms.Label();
            this.lbSocio = new System.Windows.Forms.Label();
            this.lbInvitado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbEstacionamiento = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbInter = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSinCargo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gpSinCargo = new System.Windows.Forms.GroupBox();
            this.lnkDiscaAcom = new System.Windows.Forms.LinkLabel();
            this.lnkDisca = new System.Windows.Forms.LinkLabel();
            this.lnkMenor = new System.Windows.Forms.LinkLabel();
            this.lbReintegro = new System.Windows.Forms.Label();
            this.lbSocioPileta = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbInviPileta = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbInterPileta = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkCumple = new System.Windows.Forms.CheckBox();
            this.tbCumple = new System.Windows.Forms.TextBox();
            this.chkSocio = new System.Windows.Forms.CheckBox();
            this.chkPersonalPolicial = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Personas)).BeginInit();
            this.gpFamiliares.SuspendLayout();
            this.gpInvitados.SuspendLayout();
            this.gpInterCirculo.SuspendLayout();
            this.gpSinCargo.SuspendLayout();
            this.SuspendLayout();
            // 
            // Personas
            // 
            this.Personas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Personas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Personas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Personas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Personas.Location = new System.Drawing.Point(188, 200);
            this.Personas.Name = "Personas";
            this.Personas.RowHeadersVisible = false;
            this.Personas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Personas.Size = new System.Drawing.Size(359, 273);
            this.Personas.TabIndex = 1;
            // 
            // lnkFamiliar
            // 
            this.lnkFamiliar.AutoSize = true;
            this.lnkFamiliar.LinkColor = System.Drawing.Color.Green;
            this.lnkFamiliar.Location = new System.Drawing.Point(11, 20);
            this.lnkFamiliar.Name = "lnkFamiliar";
            this.lnkFamiliar.Size = new System.Drawing.Size(68, 13);
            this.lnkFamiliar.TabIndex = 2;
            this.lnkFamiliar.TabStop = true;
            this.lnkFamiliar.Text = "+ ENTRADA";
            this.lnkFamiliar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFamiliar_LinkClicked);
            // 
            // lnk_Familiar_Pileta
            // 
            this.lnk_Familiar_Pileta.AutoSize = true;
            this.lnk_Familiar_Pileta.LinkColor = System.Drawing.Color.Green;
            this.lnk_Familiar_Pileta.Location = new System.Drawing.Point(112, 20);
            this.lnk_Familiar_Pileta.Name = "lnk_Familiar_Pileta";
            this.lnk_Familiar_Pileta.Size = new System.Drawing.Size(56, 13);
            this.lnk_Familiar_Pileta.TabIndex = 3;
            this.lnk_Familiar_Pileta.TabStop = true;
            this.lnk_Familiar_Pileta.Text = "+  PILETA";
            this.lnk_Familiar_Pileta.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_Familiar_Pileta_LinkClicked);
            // 
            // gpFamiliares
            // 
            this.gpFamiliares.Controls.Add(this.lnk_Familiar_Estacionamiento);
            this.gpFamiliares.Controls.Add(this.lnk_Familiar_Pileta);
            this.gpFamiliares.Controls.Add(this.lnkFamiliar);
            this.gpFamiliares.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gpFamiliares.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gpFamiliares.Location = new System.Drawing.Point(11, 72);
            this.gpFamiliares.Name = "gpFamiliares";
            this.gpFamiliares.Size = new System.Drawing.Size(334, 47);
            this.gpFamiliares.TabIndex = 4;
            this.gpFamiliares.TabStop = false;
            this.gpFamiliares.Text = "SOCIOS, FAMILIARES E INVITADOS PARTICIPATIVOS";
            // 
            // lnk_Familiar_Estacionamiento
            // 
            this.lnk_Familiar_Estacionamiento.AutoSize = true;
            this.lnk_Familiar_Estacionamiento.LinkColor = System.Drawing.Color.Green;
            this.lnk_Familiar_Estacionamiento.Location = new System.Drawing.Point(201, 20);
            this.lnk_Familiar_Estacionamiento.Name = "lnk_Familiar_Estacionamiento";
            this.lnk_Familiar_Estacionamiento.Size = new System.Drawing.Size(119, 13);
            this.lnk_Familiar_Estacionamiento.TabIndex = 4;
            this.lnk_Familiar_Estacionamiento.TabStop = true;
            this.lnk_Familiar_Estacionamiento.Text = "+ ESTACIONAMIENTO";
            this.lnk_Familiar_Estacionamiento.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_Familiar_Estacionamiento_LinkClicked);
            // 
            // gpInvitados
            // 
            this.gpInvitados.Controls.Add(this.lnk_Invitado_Estacionamiento);
            this.gpInvitados.Controls.Add(this.lnkInvitado);
            this.gpInvitados.Controls.Add(this.linkLabel2);
            this.gpInvitados.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gpInvitados.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gpInvitados.Location = new System.Drawing.Point(11, 134);
            this.gpInvitados.Name = "gpInvitados";
            this.gpInvitados.Size = new System.Drawing.Size(334, 47);
            this.gpInvitados.TabIndex = 5;
            this.gpInvitados.TabStop = false;
            this.gpInvitados.Text = "INVITADOS OCASIONALES";
            // 
            // lnk_Invitado_Estacionamiento
            // 
            this.lnk_Invitado_Estacionamiento.AutoSize = true;
            this.lnk_Invitado_Estacionamiento.LinkColor = System.Drawing.Color.Green;
            this.lnk_Invitado_Estacionamiento.Location = new System.Drawing.Point(201, 20);
            this.lnk_Invitado_Estacionamiento.Name = "lnk_Invitado_Estacionamiento";
            this.lnk_Invitado_Estacionamiento.Size = new System.Drawing.Size(119, 13);
            this.lnk_Invitado_Estacionamiento.TabIndex = 5;
            this.lnk_Invitado_Estacionamiento.TabStop = true;
            this.lnk_Invitado_Estacionamiento.Text = "+ ESTACIONAMIENTO";
            this.lnk_Invitado_Estacionamiento.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_Invitado_Estacionamiento_LinkClicked);
            // 
            // lnkInvitado
            // 
            this.lnkInvitado.AutoSize = true;
            this.lnkInvitado.LinkColor = System.Drawing.Color.Green;
            this.lnkInvitado.Location = new System.Drawing.Point(11, 20);
            this.lnkInvitado.Name = "lnkInvitado";
            this.lnkInvitado.Size = new System.Drawing.Size(68, 13);
            this.lnkInvitado.TabIndex = 4;
            this.lnkInvitado.TabStop = true;
            this.lnkInvitado.Text = "+ ENTRADA";
            this.lnkInvitado.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkInvitado_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.Green;
            this.linkLabel2.Location = new System.Drawing.Point(114, 20);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(53, 13);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "+ PILETA";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(471, 578);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "TOTAL $:";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.ForeColor = System.Drawing.Color.Red;
            this.lbTotal.Location = new System.Drawing.Point(634, 578);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(18, 20);
            this.lbTotal.TabIndex = 9;
            this.lbTotal.Text = "0";
            // 
            // lbDatos
            // 
            this.lbDatos.AutoSize = true;
            this.lbDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDatos.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbDatos.Location = new System.Drawing.Point(17, 15);
            this.lbDatos.Name = "lbDatos";
            this.lbDatos.Size = new System.Drawing.Size(67, 20);
            this.lbDatos.TabIndex = 10;
            this.lbDatos.Text = "lblDatos";
            // 
            // btnImprimir
            // 
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.Location = new System.Drawing.Point(288, 447);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(136, 30);
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.Text = "IMPRIMIR TICKET";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // Delete
            // 
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Delete.Location = new System.Drawing.Point(70, 479);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(161, 30);
            this.Delete.TabIndex = 7;
            this.Delete.Text = "BORRAR SELECCIONADO";
            this.Delete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Pago
            // 
            this.Pago.Image = ((System.Drawing.Image)(resources.GetObject("Pago.Image")));
            this.Pago.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Pago.Location = new System.Drawing.Point(475, 479);
            this.Pago.Name = "Pago";
            this.Pago.Size = new System.Drawing.Size(113, 30);
            this.Pago.TabIndex = 6;
            this.Pago.Text = "INGRESO";
            this.Pago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Pago.UseVisualStyleBackColor = true;
            this.Pago.Click += new System.EventHandler(this.Pago_Click);
            // 
            // gpInterCirculo
            // 
            this.gpInterCirculo.Controls.Add(this.lnk_InterCirculo_Estacionamiento);
            this.gpInterCirculo.Controls.Add(this.lnk_Intercirculo_Pileta);
            this.gpInterCirculo.Controls.Add(this.lnkIntercirculo);
            this.gpInterCirculo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gpInterCirculo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gpInterCirculo.Location = new System.Drawing.Point(351, 72);
            this.gpInterCirculo.Name = "gpInterCirculo";
            this.gpInterCirculo.Size = new System.Drawing.Size(416, 47);
            this.gpInterCirculo.TabIndex = 5;
            this.gpInterCirculo.TabStop = false;
            this.gpInterCirculo.Text = "INTERCIRCULO Y PERSONAL POLICIAL NO SOCIO";
            // 
            // lnk_InterCirculo_Estacionamiento
            // 
            this.lnk_InterCirculo_Estacionamiento.AutoSize = true;
            this.lnk_InterCirculo_Estacionamiento.LinkColor = System.Drawing.Color.Green;
            this.lnk_InterCirculo_Estacionamiento.Location = new System.Drawing.Point(275, 20);
            this.lnk_InterCirculo_Estacionamiento.Name = "lnk_InterCirculo_Estacionamiento";
            this.lnk_InterCirculo_Estacionamiento.Size = new System.Drawing.Size(119, 13);
            this.lnk_InterCirculo_Estacionamiento.TabIndex = 6;
            this.lnk_InterCirculo_Estacionamiento.TabStop = true;
            this.lnk_InterCirculo_Estacionamiento.Text = "+ ESTACIONAMIENTO";
            this.lnk_InterCirculo_Estacionamiento.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_InterCirculo_Estacionamiento_LinkClicked);
            // 
            // lnk_Intercirculo_Pileta
            // 
            this.lnk_Intercirculo_Pileta.AutoSize = true;
            this.lnk_Intercirculo_Pileta.LinkColor = System.Drawing.Color.Green;
            this.lnk_Intercirculo_Pileta.Location = new System.Drawing.Point(152, 20);
            this.lnk_Intercirculo_Pileta.Name = "lnk_Intercirculo_Pileta";
            this.lnk_Intercirculo_Pileta.Size = new System.Drawing.Size(56, 13);
            this.lnk_Intercirculo_Pileta.TabIndex = 3;
            this.lnk_Intercirculo_Pileta.TabStop = true;
            this.lnk_Intercirculo_Pileta.Text = "+  PILETA";
            this.lnk_Intercirculo_Pileta.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_Intercirculo_Pileta_LinkClicked);
            // 
            // lnkIntercirculo
            // 
            this.lnkIntercirculo.AutoSize = true;
            this.lnkIntercirculo.LinkColor = System.Drawing.Color.Green;
            this.lnkIntercirculo.Location = new System.Drawing.Point(11, 20);
            this.lnkIntercirculo.Name = "lnkIntercirculo";
            this.lnkIntercirculo.Size = new System.Drawing.Size(68, 13);
            this.lnkIntercirculo.TabIndex = 2;
            this.lnkIntercirculo.TabStop = true;
            this.lnkIntercirculo.Text = "+ ENTRADA";
            this.lnkIntercirculo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkIntercirculo_LinkClicked);
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lb.Location = new System.Drawing.Point(81, 520);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(75, 20);
            this.lb.TabIndex = 12;
            this.lb.Text = "SOCIOS:";
            // 
            // lbSocio
            // 
            this.lbSocio.AutoSize = true;
            this.lbSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSocio.ForeColor = System.Drawing.Color.OliveDrab;
            this.lbSocio.Location = new System.Drawing.Point(152, 520);
            this.lbSocio.Name = "lbSocio";
            this.lbSocio.Size = new System.Drawing.Size(18, 20);
            this.lbSocio.TabIndex = 13;
            this.lbSocio.Text = "0";
            // 
            // lbInvitado
            // 
            this.lbInvitado.AutoSize = true;
            this.lbInvitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInvitado.ForeColor = System.Drawing.Color.OliveDrab;
            this.lbInvitado.Location = new System.Drawing.Point(152, 549);
            this.lbInvitado.Name = "lbInvitado";
            this.lbInvitado.Size = new System.Drawing.Size(18, 20);
            this.lbInvitado.TabIndex = 15;
            this.lbInvitado.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(56, 549);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "INVITADOS:";
            // 
            // lbEstacionamiento
            // 
            this.lbEstacionamiento.AutoSize = true;
            this.lbEstacionamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstacionamiento.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbEstacionamiento.Location = new System.Drawing.Point(637, 520);
            this.lbEstacionamiento.Name = "lbEstacionamiento";
            this.lbEstacionamiento.Size = new System.Drawing.Size(18, 20);
            this.lbEstacionamiento.TabIndex = 17;
            this.lbEstacionamiento.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(471, 520);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "ESTACIONAMIENTO :";
            // 
            // lbInter
            // 
            this.lbInter.AutoSize = true;
            this.lbInter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInter.ForeColor = System.Drawing.Color.OliveDrab;
            this.lbInter.Location = new System.Drawing.Point(152, 578);
            this.lbInter.Name = "lbInter";
            this.lbInter.Size = new System.Drawing.Size(18, 20);
            this.lbInter.TabIndex = 19;
            this.lbInter.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(23, 578);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "INTERCIRCULO:";
            // 
            // lbSinCargo
            // 
            this.lbSinCargo.AutoSize = true;
            this.lbSinCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSinCargo.ForeColor = System.Drawing.Color.CadetBlue;
            this.lbSinCargo.Location = new System.Drawing.Point(637, 549);
            this.lbSinCargo.Name = "lbSinCargo";
            this.lbSinCargo.Size = new System.Drawing.Size(18, 20);
            this.lbSinCargo.TabIndex = 21;
            this.lbSinCargo.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(471, 549);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "SIN CARGO :";
            // 
            // gpSinCargo
            // 
            this.gpSinCargo.Controls.Add(this.lnkDiscaAcom);
            this.gpSinCargo.Controls.Add(this.lnkDisca);
            this.gpSinCargo.Controls.Add(this.lnkMenor);
            this.gpSinCargo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gpSinCargo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gpSinCargo.Location = new System.Drawing.Point(351, 134);
            this.gpSinCargo.Name = "gpSinCargo";
            this.gpSinCargo.Size = new System.Drawing.Size(416, 47);
            this.gpSinCargo.TabIndex = 7;
            this.gpSinCargo.TabStop = false;
            this.gpSinCargo.Text = "SIN CARGO";
            // 
            // lnkDiscaAcom
            // 
            this.lnkDiscaAcom.AutoSize = true;
            this.lnkDiscaAcom.LinkColor = System.Drawing.Color.Green;
            this.lnkDiscaAcom.Location = new System.Drawing.Point(275, 20);
            this.lnkDiscaAcom.Name = "lnkDiscaAcom";
            this.lnkDiscaAcom.Size = new System.Drawing.Size(94, 13);
            this.lnkDiscaAcom.TabIndex = 6;
            this.lnkDiscaAcom.TabStop = true;
            this.lnkDiscaAcom.Text = "+ VITALICIO ORO";
            this.lnkDiscaAcom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDiscaAcom_LinkClicked);
            // 
            // lnkDisca
            // 
            this.lnkDisca.AutoSize = true;
            this.lnkDisca.LinkColor = System.Drawing.Color.Green;
            this.lnkDisca.Location = new System.Drawing.Point(89, 20);
            this.lnkDisca.Name = "lnkDisca";
            this.lnkDisca.Size = new System.Drawing.Size(159, 13);
            this.lnkDisca.TabIndex = 3;
            this.lnkDisca.TabStop = true;
            this.lnkDisca.Text = "+ DISCAPACITADO Y/O ACOM";
            this.lnkDisca.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDisca_LinkClicked);
            // 
            // lnkMenor
            // 
            this.lnkMenor.AutoSize = true;
            this.lnkMenor.LinkColor = System.Drawing.Color.Green;
            this.lnkMenor.Location = new System.Drawing.Point(17, 20);
            this.lnkMenor.Name = "lnkMenor";
            this.lnkMenor.Size = new System.Drawing.Size(56, 13);
            this.lnkMenor.TabIndex = 2;
            this.lnkMenor.TabStop = true;
            this.lnkMenor.Text = "+ MENOR";
            this.lnkMenor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMenor_LinkClicked);
            // 
            // lbReintegro
            // 
            this.lbReintegro.AutoSize = true;
            this.lbReintegro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReintegro.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbReintegro.Location = new System.Drawing.Point(21, 35);
            this.lbReintegro.Name = "lbReintegro";
            this.lbReintegro.Size = new System.Drawing.Size(87, 20);
            this.lbReintegro.TabIndex = 22;
            this.lbReintegro.Text = "[Reintegro]";
            // 
            // lbSocioPileta
            // 
            this.lbSocioPileta.AutoSize = true;
            this.lbSocioPileta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSocioPileta.ForeColor = System.Drawing.Color.OliveDrab;
            this.lbSocioPileta.Location = new System.Drawing.Point(357, 520);
            this.lbSocioPileta.Name = "lbSocioPileta";
            this.lbSocioPileta.Size = new System.Drawing.Size(18, 20);
            this.lbSocioPileta.TabIndex = 24;
            this.lbSocioPileta.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(228, 520);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "C/PILETA:";
            // 
            // lbInviPileta
            // 
            this.lbInviPileta.AutoSize = true;
            this.lbInviPileta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInviPileta.ForeColor = System.Drawing.Color.OliveDrab;
            this.lbInviPileta.Location = new System.Drawing.Point(357, 549);
            this.lbInviPileta.Name = "lbInviPileta";
            this.lbInviPileta.Size = new System.Drawing.Size(18, 20);
            this.lbInviPileta.TabIndex = 26;
            this.lbInviPileta.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(228, 549);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "C/PILETA:";
            // 
            // lbInterPileta
            // 
            this.lbInterPileta.AutoSize = true;
            this.lbInterPileta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInterPileta.ForeColor = System.Drawing.Color.OliveDrab;
            this.lbInterPileta.Location = new System.Drawing.Point(357, 577);
            this.lbInterPileta.Name = "lbInterPileta";
            this.lbInterPileta.Size = new System.Drawing.Size(18, 20);
            this.lbInterPileta.TabIndex = 28;
            this.lbInterPileta.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(228, 577);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 20);
            this.label11.TabIndex = 27;
            this.label11.Text = "C/PILETA:";
            // 
            // chkCumple
            // 
            this.chkCumple.AutoSize = true;
            this.chkCumple.Location = new System.Drawing.Point(25, 628);
            this.chkCumple.Name = "chkCumple";
            this.chkCumple.Size = new System.Drawing.Size(132, 17);
            this.chkCumple.TabIndex = 29;
            this.chkCumple.Text = "Ingreso X Cumpleaños";
            this.chkCumple.UseVisualStyleBackColor = true;
            this.chkCumple.CheckedChanged += new System.EventHandler(this.chkCumple_CheckedChanged);
            // 
            // tbCumple
            // 
            this.tbCumple.Location = new System.Drawing.Point(13, 666);
            this.tbCumple.MaxLength = 100;
            this.tbCumple.Multiline = true;
            this.tbCumple.Name = "tbCumple";
            this.tbCumple.Size = new System.Drawing.Size(658, 66);
            this.tbCumple.TabIndex = 30;
            this.tbCumple.Visible = false;
            // 
            // chkSocio
            // 
            this.chkSocio.AutoSize = true;
            this.chkSocio.Location = new System.Drawing.Point(441, 42);
            this.chkSocio.Name = "chkSocio";
            this.chkSocio.Size = new System.Drawing.Size(68, 17);
            this.chkSocio.TabIndex = 32;
            this.chkSocio.Text = "Es Socio";
            this.chkSocio.UseVisualStyleBackColor = true;
            this.chkSocio.CheckedChanged += new System.EventHandler(this.chkSocio_CheckedChanged);
            // 
            // chkPersonalPolicial
            // 
            this.chkPersonalPolicial.AutoSize = true;
            this.chkPersonalPolicial.Location = new System.Drawing.Point(441, 19);
            this.chkPersonalPolicial.Name = "chkPersonalPolicial";
            this.chkPersonalPolicial.Size = new System.Drawing.Size(170, 17);
            this.chkPersonalPolicial.TabIndex = 31;
            this.chkPersonalPolicial.Text = "Personal Policial / InterCirculo ";
            this.chkPersonalPolicial.UseVisualStyleBackColor = true;
            this.chkPersonalPolicial.CheckedChanged += new System.EventHandler(this.chkPersonalPolicial_CheckedChanged);
            // 
            // EntradaCampoIngresoTotales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(779, 743);
            this.Controls.Add(this.chkSocio);
            this.Controls.Add(this.chkPersonalPolicial);
            this.Controls.Add(this.tbCumple);
            this.Controls.Add(this.chkCumple);
            this.Controls.Add(this.lbInterPileta);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbInviPileta);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbSocioPileta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbReintegro);
            this.Controls.Add(this.gpSinCargo);
            this.Controls.Add(this.lbSinCargo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbInter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbEstacionamiento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbInvitado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbSocio);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.gpInterCirculo);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lbDatos);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Pago);
            this.Controls.Add(this.gpInvitados);
            this.Controls.Add(this.Personas);
            this.Controls.Add(this.gpFamiliares);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EntradaCampoIngresoTotales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso Campo";
            ((System.ComponentModel.ISupportInitialize)(this.Personas)).EndInit();
            this.gpFamiliares.ResumeLayout(false);
            this.gpFamiliares.PerformLayout();
            this.gpInvitados.ResumeLayout(false);
            this.gpInvitados.PerformLayout();
            this.gpInterCirculo.ResumeLayout(false);
            this.gpInterCirculo.PerformLayout();
            this.gpSinCargo.ResumeLayout(false);
            this.gpSinCargo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Personas;
        private System.Windows.Forms.LinkLabel lnkFamiliar;
        private System.Windows.Forms.LinkLabel lnk_Familiar_Pileta;
        private System.Windows.Forms.GroupBox gpFamiliares;
        private System.Windows.Forms.GroupBox gpInvitados;
        private System.Windows.Forms.LinkLabel lnkInvitado;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button Pago;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbDatos;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.LinkLabel lnk_Familiar_Estacionamiento;
        private System.Windows.Forms.LinkLabel lnk_Invitado_Estacionamiento;
        private System.Windows.Forms.GroupBox gpInterCirculo;
        private System.Windows.Forms.LinkLabel lnk_InterCirculo_Estacionamiento;
        private System.Windows.Forms.LinkLabel lnk_Intercirculo_Pileta;
        private System.Windows.Forms.LinkLabel lnkIntercirculo;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.Label lbSocio;
        private System.Windows.Forms.Label lbInvitado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbEstacionamiento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbInter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbSinCargo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gpSinCargo;
        private System.Windows.Forms.LinkLabel lnkDiscaAcom;
        private System.Windows.Forms.LinkLabel lnkDisca;
        private System.Windows.Forms.LinkLabel lnkMenor;
        private System.Windows.Forms.Label lbReintegro;
        private System.Windows.Forms.Label lbSocioPileta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbInviPileta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbInterPileta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkCumple;
        private System.Windows.Forms.TextBox tbCumple;
        private System.Windows.Forms.CheckBox chkSocio;
        private System.Windows.Forms.CheckBox chkPersonalPolicial;
    }
}