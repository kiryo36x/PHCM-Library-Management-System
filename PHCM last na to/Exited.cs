using System; //fundamental types and base classes
using System.Windows.Forms; //classes for creating Windows Forms applications

namespace PHCM_last_na_to
{
    public partial class Exited : Form
    {        
        public Exited()
        {
            InitializeComponent();
        }
        private void Exited_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false; //disabling the appearance in taskbar                   
        }
    }
}
