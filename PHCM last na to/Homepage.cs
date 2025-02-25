using System; //fundamental types and base classes
using System.Data.SqlClient; //to use the library of the sql
using System.Drawing; // Accessing the system drawing
using System.Windows.Documents;
using System.Windows;
using System.Windows.Forms; //classes for creating Windows Forms applications
using System.Windows.Input;
using FontAwesome.Sharp; //using the library of FontAwesome package
using PHCM_last_na_to.Forms; //accessing the form

namespace PHCM_last_na_to
{
    public partial class Homepage : Form
    {        
        //connecting a data
        private string connect= "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"; 
        private string loggInUsername; //creating a variable
        private IconButton currentBtn; //creating a button 
        private Panel leftBorderBtn; //creating a panel  
        private Form currentChildForm; //creating a form
        private bool ExitHomepage = false; //setting it to false if it clicked Exit button instead of log out

        public Homepage(string takeUsername)
        {
            InitializeComponent();    
            loggInUsername = takeUsername; //taking a data from Log in Form using the created variable 
            leftBorderBtn = new Panel(); //creating a panel
            leftBorderBtn.Size = new System.Drawing.Size(7, 80); // Size of the border
            panelMenu.Controls.Add(leftBorderBtn); // Add the left border to the panel
            ActivateButton(HomeButton, RGBColors.color1); // Activate the Home button by default

        }
        // Method to activate the clicked button with custom colors and effects
        private void ActivateButton(object sender, System.Drawing.Color color)
        {
            if (sender != null)  // Check if the sender object is not null (to avoid errors)
            {
                DisableButton();  // Call the method to disable the previous button style

                // button customization
                currentBtn = (IconButton)sender;  // Cast the sender to an IconButton (the button that was clicked)
                currentBtn.BackColor = System.Drawing.Color.FromArgb(37, 37, 81);  // Set the button background color
                currentBtn.ForeColor = color;  // Set the text color to the specified color
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;  // Align the button text to the center
                currentBtn.IconColor = color;  // Change the icon color to match the text color
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;  // Put the text before the icon
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;  // Align the icon to the right side

                // left border customization
                leftBorderBtn.BackColor = color;  // Set the left border's background color to the chosen color
                leftBorderBtn.Location = new System.Drawing.Point(0, currentBtn.Location.Y);  // Place the left border at the same vertical position as the button
                leftBorderBtn.Visible = true;  // Make the left border visible
                leftBorderBtn.BringToFront();  // Bring the left border in front of other controls

                // current icon
                currentIconForm.IconChar = currentBtn.IconChar;  // Set the current form's icon to match the clicked button's icon
                currentIconForm.IconColor = color;  // Set the icon's color to match the button's color
            }
        }

        // Structure to store predefined colors for buttons
        private struct RGBColors
        {
            public static System.Drawing.Color color1 = System.Drawing.Color.FromArgb(172, 126, 241);  // Color 1
            public static System.Drawing.Color color2 = System.Drawing.Color.FromArgb(249, 118, 176);  // Color 2
            public static System.Drawing.Color color3 = System.Drawing.Color.FromArgb(253, 138, 114);  // Color 3
            public static System.Drawing.Color color4 = System.Drawing.Color.FromArgb(95, 77, 221);  // Color 4
            public static System.Drawing.Color color5 = System.Drawing.Color.FromArgb(249, 88, 155);  // Color 5
            public static System.Drawing.Color color6 = System.Drawing.Color.FromArgb(24, 161, 251);  // Color 6
            public static System.Drawing.Color color7 = System.Drawing.Color.FromArgb(172, 126, 241);  // Color 7
            public static System.Drawing.Color color8 = System.Drawing.Color.FromArgb(249, 118, 176);  // Color 8
        }

        // Method to disable the styling of the previous active button
        private void DisableButton()
        {
            if (currentBtn != null)  // Check if there is a button to disable
            {
                currentBtn.BackColor = System.Drawing.Color.FromArgb(40, 30, 88);  // Reset the button background color
                currentBtn.ForeColor = System.Drawing.Color.White;  // Set the text color to white
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;  // Align the text to the left
                currentBtn.IconColor = System.Drawing.Color.White;  // Set the icon color to white
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;  // Put the icon before the text
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;  // Align the icon to the left
            }
        }

        // Method that is called when the homepage form loads
        private void Homepage_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();  // Center the form on the screen
            string fullname = GetFirstNameData(loggInUsername);  // Call the method to retrieve the user's first name using their username
            lblUsername.Text = "WELCOME, " + fullname.ToUpper();  // Display the user's full name in uppercase on the label
        }

        // Method to retrieve the user's first name, middle name, and surname from the database
        private string GetFirstNameData(string username)
        {
            string fullname = string.Empty;  // Initialize the fullname variable as empty
            string query = "SELECT firstName, middleName, surname, isAdmin FROM admin WHERE username = @username";  // SQL query to get the user data from the database

            using (SqlConnection connection = new SqlConnection(connect))  // Create a new connection to the database
            {
                SqlCommand command = new SqlCommand(query, connection);  // Create a new SQL command using the query and connection
                command.Parameters.AddWithValue("@username", username);  // Add the username parameter to the SQL command

                try
                {
                    connection.Open();  // Open the database connection
                    using (SqlDataReader reader = command.ExecuteReader())  // Execute the query and read the results
                    {
                        if (reader.Read())  // If data is found
                        {
                            string firstname = reader["firstName"].ToString();  // Get the first name from the database
                            string middlename = reader["middleName"].ToString();  // Get the middle name
                            string middleInitial = !string.IsNullOrEmpty(middlename) ? middlename.Substring(0, 1) : string.Empty;  // Get the first letter of the middle name (if present)
                            string surname = reader["surname"].ToString();  // Get the surname
                            bool isAdmin = Convert.ToBoolean(reader["isAdmin"]);  // Check if the user is an admin

                            if (isAdmin)  // If the user is an admin
                            {
                                fullname = $"{firstname} {middleInitial}. {surname}(admin)";  // Append "(admin)" to the full name
                            }
                            else
                            {
                                fullname = $"{firstname} {middleInitial}. {surname}";  // Otherwise, just return the full name
                            }
                        }
                    }
                }
                catch (Exception ex)  // If there's an error connecting to the database
                {
                    System.Windows.Forms.MessageBox.Show("An error occurred while retrieving the first name: " + ex.Message);  // Show an error message
                }
            }

            return fullname;  // Return the full name
        }

        //RGB colors when users/client clicked the button
        // Method to handle the Home button click event
        private void HomeButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);  // Activate the clicked button with a color
            OpenChildForm(new HomeForm());  // Open the "HomeForm" as a child form
        }

        // Method to handle the Administrator button click event
        private void AdministratorButton_Click(object sender, EventArgs e)
        {
            // Query to check if the user is an admin in the database
            string query = "SELECT isAdmin FROM admin WHERE username = @username";

            using (SqlConnection connection = new SqlConnection(connect))  // Connect to the database
            using (SqlCommand command = new SqlCommand(query, connection))  // Create a command to query the database
            {
                command.Parameters.AddWithValue("@username", loggInUsername);  // Pass the username as a parameter

                try
                {
                    connection.Open();  // Open the connection to the database
                    using (SqlDataReader reader = command.ExecuteReader())  // Execute the query and read the result
                    {
                        if (reader.Read())  // Check if data is found
                        {
                            bool isAdmin = Convert.ToBoolean(reader["isAdmin"]);  // Check if the user is an admin

                            if (isAdmin)  // If the user is an admin
                            {
                                ActivateButton(sender, RGBColors.color2);  // Change the button style for admin
                                OpenChildForm(new AdministratorForm());  // Open the admin form
                            }
                            else  // If the user is not an admin
                            {
                                System.Windows.Forms.MessageBox.Show("Only Admin can access this feature!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);  // Show a message to non-admin users
                            }
                        }
                    }
                }
                catch (Exception ex)  // If there is an error connecting to the database
                {
                    System.Windows.Forms.MessageBox.Show("An error occurred while retrieving the first name: " + ex.Message);  // Show an error message
                }
            }
        }

        // Method to handle the Add Books button click event
        private void AddBooksButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);  // Activate the button with a color for "Add Books"
            OpenChildForm(new AddBooksForm());  // Open the "AddBooksForm" as a child form
        }

        // Method to handle the Add Student Information button click event
        private void AddStudentInformationButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);  // Activate the button with a color for "Add Student Information"
            OpenChildForm(new AddStudentInformationForm());  // Open the "AddStudentInformationForm" as a child form
        }

        // Method to handle the Issue Book button click event
        private void IssueBook_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);  // Activate the button with a color for "Issue Book"
            OpenChildForm(new IssueBooksForm());  // Open the "IssueBooksForm" as a child form
        }

        // Method to handle the Return Book button click event
        private void ReturnBookButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);  // Activate the button with a color for "Return Book"
            OpenChildForm(new ReturnBookForm());  // Open the "ReturnBookForm" as a child form
        }

        // Method to handle the Quick Overview button click event
        private void QuickOverviewButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color8);  // Activate the button with a color for "Quick Overview"


            QuickOverviewForm quickOverviewForm = new QuickOverviewForm();
            OpenChildForm(quickOverviewForm);

            // Focusing the child form to enable keyboard navigation
            quickOverviewForm.Focus();
            quickOverviewForm.Select();
            quickOverviewForm.Activate();
        }

        // Method to handle the Log Out button click event
        private void LogOut_Click(object sender, EventArgs e)
        {
            ExitHomepage = true;  // Set the flag that the user is logging out
            if (SignUp.Instance != null)  // If the login form (SignUp) already exists and is hidden
            {
                SignUp.Instance.Show();  // Show the login form
                SignUp.Instance.BringToFront();  // Bring the login form to the front
                SignUp.Instance.StartPosition = FormStartPosition.CenterParent;  // Center the login form on the screen
                this.Close();  // Close the homepage form
            }
            else  // If the login form doesn't exist yet
            {
                Form openLogin = new SignUp();  // Create a new instance of the login form
                openLogin.Show();  // Show the new login form
                SignUp.Instance.StartPosition = FormStartPosition.CenterParent;  // Center the login form
                this.Close();  // Close the homepage form
            }
        }

        private void LogOut_MouseEnter(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Hand;  // Change the cursor to a hand when the mouse enters the LogOut button
            LogOut.ForeColor = System.Drawing.Color.FromArgb(120, 90, 220);  // Change the text color of the LogOut button to a shade of purple
            LogOut.IconColor = System.Drawing.Color.FromArgb(120, 90, 220);  // Change the icon color of the LogOut button to match the text color
            LogOut.TextAlign = ContentAlignment.MiddleCenter;  // Align the text of the LogOut button to the center
            LogOut.TextImageRelation = TextImageRelation.TextBeforeImage;  // Place the text before the icon in the LogOut button
            LogOut.ImageAlign = ContentAlignment.MiddleRight;  // Align the icon to the right of the button
            LogOut.IconChar = IconChar.Question;  // Change the icon to a "question mark" when the mouse hovers over the button
        }

        private void LogOut_MouseLeave(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Default;  // Change the cursor back to the default arrow when the mouse leaves the LogOut button
            LogOut.ForeColor = System.Drawing.Color.FromArgb(80, 60, 176);  // Change the text color of the LogOut button back to its original color
            LogOut.IconColor = System.Drawing.Color.FromArgb(80, 60, 176);  // Change the icon color back to its original color
            LogOut.TextAlign = ContentAlignment.MiddleLeft;  // Align the text of the LogOut button to the left
            LogOut.TextImageRelation = TextImageRelation.ImageBeforeText;  // Place the icon before the text in the LogOut button
            LogOut.ImageAlign = ContentAlignment.MiddleLeft;  // Align the icon to the left of the button
            LogOut.IconChar = IconChar.LongArrowLeft;  // Change the icon to a "long arrow left" when the mouse leaves the button
        }

        //RGB colors when users/client clicked the button

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)  // If there is already a form open
            {
                currentChildForm.Close();  // Close the currently open form
            }
            currentChildForm = childForm;  // Set the current form to the new child form
            childForm.TopLevel = false;  // Make the child form not a top-level window
            childForm.FormBorderStyle = FormBorderStyle.None;  // Remove the border from the form
            childForm.Dock = DockStyle.Fill;  // Make the form fill the parent container (panel)
            panelDescription.Controls.Add(childForm);  // Add the child form to the panel on the main form
            panelDescription.Tag = childForm;  // Store the child form in the panel’s Tag property
            childForm.BringToFront();  // Bring the child form to the front           
            childForm.Show();  // Show the child form
            

            currentLabelForm.Text = childForm.Text;  // Update the label to show the child form’s name                                  
        }
        // This method overrides the default key handling behavior for the form
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Check if the Right Arrow key is pressed
            if (keyData == Keys.Right)
            {
                // If the currently open form is "QuickOverviewForm", open "ReturnDetailsForm"
                if (currentChildForm is QuickOverviewForm)
                {
                    OpenChildForm(new ReturnDetailsForm()); // Open the ReturnDetailsForm inside the panel
                    return true; // Stop further processing of this key event
                }

                // If the currently open form is "ReturnDetailsForm", open "StudentDetailsForm"
                if (currentChildForm is ReturnDetailsForm)
                {
                    OpenChildForm(new StudentDetailsForm()); // Open the StudentDetailsForm inside the panel
                    return true; // Stop further processing of this key event
                }
            }
            // Check if the Left Arrow key is pressed
            else if (keyData == Keys.Left)
            {
                // If the currently open form is "StudentDetailsForm", go back to "ReturnDetailsForm"
                if (currentChildForm is StudentDetailsForm)
                {
                    OpenChildForm(new ReturnDetailsForm()); // Open the ReturnDetailsForm inside the panel
                    return true; // Stop further processing of this key event
                }

                // If the currently open form is "ReturnDetailsForm", go back to "QuickOverviewForm"
                if (currentChildForm is ReturnDetailsForm)
                {
                    OpenChildForm(new QuickOverviewForm()); // Open the QuickOverviewForm inside the panel
                    return true; // Stop further processing of this key event
                }
            }
            
            return base.ProcessCmdKey(ref msg, keyData); // If no key condition is met, pass the key event to the default handler
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            ExitHomepage = false;  // Set the flag to indicate that the user is not exiting the homepage
            this.Close();  // Close the current form
        }

        private void Homepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!ExitHomepage)  // If the user didn’t intend to exit the homepage
            {
                System.Windows.Forms.Application.Exit();  // Close the entire application
            }
        }

        private void Exit_MouseEnter(object sender, EventArgs e)
        {
            Exit.ForeColor = System.Drawing.Color.Black;  // Change the text color of the Exit button when the mouse enters it
        }

        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            Exit.ForeColor = System.Drawing.Color.White;  // Change the text color of the Exit button when the mouse leaves it
        }
        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized; // Form will hide
        }
    }
}
