using System; // This line includes the basic System library, which contains essential types like numbers, strings, and other foundational elements for programming.
using System.Drawing; // This line imports the library that lets you work with images, colors, and graphics. For example, it enables drawing shapes or setting colors for buttons or text.
using System.Windows.Forms;  // This line imports the library used for creating forms and controls in a Windows desktop application. It allows you to make buttons, text boxes, labels, and other graphical elements.

namespace PHCM_last_na_to.Other_Toast_Message
{
    public partial class SelectBooksFirst: Form
    {
        int emptyfieldX, emptyfieldY; // Declaring two variables to hold the X and Y coordinates of the form.
        public SelectBooksFirst()
        {
            InitializeComponent();
        }

        private void SelectBooksFirst_Load(object sender, EventArgs e)
        {
            Position();
        }
        private void AnimationTimer_Tick(object sender, EventArgs e) // This method runs every time the AnimationTimer ticks (it’s like a timer counting down).
        {
            emptyfieldX -= 10; // Moves the form 10 pixels to the left each time.
            this.Location = new Point(emptyfieldX, emptyfieldY); // Updates the form's location on the screen to the new coordinates.
            if (emptyfieldX <= 1625) // When the form has moved far enough to the left.
            {
                AnimationTimer.Stop(); // Stops the timer for the leftward movement.
                AnimationEndTimer.Start(); // Starts a new timer to handle the form’s rightward movement.
            }
        }
        int x = 100; // Declares a variable 'x' to control the speed of the form's rightward movement.

        private void AnimationEndTimer_Tick(object sender, EventArgs e) // This method runs when the AnimationEndTimer ticks.
        {
            x--; // Decreases the 'x' value to slow down the rightward movement of the form.
            if (x <= 0) // When 'x' reaches 0 or below.
            {
                emptyfieldX += 1; // Slightly increases the form’s X position.
                this.Location = new Point(emptyfieldX += 10, emptyfieldY); // Moves the form to the right by 10 pixels.
                if (emptyfieldX > 2500) // If the form has moved too far to the right.
                {
                    AnimationEndTimer.Stop(); // Stops the timer for the rightward movement.
                    x = 100; // Resets the 'x' value back to 100 to control the speed of the next movement.
                    this.Close(); // Closes the form when the animation is finished.
                }
            }
        }

        private void Position() // This method sets the initial position of the form on the screen.
        {
            int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width; // Gets the width of the screen.
            int ScreenHeight = Screen.PrimaryScreen.WorkingArea.Height; // Gets the height of the screen.

            emptyfieldX = ScreenWidth - this.Width + 120; // Sets the initial X position of the form near the right edge of the screen.
            emptyfieldY = ScreenHeight - this.Height - 5; // Sets the initial Y position of the form near the bottom of the screen.

            this.Location = new Point(emptyfieldX, emptyfieldY); // Places the form at the calculated position on the screen.
            AnimationTimer.Start(); // Starts the animation timer to begin moving the form to the left.
        }
    }
}
