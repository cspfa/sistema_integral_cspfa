namespace SOCIOS
{

    public partial class Quorum : MicroFour.StrataFrame.UI.Windows.Forms.StandardForm
    {
        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components = null;

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("PRIMER INGRESO");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("ULTIMO INGRESO");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("QUORUM", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("ABRIR INGRESO");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("CERRAR INGRESO");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("ACCIONES", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quorum));
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.ToolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TreeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ListView1 = new MicroFour.StrataFrame.UI.Windows.Forms.ListView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.fbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.fbDataAdapter1 = new FirebirdSql.Data.FirebirdClient.FbDataAdapter();
            this.fbCommand4 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.fbCommand2 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.fbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.fbCommand3 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.fbCommand5 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.label1 = new MicroFour.StrataFrame.UI.Windows.Forms.Label();
            this.textbox1 = new MicroFour.StrataFrame.UI.Windows.Forms.Textbox();
            this.ToolStripContainer1.ContentPanel.SuspendLayout();
            this.ToolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(200, 100);
            // 
            // ToolStripContainer1
            // 
            // 
            // ToolStripContainer1.ContentPanel
            // 
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.SplitContainer1);
            this.ToolStripContainer1.ContentPanel.Size = new System.Drawing.Size(683, 343);
            this.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer1.Name = "ToolStripContainer1";
            this.ToolStripContainer1.Size = new System.Drawing.Size(683, 343);
            this.ToolStripContainer1.TabIndex = 1;
            this.ToolStripContainer1.Text = "ToolStripContainer1";
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.TreeView1);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.label1);
            this.SplitContainer1.Panel2.Controls.Add(this.textbox1);
            this.SplitContainer1.Panel2.Controls.Add(this.label3);
            this.SplitContainer1.Panel2.Controls.Add(this.label2);
            this.SplitContainer1.Panel2.Controls.Add(this.ListView1);
            this.SplitContainer1.Size = new System.Drawing.Size(683, 343);
            this.SplitContainer1.SplitterDistance = 183;
            this.SplitContainer1.TabIndex = 0;
            this.SplitContainer1.Text = "SplitContainer1";
            // 
            // TreeView1
            // 
            this.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView1.ImageIndex = 0;
            this.TreeView1.ImageList = this.imageList1;
            this.TreeView1.Location = new System.Drawing.Point(0, 0);
            this.TreeView1.Name = "TreeView1";
            treeNode1.Name = "PI";
            treeNode1.Text = "PRIMER INGRESO";
            treeNode2.Name = "UI";
            treeNode2.Text = "ULTIMO INGRESO";
            treeNode3.Name = "Nodo0";
            treeNode3.Text = "QUORUM";
            treeNode4.ImageKey = "Untitled (180).ico";
            treeNode4.Name = "AI";
            treeNode4.SelectedImageIndex = 2;
            treeNode4.Text = "ABRIR INGRESO";
            treeNode4.ToolTipText = "Habilita la carga de asistentes";
            treeNode5.ImageKey = "Untitled (374).ico";
            treeNode5.Name = "CI";
            treeNode5.SelectedImageIndex = 1;
            treeNode5.Text = "CERRAR INGRESO";
            treeNode5.ToolTipText = "Inhabilita la carga de asistentes";
            treeNode6.Name = "Nodo4";
            treeNode6.Text = "ACCIONES";
            this.TreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6});
            this.TreeView1.SelectedImageIndex = 0;
            this.TreeView1.ShowNodeToolTips = true;
            this.TreeView1.Size = new System.Drawing.Size(183, 343);
            this.TreeView1.TabIndex = 0;
            this.TreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Clock.ico");
            this.imageList1.Images.SetKeyName(1, "Untitled (374).ico");
            this.imageList1.Images.SetKeyName(2, "Untitled (180).ico");
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(19, 218);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = " ";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Location = new System.Drawing.Point(127, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = " ";
            // 
            // ListView1
            // 
            this.ListView1.CausesValidation = false;
            this.ListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView1.FullRowSelect = true;
            this.ListView1.HideSelection = false;
            this.ListView1.Location = new System.Drawing.Point(0, 0);
            this.ListView1.MultiSelect = false;
            this.ListView1.Name = "ListView1";
            this.ListView1.ParentContainer = this;
            this.ListView1.Size = new System.Drawing.Size(496, 343);
            this.ListView1.TabIndex = 0;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = System.Windows.Forms.View.Details;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // fbConnection1
            // 
            this.fbConnection1.ConnectionString = resources.GetString("fbConnection1.ConnectionString");
            // 
            // fbDataAdapter1
            // 
            this.fbDataAdapter1.DeleteCommand = this.fbCommand4;
            this.fbDataAdapter1.InsertCommand = this.fbCommand2;
            this.fbDataAdapter1.SelectCommand = this.fbCommand1;
            this.fbDataAdapter1.UpdateCommand = this.fbCommand3;
            // 
            // fbCommand4
            // 
            this.fbCommand4.CommandTimeout = 30;
            // 
            // fbCommand2
            // 
            this.fbCommand2.CommandTimeout = 30;
            // 
            // fbCommand1
            // 
            this.fbCommand1.CommandText = "SELECT COUNT(A.NRO_SOC) \r\nFROM ASAMBLEA A, CONTROL_ASISTENCIA B\r\nWHERE A.ELECCION" +
    "=B.ELECCION AND B.CERRADO=\'N\'";
            this.fbCommand1.CommandTimeout = 30;
            this.fbCommand1.Connection = this.fbConnection1;
            // 
            // fbCommand3
            // 
            this.fbCommand3.CommandTimeout = 30;
            // 
            // fbCommand5
            // 
            this.fbCommand5.CommandTimeout = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.IgnoreManageReadOnlyState = true;
            this.label1.Location = new System.Drawing.Point(151, 84);
            this.label1.Name = "label1";
            this.label1.ParentContainer = this;
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "QUORUM";
            // 
            // textbox1
            // 
            this.textbox1.BindingEditable = true;
            this.textbox1.BusinessObjectEvaluated = true;
            this.textbox1.DisabledForeColor = System.Drawing.Color.Black;
            this.textbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox1.Location = new System.Drawing.Point(130, 115);
            this.textbox1.Name = "textbox1";
            this.textbox1.ReadOnly = true;
            this.textbox1.Size = new System.Drawing.Size(133, 44);
            this.textbox1.TabIndex = 3;
            this.textbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Quorum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 343);
            this.Controls.Add(this.ToolStripContainer1);
            this.ErrorProviderBlinkStyle = System.Windows.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.ErrorProviderIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Quorum";
            this.Text = "ASISTENCIA";
            this.Load += new System.EventHandler(this.ExplorerForm1_Load);
            this.ToolStripContainer1.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer1.ResumeLayout(false);
            this.ToolStripContainer1.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        protected System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        protected System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        protected System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        protected System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        protected System.Windows.Forms.ToolStripContentPanel ContentPanel;
        protected System.Windows.Forms.ToolStripContainer ToolStripContainer1;
        protected System.Windows.Forms.SplitContainer SplitContainer1;
        protected System.Windows.Forms.TreeView TreeView1;
        protected MicroFour.StrataFrame.UI.Windows.Forms.ListView ListView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;

        private FirebirdSql.Data.FirebirdClient.FbConnection fbConnection1;
        private FirebirdSql.Data.FirebirdClient.FbDataAdapter fbDataAdapter1;
        private FirebirdSql.Data.FirebirdClient.FbCommand fbCommand4;
        private FirebirdSql.Data.FirebirdClient.FbCommand fbCommand2;
        private FirebirdSql.Data.FirebirdClient.FbCommand fbCommand1;
        private FirebirdSql.Data.FirebirdClient.FbCommand fbCommand3;
        private FirebirdSql.Data.FirebirdClient.FbCommand fbCommand5;


        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MicroFour.StrataFrame.UI.Windows.Forms.Label label1;
        private MicroFour.StrataFrame.UI.Windows.Forms.Textbox textbox1;

    }
}