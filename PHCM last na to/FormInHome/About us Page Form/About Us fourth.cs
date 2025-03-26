using PHCM_last_na_to.FormInHome.About_us_Page_Form;
using PHCM_last_na_to.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PHCM_last_na_to.HomeForm
{
    public partial class About_Us: Form
    {
        private Form currentChildForm;
        public About_Us()
        {
            InitializeComponent();
            previousbutton.Parent = HomePic;
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null) //if the curret form is still open
            {
                currentChildForm.Close(); // Close the current form before opening a new one.
            }
            currentChildForm = childForm; // Set the new form as the current one.
            childForm.TopLevel = false; // Makes the new form a child of the current form.
            childForm.FormBorderStyle = FormBorderStyle.None; // Removes borders around the child form.
            childForm.Dock = DockStyle.Fill; // Makes the child form fill the space available.
            this.Controls.Add(childForm); // Adds the child form to the parent form.
            this.Tag = childForm; // Assigns a tag to the child form for identification.
            childForm.BringToFront(); // Brings the child form to the front of the other controls.
            childForm.Show(); // Displays the child form.            
        }        
        private void clicked(object sender, EventArgs e)
        {
            if (sender is PictureBox pc)
            {                
                if (pc.Name == "previousbutton")
                {
                    OpenChildForm(new About_Us_Third());
                }
            }
            else if (sender is Label lbl)
            {
                if (lbl.Name == "ReturnButton")
                {
                    OpenChildForm(new Home());
                }
            }
        }

        private void entered(object sender, EventArgs e)
        {
            if (sender is PictureBox pc)
            {               
                if (pc.Name == "previousbutton")
                {
                    pc.Image = Properties.Resources.rightButtonAboutusFinal;
                    Cursor = Cursors.Hand;
                }
            //    else if (pc.Name == "SumalaProfile")
            //    {
            //        pc.Image = Properties.Resources.HoveredSumala;
            //        Cursor = Cursors.Hand;
            //    }                
            }
            else if (sender is Label lbl)
            {
                if (lbl.Name == "ReturnButton")
                {
                    lbl.ForeColor = SystemColors.ControlDarkDark;
                    Cursor = Cursors.Hand;
                }
            }
        }

        private void leaved(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;            
            previousbutton.Image = Properties.Resources.nextButtonAboutUsFinal__2_;
            SumalaProfile.Image = Properties.Resources.DefaultSumala;
            ReturnButton.ForeColor = Color.Black;
        }

        private void About_Us_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
