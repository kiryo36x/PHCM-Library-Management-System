using PHCM_last_na_to.Forms;
using System; // Fundamental types and base classes
using System.Drawing; // Access to GDI+
using System.Windows.Forms; // Access to Windows Forms

namespace PHCM_last_na_to.HomeForm
{
    public partial class Mission_and_Vision: Form
    {
        private Form currentChildForm; // Declare a private Form variable named currentChildForm
        public Mission_and_Vision()
        {
            InitializeComponent();
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
        private void Mission_and_Vision_Load(object sender, EventArgs e) // Load the form        
        {
           
        }

        private void saveStudentbtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Home());
        }

        private void saveStudentbtn_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void saveStudentbtn_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}
