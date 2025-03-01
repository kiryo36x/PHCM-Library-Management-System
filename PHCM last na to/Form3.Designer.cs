namespace PHCM_last_na_to
{
    partial class Loading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.SETFadeAnimation = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.FullLoaded = new System.Windows.Forms.Panel();
            this.LoadingPanel = new System.Windows.Forms.Panel();
            this.SetLoading = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoadingLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FullLoaded.SuspendLayout();
            this.SuspendLayout();
            // 
            // SETFadeAnimation
            // 
            this.SETFadeAnimation.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(0, 275);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 10);
            this.panel1.TabIndex = 0;
            // 
            // FullLoaded
            // 
            this.FullLoaded.BackColor = System.Drawing.Color.Transparent;
            this.FullLoaded.Controls.Add(this.LoadingPanel);
            this.FullLoaded.Location = new System.Drawing.Point(0, 263);
            this.FullLoaded.Name = "FullLoaded";
            this.FullLoaded.Size = new System.Drawing.Size(639, 20);
            this.FullLoaded.TabIndex = 1;
            // 
            // LoadingPanel
            // 
            this.LoadingPanel.BackColor = System.Drawing.Color.White;
            this.LoadingPanel.Location = new System.Drawing.Point(0, 0);
            this.LoadingPanel.Name = "LoadingPanel";
            this.LoadingPanel.Size = new System.Drawing.Size(2, 20);
            this.LoadingPanel.TabIndex = 2;
            this.LoadingPanel.Visible = false;
            // 
            // SetLoading
            // 
            this.SetLoading.Interval = 15;
            this.SetLoading.Tick += new System.EventHandler(this.SetLoading_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(569, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "PHCM LIBRARY MANAGEMENT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(243, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 50);
            this.label2.TabIndex = 3;
            this.label2.Text = "SYSTEM";
            // 
            // LoadingLbl
            // 
            this.LoadingLbl.AutoSize = true;
            this.LoadingLbl.BackColor = System.Drawing.Color.Transparent;
            this.LoadingLbl.Font = new System.Drawing.Font("Nirmala UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadingLbl.ForeColor = System.Drawing.Color.White;
            this.LoadingLbl.Location = new System.Drawing.Point(228, 151);
            this.LoadingLbl.Name = "LoadingLbl";
            this.LoadingLbl.Size = new System.Drawing.Size(188, 50);
            this.LoadingLbl.TabIndex = 4;
            this.LoadingLbl.Text = "LOADING";
            this.LoadingLbl.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(240, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 50);
            this.label3.TabIndex = 5;
            this.label3.Text = "LOADED";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(2, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Programmed: Catana";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(2, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "Project: Group 5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(600, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "v2.0.1";
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PHCM_last_na_to.Properties.Resources.Loading;
            this.ClientSize = new System.Drawing.Size(638, 279);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LoadingLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FullLoaded);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Loading";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading Animation";
            this.FullLoaded.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer SETFadeAnimation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel FullLoaded;
        private System.Windows.Forms.Panel LoadingPanel;
        private System.Windows.Forms.Timer SetLoading;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LoadingLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}