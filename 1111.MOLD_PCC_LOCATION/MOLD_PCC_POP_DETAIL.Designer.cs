namespace FORM
{
    partial class MOLD_PCC_POP_DETAIL
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MOLD_PCC_POP_DETAIL));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.grdMain = new DevExpress.XtraGrid.GridControl();
            this.gvwMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbo_Model = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.cmnuExcel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmr_Reload = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwMain)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_Model.Properties)).BeginInit();
            this.cmnuExcel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grdMain, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 502F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1884, 622);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lblHeader);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTop.Location = new System.Drawing.Point(3, 3);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1878, 72);
            this.pnTop.TabIndex = 2;
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
            this.lblHeader.Size = new System.Drawing.Size(1878, 72);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "Location Detail ";
            // 
            // grdMain
            // 
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.Font = new System.Drawing.Font("Calibri", 12.75F);
            gridLevelNode1.RelationName = "Level1";
            this.grdMain.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdMain.Location = new System.Drawing.Point(3, 123);
            this.grdMain.MainView = this.gvwMain;
            this.grdMain.Name = "grdMain";
            this.grdMain.Size = new System.Drawing.Size(1878, 496);
            this.grdMain.TabIndex = 3;
            this.grdMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwMain});
            this.grdMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdMain_MouseDown);
            // 
            // gvwMain
            // 
            this.gvwMain.Appearance.Row.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.gvwMain.Appearance.Row.Options.UseFont = true;
            this.gvwMain.ColumnPanelRowHeight = 50;
            this.gvwMain.GridControl = this.grdMain;
            this.gvwMain.Name = "gvwMain";
            this.gvwMain.OptionsBehavior.Editable = false;
            this.gvwMain.OptionsBehavior.ReadOnly = true;
            this.gvwMain.OptionsCustomization.AllowColumnMoving = false;
            this.gvwMain.OptionsCustomization.AllowFilter = false;
            this.gvwMain.OptionsCustomization.AllowGroup = false;
            this.gvwMain.OptionsView.AllowCellMerge = true;
            this.gvwMain.OptionsView.ColumnAutoWidth = false;
            this.gvwMain.OptionsView.ShowGroupPanel = false;
            this.gvwMain.OptionsView.ShowIndicator = false;
            this.gvwMain.RowHeight = 50;
            this.gvwMain.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvwMain_RowCellStyle);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbo_Model);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1878, 36);
            this.panel1.TabIndex = 4;
            // 
            // cbo_Model
            // 
            this.cbo_Model.Location = new System.Drawing.Point(171, -1);
            this.cbo_Model.Name = "cbo_Model";
            this.cbo_Model.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.cbo_Model.Properties.Appearance.Options.UseFont = true;
            this.cbo_Model.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Model.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbo_Model.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Model.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbo_Model.Properties.AppearanceFocused.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Model.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbo_Model.Properties.AutoHeight = false;
            this.cbo_Model.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 20, true, true, false, editorButtonImageOptions1)});
            this.cbo_Model.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.cbo_Model.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CODE", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "NAME")});
            this.cbo_Model.Properties.NullText = "";
            this.cbo_Model.Properties.ShowHeader = false;
            this.cbo_Model.Size = new System.Drawing.Size(300, 36);
            this.cbo_Model.TabIndex = 14;
            this.cbo_Model.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.cbo_Model_Closed);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Calibri", 15.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Model Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmnuExcel
            // 
            this.cmnuExcel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToExcelToolStripMenuItem});
            this.cmnuExcel.Name = "cmnuExcel";
            this.cmnuExcel.Size = new System.Drawing.Size(172, 26);
            this.cmnuExcel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmnuExcel_MouseClick);
            // 
            // downloadToExcelToolStripMenuItem
            // 
            this.downloadToExcelToolStripMenuItem.Name = "downloadToExcelToolStripMenuItem";
            this.downloadToExcelToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.downloadToExcelToolStripMenuItem.Text = "Download to Excel";
            // 
            // tmr_Reload
            // 
            this.tmr_Reload.Interval = 60000;
            this.tmr_Reload.Tick += new System.EventHandler(this.tmr_Reload_Tick);
            // 
            // MOLD_PCC_POP_DETAIL
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1884, 622);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MOLD_PCC_POP_DETAIL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.VisibleChanged += new System.EventHandler(this.SMT_SCADA_COCKPIT_FORM2_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwMain)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbo_Model.Properties)).EndInit();
            this.cmnuExcel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnTop;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraGrid.GridControl grdMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmnuExcel;
        private System.Windows.Forms.ToolStripMenuItem downloadToExcelToolStripMenuItem;
        private System.Windows.Forms.Timer tmr_Reload;
        private DevExpress.XtraEditors.LookUpEdit cbo_Model;
    }
}