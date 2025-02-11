using System; // Includes basic classes for general functionalities (e.g., working with strings, exceptions).
using System.Drawing; // Provides tools to work with graphics and images.
using System.Windows.Forms; // Provides classes for creating and managing Windows Forms applications (the user interface).

namespace PHCM_last_na_to.Toast_Message_for_add_books
{
    public partial class Author : Form
    {
        int AuthorX, AuthorY;
        public Author()
        {
            InitializeComponent();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            AuthorX -= 10; //deacreasing the X location of the form by 10
            this.Location = new Point(AuthorX, AuthorY); //declaring new location
            if (AuthorX <= 1625) //if the X reached 1625 below
            {
                AnimationTimer.Stop(); //stopping the timer
                AnimationEndTimer.Start(); //starting the second timer
            }
        }
        int x = 100;
        private void AnimationEndTimer_Tick(object sender, EventArgs e)
        {
            x--; //decreasing the X 
            if (x <= 0) //once the x is 0 or below
            {
                AuthorX += 1; //adding the X location of the form
                this.Location = new Point(AuthorX += 10, AuthorY); //new location of the form
                if (AuthorX > 2500) //of the form reached 2500 above
                {
                    AnimationEndTimer.Stop(); //stopping the form
                    x = 100; //setting to default
                    this.Close(); //closing the form
                }
            }
        }
        private void Position() //class for the position of the form
        {
            int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width; //our screen width
            int ScreenHeight = Screen.PrimaryScreen.WorkingArea.Height; // our screen height

            AuthorX = ScreenWidth - this.Width + 120; //assinging the emptyfield x as the width
            AuthorY = ScreenHeight - this.Height - 5; //assigning the emptyfield y as the width

            this.Location = new Point(AuthorX, AuthorY); //new location
            AnimationTimer.Start(); //starting the timer
        }

        private void Author_Load(object sender, EventArgs e)
        {
            Position();
        }
    }
}
