namespace PHCM_last_na_to.Forms
{
    partial class IssueBooksForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.issuedDate = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Booknamelbl = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bookNameComboBox = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.publishedDatelbl = new System.Windows.Forms.Label();
            this.publishedDatetxtBox = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Authorlbl = new System.Windows.Forms.Label();
            this.AuthortxtBox = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.studentNamelbl = new System.Windows.Forms.Label();
            this.studentNametxtbox = new System.Windows.Forms.TextBox();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.ViewBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ImagePath = new System.Windows.Forms.TextBox();
            this.changeImagebtn = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.genrelbl = new System.Windows.Forms.Label();
            this.genretxtbox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.ButtonPanel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1287, 744);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(113)))));
            this.panel8.Controls.Add(this.issuedDate);
            this.panel8.Location = new System.Drawing.Point(49, 623);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(593, 67);
            this.panel8.TabIndex = 17;
            // 
            // issuedDate
            // 
            this.issuedDate.BackColor = System.Drawing.Color.White;
            this.issuedDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.issuedDate.Font = new System.Drawing.Font("Nirmala UI", 31F);
            this.issuedDate.ForeColor = System.Drawing.Color.Black;
            this.issuedDate.Location = new System.Drawing.Point(6, 6);
            this.issuedDate.Name = "issuedDate";
            this.issuedDate.ReadOnly = true;
            this.issuedDate.Size = new System.Drawing.Size(582, 69);
            this.issuedDate.TabIndex = 4;
            this.issuedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(113)))));
            this.panel4.Controls.Add(this.Booknamelbl);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.bookNameComboBox);
            this.panel4.Location = new System.Drawing.Point(48, 199);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(593, 67);
            this.panel4.TabIndex = 18;
            // 
            // Booknamelbl
            // 
            this.Booknamelbl.AutoSize = true;
            this.Booknamelbl.BackColor = System.Drawing.Color.White;
            this.Booknamelbl.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Booknamelbl.ForeColor = System.Drawing.Color.DimGray;
            this.Booknamelbl.Location = new System.Drawing.Point(225, 16);
            this.Booknamelbl.Name = "Booknamelbl";
            this.Booknamelbl.Size = new System.Drawing.Size(186, 41);
            this.Booknamelbl.TabIndex = 2;
            this.Booknamelbl.Text = "Select Books";
            this.Booknamelbl.Click += new System.EventHandler(this.Booknamelbl_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Nirmala UI", 31F);
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(6, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(582, 69);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // bookNameComboBox
            // 
            this.bookNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bookNameComboBox.Font = new System.Drawing.Font("Nirmala UI", 24F);
            this.bookNameComboBox.FormattingEnabled = true;
            this.bookNameComboBox.Location = new System.Drawing.Point(6, 6);
            this.bookNameComboBox.Name = "bookNameComboBox";
            this.bookNameComboBox.Size = new System.Drawing.Size(581, 62);
            this.bookNameComboBox.TabIndex = 12;
            this.bookNameComboBox.DropDown += new System.EventHandler(this.bookNameComboBox_DropDown);
            this.bookNameComboBox.SelectedIndexChanged += new System.EventHandler(this.bookNameComboBox_SelectedIndexChanged);
            this.bookNameComboBox.DropDownClosed += new System.EventHandler(this.bookNameComboBox_DropDownClosed);
            this.bookNameComboBox.Enter += new System.EventHandler(this.bookNameComboBox_Enter);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(113)))));
            this.panel5.Controls.Add(this.publishedDatelbl);
            this.panel5.Controls.Add(this.publishedDatetxtBox);
            this.panel5.Location = new System.Drawing.Point(47, 460);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(593, 67);
            this.panel5.TabIndex = 21;
            // 
            // publishedDatelbl
            // 
            this.publishedDatelbl.AutoSize = true;
            this.publishedDatelbl.BackColor = System.Drawing.Color.White;
            this.publishedDatelbl.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.publishedDatelbl.ForeColor = System.Drawing.Color.DimGray;
            this.publishedDatelbl.Location = new System.Drawing.Point(18, 16);
            this.publishedDatelbl.Name = "publishedDatelbl";
            this.publishedDatelbl.Size = new System.Drawing.Size(544, 41);
            this.publishedDatelbl.TabIndex = 5;
            this.publishedDatelbl.Text = "Select a Book to Display Published Date";
            // 
            // publishedDatetxtBox
            // 
            this.publishedDatetxtBox.BackColor = System.Drawing.Color.White;
            this.publishedDatetxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.publishedDatetxtBox.Font = new System.Drawing.Font("Nirmala UI", 31F);
            this.publishedDatetxtBox.ForeColor = System.Drawing.Color.Black;
            this.publishedDatetxtBox.Location = new System.Drawing.Point(7, 5);
            this.publishedDatetxtBox.Name = "publishedDatetxtBox";
            this.publishedDatetxtBox.ReadOnly = true;
            this.publishedDatetxtBox.Size = new System.Drawing.Size(582, 69);
            this.publishedDatetxtBox.TabIndex = 3;
            this.publishedDatetxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(113)))));
            this.panel6.Controls.Add(this.Authorlbl);
            this.panel6.Controls.Add(this.AuthortxtBox);
            this.panel6.Location = new System.Drawing.Point(49, 287);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(593, 67);
            this.panel6.TabIndex = 19;
            // 
            // Authorlbl
            // 
            this.Authorlbl.AutoSize = true;
            this.Authorlbl.BackColor = System.Drawing.Color.White;
            this.Authorlbl.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Authorlbl.ForeColor = System.Drawing.Color.DimGray;
            this.Authorlbl.Location = new System.Drawing.Point(39, 17);
            this.Authorlbl.Name = "Authorlbl";
            this.Authorlbl.Size = new System.Drawing.Size(532, 41);
            this.Authorlbl.TabIndex = 3;
            this.Authorlbl.Text = "Select a Book to display Authors Name";
            // 
            // AuthortxtBox
            // 
            this.AuthortxtBox.BackColor = System.Drawing.Color.White;
            this.AuthortxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AuthortxtBox.Font = new System.Drawing.Font("Nirmala UI", 31F);
            this.AuthortxtBox.ForeColor = System.Drawing.Color.Black;
            this.AuthortxtBox.Location = new System.Drawing.Point(6, 6);
            this.AuthortxtBox.Name = "AuthortxtBox";
            this.AuthortxtBox.ReadOnly = true;
            this.AuthortxtBox.Size = new System.Drawing.Size(582, 69);
            this.AuthortxtBox.TabIndex = 1;
            this.AuthortxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(113)))));
            this.panel7.Controls.Add(this.studentNamelbl);
            this.panel7.Controls.Add(this.studentNametxtbox);
            this.panel7.Location = new System.Drawing.Point(48, 377);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(593, 67);
            this.panel7.TabIndex = 20;
            // 
            // studentNamelbl
            // 
            this.studentNamelbl.AutoSize = true;
            this.studentNamelbl.BackColor = System.Drawing.Color.White;
            this.studentNamelbl.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentNamelbl.ForeColor = System.Drawing.Color.DimGray;
            this.studentNamelbl.Location = new System.Drawing.Point(128, 16);
            this.studentNamelbl.Name = "studentNamelbl";
            this.studentNamelbl.Size = new System.Drawing.Size(364, 41);
            this.studentNamelbl.TabIndex = 5;
            this.studentNamelbl.Text = "Enter name of the Student";
            this.studentNamelbl.Click += new System.EventHandler(this.studentNamelbl_Click);
            // 
            // studentNametxtbox
            // 
            this.studentNametxtbox.BackColor = System.Drawing.Color.White;
            this.studentNametxtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.studentNametxtbox.Font = new System.Drawing.Font("Nirmala UI", 31F);
            this.studentNametxtbox.ForeColor = System.Drawing.Color.Black;
            this.studentNametxtbox.Location = new System.Drawing.Point(6, 6);
            this.studentNametxtbox.Name = "studentNametxtbox";
            this.studentNametxtbox.Size = new System.Drawing.Size(582, 69);
            this.studentNametxtbox.TabIndex = 4;
            this.studentNametxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.studentNametxtbox.Enter += new System.EventHandler(this.studentNametxtbox_Enter);
            this.studentNametxtbox.Leave += new System.EventHandler(this.studentNametxtbox_Leave);
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.ButtonPanel.Controls.Add(this.ClearBtn);
            this.ButtonPanel.Controls.Add(this.ViewBtn);
            this.ButtonPanel.Controls.Add(this.SaveBtn);
            this.ButtonPanel.Location = new System.Drawing.Point(672, 100);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Padding = new System.Windows.Forms.Padding(40, 100, 40, 0);
            this.ButtonPanel.Size = new System.Drawing.Size(615, 644);
            this.ButtonPanel.TabIndex = 14;
            this.ButtonPanel.Click += new System.EventHandler(this.ButtonPanel_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.ClearBtn.FlatAppearance.BorderSize = 0;
            this.ClearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearBtn.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.ClearBtn.ForeColor = System.Drawing.Color.White;
            this.ClearBtn.Location = new System.Drawing.Point(40, 412);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(535, 98);
            this.ClearBtn.TabIndex = 23;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = false;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // ViewBtn
            // 
            this.ViewBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.ViewBtn.FlatAppearance.BorderSize = 0;
            this.ViewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewBtn.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.ViewBtn.ForeColor = System.Drawing.Color.White;
            this.ViewBtn.Location = new System.Drawing.Point(40, 259);
            this.ViewBtn.Name = "ViewBtn";
            this.ViewBtn.Size = new System.Drawing.Size(535, 98);
            this.ViewBtn.TabIndex = 22;
            this.ViewBtn.Text = "View";
            this.ViewBtn.UseVisualStyleBackColor = false;
            this.ViewBtn.Click += new System.EventHandler(this.ViewBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.SaveBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.SaveBtn.FlatAppearance.BorderSize = 0;
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.SaveBtn.ForeColor = System.Drawing.Color.White;
            this.SaveBtn.Location = new System.Drawing.Point(40, 100);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(535, 98);
            this.SaveBtn.TabIndex = 21;
            this.SaveBtn.Text = "Add";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.ImagePath);
            this.panel2.Controls.Add(this.changeImagebtn);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1287, 100);
            this.panel2.TabIndex = 13;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(431, -6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(537, 106);
            this.label1.TabIndex = 14;
            this.label1.Text = "ISSUED BOOK";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ImagePath
            // 
            this.ImagePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ImagePath.Enabled = false;
            this.ImagePath.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImagePath.Location = new System.Drawing.Point(147, 583);
            this.ImagePath.Name = "ImagePath";
            this.ImagePath.ReadOnly = true;
            this.ImagePath.Size = new System.Drawing.Size(413, 31);
            this.ImagePath.TabIndex = 13;
            // 
            // changeImagebtn
            // 
            this.changeImagebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(113)))));
            this.changeImagebtn.FlatAppearance.BorderSize = 0;
            this.changeImagebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeImagebtn.Font = new System.Drawing.Font("Nirmala UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeImagebtn.ForeColor = System.Drawing.Color.White;
            this.changeImagebtn.Location = new System.Drawing.Point(239, 644);
            this.changeImagebtn.Name = "changeImagebtn";
            this.changeImagebtn.Size = new System.Drawing.Size(216, 66);
            this.changeImagebtn.TabIndex = 12;
            this.changeImagebtn.Text = "Add Picture";
            this.changeImagebtn.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Nirmala UI", 17.5F);
            this.textBox2.Location = new System.Drawing.Point(143, 583);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(421, 39);
            this.textBox2.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(113)))));
            this.panel3.Controls.Add(this.genrelbl);
            this.panel3.Controls.Add(this.genretxtbox);
            this.panel3.Location = new System.Drawing.Point(47, 543);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(593, 67);
            this.panel3.TabIndex = 22;
            // 
            // genrelbl
            // 
            this.genrelbl.AutoSize = true;
            this.genrelbl.BackColor = System.Drawing.Color.White;
            this.genrelbl.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genrelbl.ForeColor = System.Drawing.Color.DimGray;
            this.genrelbl.Location = new System.Drawing.Point(89, 16);
            this.genrelbl.Name = "genrelbl";
            this.genrelbl.Size = new System.Drawing.Size(424, 41);
            this.genrelbl.TabIndex = 5;
            this.genrelbl.Text = "Select a Book to Display Genre";
            // 
            // genretxtbox
            // 
            this.genretxtbox.BackColor = System.Drawing.Color.White;
            this.genretxtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.genretxtbox.Font = new System.Drawing.Font("Nirmala UI", 31F);
            this.genretxtbox.ForeColor = System.Drawing.Color.Black;
            this.genretxtbox.Location = new System.Drawing.Point(7, 5);
            this.genretxtbox.Name = "genretxtbox";
            this.genretxtbox.ReadOnly = true;
            this.genretxtbox.Size = new System.Drawing.Size(582, 69);
            this.genretxtbox.TabIndex = 3;
            this.genretxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IssueBooksForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PHCM_last_na_to.Properties.Resources.Loading;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1287, 744);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IssueBooksForm";
            this.Text = "Issue Books";
            this.Load += new System.EventHandler(this.IssueBooksForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ButtonPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox ImagePath;
        private System.Windows.Forms.Button changeImagebtn;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Booknamelbl;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label Authorlbl;
        private System.Windows.Forms.TextBox AuthortxtBox;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button ViewBtn;
        private System.Windows.Forms.Label publishedDatelbl;
        private System.Windows.Forms.Label studentNamelbl;
        private System.Windows.Forms.TextBox studentNametxtbox;
        private System.Windows.Forms.TextBox publishedDatetxtBox;
        private System.Windows.Forms.TextBox issuedDate;
        private System.Windows.Forms.ComboBox bookNameComboBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label genrelbl;
        private System.Windows.Forms.TextBox genretxtbox;
    }
}