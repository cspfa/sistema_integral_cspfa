namespace SOCIOS
{
    partial class depositarCajas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgCajasSeleccionadas = new System.Windows.Forms.DataGridView();
            this.BANCOS = new System.Data.DataSet();
            this.BANCOS_T = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BANCO = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IMPUTACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgCajasSeleccionadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BANCOS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BANCOS_T)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCajasSeleccionadas
            // 
            this.dgCajasSeleccionadas.AllowUserToAddRows = false;
            this.dgCajasSeleccionadas.AllowUserToDeleteRows = false;
            this.dgCajasSeleccionadas.AllowUserToResizeColumns = false;
            this.dgCajasSeleccionadas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgCajasSeleccionadas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCajasSeleccionadas.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgCajasSeleccionadas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgCajasSeleccionadas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCajasSeleccionadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgCajasSeleccionadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCajasSeleccionadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.FECHA,
            this.TOTAL,
            this.BANCO,
            this.IMPUTACION,
            this.CODIGO});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCajasSeleccionadas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgCajasSeleccionadas.Location = new System.Drawing.Point(14, 14);
            this.dgCajasSeleccionadas.Margin = new System.Windows.Forms.Padding(5);
            this.dgCajasSeleccionadas.Name = "dgCajasSeleccionadas";
            this.dgCajasSeleccionadas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCajasSeleccionadas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgCajasSeleccionadas.RowHeadersVisible = false;
            this.dgCajasSeleccionadas.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(1);
            this.dgCajasSeleccionadas.RowTemplate.ReadOnly = true;
            this.dgCajasSeleccionadas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCajasSeleccionadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCajasSeleccionadas.Size = new System.Drawing.Size(669, 233);
            this.dgCajasSeleccionadas.TabIndex = 78;
            // 
            // BANCOS
            // 
            this.BANCOS.DataSetName = "BANCOS";
            this.BANCOS.Tables.AddRange(new System.Data.DataTable[] {
            this.BANCOS_T});
            // 
            // BANCOS_T
            // 
            this.BANCOS_T.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
            this.BANCOS_T.TableName = "BANCOS";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "ID";
            this.dataColumn1.ColumnName = "ID";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "NOMBRE";
            this.dataColumn2.ColumnName = "NOMBRE";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // FECHA
            // 
            this.FECHA.HeaderText = "FECHA";
            this.FECHA.Name = "FECHA";
            // 
            // TOTAL
            // 
            this.TOTAL.HeaderText = "TOTAL";
            this.TOTAL.Name = "TOTAL";
            // 
            // BANCO
            // 
            this.BANCO.DataSource = this.BANCOS;
            this.BANCO.DisplayMember = "BANCOS.NOMBRE";
            this.BANCO.HeaderText = "BANCO";
            this.BANCO.Name = "BANCO";
            this.BANCO.ValueMember = "BANCOS.ID";
            this.BANCO.Width = 150;
            // 
            // IMPUTACION
            // 
            this.IMPUTACION.HeaderText = "IMPUTACION";
            this.IMPUTACION.Name = "IMPUTACION";
            // 
            // CODIGO
            // 
            this.CODIGO.HeaderText = "CODIGO";
            this.CODIGO.Name = "CODIGO";
            // 
            // depositarCajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 261);
            this.Controls.Add(this.dgCajasSeleccionadas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "depositarCajas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DEPOSITAR CAJAS SELECCIONADAS";
            ((System.ComponentModel.ISupportInitialize)(this.dgCajasSeleccionadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BANCOS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BANCOS_T)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCajasSeleccionadas;
        private System.Data.DataSet BANCOS;
        private System.Data.DataTable BANCOS_T;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        private System.Windows.Forms.DataGridViewComboBoxColumn BANCO;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPUTACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO;

    }
}