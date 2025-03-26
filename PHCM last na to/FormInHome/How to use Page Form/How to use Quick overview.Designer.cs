namespace PHCM_last_na_to.FormInHome.How_to_use_Page_Form
{
    partial class How_to_use_Quick_overview
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
            this.Exit = new System.Windows.Forms.Label();
            this.ReturnButton = new System.Windows.Forms.Label();
            this.Tips = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.admin1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.admin1)).BeginInit();
            this.SuspendLayout();
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
            this.Exit.TabIndex = 46;
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
            this.ReturnButton.TabIndex = 45;
            this.ReturnButton.Text = "Return";
            this.Tips.SetToolTip(this.ReturnButton, "Return back to Home?");
            this.ReturnButton.Click += new System.EventHandler(this.clicked);
            this.ReturnButton.MouseEnter += new System.EventHandler(this.entered);
            this.ReturnButton.MouseLeave += new System.EventHandler(this.leaved);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(539, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 46);
            this.label1.TabIndex = 47;
            this.label1.Text = "RETURN BOOK\'";
            this.Tips.SetToolTip(this.label1, "Return back to Selection?");
            // 
            // admin1
            // 
            this.admin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.admin1.Image = global::PHCM_last_na_to.Properties.Resources.quick_overview_1;
            this.admin1.Location = new System.Drawing.Point(0, 0);
            this.admin1.Name = "admin1";
            this.admin1.Size = new System.Drawing.Size(1287, 744);
            this.admin1.TabIndex = 41;
            this.admin1.TabStop = false;
            // 
            // How_to_use_Quick_overview
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1287, 744);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.admin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "How_to_use_Quick_overview";
            this.Text = "How_to_use_Quick_overview";
            ((System.ComponentModel.ISupportInitialize)(this.admin1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Exit;
        private System.Windows.Forms.ToolTip Tips;
        private System.Windows.Forms.Label ReturnButton;
        private System.Windows.Forms.PictureBox admin1;
        private System.Windows.Forms.Label label1;
    }
}