namespace FORM
{
    partial class MOLD_PCC_LOCATION
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MOLD_PCC_LOCATION));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.pnTitle = new System.Windows.Forms.Panel();
            this.cmd_Inventory = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pn_Control = new System.Windows.Forms.Panel();
            this.cbo_Size = new DevExpress.XtraEditors.LookUpEdit();
            this.cbo_MoldCd = new DevExpress.XtraEditors.LookUpEdit();
            this.cbo_Model = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmd_Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnLocation = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.pnTitle.SuspendLayout();
            this.pn_Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_Size.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_MoldCd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_Model.Properties)).BeginInit();
            this.pnLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrTime
            // 
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // pnTitle
            // 
            this.pnTitle.BackColor = System.Drawing.Color.DarkTurquoise;
            this.pnTitle.Controls.Add(this.lbl_Total);
            this.pnTitle.Controls.Add(this.label5);
            this.pnTitle.Controls.Add(this.label4);
            this.pnTitle.Controls.Add(this.cmd_Inventory);
            this.pnTitle.Controls.Add(this.cmdBack);
            this.pnTitle.Controls.Add(this.lblDate);
            this.pnTitle.Controls.Add(this.lbl_Title);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(1920, 110);
            this.pnTitle.TabIndex = 21;
            // 
            // cmd_Inventory
            // 
            this.cmd_Inventory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmd_Inventory.BackgroundImage")));
            this.cmd_Inventory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmd_Inventory.FlatAppearance.BorderSize = 0;
            this.cmd_Inventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_Inventory.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.cmd_Inventory.ForeColor = System.Drawing.Color.Yellow;
            this.cmd_Inventory.Location = new System.Drawing.Point(1045, 0);
            this.cmd_Inventory.Name = "cmd_Inventory";
            this.cmd_Inventory.Size = new System.Drawing.Size(132, 108);
            this.cmd_Inventory.TabIndex = 689;
            this.cmd_Inventory.Text = "Inventory";
            this.cmd_Inventory.UseVisualStyleBackColor = true;
            this.cmd_Inventory.Click += new System.EventHandler(this.cmd_Inventory_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.BackColor = System.Drawing.Color.Transparent;
            this.cmdBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdBack.BackgroundImage")));
            this.cmdBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdBack.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.cmdBack.FlatAppearance.BorderSize = 0;
            this.cmdBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBack.Location = new System.Drawing.Point(1517, 5);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(108, 100);
            this.cmdBack.TabIndex = 67;
            this.cmdBack.UseVisualStyleBackColor = false;
            this.cmdBack.Visible = false;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(1629, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(291, 110);
            this.lblDate.TabIndex = 1;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.DoubleClick += new System.EventHandler(this.lblDate_DoubleClick);
            // 
            // lbl_Title
            // 
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Title.Font = new System.Drawing.Font("Calibri", 62F, System.Drawing.FontStyle.Bold);
            this.lbl_Title.ForeColor = System.Drawing.Color.White;
            this.lbl_Title.Location = new System.Drawing.Point(0, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(1221, 110);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "PCC Mold Warehouse";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Title.DoubleClick += new System.EventHandler(this.lbl_Title_DoubleClick);
            // 
            // pn_Control
            // 
            this.pn_Control.Controls.Add(this.cbo_Size);
            this.pn_Control.Controls.Add(this.cbo_MoldCd);
            this.pn_Control.Controls.Add(this.cbo_Model);
            this.pn_Control.Controls.Add(this.label3);
            this.pn_Control.Controls.Add(this.label2);
            this.pn_Control.Controls.Add(this.cmd_Search);
            this.pn_Control.Controls.Add(this.label1);
            this.pn_Control.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_Control.Location = new System.Drawing.Point(0, 110);
            this.pn_Control.Name = "pn_Control";
            this.pn_Control.Size = new System.Drawing.Size(1920, 49);
            this.pn_Control.TabIndex = 23;
            // 
            // cbo_Size
            // 
            this.cbo_Size.Location = new System.Drawing.Point(982, 6);
            this.cbo_Size.Name = "cbo_Size";
            this.cbo_Size.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.cbo_Size.Properties.Appearance.Options.UseFont = true;
            this.cbo_Size.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Size.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbo_Size.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Size.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbo_Size.Properties.AppearanceFocused.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Size.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbo_Size.Properties.AutoHeight = false;
            this.cbo_Size.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 20, true, true, false, editorButtonImageOptions1)});
            this.cbo_Size.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.cbo_Size.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CODE", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "NAME")});
            this.cbo_Size.Properties.NullText = "";
            this.cbo_Size.Properties.ShowHeader = false;
            this.cbo_Size.Size = new System.Drawing.Size(204, 36);
            this.cbo_Size.TabIndex = 17;
            // 
            // cbo_MoldCd
            // 
            this.cbo_MoldCd.Location = new System.Drawing.Point(639, 6);
            this.cbo_MoldCd.Name = "cbo_MoldCd";
            this.cbo_MoldCd.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.cbo_MoldCd.Properties.Appearance.Options.UseFont = true;
            this.cbo_MoldCd.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_MoldCd.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbo_MoldCd.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_MoldCd.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbo_MoldCd.Properties.AppearanceFocused.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_MoldCd.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbo_MoldCd.Properties.AutoHeight = false;
            this.cbo_MoldCd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 20, true, true, false, editorButtonImageOptions2)});
            this.cbo_MoldCd.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.cbo_MoldCd.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CODE", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "NAME")});
            this.cbo_MoldCd.Properties.NullText = "";
            this.cbo_MoldCd.Properties.ShowHeader = false;
            this.cbo_MoldCd.Size = new System.Drawing.Size(204, 36);
            this.cbo_MoldCd.TabIndex = 16;
            this.cbo_MoldCd.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.cbo_MoldCd_Closed);
            // 
            // cbo_Model
            // 
            this.cbo_Model.Location = new System.Drawing.Point(134, 6);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 20, true, true, false, editorButtonImageOptions3)});
            this.cbo_Model.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.cbo_Model.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CODE", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "NAME")});
            this.cbo_Model.Properties.NullText = "";
            this.cbo_Model.Properties.ShowHeader = false;
            this.cbo_Model.Size = new System.Drawing.Size(368, 36);
            this.cbo_Model.TabIndex = 15;
            this.cbo_Model.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.cbo_Model_Closed);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Calibri", 15.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(849, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 35);
            this.label3.TabIndex = 11;
            this.label3.Text = "Size";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Calibri", 15.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(508, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 35);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mold Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmd_Search
            // 
            this.cmd_Search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmd_Search.BackgroundImage")));
            this.cmd_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmd_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_Search.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_Search.ForeColor = System.Drawing.Color.Transparent;
            this.cmd_Search.Location = new System.Drawing.Point(1192, 2);
            this.cmd_Search.Name = "cmd_Search";
            this.cmd_Search.Size = new System.Drawing.Size(141, 44);
            this.cmd_Search.TabIndex = 7;
            this.cmd_Search.UseVisualStyleBackColor = true;
            this.cmd_Search.Click += new System.EventHandler(this.cmd_Search_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Calibri", 15.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "Model Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnLocation
            // 
            this.pnLocation.BackColor = System.Drawing.Color.White;
            this.pnLocation.Controls.Add(this.pictureBox1);
            this.pnLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnLocation.Location = new System.Drawing.Point(0, 159);
            this.pnLocation.Name = "pnLocation";
            this.pnLocation.Size = new System.Drawing.Size(1920, 921);
            this.pnLocation.TabIndex = 24;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(1331, 875);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 87);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightGreen;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(1388, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 35);
            this.label4.TabIndex = 690;
            this.label4.Text = "Empty Mold";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.Font = new System.Drawing.Font("Calibri", 15.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(1388, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 35);
            this.label5.TabIndex = 691;
            this.label5.Text = "Have Mold";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Total
            // 
            this.lbl_Total.BackColor = System.Drawing.Color.Green;
            this.lbl_Total.Font = new System.Drawing.Font("Calibri", 17.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Total.ForeColor = System.Drawing.Color.White;
            this.lbl_Total.Location = new System.Drawing.Point(1203, 12);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(130, 72);
            this.lbl_Total.TabIndex = 692;
            this.lbl_Total.Text = "Total Mold ";
            this.lbl_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MOLD_PCC_LOCATION
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pnLocation);
            this.Controls.Add(this.pn_Control);
            this.Controls.Add(this.pnTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MOLD_PCC_LOCATION";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SMT_QUALITY_COCKPIT_MAIN_Load);
            this.VisibleChanged += new System.EventHandler(this.SMT_SCADA_COCKPIT_MENU_VisibleChanged);
            this.pnTitle.ResumeLayout(false);
            this.pn_Control.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbo_Size.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_MoldCd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_Model.Properties)).EndInit();
            this.pnLocation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lbl_Title;
        public System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Button cmd_Inventory;
        private System.Windows.Forms.Panel pn_Control;
        private System.Windows.Forms.Panel pnLocation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmd_Search;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit cbo_Size;
        private DevExpress.XtraEditors.LookUpEdit cbo_MoldCd;
        private DevExpress.XtraEditors.LookUpEdit cbo_Model;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Total;
    }
}