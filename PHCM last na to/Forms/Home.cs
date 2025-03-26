using PHCM_last_na_to.FormInHome.About_us_Page_Form;
using PHCM_last_na_to.FormInHome.Credits_Form;
using PHCM_last_na_to.FormInHome.How_to_use_Page_Form;
using PHCM_last_na_to.HomeForm;
using System.Windows.Forms; // Import System.Windows.Forms, which is used for building Windows Forms applications with graphical user interfaces (UI)

namespace PHCM_last_na_to.Forms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();            
            visionandmission.Parent = HomeImage; // Set the parent of the VisionandMission panel to HomePic.
            aboutus.Parent = HomeImage; // Set the parent of the AboutUs panel to HomePic.
            credits.Parent = HomeImage; // Set the parent of the Credits panel to HomePic.
            howtouse.Parent = HomeImage; // Set the parent of the howToUse panel to HomePic.
        }
        private Form currentChildForm;       
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
        private void Entered(object sender, System.EventArgs e)
        {
            if (sender is PictureBox image)
            {
                if (image.Name == visionandmission.Name)
                {
                    image.Image = Properties.Resources.HoverButtonVisionanMission;
                }
                else if (image.Name == aboutus.Name)
                {
                    image.Image = Properties.Resources.HoverButtonAboutus;
                }
                else if (image.Name == credits.Name)
                {
                    image.Image = Properties.Resources.HoverButtonCredits;
                }
                else if (image.Name == howtouse.Name)
                {
                    image.Image = Properties.Resources.HoverButtonHowtoUse;
                }                
                Cursor = Cursors.Hand;                
            }            
        }

        private void Leaved(object sender, System.EventArgs e)
        {            
            visionandmission.Image = Properties.Resources.defaultButtonVisionanMission;
            aboutus.Image = Properties.Resources.defaultButtonAboutus;
            credits.Image = Properties.Resources.defaultButtonCredits;
            howtouse.Image = Properties.Resources.DefaultButtonHowtoUse;
            Cursor = Cursors.Default;            
        }

        private void Clicked(object sender, System.EventArgs e)
        {
            if (sender is PictureBox imageClicked)
            {
                if (imageClicked.Name == visionandmission.Name)
                {
                    OpenChildForm(new Mission_and_Vision());
                }
                else if (imageClicked.Name == aboutus.Name)
                {
                    OpenChildForm(new About_Us_First());
                }
                else if (imageClicked.Name == credits.Name)
                {
                    OpenChildForm(new Credits());
                }
                else if (imageClicked.Name == howtouse.Name)
                {
                    OpenChildForm(new How_To_Use_Page_Form_Home());
                }
            }
        }        
    }
}
