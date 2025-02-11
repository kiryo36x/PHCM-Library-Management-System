using System; //fundamental types and base classes
using System.Threading.Tasks; // Supports asynchronous programming
using System.Windows.Forms; //classes for creating Windows Forms applications

namespace PHCM_last_na_to
{
    public partial class Loading : Form
    {        
        public Loading()
        {
            InitializeComponent();
            this.CenterToScreen(); //centering the loading form
            this.FormBorderStyle = FormBorderStyle.None; //removing the header     
            SETFadeAnimation.Start();  //start the timer
        }
        private void timer1_Tick(object sender, EventArgs e) //increasing the opacity/showing the form slowly
        {
            this.Opacity += .10;
            if (this.Opacity >= 1) //if it hit's 1 (default)
            {               
                SETFadeAnimation.Stop(); //stopping the timer
                Loading1(); //executing the next loading class
            }            

        }
        private void SetLoading_Tick(object sender, EventArgs e)
        {
            LoadingPanel.Width += 4; //adding width looks the panel to be animation loading

            if (LoadingPanel.Width >= FullLoaded.Width) //if it hits the hidden panel widt
            {
                SetLoading.Stop(); //stopping the loading
                Loading2(); //starting the last loading
                                
            }
        }

        private async void Loading1()
        {
            SETFadeAnimation.Stop(); //stopping the timer
            await Task.Run(() => //delaying for 3.5 seconds (alternative: await Task.Delay(3500)
            {
                for (int i = 0; i < 35; i++)
                {
                    
                    System.Threading.Thread.Sleep(100);
                }
            });           
            LoadingLbl.Visible = true; //setting the label "Loading" visible

            await Task.Run(() =>
            {
                for (int i = 0; i < 15; i++) //delaying for 1.5 seconds (alternative: await Task.Delay(1500)
                {

                    System.Threading.Thread.Sleep(100);
                }
            });
            LoadingPanel.Visible = true; //starting the loding animation
            await Task.Run(() =>
            {
                for (int i = 0; i < 20; i++) //delaying for 2 seconds (alternative: await Task.Delay(2000)
                {

                    System.Threading.Thread.Sleep(100);
                }
            });
            SetLoading.Start(); //starting the animation
            
        }
        private async void Loading2()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)  //delaying for 2 seconds (alternative: await Task.Delay(2000)
                {
                    System.Threading.Thread.Sleep(100); 
                }
            });
            LoadingLbl.Visible = false; //the label "Loading" will be hidden
            label3.Visible = true; //the label "Loaded" will show
            Cursor = Cursors.WaitCursor;
            await Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    System.Threading.Thread.Sleep(100); //delaying for 2 seconds (alternative: await Task.Delay(2000)
                }
            });
            Cursor = Cursors.Default;
            Form open = new SignUp(); //creating a form for sign up
            open.Show(); //showing the form
            this.Hide(); //hiding this form
        }
    }
}
