using System; // This line includes the basic System library, which contains essential types like numbers, strings, and other foundational elements for programming.
using System.Threading.Tasks; // This imports the library that allows us to handle tasks that run in the background without interrupting the main program. It helps manage long-running operations (like downloading files or waiting for a response) without freezing the app.
using System.Windows.Forms; // This brings in the Windows Forms library, which is used to create the graphical user interface (GUI) of the application. It lets you build forms, buttons, text boxes, and other visual elements.

namespace PHCM_last_na_to.Toast_Message_for_add_books
{
    public partial class Deleting : Form
    {
        public Deleting()
        {
            InitializeComponent();

        }

        private async void Deleting_Load(object sender, EventArgs e)
        {
            await Task.Delay(2000); //wait 2 seconds
            this.Close(); //close this form
        }
    }
}
