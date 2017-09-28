namespace SOCIOS
{
    partial class listadoMovimientos
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
            this.btnListar = new System.Windows.Forms.Button();
            this.dpHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dpDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPersonas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTodos = new System.Windows.Forms.CheckBox();
            this.lvMovimientos = new MicroFour.StrataFrame.UI.Windows.Forms.ListView();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lbTotalHoras = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(366, 42);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(127, 25);
            this.btnListar.TabIndex = 15;
            this.btnListar.Text = "LISTAR!";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // dpHasta
            // 
            this.dpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpHasta.Location = new System.Drawing.Point(254, 44);
            this.dpHasta.Name = "dpHasta";
            this.dpHasta.Size = new System.Drawing.Size(100, 20);
            this.dpHasta.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "HASTA";
            // 
            // dpDesde
            // 
            this.dpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDesde.Location = new System.Drawing.Point(84, 44);
            this.dpDesde.Name = "dpDesde";
            this.dpDesde.Size = new System.Drawing.Size(100, 20);
            this.dpDesde.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "DESDE";
            // 
            // cbPersonas
            // 
            this.cbPersonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPersonas.FormattingEnabled = true;
            this.cbPersonas.Location = new System.Drawing.Point(85, 12);
            this.cbPersonas.Name = "cbPersonas";
            this.cbPersonas.Size = new System.Drawing.Size(171, 21);
            this.cbPersonas.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "PERSONAS";
            // 
            // cbTodos
            // 
            this.cbTodos.AutoSize = true;
            this.cbTodos.Location = new System.Drawing.Point(274, 14);
            this.cbTodos.Name = "cbTodos";
            this.cbTodos.Size = new System.Drawing.Size(105, 17);
            this.cbTodos.TabIndex = 16;
            this.cbTodos.Text = "LISTAR TODOS";
            this.cbTodos.UseVisualStyleBackColor = true;
            this.cbTodos.CheckedChanged += new System.EventHandler(this.cbTodos_CheckedChanged);
            // 
            // lvMovimientos
            // 
            this.lvMovimientos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvMovimientos.CausesValidation = false;
            this.lvMovimientos.DefaultSortDirection = System.Windows.Forms.SortOrder.None;
            this.lvMovimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMovimientos.FullRowSelect = true;
            this.lvMovimientos.HideSelection = false;
            this.lvMovimientos.Location = new System.Drawing.Point(13, 76);
            this.lvMovimientos.Margin = new System.Windows.Forms.Padding(0);
            this.lvMovimientos.MultiSelect = false;
            this.lvMovimientos.Name = "lvMovimientos";
            this.lvMovimientos.ParentContainer = null;
            this.lvMovimientos.ShowItemToolTips = true;
            this.lvMovimientos.Size = new System.Drawing.Size(624, 560);
            this.lvMovimientos.TabIndex = 17;
            this.lvMovimientos.UseCompatibleStateImageBehavior = false;
            this.lvMovimientos.View = System.Windows.Forms.View.Details;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(510, 42);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(127, 25);
            this.btnImprimir.TabIndex = 18;
            this.btnImprimir.Text = "IMPRIMIR";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lbTotalHoras
            // 
            this.lbTotalHoras.AutoSize = true;
            this.lbTotalHoras.Location = new System.Drawing.Point(12, 643);
            this.lbTotalHoras.Name = "lbTotalHoras";
            this.lbTotalHoras.Size = new System.Drawing.Size(174, 13);
            this.lbTotalHoras.TabIndex = 19;
            this.lbTotalHoras.Text = "TOTAL DE HORAS REALIZADAS:";
            // 
            // listadoMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 662);
            this.Controls.Add(this.lbTotalHoras);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lvMovimientos);
            this.Controls.Add(this.cbTodos);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.dpHasta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dpDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbPersonas);
            this.Controls.Add(this.label1);
            this.Name = "listadoMovimientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LISTADO DE MOVIMIENTOS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DateTimePicker dpHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPersonas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbTodos;
        private MicroFour.StrataFrame.UI.Windows.Forms.ListView lvMovimientos;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lbTotalHoras;
    }
}