namespace SOCIOS
{
    partial class asistenciaAsamblea
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbPrimerIngreso = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbUltimoIngreso = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbQuorum = new System.Windows.Forms.Label();
            this.btnActualizarQuorum = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbPrimerIngreso);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PRIMER INGRESO";
            // 
            // lbPrimerIngreso
            // 
            this.lbPrimerIngreso.AutoSize = true;
            this.lbPrimerIngreso.Location = new System.Drawing.Point(16, 23);
            this.lbPrimerIngreso.Name = "lbPrimerIngreso";
            this.lbPrimerIngreso.Size = new System.Drawing.Size(167, 13);
            this.lbPrimerIngreso.TabIndex = 0;
            this.lbPrimerIngreso.Text = "NO SE ENCONTRARON DATOS";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbUltimoIngreso);
            this.groupBox2.Location = new System.Drawing.Point(12, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 51);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ULTIMO INGRESO";
            // 
            // lbUltimoIngreso
            // 
            this.lbUltimoIngreso.AutoSize = true;
            this.lbUltimoIngreso.Location = new System.Drawing.Point(16, 24);
            this.lbUltimoIngreso.Name = "lbUltimoIngreso";
            this.lbUltimoIngreso.Size = new System.Drawing.Size(167, 13);
            this.lbUltimoIngreso.TabIndex = 1;
            this.lbUltimoIngreso.Text = "NO SE ENCONTRARON DATOS";
            // 
            // timer
            // 
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "QUORUM";
            // 
            // lbQuorum
            // 
            this.lbQuorum.AutoSize = true;
            this.lbQuorum.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuorum.Location = new System.Drawing.Point(216, 178);
            this.lbQuorum.Name = "lbQuorum";
            this.lbQuorum.Size = new System.Drawing.Size(39, 42);
            this.lbQuorum.TabIndex = 3;
            this.lbQuorum.Text = "0";
            // 
            // btnActualizarQuorum
            // 
            this.btnActualizarQuorum.Location = new System.Drawing.Point(149, 235);
            this.btnActualizarQuorum.Name = "btnActualizarQuorum";
            this.btnActualizarQuorum.Size = new System.Drawing.Size(173, 38);
            this.btnActualizarQuorum.TabIndex = 4;
            this.btnActualizarQuorum.Text = "ACTUALIZAR QUORUM";
            this.btnActualizarQuorum.UseVisualStyleBackColor = true;
            this.btnActualizarQuorum.Click += new System.EventHandler(this.btnActualizarQuorum_Click);
            // 
            // asistenciaAsamblea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 285);
            this.Controls.Add(this.btnActualizarQuorum);
            this.Controls.Add(this.lbQuorum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "asistenciaAsamblea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asistencia Asamblea";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.asistenciaAsamblea_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lbPrimerIngreso;
        private System.Windows.Forms.Label lbUltimoIngreso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbQuorum;
        private System.Windows.Forms.Button btnActualizarQuorum;
    }
}