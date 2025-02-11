using System; // This line brings in the basic system library, which provides essential functions and types, such as working with numbers, dates, and exceptions.
using System.Drawing; // This line imports the library that lets you work with images, colors, and graphics. For example, it enables drawing shapes or setting colors for buttons or text.
using System.Windows.Forms; // This line imports the library used for creating forms and controls in a Windows desktop application. It allows you to make buttons, text boxes, labels, and other graphical elements.

namespace PHCM_last_na_to.Toast_Message_for_add_books
{
    public partial class Quantity : Form
    {
        int QuantityX, QuantityY; // Declares two variables to store the x and y positions of the form.

        public Quantity() // This is the constructor of the Quantity class. It's called when the form is created.
        {
            InitializeComponent(); // Initializes the form and its components (sets up buttons, labels, etc.).
            Position(); // Calls the Position method to set the starting position of the form.
        }

        private void AnimationTimer_Tick(object sender, EventArgs e) // This method is triggered every time the animation timer "ticks" (fires).
        {
            QuantityX -= 10; // Decreases the x position (moves the form left).
            this.Location = new Point(QuantityX, QuantityY); // Updates the form's location on the screen based on new x and y coordinates.

            if (QuantityX <= 1625) // Checks if the form has moved far enough to the left.
            {
                AnimationTimer.Stop(); // Stops the animation timer when the form reaches its limit.
                AnimationEndTimer.Start(); // Starts a new timer to handle the next phase of the animation.
            }
        }

        int x = 100; // A variable to control the speed of the second phase of the animation.

        private void AnimationEndTimer_Tick(object sender, EventArgs e) // This method runs every time the AnimationEndTimer "ticks."
        {
            x--; // Decreases the x variable, slowing the movement of the form.

            if (x <= 0) // When x reaches 0, it starts moving the form back to the right.
            {
                QuantityX += 1; // Slightly increases the x position.
                this.Location = new Point(QuantityX += 10, QuantityY); // Moves the form back to the right by 10 units.

                if (QuantityX > 2500) // If the form has moved too far to the right.
                {
                    AnimationEndTimer.Stop(); // Stops the second animation timer.
                    x = 100; // Resets the x value to 100 to prepare for the next animation.
                    this.Close(); // Closes the form when the animation ends.
                }
            }
        }

        private void Position() // This method sets the initial position of the form on the screen.
        {
            int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width; // Gets the width of the screen.
            int ScreenHeight = Screen.PrimaryScreen.WorkingArea.Height; // Gets the height of the screen.

            QuantityX = ScreenWidth - this.Width + 120; // Sets the initial x position, a little away from the right edge of the screen.
            QuantityY = ScreenHeight - this.Height - 5; // Sets the initial y position, close to the bottom of the screen.

            this.Location = new Point(QuantityX, QuantityY); // Places the form at the calculated position.
            AnimationTimer.Start(); // Starts the animation timer to begin the animation.
        }
    }
}
