namespace PHCM_last_na_to.FormInHome.About_us_Page_Form
{
    partial class About_Us_First
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
            this.ReturnButton = new System.Windows.Forms.Label();
            this.Tips = new System.Windows.Forms.ToolTip(this.components);
            this.MagbooProfile = new System.Windows.Forms.PictureBox();
            this.nextbutton = new System.Windows.Forms.PictureBox();
            this.HomePic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MagbooProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomePic)).BeginInit();
            this.SuspendLayout();
            // 
            // ReturnButton
            // 
            this.ReturnButton.AutoSize = true;
            this.ReturnButton.BackColor = System.Drawing.Color.White;
            this.ReturnButton.Font = new System.Drawing.Font("Nirmala UI", 13F);
            this.ReturnButton.ForeColor = System.Drawing.Color.Black;
            this.ReturnButton.Location = new System.Drawing.Point(1208, 701);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(76, 30);
            this.ReturnButton.TabIndex = 7;
            this.ReturnButton.Text = "Return";
            this.Tips.SetToolTip(this.ReturnButton, "Return back to Home?");
            this.ReturnButton.Click += new System.EventHandler(this.clicked);
            this.ReturnButton.MouseEnter += new System.EventHandler(this.Entered);
            this.ReturnButton.MouseLeave += new System.EventHandler(this.Leaved);
            // 
            // MagbooProfile
            // 
            this.MagbooProfile.Image = global::PHCM_last_na_to.Properties.Resources.DefaultMagboo_2;
            this.MagbooProfile.Location = new System.Drawing.Point(188, 379);
            this.MagbooProfile.Name = "MagbooProfile";
            this.MagbooProfile.Size = new System.Drawing.Size(532, 158);
            this.MagbooProfile.TabIndex = 9;
            this.MagbooProfile.TabStop = false;
            this.MagbooProfile.Click += new System.EventHandler(this.clicked);
            this.MagbooProfile.MouseEnter += new System.EventHandler(this.Entered);
            this.MagbooProfile.MouseLeave += new System.EventHandler(this.Leaved);
            // 
            // nextbutton
            // 
            this.nextbutton.BackColor = System.Drawing.Color.Transparent;
            this.nextbutton.Image = global::PHCM_last_na_to.Properties.Resources.nextButtonAboutUsFinal;
            this.nextbutton.Location = new System.Drawing.Point(662, 25);
            this.nextbutton.Name = "nextbutton";
            this.nextbutton.Size = new System.Drawing.Size(21, 38);
            this.nextbutton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nextbutton.TabIndex = 8;
            this.nextbutton.TabStop = false;
            this.Tips.SetToolTip(this.nextbutton, "Click me to go next page");
            this.nextbutton.Click += new System.EventHandler(this.clicked);
            this.nextbutton.MouseEnter += new System.EventHandler(this.Entered);
            this.nextbutton.MouseLeave += new System.EventHandler(this.Leaved);
            // 
            // HomePic
            // 
            this.HomePic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HomePic.Image = global::PHCM_last_na_to.Properties.Resources.about_us_page_1_Final_2;
            this.HomePic.Location = new System.Drawing.Point(0, 0);
            this.HomePic.Name = "HomePic";
            this.HomePic.Size = new System.Drawing.Size(1287, 744);
            this.HomePic.TabIndex = 10;
            this.HomePic.TabStop = false;
            // 
            // About_Us_First
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1287, 744);
            this.Controls.Add(this.MagbooProfile);
            this.Controls.Add(this.nextbutton);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.HomePic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "About_Us_First";
            this.Text = "About_Us_First";
            ((System.ComponentModel.ISupportInitialize)(this.MagbooProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ReturnButton;
        private System.Windows.Forms.PictureBox nextbutton;
        private System.Windows.Forms.PictureBox MagbooProfile;
        private System.Windows.Forms.PictureBox HomePic;
        private System.Windows.Forms.ToolTip Tips;
    }
}