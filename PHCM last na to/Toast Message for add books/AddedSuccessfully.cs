using System; // Includes basic classes for general functionalities (e.g., working with strings, exceptions).
using System.Windows.Forms; // Provides classes for creating and managing Windows Forms applications (the user interface).

namespace PHCM_last_na_to.Toast_Message_for_add_books
{
    public partial class AddedSuccessfully : Form
    {
        public AddedSuccessfully()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); //close this form
        }
    }
}
