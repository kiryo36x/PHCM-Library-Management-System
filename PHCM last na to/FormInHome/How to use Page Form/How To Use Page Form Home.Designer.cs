namespace PHCM_last_na_to.FormInHome.How_to_use_Page_Form
{
    partial class How_To_Use_Page_Form_Home
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
            this.quickOverview = new System.Windows.Forms.PictureBox();
            this.returnBook = new System.Windows.Forms.PictureBox();
            this.issuedBook = new System.Windows.Forms.PictureBox();
            this.addStudent = new System.Windows.Forms.PictureBox();
            this.books = new System.Windows.Forms.PictureBox();
            this.administrator = new System.Windows.Forms.PictureBox();
            this.HomePic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.quickOverview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.issuedBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.books)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.administrator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomePic)).BeginInit();
            this.SuspendLayout();
            // 
            // ReturnButton
            // 
            this.ReturnButton.AutoSize = true;
            this.ReturnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.ReturnButton.Font = new System.Drawing.Font("Nirmala UI", 16F);
            this.ReturnButton.ForeColor = System.Drawing.Color.White;
            this.ReturnButton.Location = new System.Drawing.Point(1181, 698);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(94, 37);
            this.ReturnButton.TabIndex = 8;
            this.ReturnButton.Text = "Return";
            this.Tips.SetToolTip(this.ReturnButton, "Return back to Home?");
            this.ReturnButton.Click += new System.EventHandler(this.clicked);
            this.ReturnButton.MouseEnter += new System.EventHandler(this.entered);
            this.ReturnButton.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // quickOverview
            // 
            this.quickOverview.BackColor = System.Drawing.Color.Transparent;
            this.quickOverview.Image = global::PHCM_last_na_to.Properties.Resources.DefaultQuickOverview;
            this.quickOverview.Location = new System.Drawing.Point(863, 545);
            this.quickOverview.Name = "quickOverview";
            this.quickOverview.Size = new System.Drawing.Size(354, 92);
            this.quickOverview.TabIndex = 6;
            this.quickOverview.TabStop = false;
            this.quickOverview.Click += new System.EventHandler(this.clicked);
            this.quickOverview.MouseEnter += new System.EventHandler(this.entered);
            this.quickOverview.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // returnBook
            // 
            this.returnBook.BackColor = System.Drawing.Color.Transparent;
            this.returnBook.Image = global::PHCM_last_na_to.Properties.Resources.DefaultReturnBook;
            this.returnBook.Location = new System.Drawing.Point(863, 423);
            this.returnBook.Name = "returnBook";
            this.returnBook.Size = new System.Drawing.Size(354, 92);
            this.returnBook.TabIndex = 5;
            this.returnBook.TabStop = false;
            this.returnBook.Click += new System.EventHandler(this.clicked);
            this.returnBook.MouseEnter += new System.EventHandler(this.entered);
            this.returnBook.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // issuedBook
            // 
            this.issuedBook.BackColor = System.Drawing.Color.Transparent;
            this.issuedBook.Image = global::PHCM_last_na_to.Properties.Resources.DefaultissuedBook;
            this.issuedBook.Location = new System.Drawing.Point(863, 304);
            this.issuedBook.Name = "issuedBook";
            this.issuedBook.Size = new System.Drawing.Size(354, 92);
            this.issuedBook.TabIndex = 4;
            this.issuedBook.TabStop = false;
            this.issuedBook.Click += new System.EventHandler(this.clicked);
            this.issuedBook.MouseEnter += new System.EventHandler(this.entered);
            this.issuedBook.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // addStudent
            // 
            this.addStudent.BackColor = System.Drawing.Color.Transparent;
            this.addStudent.Image = global::PHCM_last_na_to.Properties.Resources.DefaultAddStudentInformation;
            this.addStudent.Location = new System.Drawing.Point(449, 545);
            this.addStudent.Name = "addStudent";
            this.addStudent.Size = new System.Drawing.Size(354, 92);
            this.addStudent.TabIndex = 3;
            this.addStudent.TabStop = false;
            this.addStudent.Click += new System.EventHandler(this.clicked);
            this.addStudent.MouseEnter += new System.EventHandler(this.entered);
            this.addStudent.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // books
            // 
            this.books.BackColor = System.Drawing.Color.Transparent;
            this.books.Image = global::PHCM_last_na_to.Properties.Resources.DefaultBooks;
            this.books.Location = new System.Drawing.Point(449, 423);
            this.books.Name = "books";
            this.books.Size = new System.Drawing.Size(354, 92);
            this.books.TabIndex = 2;
            this.books.TabStop = false;
            this.books.Click += new System.EventHandler(this.clicked);
            this.books.MouseEnter += new System.EventHandler(this.entered);
            this.books.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // administrator
            // 
            this.administrator.BackColor = System.Drawing.Color.Transparent;
            this.administrator.Image = global::PHCM_last_na_to.Properties.Resources.DefaultAdministrator;
            this.administrator.Location = new System.Drawing.Point(449, 304);
            this.administrator.Name = "administrator";
            this.administrator.Size = new System.Drawing.Size(354, 92);
            this.administrator.TabIndex = 1;
            this.administrator.TabStop = false;
            this.administrator.Click += new System.EventHandler(this.clicked);
            this.administrator.MouseEnter += new System.EventHandler(this.entered);
            this.administrator.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // HomePic
            // 
            this.HomePic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HomePic.Image = global::PHCM_last_na_to.Properties.Resources.HomeHowToUseUpdated;
            this.HomePic.Location = new System.Drawing.Point(0, 0);
            this.HomePic.Name = "HomePic";
            this.HomePic.Size = new System.Drawing.Size(1287, 744);
            this.HomePic.TabIndex = 0;
            this.HomePic.TabStop = false;
            // 
            // How_To_Use_Page_Form_Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1287, 744);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.quickOverview);
            this.Controls.Add(this.returnBook);
            this.Controls.Add(this.issuedBook);
            this.Controls.Add(this.addStudent);
            this.Controls.Add(this.books);
            this.Controls.Add(this.administrator);
            this.Controls.Add(this.HomePic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "How_To_Use_Page_Form_Home";
            this.Text = "How_To_Use_Page_Form_Home";
            ((System.ComponentModel.ISupportInitialize)(this.quickOverview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.issuedBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.books)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.administrator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox HomePic;
        private System.Windows.Forms.PictureBox administrator;
        private System.Windows.Forms.PictureBox books;
        private System.Windows.Forms.PictureBox addStudent;
        private System.Windows.Forms.PictureBox issuedBook;
        private System.Windows.Forms.PictureBox returnBook;
        private System.Windows.Forms.PictureBox quickOverview;
        private System.Windows.Forms.Label ReturnButton;
        private System.Windows.Forms.ToolTip Tips;
    }
}