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
    public partial class How_To_Use_Page_Form_Home: Form
    {
        private Form currentChildForm;
        public How_To_Use_Page_Form_Home()
        {
            InitializeComponent();
            administrator.Parent = HomePic;
            books.Parent = HomePic;
            addStudent.Parent = HomePic;
            issuedBook.Parent = HomePic;
            returnBook.Parent = HomePic;
            quickOverview.Parent = HomePic;
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
            if (sender is PictureBox image)
            {
                if (image.Name == administrator.Name)
                {
                    OpenChildForm(new How_to_use_Administrator());
                }
                else if (image.Name == books.Name)
                {
                    OpenChildForm(new How_to_use_Books());
                }
                else if (image.Name == addStudent.Name)
                {
                    OpenChildForm(new How_to_use_Add_Student_Information());
                }
                else if (image.Name == issuedBook.Name)
                {
                    OpenChildForm(new How_to_use_Issued_Book());
                }
                else if (image.Name == returnBook.Name)
                {
                    OpenChildForm(new How_to_use_Return_Book());
                }
                else if (image.Name == quickOverview.Name)
                {
                    OpenChildForm(new How_to_use_Quick_overview());
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
            if (sender is PictureBox image)
            {
                if (image.Name == administrator.Name)
                {
                    image.Image = Properties.Resources.HoveredAdministrator;
                    Cursor = Cursors.Hand;
                }
                else if (image.Name == books.Name)
                {
                    image.Image = Properties.Resources.HoveredBooks;
                    Cursor = Cursors.Hand;
                }
                else if (image.Name == addStudent.Name)
                {
                    image.Image = Properties.Resources.HoveredAddStudentInformation;
                    Cursor = Cursors.Hand;
                }
                else if (image.Name == issuedBook.Name)
                {
                    image.Image = Properties.Resources.HoveredissuedBook;
                    Cursor = Cursors.Hand;
                }
                else if (image.Name == returnBook.Name)
                {
                    image.Image = Properties.Resources.HoveredReturnBook;
                    Cursor = Cursors.Hand;
                }
                else if (image.Name == quickOverview.Name)
                {
                    image.Image = Properties.Resources.HoveredQuickOverview;
                    Cursor = Cursors.Hand;
                }                
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
            administrator.Image = Properties.Resources.DefaultAdministrator;
            books.Image = Properties.Resources.DefaultBooks;
            addStudent.Image = Properties.Resources.DefaultAddStudentInformation;
            issuedBook.Image = Properties.Resources.DefaultissuedBook;
            returnBook.Image = Properties.Resources.DefaultReturnBook;
            quickOverview.Image = Properties.Resources.DefaultQuickOverview;
            ReturnButton.ForeColor = Color.White;
        }
    }
}
