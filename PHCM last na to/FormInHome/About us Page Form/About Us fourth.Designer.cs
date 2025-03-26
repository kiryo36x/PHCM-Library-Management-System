namespace PHCM_last_na_to.HomeForm
{
    partial class About_Us
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
            this.HomePic = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SumalaProfile = new System.Windows.Forms.PictureBox();
            this.ReturnButton = new System.Windows.Forms.Label();
            this.previousbutton = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Tips = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.HomePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumalaProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previousbutton)).BeginInit();
            this.SuspendLayout();
            // 
            // HomePic
            // 
            this.HomePic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HomePic.Image = global::PHCM_last_na_to.Properties.Resources.about_us_page_4_Final_2;
            this.HomePic.Location = new System.Drawing.Point(0, 0);
            this.HomePic.Name = "HomePic";
            this.HomePic.Size = new System.Drawing.Size(1287, 744);
            this.HomePic.TabIndex = 0;
            this.HomePic.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(-3, 412);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(69, 100);
            this.panel1.TabIndex = 3;
            // 
            // SumalaProfile
            // 
            this.SumalaProfile.Image = global::PHCM_last_na_to.Properties.Resources.DefaultSumala;
            this.SumalaProfile.Location = new System.Drawing.Point(188, 361);
            this.SumalaProfile.Name = "SumalaProfile";
            this.SumalaProfile.Size = new System.Drawing.Size(532, 158);
            this.SumalaProfile.TabIndex = 16;
            this.SumalaProfile.TabStop = false;
            this.Tips.SetToolTip(this.SumalaProfile, "Click me to see my information!");
            this.SumalaProfile.Click += new System.EventHandler(this.clicked);
            this.SumalaProfile.MouseEnter += new System.EventHandler(this.entered);
            this.SumalaProfile.MouseLeave += new System.EventHandler(this.leaved);
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
            this.ReturnButton.TabIndex = 22;
            this.ReturnButton.Text = "Return";
            this.Tips.SetToolTip(this.ReturnButton, "Return back to Home?");
            this.ReturnButton.Click += new System.EventHandler(this.clicked);
            this.ReturnButton.MouseEnter += new System.EventHandler(this.entered);
            this.ReturnButton.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // previousbutton
            // 
            this.previousbutton.BackColor = System.Drawing.Color.Transparent;
            this.previousbutton.Image = global::PHCM_last_na_to.Properties.Resources.nextButtonAboutUsFinal__2_;
            this.previousbutton.Location = new System.Drawing.Point(601, 25);
            this.previousbutton.Name = "previousbutton";
            this.previousbutton.Size = new System.Drawing.Size(21, 38);
            this.previousbutton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previousbutton.TabIndex = 24;
            this.previousbutton.TabStop = false;
            this.Tips.SetToolTip(this.previousbutton, "Click me to go previous page");
            this.previousbutton.Click += new System.EventHandler(this.clicked);
            this.previousbutton.MouseEnter += new System.EventHandler(this.entered);
            this.previousbutton.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel2.Location = new System.Drawing.Point(661, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 38);
            this.panel2.TabIndex = 25;
            // 
            // About_Us
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(247)))));
            this.BackgroundImage = global::PHCM_last_na_to.Properties.Resources.Loading;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1287, 744);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.previousbutton);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.SumalaProfile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HomePic);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Nirmala UI", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "About_Us";
            this.Text = "About_Us";
            ((System.ComponentModel.ISupportInitialize)(this.HomePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumalaProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previousbutton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox HomePic;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox SumalaProfile;
        private System.Windows.Forms.Label ReturnButton;
        private System.Windows.Forms.PictureBox previousbutton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip Tips;
    }
}