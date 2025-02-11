namespace PHCM_last_na_to
{
    partial class Exited
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
            this.label2 = new System.Windows.Forms.Label();
            this.LabelChange = new System.Windows.Forms.Label();
            this.USERincMG1 = new FontAwesome.Sharp.IconPictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.USERincMG1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-7, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 27);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(134, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Notice";
            // 
            // LabelChange
            // 
            this.LabelChange.AccessibleName = "OpenLabelChange";
            this.LabelChange.AutoSize = true;
            this.LabelChange.BackColor = System.Drawing.Color.Transparent;
            this.LabelChange.Font = new System.Drawing.Font("Nirmala UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelChange.ForeColor = System.Drawing.Color.White;
            this.LabelChange.Location = new System.Drawing.Point(73, 57);
            this.LabelChange.Name = "LabelChange";
            this.LabelChange.Size = new System.Drawing.Size(155, 45);
            this.LabelChange.TabIndex = 1;
            this.LabelChange.Text = "CLOSING";
            // 
            // USERincMG1
            // 
            this.USERincMG1.BackColor = System.Drawing.Color.Transparent;
            this.USERincMG1.ForeColor = System.Drawing.Color.Red;
            this.USERincMG1.IconChar = FontAwesome.Sharp.IconChar.CircleExclamation;
            this.USERincMG1.IconColor = System.Drawing.Color.Red;
            this.USERincMG1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.USERincMG1.Location = new System.Drawing.Point(260, 57);
            this.USERincMG1.Name = "USERincMG1";
            this.USERincMG1.Size = new System.Drawing.Size(32, 32);
            this.USERincMG1.TabIndex = 17;
            this.USERincMG1.TabStop = false;
            this.USERincMG1.Visible = false;
            // 
            // Exited
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PHCM_last_na_to.Properties.Resources.perpetual_help_header;
            this.ClientSize = new System.Drawing.Size(304, 150);
            this.Controls.Add(this.USERincMG1);
            this.Controls.Add(this.LabelChange);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Exited";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Exited_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.USERincMG1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label LabelChange;
        private FontAwesome.Sharp.IconPictureBox USERincMG1;
    }
}