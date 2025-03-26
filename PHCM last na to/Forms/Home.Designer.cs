namespace PHCM_last_na_to.Forms
{
    partial class Home
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
            this.HomeImage = new System.Windows.Forms.PictureBox();
            this.visionandmission = new System.Windows.Forms.PictureBox();
            this.aboutus = new System.Windows.Forms.PictureBox();
            this.credits = new System.Windows.Forms.PictureBox();
            this.howtouse = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.HomeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visionandmission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.credits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.howtouse)).BeginInit();
            this.SuspendLayout();
            // 
            // HomeImage
            // 
            this.HomeImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HomeImage.Image = global::PHCM_last_na_to.Properties.Resources.PHCM_Home_UI_Design;
            this.HomeImage.Location = new System.Drawing.Point(0, 0);
            this.HomeImage.Name = "HomeImage";
            this.HomeImage.Size = new System.Drawing.Size(1287, 744);
            this.HomeImage.TabIndex = 0;
            this.HomeImage.TabStop = false;
            // 
            // visionandmission
            // 
            this.visionandmission.BackColor = System.Drawing.Color.Transparent;
            this.visionandmission.Image = global::PHCM_last_na_to.Properties.Resources.defaultButtonVisionanMission;
            this.visionandmission.Location = new System.Drawing.Point(787, 162);
            this.visionandmission.Name = "visionandmission";
            this.visionandmission.Size = new System.Drawing.Size(389, 104);
            this.visionandmission.TabIndex = 1;
            this.visionandmission.TabStop = false;
            this.visionandmission.Click += new System.EventHandler(this.Clicked);
            this.visionandmission.MouseEnter += new System.EventHandler(this.Entered);
            this.visionandmission.MouseLeave += new System.EventHandler(this.Leaved);
            // 
            // aboutus
            // 
            this.aboutus.BackColor = System.Drawing.Color.Transparent;
            this.aboutus.Image = global::PHCM_last_na_to.Properties.Resources.defaultButtonAboutus;
            this.aboutus.Location = new System.Drawing.Point(787, 282);
            this.aboutus.Name = "aboutus";
            this.aboutus.Size = new System.Drawing.Size(389, 104);
            this.aboutus.TabIndex = 2;
            this.aboutus.TabStop = false;
            this.aboutus.Click += new System.EventHandler(this.Clicked);
            this.aboutus.MouseEnter += new System.EventHandler(this.Entered);
            this.aboutus.MouseLeave += new System.EventHandler(this.Leaved);
            // 
            // credits
            // 
            this.credits.BackColor = System.Drawing.Color.Transparent;
            this.credits.Image = global::PHCM_last_na_to.Properties.Resources.defaultButtonCredits;
            this.credits.Location = new System.Drawing.Point(787, 392);
            this.credits.Name = "credits";
            this.credits.Size = new System.Drawing.Size(389, 104);
            this.credits.TabIndex = 4;
            this.credits.TabStop = false;
            this.credits.Click += new System.EventHandler(this.Clicked);
            this.credits.MouseEnter += new System.EventHandler(this.Entered);
            this.credits.MouseLeave += new System.EventHandler(this.Leaved);
            // 
            // howtouse
            // 
            this.howtouse.BackColor = System.Drawing.Color.Transparent;
            this.howtouse.Image = global::PHCM_last_na_to.Properties.Resources.DefaultButtonHowtoUse;
            this.howtouse.Location = new System.Drawing.Point(787, 503);
            this.howtouse.Name = "howtouse";
            this.howtouse.Size = new System.Drawing.Size(389, 104);
            this.howtouse.TabIndex = 4;
            this.howtouse.TabStop = false;
            this.howtouse.Click += new System.EventHandler(this.Clicked);
            this.howtouse.MouseEnter += new System.EventHandler(this.Entered);
            this.howtouse.MouseLeave += new System.EventHandler(this.Leaved);
            // 
            // Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1287, 744);
            this.Controls.Add(this.howtouse);
            this.Controls.Add(this.visionandmission);
            this.Controls.Add(this.credits);
            this.Controls.Add(this.aboutus);
            this.Controls.Add(this.HomeImage);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.HomeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visionandmission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.credits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.howtouse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox HomeImage;
        private System.Windows.Forms.PictureBox visionandmission;
        private System.Windows.Forms.PictureBox aboutus;
        private System.Windows.Forms.PictureBox credits;
        private System.Windows.Forms.PictureBox howtouse;
        private System.Windows.Forms.PictureBox HomePic;
    }
}