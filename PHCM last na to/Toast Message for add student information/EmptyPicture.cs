using System; // This line brings in the basic system library, which provides essential functions and types, such as working with numbers, dates, and exceptions.
using System.Drawing; // This line imports the library that lets you work with images, colors, and graphics. For example, it enables drawing shapes or setting colors for buttons or text.
using System.Windows.Forms;  // This line imports the library used for creating forms and controls in a Windows desktop application. It allows you to make buttons, text boxes, labels, and other graphical elements.

namespace PHCM_last_na_to.Toast_Message_for_add_student_information
{
    public partial class EmptyPicture : Form
    {
        int EmptyPictureX, EmptyPictureY; // Declaring two variables to store the X and Y coordinates of the form.

        public EmptyPicture() // Constructor method for initializing the form.
        {
            InitializeComponent(); // Initializes the form’s components like buttons, textboxes, etc.
        }

        private void EmptyPicture_Load(object sender, EventArgs e) // This method runs when the form is loaded.
        {
            Position(); // Calls the Position method to set the form's initial location on the screen.
        }

        private void AnimationTimer_Tick(object sender, EventArgs e) // This method runs each time the AnimationTimer ticks (it’s like a timer counting down).
        {
            EmptyPictureX -= 10; // Moves the form 10 pixels to the left on the screen.
            this.Location = new Point(EmptyPictureX, EmptyPictureY); // Updates the form’s location to the new coordinates.
            if (EmptyPictureX <= 1625) // If the form has moved far enough to the left.
            {
                AnimationTimer.Stop(); // Stops the leftward movement timer.
                AnimationEndTimer.Start(); // Starts a new timer for the form to start moving right.
            }
        }
        int x = 100; // Declares a variable 'x' to control the speed of the form's rightward movement.

        private void AnimationEndTimer_Tick(object sender, EventArgs e) // This method runs when the AnimationEndTimer ticks (when it's time for the form to move right).
        {
            x--; // Decreases the 'x' value to slow down the rightward movement.
            if (x <= 0) // When 'x' reaches 0 or below.
            {
                EmptyPictureX += 1; // Moves the form a little bit to the right.
                this.Location = new Point(EmptyPictureX += 10, EmptyPictureY); // Moves the form 10 pixels to the right.
                if (EmptyPictureX > 2500) // If the form has moved too far to the right.
                {
                    AnimationEndTimer.Stop(); // Stops the timer for the rightward movement.
                    x = 100; // Resets the 'x' value back to 100 to control the speed of the next movement.
                    this.Close(); // Closes the form when the animation is finished.
                }
            }
        }

        private void Position() // This method sets the form's initial position on the screen.
        {
            int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width; // Gets the width of the screen.
            int ScreenHeight = Screen.PrimaryScreen.WorkingArea.Height; // Gets the height of the screen.

            EmptyPictureX = ScreenWidth - this.Width + 120; // Sets the initial X position of the form near the right edge of the screen.
            EmptyPictureY = ScreenHeight - this.Height - 5; // Sets the initial Y position of the form near the bottom of the screen.

            this.Location = new Point(EmptyPictureX, EmptyPictureY); // Places the form at the calculated position.
            AnimationTimer.Start(); // Starts the animation timer to move the form to the left.
        }
    }
}
