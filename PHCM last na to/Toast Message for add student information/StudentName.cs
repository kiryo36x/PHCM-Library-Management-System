using System; // This line brings in the basic system library, which provides essential functions and types, such as working with numbers, dates, and exceptions.
using System.Drawing; // This line imports the library that lets you work with images, colors, and graphics. For example, it enables drawing shapes or setting colors for buttons or text.
using System.Windows.Forms;  // This line imports the library used for creating forms and controls in a Windows desktop application. It allows you to make buttons, text boxes, labels, and other graphical elements.

namespace PHCM_last_na_to.Toast_Messsage_Form
{
    public partial class StudentName : Form
    {
        int StudentNameX, StudentNameY; // Declaring variables to hold the X and Y positions of the form.

        public StudentName() // Constructor method for the form. This is automatically called when the form is created.
        {
            InitializeComponent(); // Initializes all the components of the form (like buttons, labels, etc.).
        }

        private void StudentName_Load(object sender, EventArgs e) // This method runs when the form is loaded.
        {
            Position(); // Calls the Position method to set the initial location of the form.
        }

        private void AnimationTimer_Tick(object sender, EventArgs e) // This method is called when the AnimationTimer reaches a certain time (like a stopwatch ticking).
        {
            StudentNameX -= 10; // Moves the form 10 pixels to the left.
            this.Location = new Point(StudentNameX, StudentNameY); // Updates the form's location with the new X and Y positions.
            if (StudentNameX <= 1625) // When the form has moved to the left enough.
            {
                AnimationTimer.Stop(); // Stops the leftward movement timer.
                AnimationEndTimer.Start(); // Starts the timer for the next phase of the animation (moving the form to the right).
            }
        }

        int x = 100; // Declares a variable 'x' to control the speed of the rightward movement of the form.

        private void AnimationEndTimer_Tick(object sender, EventArgs e) // This method is called when the AnimationEndTimer reaches a certain time (for rightward movement).
        {
            x--; // Decreases the 'x' value to gradually slow down the rightward movement.
            if (x <= 0) // When 'x' reaches 0 or below.
            {
                StudentNameX += 1; // Moves the form a little bit to the right.
                this.Location = new Point(StudentNameX += 10, StudentNameY); // Moves the form 10 pixels to the right.
                if (StudentNameX > 2500) // If the form has moved too far to the right.
                {
                    AnimationEndTimer.Stop(); // Stops the timer for rightward movement.
                    x = 100; // Resets the 'x' value back to 100 to control the speed of the next movement.
                    this.Close(); // Closes the form once the animation is completed.
                }
            }
        }

        private void Position() // This method sets the initial position of the form on the screen.
        {
            int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width; // Gets the width of the screen.
            int ScreenHeight = Screen.PrimaryScreen.WorkingArea.Height; // Gets the height of the screen.

            StudentNameX = ScreenWidth - this.Width + 120; // Sets the initial X position of the form near the right edge of the screen.
            StudentNameY = ScreenHeight - this.Height - 5; // Sets the initial Y position of the form near the bottom of the screen.

            this.Location = new Point(StudentNameX, StudentNameY); // Places the form at the calculated position.
            AnimationTimer.Start(); // Starts the leftward movement timer.
        }
    }
}
