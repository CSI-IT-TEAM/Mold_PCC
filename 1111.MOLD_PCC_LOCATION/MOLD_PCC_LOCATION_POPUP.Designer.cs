namespace FORM
{
    partial class MOLD_PCC_LOCATION_POPUP
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MOLD_PCC_LOCATION_POPUP));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.RN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MOLD_CD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MODEL_NM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.USE_SIZE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SEQ_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnTop = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnTop, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(887, 619);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("Calibri", 12.75F);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(3, 81);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(881, 535);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.ColumnPanelRowHeight = 50;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.RN,
            this.MOLD_CD,
            this.MODEL_NM,
            this.USE_SIZE,
            this.SEQ_NO});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 50;
            // 
            // RN
            // 
            this.RN.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.RN.AppearanceHeader.Options.UseFont = true;
            this.RN.AppearanceHeader.Options.UseTextOptions = true;
            this.RN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RN.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.RN.Caption = "No";
            this.RN.FieldName = "RN";
            this.RN.FieldNameSortGroup = "RN";
            this.RN.Name = "RN";
            this.RN.Visible = true;
            this.RN.VisibleIndex = 0;
            this.RN.Width = 60;
            // 
            // MOLD_CD
            // 
            this.MOLD_CD.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.MOLD_CD.AppearanceHeader.Options.UseFont = true;
            this.MOLD_CD.AppearanceHeader.Options.UseTextOptions = true;
            this.MOLD_CD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MOLD_CD.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.MOLD_CD.Caption = "Mold Code";
            this.MOLD_CD.FieldName = "MOLD_CD";
            this.MOLD_CD.Name = "MOLD_CD";
            this.MOLD_CD.Visible = true;
            this.MOLD_CD.VisibleIndex = 1;
            this.MOLD_CD.Width = 124;
            // 
            // MODEL_NM
            // 
            this.MODEL_NM.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.MODEL_NM.AppearanceHeader.Options.UseFont = true;
            this.MODEL_NM.AppearanceHeader.Options.UseTextOptions = true;
            this.MODEL_NM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MODEL_NM.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.MODEL_NM.Caption = "Model Name";
            this.MODEL_NM.FieldName = "MODEL_NM";
            this.MODEL_NM.Name = "MODEL_NM";
            this.MODEL_NM.Visible = true;
            this.MODEL_NM.VisibleIndex = 2;
            this.MODEL_NM.Width = 525;
            // 
            // USE_SIZE
            // 
            this.USE_SIZE.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.USE_SIZE.AppearanceHeader.Options.UseFont = true;
            this.USE_SIZE.AppearanceHeader.Options.UseTextOptions = true;
            this.USE_SIZE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.USE_SIZE.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.USE_SIZE.Caption = "Size";
            this.USE_SIZE.FieldName = "USE_SIZE";
            this.USE_SIZE.Name = "USE_SIZE";
            this.USE_SIZE.Visible = true;
            this.USE_SIZE.VisibleIndex = 3;
            this.USE_SIZE.Width = 82;
            // 
            // SEQ_NO
            // 
            this.SEQ_NO.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.SEQ_NO.AppearanceHeader.Options.UseFont = true;
            this.SEQ_NO.AppearanceHeader.Options.UseTextOptions = true;
            this.SEQ_NO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SEQ_NO.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SEQ_NO.Caption = "Seq";
            this.SEQ_NO.FieldName = "SEQ_NO";
            this.SEQ_NO.Name = "SEQ_NO";
            this.SEQ_NO.Visible = true;
            this.SEQ_NO.VisibleIndex = 4;
            this.SEQ_NO.Width = 88;
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.button1);
            this.pnTop.Controls.Add(this.lblHeader);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTop.Location = new System.Drawing.Point(3, 3);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(881, 72);
            this.pnTop.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(699, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "Export Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.Appearance.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Appearance.Options.UseFont = true;
            this.lblHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.LineVisible = true;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(881, 72);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "Location Detail ";
            // 
            // MOLD_PCC_LOCATION_POPUP
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(887, 619);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MOLD_PCC_LOCATION_POPUP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.VisibleChanged += new System.EventHandler(this.SMT_SCADA_COCKPIT_FORM2_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnTop;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn MOLD_CD;
        private DevExpress.XtraGrid.Columns.GridColumn MODEL_NM;
        private DevExpress.XtraGrid.Columns.GridColumn USE_SIZE;
        private DevExpress.XtraGrid.Columns.GridColumn SEQ_NO;
        private DevExpress.XtraGrid.Columns.GridColumn RN;
        private System.Windows.Forms.Button button1;
    }
}