namespace PHCM_last_na_to.FormInHome.How_to_use_Page_Form
{
    partial class How_to_use_Books
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
            this.catanaPanel1 = new PHCM_last_na_to.CatanaPanel();
            this.Exit = new System.Windows.Forms.Label();
            this.ReturnButton = new System.Windows.Forms.Label();
            this.count = new System.Windows.Forms.Label();
            this.previousbutton = new System.Windows.Forms.PictureBox();
            this.nextbutton = new System.Windows.Forms.PictureBox();
            this.books = new System.Windows.Forms.PictureBox();
            this.Tips = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.previousbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.books)).BeginInit();
            this.SuspendLayout();
            // 
            // catanaPanel1
            // 
            this.catanaPanel1.BackColor = System.Drawing.Color.White;
            this.catanaPanel1.BorderRadius = 30;
            this.catanaPanel1.ForeColor = System.Drawing.Color.Black;
            this.catanaPanel1.GradientAngle = 90F;
            this.catanaPanel1.GradientBottomColor = System.Drawing.Color.CadetBlue;
            this.catanaPanel1.GradientTopColor = System.Drawing.Color.DodgerBlue;
            this.catanaPanel1.Location = new System.Drawing.Point(562, 107);
            this.catanaPanel1.Name = "catanaPanel1";
            this.catanaPanel1.Size = new System.Drawing.Size(8, 8);
            this.catanaPanel1.TabIndex = 0;
            // 
            // Exit
            // 
            this.Exit.AutoSize = true;
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.Exit.Font = new System.Drawing.Font("Nirmala UI", 13F);
            this.Exit.ForeColor = System.Drawing.Color.White;
            this.Exit.Location = new System.Drawing.Point(12, 694);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(73, 30);
            this.Exit.TabIndex = 27;
            this.Exit.Text = "Home";
            this.Tips.SetToolTip(this.Exit, "Return back to Home?");
            this.Exit.Click += new System.EventHandler(this.clicked);
            this.Exit.MouseEnter += new System.EventHandler(this.entered);
            this.Exit.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // ReturnButton
            // 
            this.ReturnButton.AutoSize = true;
            this.ReturnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.ReturnButton.Font = new System.Drawing.Font("Nirmala UI", 13F);
            this.ReturnButton.ForeColor = System.Drawing.Color.White;
            this.ReturnButton.Location = new System.Drawing.Point(1199, 694);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(76, 30);
            this.ReturnButton.TabIndex = 26;
            this.ReturnButton.Text = "Return";
            this.Tips.SetToolTip(this.ReturnButton, "Return back to Selection?");
            this.ReturnButton.Click += new System.EventHandler(this.clicked);
            this.ReturnButton.MouseEnter += new System.EventHandler(this.entered);
            this.ReturnButton.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // count
            // 
            this.count.AutoSize = true;
            this.count.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.count.Font = new System.Drawing.Font("Nirmala UI", 15F);
            this.count.ForeColor = System.Drawing.Color.White;
            this.count.Location = new System.Drawing.Point(669, 694);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(51, 35);
            this.count.TabIndex = 25;
            this.count.Text = "1/3";
            // 
            // previousbutton
            // 
            this.previousbutton.BackColor = System.Drawing.Color.Transparent;
            this.previousbutton.Image = global::PHCM_last_na_to.Properties.Resources.nextButtonAboutUsFinal__2_;
            this.previousbutton.Location = new System.Drawing.Point(642, 694);
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
            // nextbutton
            // 
            this.nextbutton.BackColor = System.Drawing.Color.Transparent;
            this.nextbutton.Image = global::PHCM_last_na_to.Properties.Resources.nextButtonAboutUsFinal;
            this.nextbutton.Location = new System.Drawing.Point(726, 694);
            this.nextbutton.Name = "nextbutton";
            this.nextbutton.Size = new System.Drawing.Size(21, 38);
            this.nextbutton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nextbutton.TabIndex = 23;
            this.nextbutton.TabStop = false;
            this.Tips.SetToolTip(this.nextbutton, "Click me to go next page");
            this.nextbutton.Click += new System.EventHandler(this.clicked);
            this.nextbutton.MouseEnter += new System.EventHandler(this.entered);
            this.nextbutton.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // books
            // 
            this.books.Dock = System.Windows.Forms.DockStyle.Fill;
            this.books.Image = global::PHCM_last_na_to.Properties.Resources.Add_Books_1;
            this.books.Location = new System.Drawing.Point(0, 0);
            this.books.Name = "books";
            this.books.Size = new System.Drawing.Size(1287, 744);
            this.books.TabIndex = 22;
            this.books.TabStop = false;
            // 
            // How_to_use_Books
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1287, 744);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.count);
            this.Controls.Add(this.previousbutton);
            this.Controls.Add(this.nextbutton);
            this.Controls.Add(this.books);
            this.Controls.Add(this.catanaPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "How_to_use_Books";
            this.Text = "How_to_use_Books";
            ((System.ComponentModel.ISupportInitialize)(this.previousbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.books)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CatanaPanel catanaPanel1;
        private System.Windows.Forms.Label Exit;
        private System.Windows.Forms.ToolTip Tips;
        private System.Windows.Forms.Label ReturnButton;
        private System.Windows.Forms.Label count;
        private System.Windows.Forms.PictureBox previousbutton;
        private System.Windows.Forms.PictureBox nextbutton;
        private System.Windows.Forms.PictureBox books;
    }
}