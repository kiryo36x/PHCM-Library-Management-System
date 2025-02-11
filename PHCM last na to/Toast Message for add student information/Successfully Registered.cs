using System; // This line brings in the basic system library, which provides essential functions and types, such as working with numbers, dates, and exceptions.
using System.Windows.Forms; // This line imports the library used for creating forms and controls in a Windows desktop application. It allows you to make buttons, text boxes, labels, and other graphical elements.

namespace PHCM_last_na_to.Toast_Message_for_add_student_information
{
    public partial class Successfully_Registered : Form
    {
        public Successfully_Registered()
        {
            InitializeComponent();
            this.CenterToParent(); //centering to parent       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); //closing this form
        }
    }
}
