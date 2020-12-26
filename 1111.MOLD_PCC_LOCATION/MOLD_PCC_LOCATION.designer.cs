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
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.pnTitle = new System.Windows.Forms.Panel();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnLocation = new System.Windows.Forms.Panel();
            this.pnTitle.SuspendLayout();
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
            this.pnTitle.Controls.Add(this.cmdBack);
            this.pnTitle.Controls.Add(this.lblDate);
            this.pnTitle.Controls.Add(this.label1);
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
            this.cmdBack.Location = new System.Drawing.Point(1388, 5);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(108, 101);
            this.cmdBack.TabIndex = 67;
            this.cmdBack.UseVisualStyleBackColor = false;
            this.cmdBack.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(1614, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(306, 110);
            this.lblDate.TabIndex = 1;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Calibri", 62F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1207, 110);
            this.label1.TabIndex = 0;
            this.label1.Text = "Long Term Mold Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnLocation
            // 
            this.pnLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnLocation.Location = new System.Drawing.Point(0, 110);
            this.pnLocation.Name = "pnLocation";
            this.pnLocation.Size = new System.Drawing.Size(1920, 970);
            this.pnLocation.TabIndex = 22;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Panel pnLocation;
    }
}