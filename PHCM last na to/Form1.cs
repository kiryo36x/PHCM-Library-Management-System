using System; //fundamental types and base classes
using System.Data; // Used for handling data (Sign up/Login, DataTables, DataSets)
using System.Drawing; // Accessing the system drawing
using System.Media; // Can use to play audio or music or video
using System.Threading.Tasks; // Supports asynchronous programming
using System.Windows.Forms; //classes for creating Windows Forms applications
using System.Data.SqlClient; //SQL Server databases


namespace PHCM_last_na_to
{        
    public partial class SignUp : Form
    {
        SqlConnection Connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"); //connecting to database of sql
        public static SignUp Instance {  get; private set; } //Form 1(Named: Sign up) as Instance to use by the other form
        private Form EmptyUsername; //if the username is empty and the log in button is clicked
        private Form EmptyPassword; //if the password is empty and the log in button is clicked
        private Form EmptyAll; //if the user and pass is empty and the log in button is clicked
        private Form IncorrectUserandPass; //if the user or pass is incorrect or (not available in database)
        private bool oneErrorLimit = false; //limiting the error pop message for only 1        
        
        public SignUp()
        {
            InitializeComponent();
            this.CenterToScreen(); //setting the form to center of our screen            

            Instance = this; //taking the current form to instance to used other form

            this.FormBorderStyle = FormBorderStyle.None; //setting the borderstyle of the form to none. removing head title
            BGPnL.BackColor = Color.FromArgb(100, 0, 0, 0); //setting the panel to transparent
            Declare.AsteriskSound.SoundLocation = "C:\\Users\\blood\\source\\repos\\PHCM last na to\\PHCM last na to\\Music and Sound\\Notice.wav"; //location of notice sound for custom notice
            Declare.WarningSound.SoundLocation = "C:\\Users\\blood\\source\\repos\\PHCM last na to\\PHCM last na to\\Music and Sound\\Windows Exclamation.wav"; //location of warning sound for custom  notice
            userIncorrect1.Visible = false; //Hiding the red textbox to show when username is either blank nor incorrect
            userIncorrect2.Visible = false; //Hiding the red textbox to show when username is either blank nor incorrect
            userIncorrect3.Visible = false; //Hiding the red textbox to show when username is either blank nor incorrect

            passIncorrect1.Visible = false; //Hiding the red textbox to show when password is either blank nor incorrect
            passIncorrect2.Visible = false; //Hiding the red textbox to show when password is either blank nor incorrect
            passIncorrect3.Visible = false; //Hiding the red textbox to show when password is either blank nor incorrect

            USERincMG1.Visible = false; //Hiding the image to show when username is either blank nor incorrect
            USERincIMG2.Visible = false; //Hiding the image to show when password is either blank nor incorrect

            userIncorrect1.ReadOnly = true; //setting the textbox read only so the user/client can't interact it
            userIncorrect2.ReadOnly = true; //setting the textbox read only so the user/client can't interact it
            userIncorrect3.ReadOnly = true; //setting the textbox read only so the user/client can't interact it
            passIncorrect1.ReadOnly = true; //setting the textbox read only so the user/client can't interact it
            passIncorrect2.ReadOnly = true; //setting the textbox read only so the user/client can't interact it
            passIncorrect3.ReadOnly = true; //setting the textbox read only so the user/client can't interact it
            password.PasswordChar = '*'; //setting the text password to *
        }        
        public static class Declare //Declarint class to global to use by the other form
        {
            public static SoundPlayer AsteriskSound { get; set; } = new SoundPlayer(); //declaring sound variable 
            public static SoundPlayer WarningSound { get; set; } = new SoundPlayer(); //declaring sound variable
            public static bool DragForm = true; //for draggable form if it's either enable to dragged (true) or unable (false)
        }        
        protected override void WndProc(ref Message m) //class for draggable form and never change by the other
        {
            // Constants to identify window messages and hit test results
            const int WM_NCHITTEST = 0x84; // Message for hit testing
            const int HTCLIENT = 0x1; // Client area of the window
            const int HTCAPTION = 0x2; // Title bar (draggable area)

            // Check if dragging the form is enabled and the current message is WM_NCHITTEST
            if (Declare.DragForm && m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m); // Pass the message to the base class for default processing

                /* If the hit test result is in the client area, change it to the caption area
                 This makes the form draggable by clicking anywhere in the client area*/
                if ((int)m.Result == HTCLIENT)
                    m.Result = (IntPtr)HTCAPTION;
                return; // Exit the method as the message has been handled
            }

            base.WndProc(ref m); // Pass the message to the base class for default processing if no special handling is needed
        }

        private void label2_MouseEnter(object sender, EventArgs e) //if the mouse entered the label
        {
            SignUp_label.ForeColor = Color.FromArgb(128, 128, 255); //changing the "Sign Up" color label
            SignUp_label.Cursor = Cursors.Hand; //changing the default cursor to hand
        }

        private void SignUp_label_MouseLeave(object sender, EventArgs e) //if the mouse leaved the label
        {
            SignUp_label.ForeColor = Color.White; //changing back to default color of "Sign Up"
            SignUp_label.Cursor = Cursors.Default; //returning the cursor back to default
        }

        private void label2_MouseEnter_1(object sender, EventArgs e) //if the mouse entered or touch the "X" label
        {
            label2.ForeColor = Color.Black; //changing the "X" to black once the mouse entered
            label3.Visible = true; //the "exit?" label show
            AskPnl.Visible = true; //the panel of "exit?" label show
            label2.Cursor = Cursors.Hand; //changing the default cursor to hand
        }

        private void label2_MouseLeave(object sender, EventArgs e) //if the mouse leaved "X"
        {
            label2.ForeColor = Color.White; //defaulting the color of "X"
            label3.Visible = false; //hiding the "exit?"
            AskPnl.Visible = false; // hiding the panel of "exit?"
            label2.Cursor = Cursors.Default; //returning the cursor back to default
        }

        private void label2_Click(object sender, EventArgs e) //once the client clicked the "X"
        {
            Declare.AsteriskSound.Play(); //play the notice sound
            DialogResult Confirmation = MessageBox.Show("Do you want to exit?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //showing a popup message

            if (Confirmation == DialogResult.Yes) //when the client clicked the yes in the popup message
            {
                wait(); //executes the class
            }
            else //if the user didn't click yes but no instead
            {
                Declare.DragForm = true; //returning the dragform back to true
            }
        }
        private async void wait() //executes this block of code if the user clicked yes in the popup message earlier 
        {
            Form closingForm = new Exited(); //creating a custom form for exiting
            Declare.DragForm = false; //setting the form to unable to drag so while the system is exiting the form is unable to drag
            closingForm.Show(); //showing the form created 
            await Task.Delay(3000); //sets delay of to 3 seconds (wait 3 seconds)
            closingForm.Close(); //closing the form created
            this.Close(); //closing signUp form(form/current form)
        }
        private void SignUp_FormClosed(object sender, FormClosedEventArgs e) //if this form is closed
        {
            MessageBox.Show("Form Closed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information); //pop up show after the form is closed
            System.Environment.Exit(0); //closing all the form/stopping the compiler (alternative: Apllication.Exit(0)
        }
        private void SignUp_Load(object sender, EventArgs e) //once this form is loaded
        {
            this.MaximizeBox = false; //setting maximize to false so the form won't be fullscreen
            this.MinimizeBox = false; //setting minimize to false so the form won't be hidden in taskbar
            this.ControlBox = false; //setting the controlbox to false so the title of this form, icon, the (-), ([]) and X to be hidden and disable
            this.SizeGripStyle = SizeGripStyle.Hide;  //so the form is unable to resize
        }

        private void SignUp_label_Click(object sender, EventArgs e)  //when the sign up label is clicked
        {
            userIncorrect1.Visible = false; //Hiding the red textbox to show when username is either blank nor incorrect
            userIncorrect2.Visible = false; //Hiding the red textbox to show when username is either blank nor incorrect
            userIncorrect3.Visible = false; //Hiding the red textbox to show when username is either blank nor incorrect

            passIncorrect1.Visible = false; //Hiding the red textbox to show when password is either blank nor incorrect
            passIncorrect2.Visible = false; //Hiding the red textbox to show when password is either blank nor incorrect
            passIncorrect3.Visible = false; //Hiding the red textbox to show when password is either blank nor incorrect

            USERincMG1.Visible = false; //Hiding the image to show when username is either blank nor incorrect
            USERincIMG2.Visible = false; //Hiding the image to show when password is either blank nor incorrect

            if (Register.Instance != null) //if the Register form (Form2) was already created and is still hiding 
            {
                Register.Instance.Show(); //the Register Form (Form2) will show
                Register.Instance.BringToFront(); //bringing to the front of the screen
                password.Text = ""; //clearing the inputted password text 
                username.Text = ""; //clearing the inputted username text 
                this.Hide(); //the Log in Form (Form1) will hide
            }
            else //if the form isn't created yet
            {
                password.Text = ""; //clearing the inputted password text 
                username.Text = ""; //clearing the inputted username text 
                Form openRegister = new Register(); //creating a Register form (form2)
                openRegister.Show(); //showing the new Register Form (Form2)
                this.Hide(); //form 1 will hide
            }            
        }
        private void SignUp_VisibleChanged(object sender, EventArgs e) //visible change when the form is opened
        {
            if (this.Visible) //if the sign up label visible is show
            {
                this.CenterToScreen(); //centering the form to screen
            }
        }       
        private void LogInBtn_Click(object sender, EventArgs e) //when the Log in button is clicked
        {
            LoggedIn(); //entering the homepage         
        }
        private async void LoggedIn()
        {
            if (username.Text == "" && password.Text == "") //clearing the text inside both username and password text box
            {
                if (!oneErrorLimit)
                {
                    oneErrorLimit = true; //if the popup message error appeared
                    Declare.AsteriskSound.Play(); //play the notice ound 
                    await Task.Delay(500); //waait 500 millisecond
                    isAllEmpty(); //execute class                    
                }
            }
            else if (username.Text == "") //clearing the text inside of username text box
            {
                if (!oneErrorLimit)
                {
                    oneErrorLimit = true; //if the popup message error appeared
                    Declare.AsteriskSound.Play(); //play the notice sound
                    await Task.Delay(500); //wait 500 millisecond
                    isUsernameEmpty(); //execute class                  
                }
            }
            else if (password.Text == "") //clearing the text inside of password text box
            {
                if (!oneErrorLimit) 
                {
                    Declare.AsteriskSound.Play(); //play the notice sound 
                    await Task.Delay(500); //wait 500 millisecond
                    isPasswordEmpty(); //execute class                  
                }
            }
            else //if the username and password is filled
            {
                oneErrorLimit = false; //if the popup message error appeared
                if (Connect.State != ConnectionState.Open) //if the sql server state isn't open
                {
                    try //trying to open the sql server
                    {
                        Connect.Open(); //opening the sql server
                        String SelectData = "SELECT * FROM admin WHERE username = @username AND passowrd = @passowrd"; //taking a main value from sql if it's exist
                        using (SqlCommand cmd = new SqlCommand(SelectData, Connect)) //commanding sql (taking value, sql database)
                        {
                            cmd.Parameters.AddWithValue("@username", username.Text); // Add the username parameter to the SQL command, using the value from the username TextBox /////////////////////////////////////////////////////////////////////
                            cmd.Parameters.AddWithValue("@passowrd", password.Text); // Add the password parameter to the SQL command, using the value from the password TextBox
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Create a new SqlDataAdapter to execute the command and fetch the results
                            DataTable table = new DataTable(); // Creaing new DataTable to store the data retrieved from the database
                            adapter.Fill(table); // Fill the DataTable with the data retrieved by the SqlDataAdapter

                            if (table.Rows.Count >= 1) // if the dataa table of sql database has the value of 1 above (if client/user signed in)
                            {
                                string takeUsername = username.Text; //taking the text value of username textbox
                                Form form = new Homepage(takeUsername); //creating a form to go homepage
                                this.Hide(); //hiding the log in form(form 1)   
                                username.Text = ""; //clearing the text in username
                                password.Text = ""; //clearing the text in password

                                form.Show(); //show the homepage
                            }
                            else
                            {
                                if (!oneErrorLimit)
                                {
                                    Declare.AsteriskSound.Play(); //play notice sound for incorrect login
                                    await Task.Delay(500); //wait 500 milliseconds
                                    IncorrectLogin(); //execute incorrectlogin class
                                    username.Focus();
                                }
                            }
                        }
                    }
                    catch (Exception ex) //if the server is unable to open/connect
                    {
                        MessageBox.Show("Error Connecting Database: " + ex, "Can't Connect!", MessageBoxButtons.OK, MessageBoxIcon.Error); //show the result of error
                    }
                    finally //after loging in, the sql will close
                    {
                        Connect.Close(); //closed sql
                    }
                }
            }
        }
        private void isUsernameEmpty() //creating a class if the username is still empty
        {

            EmptyUsername = new Form() //creating a custom form for username notice
            {
                Size = new Size(350, 120), //size of the form
                StartPosition = FormStartPosition.CenterScreen, //setting the form to the center
                BackgroundImage = Image.FromFile(@"C:\Users\blood\source\repos\PHCM last na to\PHCM last na to\Resources\Loading.png"), //locating the image saved in the solution explorer
                FormBorderStyle = FormBorderStyle.None, //removing the title header
                MinimizeBox = false, //disabling minimizing form
                ShowInTaskbar = false, //disabling the visibility of the form in the taskbar
                MaximizeBox = false, //disabling maximizing form
                BackColor = SystemColors.Control, //changing the color of the form to control 
                BackgroundImageLayout = ImageLayout.Tile //setting the background of the image to tile to repeat the image of the background
            };            

            System.Windows.Forms.Label SuccessLabel = new System.Windows.Forms.Label() //creating a first label 
            {
                Text = "Please fill the username", //setting the label text
                Size = new Size(155, 45), //setting the size
                Font = new Font("Nirmala UI", 18, FontStyle.Regular), //changing the font
                ForeColor = Color.White, //text color of the label
                BackColor = Color.Transparent, //background color of the text
                Padding = new Padding(0), //border of the text (top & bottom)
                Margin = new Padding(0), //border of the text (left & right)
                AutoSize = true //setting the label to autosize, once the form was accidentally resize
            };
            Panel HeadPanel = new Panel() //creating a panel
            {
                Size = new Size(529, 27), //size of the panel
                Location = new Point(-7, -2), //setting it's location
                BackColor = SystemColors.Control //background color of the panel

            };
            System.Windows.Forms.Label NoticeLabel = new System.Windows.Forms.Label() //creating new label
            {
                Text = "Notice", //setting its text 
                Size = new Size(46, 17), //size of the label
                Location = new Point(155, 5), //location
                ForeColor = Color.Black, //text color
                Font = new Font("Nirmala UI", 8, FontStyle.Regular), //font of the label
                FlatStyle = FlatStyle.Standard, //default label flatstle
                AutoSize = true, //setting the label to autosize, once the form was accidentally resize
                TabIndex = 1 //setting tab index (default was 0) when pressing tab, this label will interact
            };
            Button Addbutton = new Button() //creating a button
            {
                Text = "Okay",  //setting its text
                Size = new Size(60, 25), //size of the label
                Location = new Point((NoticeLabel.Location.X - 5), 88), //setting its location (the location of the notice label was 130 decrasing it by 10 which is x=120 & y=88
                ForeColor = Color.Black, //color text
                BackColor = Color.White, //background color
                Padding = new Padding(0), //top & both space border
                Margin = new Padding(0), //left & right space border
                FlatStyle = FlatStyle.Flat, //repeat text once the button was resize 
                Font = new Font("Nirmala Ui", 8, FontStyle.Regular) //font
            };
            SuccessLabel.Location = new Point((NoticeLabel.Location.X - 135), 30); //setting its location (130 - 135 is X = -5 & Y = 30)

            NoticeLabel.BringToFront(); //bringing the notice label to front 
            HeadPanel.SendToBack(); //sending it to back 
            SuccessLabel.SendToBack(); //sending it to back 
            Addbutton.BringToFront(); // bringing it to back 
            Addbutton.FlatAppearance.BorderSize = 0; //setting the border of the button to none (removing)

            Addbutton.Click += new EventHandler(EmptyUsernameOK); //create an event for button (when the button is clicked)

            EmptyUsername.Controls.Add(SuccessLabel); EmptyUsername.Controls.Add(NoticeLabel); EmptyUsername.Controls.Add(HeadPanel); EmptyUsername.Controls.Add(Addbutton); //adding all the created label and button to the specific form
            EmptyUsername.ShowDialog(); //showing the new form
        }
        private void isPasswordEmpty() //a class for the empty password 
        {
            EmptyPassword = new Form() //new form
            {
                Size = new Size(350, 120), //size
                StartPosition = FormStartPosition.CenterScreen, //center of the screen
                BackgroundImage = Image.FromFile(@"C:\Users\blood\source\repos\PHCM last na to\PHCM last na to\Resources\Loading.png"), //location of the image for form
                FormBorderStyle = FormBorderStyle.None, //removing head title
                MinimizeBox = false, //disabling minimizing of the form
                ShowInTaskbar = false, //disabling the visibility of the form in the task bar
                MaximizeBox = false, //disabling maximizing of the form
                BackColor = SystemColors.Control, //background color
                BackgroundImageLayout = ImageLayout.Tile //repeat background image
            };
            System.Windows.Forms.Label SuccessLabel = new System.Windows.Forms.Label() //creaing new label
            {
                Text = "Please fill the password", //text
                Size = new Size(155, 45), //size
                Font = new Font("Nirmala UI", 18, FontStyle.Regular), //font
                ForeColor = Color.White, //color of the text
                BackColor = Color.Transparent, //background color
                Padding = new Padding(0), //top and bot border
                Margin = new Padding(0), //left and right border
                AutoSize = true //auto size when the form is resize
            };
            Panel HeadPanel = new Panel()  //creating new panel
            {
                Size = new Size(529, 27), //size
                Location = new Point(-7, -2), //location 
                BackColor = SystemColors.Control, //background color of the panel

            };
            System.Windows.Forms.Label NoticeLabel = new System.Windows.Forms.Label() //new label
            {
                Text = "Notice", //text
                Size = new Size(46, 17), //size 
                Location = new Point(155, 5), //location
                ForeColor = Color.Black, //color of the text
                Font = new Font("Nirmala UI", 8, FontStyle.Regular), //font
                FlatStyle = FlatStyle.Standard, //default
                AutoSize = true, //auto size
                TabIndex = 1 //when the tab is presseed 
            };
            Button Addbutton = new Button() //new button
            {
                Text = "Okay", //text
                Size = new Size(60, 25), //size
                Location = new Point((NoticeLabel.Location.X - 5), 88), //location
                ForeColor = Color.Black, //color of the text
                BackColor = Color.White, //background color 
                Padding = new Padding(0), //top and bot border 
                Margin = new Padding(0), //left and right border
                FlatStyle = FlatStyle.Flat, //trying to remove the border 
                Font = new Font("Nirmala Ui", 8, FontStyle.Regular) //font
            };
            SuccessLabel.Location = new Point((NoticeLabel.Location.X - 135), 30); //location

            NoticeLabel.BringToFront(); //bringing the label to front
            HeadPanel.SendToBack(); //bringing the panel to back
            SuccessLabel.SendToBack(); //bringing the pabel to back
            Addbutton.BringToFront(); //bringing the button to front
            Addbutton.FlatAppearance.BorderSize = 0; //attempting to remove the border if the previous one is failer

            Addbutton.Click += new EventHandler(EmptyPasswordOK); //creating a new event for button if it's clicked

            EmptyPassword.Controls.Add(SuccessLabel); EmptyPassword.Controls.Add(NoticeLabel); EmptyPassword.Controls.Add(HeadPanel); EmptyPassword.Controls.Add(Addbutton); //adding all the labels and buttons to the specific form
            EmptyPassword.ShowDialog(); //showing the form
        }
        private void isAllEmpty() //declaring a class once the user and pass is empty but the button is clicked
        {            
            EmptyAll = new Form()  //creating a form 
            {
                Size = new Size(350, 120), //size 
                StartPosition = FormStartPosition.CenterScreen, //centering the form 
                BackgroundImage = Image.FromFile(@"C:\Users\blood\source\repos\PHCM last na to\PHCM last na to\Resources\Loading.png"), //location of the image for the background
                FormBorderStyle = FormBorderStyle.None, //removing title header
                MinimizeBox = false, //disabling minimize of the form
                ShowInTaskbar = false, //disabling the visibility of the form to the task bar
                MaximizeBox = false, //disabling maximize of the form
                BackColor = SystemColors.Control, //background color
                BackgroundImageLayout = ImageLayout.Tile //repetition of image if the image reached its normal size
            };

            System.Windows.Forms.Label SuccessLabel = new System.Windows.Forms.Label() //creating label
            {
                Text = "Please fill all the blanks", //text
                Size = new Size(155, 45), //size
                Font = new Font("Nirmala UI", 18, FontStyle.Regular), //font
                ForeColor = Color.White, //color of the text 
                BackColor = Color.Transparent, //background color
                Padding = new Padding(0), //top and bot border 
                Margin = new Padding(0), //left and right border
                AutoSize = true //auto size once the panel is resize
            };
            Panel HeadPanel = new Panel() //creating panel
            {
                Size = new Size(529, 27), //size
                Location = new Point(-7, -2), //locayion
                BackColor = SystemColors.Control, //background color of the panel

            };
            System.Windows.Forms.Label NoticeLabel = new System.Windows.Forms.Label() //creating new label
            {
                Text = "Notice", //text
                Size = new Size(46, 17), //size
                Location = new Point(155, 5), //location
                ForeColor = Color.Black, //color of the text
                Font = new Font("Nirmala UI", 8, FontStyle.Regular), //font  
                FlatStyle = FlatStyle.Standard, //default flat style
                AutoSize = true, //auto size once the form is resize
                TabIndex = 1 //tab index when the tab is pressed
            };
            Button Addbutton = new Button() //creating button
            {
                Text = "Okay", //text
                Size = new Size(60, 25), //size
                Location = new Point((NoticeLabel.Location.X - 5), 88), //locatiom
                ForeColor = Color.Black, //color of the text
                BackColor = Color.White, //background color of the button
                Padding = new Padding(0), //top and both border
                Margin = new Padding(0), //left and right border
                FlatStyle = FlatStyle.Flat,//no border
                Font = new Font("Nirmala Ui", 8, FontStyle.Regular) //font
            };
            SuccessLabel.Location = new Point((NoticeLabel.Location.X - 135), 30); //location

            NoticeLabel.BringToFront(); //label to the front of the panel
            HeadPanel.SendToBack(); //panel to the back
            SuccessLabel.SendToBack(); //label to the back
            Addbutton.BringToFront(); //button to the fornt
            Addbutton.FlatAppearance.BorderSize = 0; //removing the border size

            Addbutton.Click += new EventHandler(EmptyAllOK); //declaring a new button for a button when clicked

            EmptyAll.Controls.Add(SuccessLabel); EmptyAll.Controls.Add(NoticeLabel); EmptyAll.Controls.Add(HeadPanel); EmptyAll.Controls.Add(Addbutton); //adding all the created button and label to the form
            EmptyAll.ShowDialog(); //showing the custom notice/popup message empty form
        }
        private void EmptyUsernameOK(object sender, EventArgs e) //when the button is clicked 
        {
            oneErrorLimit = false;
            userIncorrect1.Visible = true; //enabling the visibility of the red border design error
            userIncorrect2.Visible = true; //enabling the visibility of the red border design error
            userIncorrect3.Visible = true; //enabling the visibility of the red border design error
            USERincMG1.Visible = true; //disabling the visibility of the error image
            username.Focus();
            EmptyUsername.Close(); //closing the error form when the username is empty
        }
        private void EmptyPasswordOK(object sender, EventArgs e) //when the button is clicked 
        {
            oneErrorLimit = false;
            passIncorrect1.Visible = true; //enabling the visibility of the red border design error
            passIncorrect2.Visible = true; //enabling the visibility of the red border design error
            passIncorrect3.Visible = true; //enabling the visibility of the red border design error
            USERincIMG2.Visible = true;  //disabling the visibility of the error image
            username.Focus();
            EmptyPassword.Close(); //closing the error form when the password is empty
        }        
        private void EmptyAllOK(object sender, EventArgs e) //when the button is clicked 
        {
            oneErrorLimit = false;
            userIncorrect1.Visible = true; //enabling the visibility of the red border design error
            userIncorrect2.Visible = true; //enabling the visibility of the red border design error
            userIncorrect3.Visible = true; //enabling the visibility of the red border design error
           
            passIncorrect1.Visible = true; //enabling the visibility of the red border design error
            passIncorrect2.Visible = true; //enabling the visibility of the red border design error 
            passIncorrect3.Visible = true; //enabling the visibility of the red border design error

            USERincMG1.Visible = true;  //disabling the visibility of the error image
            USERincIMG2.Visible = true; //disabling the visibility of the error image
            username.Focus();
            EmptyAll.Close(); //closing the error form when the both user and pass is empty
        }
        private void IncorrectLogin() //class for incorrect log in
        {            
            IncorrectUserandPass = new Form() //creating a form
            {
                Size = new Size(395, 120), //size 
                StartPosition = FormStartPosition.CenterScreen, //centering the form to the screen
                BackgroundImage = Image.FromFile(@"C:\Users\blood\source\repos\PHCM last na to\PHCM last na to\Resources\Loading.png"), //location of the image for background
                FormBorderStyle = FormBorderStyle.None, //removing title header
                MinimizeBox = false, //disabling minimize for form
                ShowInTaskbar = false, //disabling the visibility of the form in the task bar
                MaximizeBox = false, //disabling maximize for form 
                BackColor = SystemColors.Control, //background color
                BackgroundImageLayout = ImageLayout.Tile //repeats image
            };
            System.Windows.Forms.Label SuccessLabel = new System.Windows.Forms.Label() //creating a label
            {
                Text = "Incorrect Username or Password", //setting label text 
                Size = new Size(250, 45),// size
                Font = new Font("Nirmala UI", 15, FontStyle.Regular), //font 
                ForeColor = Color.White, //color of the text 
                BackColor = Color.Transparent, //color of the background
                Padding = new Padding(0), //top and bottom border
                Margin = new Padding(0), //left and right border
                AutoSize = true //sets true once the form resized
            };
            Panel HeadPanel = new Panel() //creating a panel
            {
                Size = new Size(529, 27), //size 
                Location = new Point(-7, -2), //location 
                BackColor = SystemColors.Control, //background color of the panel

            };
            System.Windows.Forms.Label NoticeLabel = new System.Windows.Forms.Label() //creating new label
            {
                Text = "Notice", //changing the label text
                Size = new Size(46, 17), //size 
                Location = new Point(185, 5),  //location
                ForeColor = Color.Black, //color of the text
                Font = new Font("Nirmala UI", 8, FontStyle.Regular), //font
                FlatStyle = FlatStyle.Standard, //default text style 
                AutoSize = true, //set auto size 
                TabIndex = 1 //setting tab index to 1 for second to interact once the tab button was pressed (default 0)
            };
            Button Addbutton = new Button() //creating new button
            {
                Text = "Okay", //text
                Size = new Size(60, 25), //size
                Location = new Point((NoticeLabel.Location.X - 5), 88), //location
                ForeColor = Color.Black, //color of the text
                BackColor = Color.White, //background color of the button
                Padding = new Padding(0), //top and bot border
                Margin = new Padding(0), //left and right border
                FlatStyle = FlatStyle.Flat, //removing border
                Font = new Font("Nirmala Ui", 8, FontStyle.Regular) //font
            };
            SuccessLabel.Location = new Point(15, 30); //location of the label

            NoticeLabel.BringToFront(); //sending label to front
            HeadPanel.SendToBack(); //sending panel to front so the label can be seen
            SuccessLabel.SendToBack(); //label sending to back
            Addbutton.BringToFront(); //button to the front
            Addbutton.FlatAppearance.BorderSize = 0; //removing the button bordersize if the previous one was failed

            Addbutton.Click += new EventHandler(IncorrectLoginOk); //event for a button once it clocked

            IncorrectUserandPass.Controls.Add(SuccessLabel); IncorrectUserandPass.Controls.Add(NoticeLabel); IncorrectUserandPass.Controls.Add(HeadPanel); IncorrectUserandPass.Controls.Add(Addbutton); //adding all the buttons, panels and labels to the form
            IncorrectUserandPass.ShowDialog(); //showing the form
        }
        private void IncorrectLoginOk(object sender, EventArgs e) //if the button was clicked and the username or password is incorrect
        {
            oneErrorLimit = false;
            username.Text = ""; //clearing all the text inside of the username box
            password.Text = ""; //clearing all the text inside of the password box

            userIncorrect1.Visible =  true; //enabling the visibility of the red border design error
            userIncorrect2.Visible = true; //enabling the visibility of the red border design error
            userIncorrect3.Visible = true; //enabling the visibility of the red border design error

            passIncorrect1.Visible = true; //enabling the visibility of the red border design error
            passIncorrect2.Visible = true; //enabling the visibility of the red border design error
            passIncorrect3.Visible = true; //enabling the visibility of the red border design error

            USERincMG1.Visible = true; //enabling the visibility of the error image for username
            USERincIMG2.Visible = true; //enabling the visibility of the error image for password
            IncorrectUserandPass.Close(); //closed the customized notice error log in form/popup message
        }

        private void username_TextChanged(object sender, EventArgs e) //event of the text box username once the text was inputted inside or deleted some text(backspace)
        {
            userIncorrect1.Visible = false; //disabling the visibility of the red border design error
            userIncorrect2.Visible = false; //disabling the visibility of the red border design error
            userIncorrect3.Visible = false; //disabling the visibility of the red border design error
            USERincMG1.Visible = false; //disabling the visibility of the error image
        }

        private void password_TextChanged(object sender, EventArgs e) //event of the text box password once the text was inputted inside or deleted some text(backspace)
        {            
            passIncorrect1.Visible = false; //disabling the visibility of the red border design error
            passIncorrect2.Visible = false; //disabling the visibility of the red border design error
            passIncorrect3.Visible = false; //disabling the visibility of the red border design error
            USERincIMG2.Visible = false; //disabling the visibility of the error image
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //event of the checkbox once the box was checked
        {
            if (password.PasswordChar == '*') //checking if the password was already set to * (hiding password)
            {
                password.PasswordChar = '\0'; // Show password
            }
            else
            {
                password.PasswordChar = '*'; // Hide password
            }
        }       
        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) //pressing enter
            {
                LoggedIn(); //executes the logged in class
            }            
        }

        private void username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) //pressing enter
            {
                LoggedIn(); //executes the logged in class
            }
        }
    }
}