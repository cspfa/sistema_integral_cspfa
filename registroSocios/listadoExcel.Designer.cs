namespace SOCIOS
{
    partial class listadoExcel
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
            this.dtpADTO = new System.Windows.Forms.DateTimePicker();
            this.cbOrigenAlta = new System.Windows.Forms.ComboBox();
            this.btnVer = new System.Windows.Forms.Button();
            this.rbAlfabetico = new System.Windows.Forms.RadioButton();
            this.rbAfiliado = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLegajo = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.newDataSet1 = new SOCIOS.NewDataSet();
            this.newDataSet2 = new SOCIOS.NewDataSet();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbAlta = new System.Windows.Forms.RadioButton();
            this.rbBaja = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newDataSet2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpADTO
            // 
            this.dtpADTO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpADTO.Location = new System.Drawing.Point(11, 24);
            this.dtpADTO.Name = "dtpADTO";
            this.dtpADTO.Size = new System.Drawing.Size(161, 20);
            this.dtpADTO.TabIndex = 18;
            // 
            // cbOrigenAlta
            // 
            this.cbOrigenAlta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrigenAlta.FormattingEnabled = true;
            this.cbOrigenAlta.Location = new System.Drawing.Point(11, 24);
            this.cbOrigenAlta.Name = "cbOrigenAlta";
            this.cbOrigenAlta.Size = new System.Drawing.Size(161, 21);
            this.cbOrigenAlta.TabIndex = 17;
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(12, 145);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(273, 27);
            this.btnVer.TabIndex = 15;
            this.btnVer.Text = "GENERAR LISTADO";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // rbAlfabetico
            // 
            this.rbAlfabetico.AutoSize = true;
            this.rbAlfabetico.Location = new System.Drawing.Point(16, 26);
            this.rbAlfabetico.Name = "rbAlfabetico";
            this.rbAlfabetico.Size = new System.Drawing.Size(72, 17);
            this.rbAlfabetico.TabIndex = 21;
            this.rbAlfabetico.TabStop = true;
            this.rbAlfabetico.Text = "Alfabético";
            this.rbAlfabetico.UseVisualStyleBackColor = true;
            // 
            // rbAfiliado
            // 
            this.rbAfiliado.AutoSize = true;
            this.rbAfiliado.Location = new System.Drawing.Point(94, 26);
            this.rbAfiliado.Name = "rbAfiliado";
            this.rbAfiliado.Size = new System.Drawing.Size(59, 17);
            this.rbAfiliado.TabIndex = 22;
            this.rbAfiliado.TabStop = true;
            this.rbAfiliado.Text = "Afiliado";
            this.rbAfiliado.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLegajo);
            this.groupBox1.Controls.Add(this.rbAlfabetico);
            this.groupBox1.Controls.Add(this.rbAfiliado);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 60);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenamiento";
            // 
            // rbLegajo
            // 
            this.rbLegajo.AutoSize = true;
            this.rbLegajo.Location = new System.Drawing.Point(159, 26);
            this.rbLegajo.Name = "rbLegajo";
            this.rbLegajo.Size = new System.Drawing.Size(101, 17);
            this.rbLegajo.TabIndex = 23;
            this.rbLegajo.TabStop = true;
            this.rbLegajo.Text = "Legajo Personal";
            this.rbLegajo.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbOrigenAlta);
            this.groupBox3.Location = new System.Drawing.Point(293, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(179, 60);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Origen Alta";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtpADTO);
            this.groupBox4.Location = new System.Drawing.Point(291, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(181, 60);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "A Descuento";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(293, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 27);
            this.button1.TabIndex = 28;
            this.button1.Text = "LIMPIAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // newDataSet1
            // 
            this.newDataSet1.DataSetName = "NewDataSet";
            this.newDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // newDataSet2
            // 
            this.newDataSet2.DataSetName = "NewDataSet";
            this.newDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbAlta);
            this.groupBox2.Controls.Add(this.rbBaja);
            this.groupBox2.Location = new System.Drawing.Point(12, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 60);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estado";
            // 
            // rbAlta
            // 
            this.rbAlta.AutoSize = true;
            this.rbAlta.Location = new System.Drawing.Point(16, 26);
            this.rbAlta.Name = "rbAlta";
            this.rbAlta.Size = new System.Drawing.Size(43, 17);
            this.rbAlta.TabIndex = 21;
            this.rbAlta.TabStop = true;
            this.rbAlta.Text = "Alta";
            this.rbAlta.UseVisualStyleBackColor = true;
            // 
            // rbBaja
            // 
            this.rbBaja.AutoSize = true;
            this.rbBaja.Location = new System.Drawing.Point(94, 26);
            this.rbBaja.Name = "rbBaja";
            this.rbBaja.Size = new System.Drawing.Size(46, 17);
            this.rbBaja.TabIndex = 22;
            this.rbBaja.TabStop = true;
            this.rbBaja.Text = "Baja";
            this.rbBaja.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 181);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(460, 23);
            this.progressBar1.TabIndex = 29;
            // 
            // listadoExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 214);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnVer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "listadoExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado Excel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.newDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newDataSet2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpADTO;
        private System.Windows.Forms.ComboBox cbOrigenAlta;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.RadioButton rbAlfabetico;
        private System.Windows.Forms.RadioButton rbAfiliado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbLegajo;
        private NewDataSet newDataSet1;
        private NewDataSet newDataSet2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbAlta;
        private System.Windows.Forms.RadioButton rbBaja;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}