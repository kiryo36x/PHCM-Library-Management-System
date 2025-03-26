namespace PHCM_last_na_to.FormInHome.Credits_Form
{
    partial class Credits
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
            this.imageHome = new System.Windows.Forms.PictureBox();
            this.nextButton = new System.Windows.Forms.PictureBox();
            this.previousButton = new System.Windows.Forms.PictureBox();
            this.Tips = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previousButton)).BeginInit();
            this.SuspendLayout();
            // 
            // imageHome
            // 
            this.imageHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageHome.Image = global::PHCM_last_na_to.Properties.Resources.System_Contributors;
            this.imageHome.Location = new System.Drawing.Point(0, 0);
            this.imageHome.Name = "imageHome";
            this.imageHome.Size = new System.Drawing.Size(1287, 744);
            this.imageHome.TabIndex = 0;
            this.imageHome.TabStop = false;
            // 
            // nextButton
            // 
            this.nextButton.Image = global::PHCM_last_na_to.Properties.Resources.nextButtonCredits;
            this.nextButton.Location = new System.Drawing.Point(1246, 340);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(38, 64);
            this.nextButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nextButton.TabIndex = 1;
            this.nextButton.TabStop = false;
            this.Tips.SetToolTip(this.nextButton, "Click me to go next page");
            this.nextButton.Click += new System.EventHandler(this.clicked);
            this.nextButton.MouseEnter += new System.EventHandler(this.entered);
            this.nextButton.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // previousButton
            // 
            this.previousButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.previousButton.Image = global::PHCM_last_na_to.Properties.Resources.previousButtonCredits;
            this.previousButton.Location = new System.Drawing.Point(12, 340);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(38, 64);
            this.previousButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previousButton.TabIndex = 2;
            this.previousButton.TabStop = false;
            this.Tips.SetToolTip(this.previousButton, "Click me to go previous page");
            this.previousButton.Visible = false;
            this.previousButton.Click += new System.EventHandler(this.clicked);
            this.previousButton.MouseEnter += new System.EventHandler(this.entered);
            this.previousButton.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // Credits
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1287, 744);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.imageHome);
            this.Font = new System.Drawing.Font("Nirmala UI", 7.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Credits";
            this.Text = "Credits";
            ((System.ComponentModel.ISupportInitialize)(this.imageHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previousButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imageHome;
        private System.Windows.Forms.PictureBox nextButton;
        private System.Windows.Forms.PictureBox previousButton;
        private System.Windows.Forms.ToolTip Tips;
    }
}