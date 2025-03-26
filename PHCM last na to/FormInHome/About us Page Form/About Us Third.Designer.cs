namespace PHCM_last_na_to.FormInHome.About_us_Page_Form
{
    partial class About_Us_Third
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
            this.label1 = new System.Windows.Forms.Label();
            this.ReturnButton = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MacasangProfile = new System.Windows.Forms.PictureBox();
            this.GuiterrezProfile = new System.Windows.Forms.PictureBox();
            this.ElposProfile = new System.Windows.Forms.PictureBox();
            this.DwayneProfile = new System.Windows.Forms.PictureBox();
            this.previousbutton = new System.Windows.Forms.PictureBox();
            this.nextbutton = new System.Windows.Forms.PictureBox();
            this.HomePic = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Tips = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MacasangProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiterrezProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElposProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DwayneProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previousbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(247)))));
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 13F);
            this.label1.Location = new System.Drawing.Point(1208, 701);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Return";
            // 
            // ReturnButton
            // 
            this.ReturnButton.AutoSize = true;
            this.ReturnButton.BackColor = System.Drawing.Color.White;
            this.ReturnButton.Font = new System.Drawing.Font("Nirmala UI", 13F);
            this.ReturnButton.ForeColor = System.Drawing.Color.Black;
            this.ReturnButton.Location = new System.Drawing.Point(1211, 705);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(76, 30);
            this.ReturnButton.TabIndex = 19;
            this.ReturnButton.Text = "Return";
            this.Tips.SetToolTip(this.ReturnButton, "Return back to Home?");
            this.ReturnButton.Click += new System.EventHandler(this.clicked);
            this.ReturnButton.MouseEnter += new System.EventHandler(this.entered);
            this.ReturnButton.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(916, 676);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 100);
            this.panel1.TabIndex = 20;
            // 
            // MacasangProfile
            // 
            this.MacasangProfile.Image = global::PHCM_last_na_to.Properties.Resources.DefaultMacasang;
            this.MacasangProfile.Location = new System.Drawing.Point(727, 525);
            this.MacasangProfile.Name = "MacasangProfile";
            this.MacasangProfile.Size = new System.Drawing.Size(533, 158);
            this.MacasangProfile.TabIndex = 18;
            this.MacasangProfile.TabStop = false;
            this.Tips.SetToolTip(this.MacasangProfile, "Click me to see my information!");
            this.MacasangProfile.Click += new System.EventHandler(this.clicked);
            this.MacasangProfile.MouseEnter += new System.EventHandler(this.entered);
            this.MacasangProfile.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // GuiterrezProfile
            // 
            this.GuiterrezProfile.Image = global::PHCM_last_na_to.Properties.Resources.DefaultGuiterrez;
            this.GuiterrezProfile.Location = new System.Drawing.Point(727, 361);
            this.GuiterrezProfile.Name = "GuiterrezProfile";
            this.GuiterrezProfile.Size = new System.Drawing.Size(533, 158);
            this.GuiterrezProfile.TabIndex = 17;
            this.GuiterrezProfile.TabStop = false;
            this.Tips.SetToolTip(this.GuiterrezProfile, "Click me to see my information!");
            this.GuiterrezProfile.Click += new System.EventHandler(this.clicked);
            this.GuiterrezProfile.MouseEnter += new System.EventHandler(this.entered);
            this.GuiterrezProfile.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // ElposProfile
            // 
            this.ElposProfile.Image = global::PHCM_last_na_to.Properties.Resources.DefaultElpos;
            this.ElposProfile.Location = new System.Drawing.Point(188, 525);
            this.ElposProfile.Name = "ElposProfile";
            this.ElposProfile.Size = new System.Drawing.Size(532, 158);
            this.ElposProfile.TabIndex = 16;
            this.ElposProfile.TabStop = false;
            this.Tips.SetToolTip(this.ElposProfile, "Click me to see my information!");
            this.ElposProfile.Click += new System.EventHandler(this.clicked);
            this.ElposProfile.MouseEnter += new System.EventHandler(this.entered);
            this.ElposProfile.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // DwayneProfile
            // 
            this.DwayneProfile.Image = global::PHCM_last_na_to.Properties.Resources.DefaultDwayne_1;
            this.DwayneProfile.Location = new System.Drawing.Point(188, 361);
            this.DwayneProfile.Name = "DwayneProfile";
            this.DwayneProfile.Size = new System.Drawing.Size(532, 158);
            this.DwayneProfile.TabIndex = 15;
            this.DwayneProfile.TabStop = false;
            this.Tips.SetToolTip(this.DwayneProfile, "Click me to see my information!");
            this.DwayneProfile.Click += new System.EventHandler(this.clicked);
            this.DwayneProfile.MouseEnter += new System.EventHandler(this.entered);
            this.DwayneProfile.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // previousbutton
            // 
            this.previousbutton.BackColor = System.Drawing.Color.Transparent;
            this.previousbutton.Image = global::PHCM_last_na_to.Properties.Resources.nextButtonAboutUsFinal__2_;
            this.previousbutton.Location = new System.Drawing.Point(601, 25);
            this.previousbutton.Name = "previousbutton";
            this.previousbutton.Size = new System.Drawing.Size(21, 38);
            this.previousbutton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previousbutton.TabIndex = 13;
            this.previousbutton.TabStop = false;
            this.Tips.SetToolTip(this.previousbutton, "Click me to go previous page");
            this.previousbutton.Click += new System.EventHandler(this.clicked);
            this.previousbutton.MouseEnter += new System.EventHandler(this.entered);
            this.previousbutton.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // nextbutton
            // 
            this.nextbutton.BackColor = System.Drawing.Color.Transparent;
            this.nextbutton.Image = global::PHCM_last_na_to.Properties.Resources.nextButtonAboutUsFinal;
            this.nextbutton.Location = new System.Drawing.Point(662, 25);
            this.nextbutton.Name = "nextbutton";
            this.nextbutton.Size = new System.Drawing.Size(21, 38);
            this.nextbutton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nextbutton.TabIndex = 12;
            this.nextbutton.TabStop = false;
            this.Tips.SetToolTip(this.nextbutton, "Click me to go next page");
            this.nextbutton.Click += new System.EventHandler(this.clicked);
            this.nextbutton.MouseEnter += new System.EventHandler(this.entered);
            this.nextbutton.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // HomePic
            // 
            this.HomePic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HomePic.Image = global::PHCM_last_na_to.Properties.Resources.about_us_page_3_Final_2;
            this.HomePic.Location = new System.Drawing.Point(0, 0);
            this.HomePic.Name = "HomePic";
            this.HomePic.Size = new System.Drawing.Size(1287, 744);
            this.HomePic.TabIndex = 11;
            this.HomePic.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::PHCM_last_na_to.Properties.Resources.about_us_page_3_Final_2;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1287, 744);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // About_Us_Third
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1287, 744);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.MacasangProfile);
            this.Controls.Add(this.GuiterrezProfile);
            this.Controls.Add(this.ElposProfile);
            this.Controls.Add(this.DwayneProfile);
            this.Controls.Add(this.previousbutton);
            this.Controls.Add(this.nextbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HomePic);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "About_Us_Third";
            this.Text = "About_Us_Third";
            ((System.ComponentModel.ISupportInitialize)(this.MacasangProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiterrezProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElposProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DwayneProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previousbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox previousbutton;
        private System.Windows.Forms.PictureBox nextbutton;
        private System.Windows.Forms.PictureBox HomePic;
        private System.Windows.Forms.PictureBox MacasangProfile;
        private System.Windows.Forms.PictureBox GuiterrezProfile;
        private System.Windows.Forms.PictureBox ElposProfile;
        private System.Windows.Forms.PictureBox DwayneProfile;
        private System.Windows.Forms.Label ReturnButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip Tips;
    }
}