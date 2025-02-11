using System; // This line brings in the basic system library, which provides essential functions and types, such as working with numbers, dates, and exceptions.
using System.Drawing; // This line imports the library that lets you work with images, colors, and graphics. For example, it enables drawing shapes or setting colors for buttons or text.
using System.Windows.Forms;  // This line imports the library used for creating forms and controls in a Windows desktop application. It allows you to make buttons, text boxes, labels, and other graphical elements.

namespace PHCM_last_na_to.Toast_Messsage_Form
{
    public partial class StudentNumber : Form // Declares a new form called 'StudentNumber'.
    {
        int StudentNumberX, StudentNumberY; // Declaring variables to store the X and Y coordinates of the form.

        public StudentNumber() // Constructor method for the 'StudentNumber' form. Called when the form is created.
        {
            InitializeComponent(); // Initializes all components of the form (like buttons, labels, etc.).
        }

        private void StudentNumber_Load(object sender, EventArgs e) // This method runs when the form is loaded (opened).
        {
            Position(); // Calls the Position method to set the initial location of the form on the screen.
        }

        private void AnimationTimer_Tick(object sender, EventArgs e) // This method is triggered when the 'AnimationTimer' reaches a certain time.
        {
            StudentNumberX -= 10; // Moves the form 10 pixels to the left.
            this.Location = new Point(StudentNumberX, StudentNumberY); // Updates the form's location to the new X and Y coordinates.
            if (StudentNumberX <= 1625) // If the form's X position reaches 1625 or less.
            {
                AnimationTimer.Stop(); // Stops the leftward movement timer.
                AnimationEndTimer.Start(); // Starts the second timer to begin moving the form to the right.
            }
        }

        int x = 100; // Declares a variable 'x' to control the speed of the rightward movement.

        private void AnimationEndTimer_Tick(object sender, EventArgs e) // This method is triggered when the 'AnimationEndTimer' reaches a certain time.
        {
            x--; // Decreases the 'x' value to slow down the rightward movement.
            if (x <= 0) // When 'x' reaches 0 or below.
            {
                StudentNumberX += 1; // Moves the form slightly to the right.
                this.Location = new Point(StudentNumberX += 10, StudentNumberY); // Moves the form 10 pixels to the right.
                if (StudentNumberX > 2500) // If the form's X position exceeds 2500.
                {
                    AnimationEndTimer.Stop(); // Stops the timer for the rightward movement.
                    x = 100; // Resets the 'x' value to 100 to control the speed of the next movement.
                    this.Close(); // Closes the form after the animation is completed.
                }
            }
        }

        private void Position() // This method sets the initial position of the form on the screen.
        {
            int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width; // Gets the width of the screen.
            int ScreenHeight = Screen.PrimaryScreen.WorkingArea.Height; // Gets the height of the screen.

            StudentNumberX = ScreenWidth - this.Width + 120; // Sets the X position of the form near the right edge of the screen.
            StudentNumberY = ScreenHeight - this.Height - 5; // Sets the Y position of the form near the bottom of the screen.

            this.Location = new Point(StudentNumberX, StudentNumberY); // Places the form at the calculated X and Y positions.
            AnimationTimer.Start(); // Starts the timer to begin the leftward movement of the form.
        }
    }
}
