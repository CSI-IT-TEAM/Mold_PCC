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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MOLD_PCC_LOCATION));
            this.tmrTime = new System.Windows.Forms.Timer();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pnLocation = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmd_Inventory = new System.Windows.Forms.Button();
            this.pnTitle.SuspendLayout();
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
            this.lbl_Title.Click += new System.EventHandler(this.lbl_Title_Click);
            // 
            // pnLocation
            // 
            this.pnLocation.BackColor = System.Drawing.Color.White;
            this.pnLocation.Controls.Add(this.pictureBox1);
            this.pnLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnLocation.Location = new System.Drawing.Point(0, 110);
            this.pnLocation.Name = "pnLocation";
            this.pnLocation.Size = new System.Drawing.Size(1920, 970);
            this.pnLocation.TabIndex = 22;
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
            // 
            // cmd_Inventory
            // 
            this.cmd_Inventory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmd_Inventory.BackgroundImage")));
            this.cmd_Inventory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmd_Inventory.FlatAppearance.BorderSize = 0;
            this.cmd_Inventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_Inventory.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.cmd_Inventory.ForeColor = System.Drawing.Color.Yellow;
            this.cmd_Inventory.Location = new System.Drawing.Point(1136, 0);
            this.cmd_Inventory.Name = "cmd_Inventory";
            this.cmd_Inventory.Size = new System.Drawing.Size(132, 108);
            this.cmd_Inventory.TabIndex = 689;
            this.cmd_Inventory.Text = "Inventory";
            this.cmd_Inventory.UseVisualStyleBackColor = true;
            this.cmd_Inventory.Click += new System.EventHandler(this.cmd_Inventory_Click);
            // 
            // MOLD_PCC_LOCATION
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pnLocation);
            this.Controls.Add(this.pnTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MOLD_PCC_LOCATION";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SMT_QUALITY_COCKPIT_MAIN_Load);
            this.VisibleChanged += new System.EventHandler(this.SMT_SCADA_COCKPIT_MENU_VisibleChanged);
            this.pnTitle.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnLocation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cmd_Inventory;
    }
}