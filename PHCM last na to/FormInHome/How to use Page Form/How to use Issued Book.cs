using PHCM_last_na_to.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHCM_last_na_to.FormInHome.How_to_use_Page_Form
{
    
    public partial class How_to_use_Issued_Book: Form
    {
        private Form currentChildForm;
        private int switchImage = 1;
        public How_to_use_Issued_Book()
        {
            InitializeComponent();
            nextbutton.Parent = admin1;
            previousbutton.Parent = admin1;
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
                if (pc.Name == "nextbutton")
                {
                    switchImage++;
                    if (switchImage > 2)
                    {
                        switchImage = 2;
                    }
                    else if (switchImage == 2)
                    {
                        admin1.Image = Properties.Resources.issued_book_2;
                        count.Text = "2/2";
                    }                    
                }
                else if (pc.Name == "previousbutton")
                {
                    switchImage--;
                    if (switchImage < 1)
                    {
                        switchImage = 1;
                    }
                    else if (switchImage == 1)
                    {
                        admin1.Image = Properties.Resources.issued_book_1_1;
                        count.Text = "1/2";
                    }                    
                }
            }
            else if (sender is Label lbl)
            {
                if (lbl.Name == "ReturnButton")
                {
                    OpenChildForm(new How_To_Use_Page_Form_Home());
                }
                else if (lbl.Name == "Exit")
                {
                    OpenChildForm(new Home());
                }
            }
        }

        private void entered(object sender, EventArgs e)
        {
            if (sender is PictureBox pc)
            {
                if (pc.Name == "nextbutton")
                {
                    pc.Image = Properties.Resources.nextButtonAboutUsFinal__3_;
                    Cursor = Cursors.Hand;
                }
                else if (pc.Name == "previousbutton")
                {
                    pc.Image = Properties.Resources.rightButtonAboutusFinal;
                    Cursor = Cursors.Hand;
                }
            }
            else if (sender is Label lbl)
            {
                lbl.ForeColor = SystemColors.ControlDarkDark;
                Cursor = Cursors.Hand;
            }
        }

        private void leaved(object sender, EventArgs e)
        {
            nextbutton.Image = Properties.Resources.nextButtonAboutUsFinal;
            previousbutton.Image = Properties.Resources.nextButtonAboutUsFinal__2_;
            Cursor = Cursors.Default;
            ReturnButton.ForeColor = Color.White;
            Exit.ForeColor = Color.White;
        }
    }
}
