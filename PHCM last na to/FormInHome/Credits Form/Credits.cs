using System; // Math
using System.Windows.Forms; // Windows Forms

namespace PHCM_last_na_to.FormInHome.Credits_Form
{
    public partial class Credits: Form
    {
        private int changeImageIndex = 1; // Index of the image to be displayed
        public Credits() 
        {
            InitializeComponent();
        }
        

        private void clicked(object sender, EventArgs e) // Event handler for the next and previous buttons
        {
            if (sender is PictureBox px) // Check if the sender is a PictureBox
            {
                if (px.Name == "nextButton") // Check if the sender is the next button
                {
                    changeImageIndex = Math.Min(changeImageIndex + 1, 3); // Increment the index by 1, but not more than 3
                }
                else if (px.Name == "previousButton") // Check if the sender is the previous button
                {
                    changeImageIndex = Math.Max(changeImageIndex - 1, 1); // Decrement the index by 1, but not less than 1
                }

                // Update the image based on changeImageIndex
                switch (changeImageIndex)
                {
                    case 1: // If changeImageIndex is 1
                        imageHome.Image = Properties.Resources.System_Contributors; // Set the image to System Contributors
                        break; // Exit the switch statement
                    case 2: // If changeImageIndex is 2
                        imageHome.Image = Properties.Resources.Teachers; // Set the image to Teachers
                        break; // Exit the switch statement
                    case 3: // If changeImageIndex is 3
                        imageHome.Image = Properties.Resources.Speech; // Set the image to Speech
                        break; // Exit the switch statement
                }
            }
        }


        private void entered(object sender, EventArgs e) // Event handler for when the mouse enters the next and previous buttons
        {
            if (sender is PictureBox px) // Check if the sender is a PictureBox
            {
                if (px.Name == "nextButton") // Check if the sender is the next button
                {
                    px.Image = Properties.Resources.hoveredNextButtonCredits; // Change the image to hoveredNextButtonCredits
                }
                else if (px.Name == "previousButton") // Check if the sender is the previous button
                {
                    px.Image = Properties.Resources.hoveredPreviousButtonCredits; // Change the image to hoveredPreviousButtonCredits
                }
            }
        }

        private void leaved(object sender, EventArgs e) // Event handler for when the mouse leaves the next and previous buttons
        {
            if (sender is PictureBox px) // Check if the sender is a PictureBox 
            {
                if (px.Name == "nextButton") // Check if the sender is the next button
                {
                    px.Image = Properties.Resources.nextButtonCredits;
                }
                else if (px.Name == "previousButton") // Check if the sender is the previous button
                {
                    px.Image = Properties.Resources.previousButtonCredits; // Change the image to previousButtonCredits
                }
            }
        }
    }
}
