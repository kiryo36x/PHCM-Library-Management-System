using System; //fundamental types and base classes
using System.Data; // Used for handling data (Sign up/Login, DataTables, DataSets)
using System.Drawing; // Accessing the system drawin
using System.Linq; // Enables querying collections using LINQ (Language Integrated Query)
using System.Threading.Tasks; // Supports asynchronous programming
using System.Windows.Forms; //classes for creating Windows Forms applications
using static PHCM_last_na_to.SignUp; // Imports all the members inside from the SignUp class
using System.Data.SqlClient; //SQL Server databases

namespace PHCM_last_na_to
{
    public partial class Register : Form
    {
        //connecting the database
        SqlConnection Connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30");
        private Form SuccessForm; //creating a success form for registration success
        private Form UserAlrExist; //creating an already exist form for a user if the account is already exist or its username
        public static Register Instance { get; private set; } //Create a public static instance of the Register class to allow global access
        public Register()
        {
            InitializeComponent();

            Instance = this; // Assign the current instance to the static Instance variable

            this.MaximizeBox = false; //setting the maximize box to false 
            this.MinimizeBox = false; //setting the minimize box to false
            this.CenterToScreen(); //centering to our screen
            this.FormBorderStyle = FormBorderStyle.None; //removing the border of the form        
                                     
        }

        private void Form2_Load(object sender, EventArgs e) //when the form is full loaded
        {            
            ImgLogo.SendToBack(); label2.BringToFront(); label3.BringToFront(); //sending all the mentioned label and image to front
            label2.Visible = true; // Make label2 visible
            label3.Visible = false; // Hide label3 initially
            AskPnl.Visible = false; // Hide the AskPnl panel initially

            BGPnL.BackColor = Color.FromArgb(100, 0, 0, 0); // Set background panel transparency

            this.ControlBox = false; // Remove the control box (close, minimize, maximize)

            PWbx.PasswordChar = '*'; // Mask password input with asterisks (*)            
        }
        protected override void WndProc(ref Message m) // This method allows the form to be draggable even if it has no title bar.
        {
            const int WM_NCHITTEST = 0x84; // Message sent to determine which part of the window was clicked.
            const int HTCLIENT = 0x1; // Represents the client area (inside the window).
            const int HTCAPTION = 0x2; // Represents the title bar area (used for dragging).

            if (Declare.DragForm && m.Msg == WM_NCHITTEST)
            {
                // Call the base method to process the message.
                base.WndProc(ref m);

                // If the clicked area is the client area (inside the form),
                // change it to the title bar area, making the window draggable.
                if ((int)m.Result == HTCLIENT)
                    m.Result = (IntPtr)HTCAPTION;

                return; // Stop further processing.
            }
            // Call the base method for all other messages.
            base.WndProc(ref m);
        }
        private void label2_Click(object sender, EventArgs e) //if the label is clicked
        {
            Declare.AsteriskSound.Play(); //play the sound
            DialogResult Confirmation = MessageBox.Show("Do you want to exit?", "Confirm?", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question); //give a pop message question

            if (Confirmation == DialogResult.Yes) //if the user press yes
            {
                wait(); //initiate the class
            }
            else
            {
                Declare.DragForm = true; //setting the form to be draggable again
            }
        }
        private async void wait() //a class for an exit form
        {
            Form closingForm = new Exited(); //create new form
            Declare.DragForm = false; //setting the form to undraggable
            closingForm.Show(); //show the form as modal
            await Task.Delay(3000); //delay for 3 seconds
            closingForm.Close(); //closing the form
            this.Close(); //closing this form
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e) //when the form is closed
        {
            MessageBox.Show("Form Closed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information); //show a pop up message 
            System.Environment.Exit(0); //closing the program (Alternative: Application.Exit();)
        }
        public void exitClearSignIn() //if exited the sign in
        {
            FNPNLappearbx.Visible = false;  //hide 
            FNlettersREMINDbx.Visible = false; //hide
            MDNPNLAppearbx.Visible = false; //hide
            MDNReminder.Visible = false; //hide
            SRNPNLAppearbx.Visible = false; //hide
            SRREMINDER.Visible = false; //hide
            CTPNLAppearBX.Visible = false; //hide
            CTReminder.Visible = false; //hide

            FrstNMTXTbx.Visible = true; MDLNMbx.Visible = true; SRNMbx.Visible = true; CTnobx.Visible = true; USRNMbx.Visible = true; PWbx.Visible = true; //making all the text box to be visible if isn't visible
            Firstname_label.Visible = true; MiddleName_label.Visible = true; Surname_Label.Visible = true; ContactNo_Label.Visible = true; Username_Label.Visible = true; password_Label.Visible = true; //setting all the label to be visible if isn't visible
        }
        private void button1_Click(object sender, EventArgs e) //when the button is clicked
        {
            if (String.IsNullOrEmpty(FrstNMTXTbx.Text) && String.IsNullOrEmpty(MDLNMbx.Text)
                && String.IsNullOrEmpty(SRNMbx.Text) && String.IsNullOrEmpty(CTnobx.Text)
                && String.IsNullOrEmpty(USRNMbx.Text) && String.IsNullOrEmpty(PWbx.Text)) //if all the text box is empty
            {
                if (SignUp.Instance != null) //if the form is exis
                {
                    SignUp.Instance.Show(); //show the form
                    SignUp.Instance.BringToFront(); //bringing it to front
                    this.Hide(); //hiding this form
                }
                else //if form isn't exist
                {
                    SignUp CreateSignUp = new SignUp(); //creating new form
                    CreateSignUp.Show(); //showing the form
                    this.Hide(); //hiding this form
                }
            }
            else if(int.TryParse(FrstNMTXTbx.Text, out int Fname) || int.TryParse(MDLNMbx.Text, out int Mname)
                || int.TryParse(USRNMbx.Text, out int Lname) || int.TryParse(CTnobx.Text, out int Cno)
                || int.TryParse(USRNMbx.Text, out int Uname) || int.TryParse(PWbx.Text, out int PW)) //changing all the text box value from string to integer
            {              
                Declare.WarningSound.Play(); //play the soubd
                DialogResult ChckExit = MessageBox.Show("Register is in process. " +
                    "\nAre you sure you want to exit? \nYour progress won't be saved!",
                    "Process can be undone!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); //creating a pop message for user to ask
                if (ChckExit == DialogResult.Yes) //if the user click yes
                {
                    if (SignUp.Instance != null) //if the form is already exist
                    {
                        FrstNMTXTbx.Text = ""; MDLNMbx.Text = ""; SRNMbx.Text = ""; CTnobx.Text = ""; USRNMbx.Text = ""; PWbx.Text = ""; //clearing all the textbox
                        exitClearSignIn(); //initiate the class
                        SignUp.Instance.Show(); //show the form
                        SignUp.Instance.BringToFront(); //bringing it to front
                        this.Hide(); //hiding this form
                    }
                    else //if the form is not exist
                    {
                        exitClearSignIn(); //initiate the class
                        FrstNMTXTbx.Text = ""; MDLNMbx.Text = ""; SRNMbx.Text = ""; CTnobx.Text = ""; USRNMbx.Text = ""; PWbx.Text = "";  //clearing all the textbox
                        SignUp CreateSignUp = new SignUp(); //createes new form
                        CreateSignUp.Show(); //showing the form
                        this.Hide(); //hiding this form
                    }
                }
            }                            
            else //if the user return to log in form and some of the textbox is already existed
            {
                Declare.WarningSound.Play(); //play the sound
                DialogResult ChckExit = MessageBox.Show("Register is in process. " +
                    "\nAre you sure you want to exit? \nYour progress won't be saved!",
                    "Process can be undone!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);  //creating a pop message for user to ask
                if (ChckExit == DialogResult.Yes) //if the user click yes
                {
                    if (SignUp.Instance != null) //if the form is already exist
                    {
                        FrstNMTXTbx.Text = ""; MDLNMbx.Text = ""; SRNMbx.Text = ""; CTnobx.Text = ""; USRNMbx.Text = ""; PWbx.Text = ""; //clearing all the textbox
                        SignUp.Instance.Show(); //showing the form
                        SignUp.Instance.BringToFront(); //bringing the form to front 
                        this.Hide(); //hiding this form
                    }
                    else //if the form is already exist
                    {
                        FrstNMTXTbx.Text = ""; MDLNMbx.Text = ""; SRNMbx.Text = ""; CTnobx.Text = ""; USRNMbx.Text = ""; PWbx.Text = ""; //clearing all the textbox
                        SignUp CreateSignUp = new SignUp(); //creating new form
                        CreateSignUp.Show(); //showing the form
                        this.Hide(); //hiding this form
                    }
                }
            }
        }

        private void Register_VisibleChanged(object sender, EventArgs e) //if the register textbox inserted or deleted letter or numbers 
        {
            if (this.Visible) //if this form is visible
            {
                this.CenterToScreen(); //centering this to screen
            }
        }

        private void label2_MouseEnter(object sender, EventArgs e) //if the mouse touch the  label
        {
            label2.ForeColor = Color.Black; //changing the text color 
            label3.Visible = true; //showing the label
            AskPnl.Visible = true; //showing the panel
        }

        private void label2_MouseLeave(object sender, EventArgs e) //if the mouse untouched the label
        {
            label2.ForeColor = Color.White; //returning the text to default (white)
            label3.Visible = false; //hiding the label
            AskPnl.Visible = false; //hiding the panel
        }
        //------------------------------------------------------------------------------------------------------//


        private void FrstNMTXTbx_TextChanged(object sender, EventArgs e) //if the first name text box inserted or deleted letter or numbers 
        {
            if (FrstNMTXTbx.Text.Any(Char.IsDigit)) //if the textbox contain number
            {
                FNPNLappearbx.Visible = true; //show the panel
                FNlettersREMINDbx.Visible = true; //show label
                LogInBtn.Enabled = false; //disabling the button

                MDLNMbx.Visible = false; SRNMbx.Visible = false; CTnobx.Visible = false; USRNMbx.Visible = false; PWbx.Visible = false; //hiding all the button
                MiddleName_label.Visible = false; Surname_Label.Visible = false; ContactNo_Label.Visible = false; Username_Label.Visible = false; password_Label.Visible = false; //hiding all the label
                CHCKPW.Visible = false; //hiding the see password
                ButtonDisability(); //executes the class
            }
            else //if the textbox has no number
            {
                FNPNLappearbx.Visible = false; //hiding the panel
                FNlettersREMINDbx.Visible = false; //hiding the label
                LogInBtn.Enabled = true; //enabling the button

                MDLNMbx.Visible = true; SRNMbx.Visible = true; CTnobx.Visible = true; USRNMbx.Visible = true; PWbx.Visible = true; //showing all the button
                MiddleName_label.Visible = true; Surname_Label.Visible = true; ContactNo_Label.Visible = true; Username_Label.Visible = true; password_Label.Visible = true; //showing all the label
                CHCKPW.Visible = true; //shoeing the see password
                ButtonDisability(); //executes the class
            }
        }

        private void MDLNMbx_TextChanged(object sender, EventArgs e) //if the middle name textbox inserted or deleted letter or numbers 
        {
            if (MDLNMbx.Text.Any(Char.IsDigit)) //if middle name contains number
            {
                MDNPNLAppearbx.Visible = true; //showing the panel
                MDNReminder.Visible = true; //showing the label
                LogInBtn.Enabled = false; //disabling the button
                CHCKPW.Visible = false; //hiding the see password

                FrstNMTXTbx.Visible = false; SRNMbx.Visible = false; CTnobx.Visible = false; USRNMbx.Visible = false; PWbx.Visible = false; //hiding all the button
                Firstname_label.Visible = false; Surname_Label.Visible = false; ContactNo_Label.Visible = false; Username_Label.Visible = false; password_Label.Visible = false; //hiding all the label
                ButtonDisability(); //executes the class
            }
            else //if it doesn't contains number
            {
                MDNPNLAppearbx.Visible = false; //hiding the panel
                MDNReminder.Visible = false; //hiding the label
                LogInBtn.Enabled = true; //enabling the buttong

                FrstNMTXTbx.Visible = true; SRNMbx.Visible = true; CTnobx.Visible = true; USRNMbx.Visible = true; PWbx.Visible = true; //showing all the button
                Firstname_label.Visible = true; Surname_Label.Visible = true; ContactNo_Label.Visible = true; Username_Label.Visible = true; password_Label.Visible = true; //showing all the label
                CHCKPW.Visible = true; //showing the see password
                ButtonDisability(); //executes the class
            }
        }

        private void SRNMbx_TextChanged(object sender, EventArgs e) //if the surname textbox inserted or deleted letter or numbers 
        {
            if (SRNMbx.Text.Any(Char.IsDigit)) //if it contains number
            {
                SRNPNLAppearbx.Visible = true; //show the panel
                SRREMINDER.Visible = true; //hide the label
                LogInBtn.Enabled = false;  //disabling the button

                FrstNMTXTbx.Visible = false; MDLNMbx.Visible = false; CTnobx.Visible = false; USRNMbx.Visible = false; PWbx.Visible = false; //hiding all the button
                Firstname_label.Visible = false; MiddleName_label.Visible = false; ContactNo_Label.Visible = false; Username_Label.Visible = false; password_Label.Visible = false; //hiding all the label
                CHCKPW.Visible = false; //hiding the see password
                ButtonDisability(); //executes the class
            }
            else //if it does't contains number
            {
                SRNPNLAppearbx.Visible = false; //hiding the panel
                SRREMINDER.Visible = false; //hiding the label
                LogInBtn.Enabled = true; //enabling the buttong

                FrstNMTXTbx.Visible = true; MDLNMbx.Visible = true; CTnobx.Visible = true; USRNMbx.Visible = true; PWbx.Visible = true; //showing all the button
                Firstname_label.Visible = true; MiddleName_label.Visible = true; ContactNo_Label.Visible = true; Username_Label.Visible = true; password_Label.Visible = true; //showing all the label
                CHCKPW.Visible = true; //showing the see password
                ButtonDisability(); //execute the class
            }
        }

        private void CTnobx_TextChanged(object sender, EventArgs e) //if the contact number textbox inserted or deleted letter or numbers 
        {
            if (CTnobx.Text.Any(Char.IsLetter) || CTnobx.Text.Any(Char.IsSymbol)) // if it contains number
            {
                CTPNLAppearBX.Visible = true; //showing the panel
                CTReminder.Visible = true; //hiding the panel
                LogInBtn.Enabled = false; //disabling the button

                FrstNMTXTbx.Visible = false; MDLNMbx.Visible = false; SRNMbx.Visible = false; USRNMbx.Visible = false; PWbx.Visible = false; //hiding all the buttong
                Firstname_label.Visible = false; MiddleName_label.Visible = false; Surname_Label.Visible = false; Username_Label.Visible = false; password_Label.Visible = false; //hiding all the label
                CHCKPW.Visible = false; //hiding the see password
                ButtonDisability(); //executes the class
            }
            else //if it doesn't contain number
            {
                CTPNLAppearBX.Visible = false; //hiding the panel
                CTReminder.Visible = false; //hiding the label
                LogInBtn.Enabled = true; //enabling the button

                FrstNMTXTbx.Visible = true; MDLNMbx.Visible = true; SRNMbx.Visible = true; USRNMbx.Visible = true; PWbx.Visible = true; //show all the button
                Firstname_label.Visible = true; MiddleName_label.Visible = true; Surname_Label  .Visible = true; Username_Label.Visible = true; password_Label.Visible = true; //show all the label
                CHCKPW.Visible = true; //show the see password
                ButtonDisability(); //execute the clas
            }
        }
        public void ButtonDisability() //disabling the login button
        {
            if (LogInBtn.Enabled) //if the button is enable
            {
                LogInBtn.BackColor = Color.White; //coloring the background of the button to white
            }
            else //if the button is disable
            {
                LogInBtn.BackColor = Color.LightGray; //coloring the background of the button to Light gray
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) //if the see pasword was checked
        {
            if (PWbx.PasswordChar == '*') //if it was check
            {
                PWbx.PasswordChar = '\0'; // Show password
            }
            else //if it was uncheck
            {
                PWbx.PasswordChar = '*'; // Hide password
            }
        }
        //------------------------------------------------------------------------------------------------------//

        private void LogInBtn_Click(object sender, EventArgs e) // Triggered when the LogIn button is clicked
        {
            SignedIn();  // Call the function that handles user login
        }

        private async void SignedIn()
        {
            if (LogInBtn.Enabled)  // Check if the LogIn button is enabled
            {
                if (FrstNMTXTbx.Text == "")  // Check if the First Name field is empty
                {
                    MessageBox.Show("Please Fill your Firstname!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);  // Show a message asking for First Name
                }
                else if (SRNMbx.Text == "")  // Check if the Surname field is empty
                {
                    MessageBox.Show("Please Fill your Surname!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);  // Show a message asking for Surname
                }
                else if (CTnobx.Text == "")  // Check if the Contact Number field is empty
                {
                    MessageBox.Show("Please Fill your Contact Number!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);  // Show a message asking for Contact Number
                }
                else if (USRNMbx.Text == "")  // Check if the Username field is empty
                {
                    MessageBox.Show("Please Fill your Username!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);  // Show a message asking for Username
                }
                else if (PWbx.Text == "")  // Check if the Password field is empty
                {
                    MessageBox.Show("Please Fill your Password!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);  // Show a message asking for Password
                }
                else
                {
                    if (Connect.State != ConnectionState.Open)  // Check if the database connection is not open
                    {
                        try
                        {
                            Connect.Open();  // Open the database connection
                            String checkFirstname = "Select * FROM admin WHERE username = '"
                                + USRNMbx.Text.Trim() + "'";  // Create a query to check if the user entered username already exists

                            using (SqlCommand checkUser = new SqlCommand(checkFirstname, Connect))  // Execute the query using SqlCommand
                            {
                                SqlDataAdapter adapter = new SqlDataAdapter(checkUser);  // Use SqlDataAdapter to fetch data from the database
                                DataTable newtable = new DataTable();  // Create a new table to hold the results
                                adapter.Fill(newtable);  // Fill the table with the query results

                                if (newtable.Rows.Count >= 1)  // If a user with the same username is found
                                {
                                    Declare.AsteriskSound.Play();  // Play a sound
                                    await Task.Delay(500);  // Wait for half a second
                                    UserExisted();  // Call a function to handle when the user already exists
                                }
                                else
                                {
                                    string insertData = "insert INTO admin (firstname, middlename, surname, contactno, username, passowrd)" +  // SQL query to insert new user data
                                        "VALUES(@firstname, @middlename, @surname, @contactno, @username, @passowrd)";  // Values to be inserted into the database

                                    using (SqlCommand cmd = new SqlCommand(insertData, Connect))  // Create a new SqlCommand to execute the insert query
                                    {
                                        cmd.Parameters.AddWithValue("@firstname", FrstNMTXTbx.Text.Trim());  // Add the First Name to the query
                                        cmd.Parameters.AddWithValue("@middlename", MDLNMbx.Text.Trim());  // Add the Middle Name to the query
                                        cmd.Parameters.AddWithValue("@surname", SRNMbx.Text.Trim());  // Add the Surname to the query
                                        cmd.Parameters.AddWithValue("@contactNo", CTnobx.Text.Trim());  // Add the Contact Number to the query
                                        cmd.Parameters.AddWithValue("@username", USRNMbx.Text.Trim());  // Add the Username to the query
                                        cmd.Parameters.AddWithValue("@passowrd", PWbx.Text.Trim());  // Add the Password to the query
                                        cmd.ExecuteNonQuery();  // Execute the query to insert the data

                                        OpenSuccessform();  // Open a success form after inserting the data
                                    }
                                }
                            }
                        }
                        catch (Exception ex)  // If there’s an error while connecting to the database
                        {
                            MessageBox.Show("Error Connecting Database: " + ex, "Can't Connect!", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Show an error message
                        }
                        finally
                        {
                            Connect.Close();  // Close the database connection after the operation
                        }
                    }
                }
            }
        }

        private void AddbuttonEntered(object sender, EventArgs e) // When the mouse hovers over the button, change its background color to indicate interaction.
        {            
            Button changeButton = sender as Button; // Cast the sender (button) to a Button object.
            changeButton.BackColor = SystemColors.ActiveBorder; //change the color
        }

        private void AddbuttonLeaved(object sender, EventArgs e) // When the mouse leaves the button, reset its background color to the default.
        {            
            Button returnBack = sender as Button; //Cast the sender (button) to a Button object.
            returnBack.BackColor = SystemColors.Control;
        }

        private void AddbuttonClicked(object sender, EventArgs e) // When the mouse clicked the button
        {
            // Cast the sender (button) to a Button object.
            Button SignedIn = sender as Button;

            // Close the success message form.
            SuccessForm.Close();

            // Check if an instance of the SignUp form already exists.
            if (SignUp.Instance != null)
            {
                // If it exists, show it and bring it to the front.
                SignUp.Instance.Show();
                SignUp.Instance.BringToFront();
                this.Hide(); // Hide the current form.
            }
            else
            {
                // If no instance exists, create a new one and show it.
                SignUp CreateSignUp = new SignUp();
                CreateSignUp.Show();
                this.Hide(); // Hide the current form.
            }

            // Clear the input fields after clicking the button.
            FrstNMTXTbx.Text = "";
            MDLNMbx.Text = "";
            SRNMbx.Text = "";
            CTnobx.Text = "";
            USRNMbx.Text = "";
            PWbx.Text = "";
        }

        private void OpenSuccessform()
        {
            // Create a new form (a small popup) for the success message.
            SuccessForm = new Form()
            {
                Size = new Size(355, 140), // Set the size of the form.
                StartPosition = FormStartPosition.CenterScreen, // Center it on the screen.
                BackgroundImage = Image.FromFile(@"C:\Users\blood\source\repos\PHCM last na to\PHCM last na to\Resources\Loading.png"), // Set a background image.
                FormBorderStyle = FormBorderStyle.None, // Remove the border to make it look like a popup.
                MinimizeBox = false, // Disable minimize button.
                ShowInTaskbar = false, // Do not show in the taskbar.
                MaximizeBox = false, // Disable maximize button.
                BackColor = SystemColors.Control, // Set background color.
                BackgroundImageLayout = ImageLayout.Tile // Arrange the background image.
            };

            // Create a label to display "Successfully Registered!" message.
            Label SuccessLabel = new Label()
            {
                Text = "Successfully Registered!", // The message to show.
                Size = new Size(155, 45), // Set size.
                Font = new Font("Nirmala UI", 18, FontStyle.Regular), // Set font style.
                ForeColor = Color.White, // Set text color.
                BackColor = Color.Transparent, // Make background transparent.
                Padding = new Padding(0), // Remove padding.
                Margin = new Padding(0), // Remove margin.
                AutoSize = true // Adjust label size to fit text.
            };

            // Create a small top panel (header bar) for the popup.
            Panel HeadPanel = new Panel()
            {
                Size = new Size(529, 27), // Set size.
                Location = new Point(-7, -2), // Position it at the top.
                BackColor = SystemColors.Control, // Set background color.
            };

            // Create a "Notice" label for the top panel.
            Label NoticeLabel = new Label()
            {
                Text = "Notice", // Label text.
                Size = new Size(46, 17), // Set size.
                Location = new Point(150, 5), // Position it at the top.
                ForeColor = Color.Black, // Set text color.
                Font = new Font("Nirmala UI", 8, FontStyle.Regular), // Set font.
                FlatStyle = FlatStyle.Standard, // Default flat style.
                AutoSize = true, // Auto-resize to fit text.
                TabIndex = 1 // Tab order.
            };

            // Create an "Okay" button to close the popup.
            Button Addbutton = new Button()
            {
                Text = "Okay", // Button text.
                Size = new Size(110, 30), // Set button size.
                Location = new Point(120, 90), // Position it near the bottom.
                ForeColor = Color.Black, // Text color.
                BackColor = Color.White, // Button color.
                Padding = new Padding(0), // Remove padding.
                Margin = new Padding(0), // Remove margin.
                FlatStyle = FlatStyle.Flat, // Make button look flat.
                Font = new Font("Nirmala Ui", 10, FontStyle.Regular) // Set font style.
            };

            // Set the location of the success message label.
            SuccessLabel.Location = new Point(15, 30);

            // Ensure proper layering of UI elements.
            NoticeLabel.BringToFront(); // Bring "Notice" label to the front.
            HeadPanel.SendToBack(); // Send the panel to the back.
            SuccessLabel.SendToBack(); // Send success message behind the button.
            Addbutton.BringToFront(); // Bring the button forward.

            // Add hover effects to the button (change color on hover).
            Addbutton.MouseEnter += new EventHandler(AddbuttonEntered);
            Addbutton.MouseLeave += new EventHandler(AddbuttonLeaved);

            // When clicked, the button will close the form and proceed.
            Addbutton.Click += new EventHandler(AddbuttonClicked);

            // Remove button border when not hovered.
            Addbutton.FlatAppearance.BorderSize = 0;

            // Add elements to the form.
            SuccessForm.Controls.Add(SuccessLabel);
            SuccessForm.Controls.Add(NoticeLabel);
            SuccessForm.Controls.Add(HeadPanel);
            SuccessForm.Controls.Add(Addbutton);

            // Display the form.
            SuccessForm.Show();
        }
        // Function to show a popup form when a username already exists
        private void UserExisted()
        {
            // Create a new form
            UserAlrExist = new Form()
            {
                Size = new Size(345, 170), // Set form size
                StartPosition = FormStartPosition.CenterScreen, // Position it in the center of the screen
                BackgroundImage = Image.FromFile(@"C:\Users\blood\source\repos\PHCM last na to\PHCM last na to\Resources\Loading.png"), // Set background image
                FormBorderStyle = FormBorderStyle.None, // Remove form borders
                MinimizeBox = false, // Disable minimize button
                ShowInTaskbar = false, // Do not show in taskbar
                MaximizeBox = false, // Disable maximize button
                BackColor = SystemColors.Control, // Set background color
                BackgroundImageLayout = ImageLayout.Tile // Set background image layout
            };

            // Create a label to show "Exist!"
            Label ErrorLabel = new Label()
            {
                Text = "Exist!", // Text displayed
                Size = new Size(155, 45),
                Font = new Font("Nirmala UI", 18, FontStyle.Regular), // Font style
                ForeColor = Color.White, // Text color
                BackColor = Color.Transparent, // No background color
                AutoSize = true // Adjust size automatically
            };

            // Create another label to show "Username is Already"
            Label ErrorLabel_2 = new Label()
            {
                Text = "Username is Already",
                Size = new Size(155, 45),
                Font = new Font("Nirmala UI", 18, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = true
            };

            // Create a panel for the header
            Panel HeadPanel = new Panel()
            {
                Size = new Size(529, 27), // Set panel size
                Location = new Point(-7, -2), // Position the panel
                BackColor = SystemColors.Control // Background color
            };

            // Create a label for the title
            Label TitleLabel = new Label()
            {
                Text = "Notice",
                Size = new Size(46, 17),
                Location = new Point(160, 5), // Position the label
                ForeColor = Color.Black, // Text color
                Font = new Font("Nirmala UI", 8, FontStyle.Regular), // Font style
                AutoSize = true // Adjust size automatically
            };

            // Create a button to close the popup
            Button Addbutton = new Button()
            {
                Text = "Okay", // Button text
                Size = new Size(60, 25),
                Location = new Point(155, 135), // Position the button
                ForeColor = Color.Black,
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat, // Remove button border
                Font = new Font("Nirmala Ui", 8, FontStyle.Regular)
            };

            // Set the positions of the labels inside the form
            ErrorLabel_2.Location = new Point(35, 30);
            ErrorLabel.Location = new Point(145, 70);
            TitleLabel.BringToFront(); // Ensure title label is in front
            HeadPanel.SendToBack(); // Move panel to the back

            // Add elements to the popup form
            UserAlrExist.Controls.Add(ErrorLabel);
            UserAlrExist.Controls.Add(TitleLabel);
            UserAlrExist.Controls.Add(HeadPanel);
            UserAlrExist.Controls.Add(ErrorLabel_2);
            UserAlrExist.Controls.Add(Addbutton);

            // Remove border from button
            Addbutton.FlatAppearance.BorderSize = 0;

            // Set click event for the button
            Addbutton.Click += new EventHandler(UserAlrExistOk);

            // Show the popup form
            UserAlrExist.Show();
        }

        // Function to clear username and close the "User Already Exists" form when "Okay" is clicked
        private void UserAlrExistOk(object sender, EventArgs e)
        {
            USRNMbx.Text = ""; // Clear username textbox
            UserAlrExist.Close(); // Close the popup
        }
        
        private void PWbx_KeyPress(object sender, KeyPressEventArgs e) //if the focus is inside the textbox and pressed the key
        {
            if (e.KeyChar == (char)Keys.Enter) //if the user press enter
            {
                if (LogInBtn.Visible) //if the button is visible
                {
                    SignedIn(); //executes the class
                }
            }
        }

        // Function triggered when a button is clicked to open a success form
        private void catana_button1_Click(object sender, EventArgs e)
        {
            OpenSuccessform(); // Open a success form
        }
        
        private void USRNMbx_KeyPress(object sender, KeyPressEventArgs e) //if the focus is inside the textbox and pressed the key
        {
            if (e.KeyChar == (char)Keys.Enter) //if the user press enter
            {
                if (LogInBtn.Visible) //if the button is visible
                {
                    SignedIn(); //execute the class
                }
            }
        }

        private void CTnobx_KeyPress(object sender, KeyPressEventArgs e) //if the focus is inside the textbox and pressed the key
        {
            if (e.KeyChar == (char)Keys.Enter) //if the user press enter
            {
                if (LogInBtn.Visible) //if the button is visible
                {
                    SignedIn(); //execute the class
                }
            }
        }

        private void SRNMbx_KeyPress(object sender, KeyPressEventArgs e) //if the focus is inside the textbox and pressed the key
        {
            if (e.KeyChar == (char)Keys.Enter) //if the user press enter
            {
                if (LogInBtn.Visible) //if the button is visible
                {
                    SignedIn(); //execute the class
                }
            }
        }

        private void MDLNMbx_KeyPress(object sender, KeyPressEventArgs e) //if the focus is inside the textbox and pressed the key
        {
            if (e.KeyChar == (char)Keys.Enter) //if the user press enter
            {
                if (LogInBtn.Visible) //if the button is visible
                {
                    SignedIn(); //execute the ckass
                } 
            }
        }

        private void FrstNMTXTbx_KeyPress(object sender, KeyPressEventArgs e) //if the focus is inside the textbox and pressed the key
        {
            if (e.KeyChar == (char)Keys.Enter) //if the user press enter
            {
                if (LogInBtn.Visible) //if the button is visible
                {
                    SignedIn(); //execute the class
                }
            }
        }
    }
}