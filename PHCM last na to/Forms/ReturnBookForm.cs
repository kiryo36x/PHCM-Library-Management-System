// Including external code files that handle toast messages related to adding books, student information, and general message forms
using PHCM_last_na_to.Toast_Message_for_add_books;
using PHCM_last_na_to.Toast_Message_for_add_student_information;

// Importing basic namespaces required for working with data, graphics, and user interface components in a Windows Forms application
using System;  // This is for basic programming functionality
using System.Data;  // This is used for working with data, such as retrieving or sending information to a database
using System.Data.SqlClient;  // This is for connecting to and interacting with a SQL database
using System.Drawing;  // This helps in working with colors, fonts, and other visual elements
using System.Linq;  // This provides functionality for processing collections of data in an easy-to-read way
using System.Windows.Forms;  // This is for creating windows (forms) and controls, like buttons and text boxes, that users interact with in the application


namespace PHCM_last_na_to.Forms
{
    public partial class ReturnBookForm : Form
    {
        //connecting to database
        SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30");
        // Declaring a variable to hold the current form that's being shown inside the parent form
        private Form currentChildForm;

        // Constructor for the ReturnBookForm class
        public ReturnBookForm()
        {
            InitializeComponent();  // Initializes the form and its components (sets up the layout, buttons, etc.)

            // This positions the label in the center horizontally of the panel1 (used to display book name or information)
            label1.Location = new Point((panel1.Size.Width - label1.Size.Width) / 2, 9);
        }

        // Event handler for when the Booknamelbl label is clicked
        private void Booknamelbl_Click(object sender, EventArgs e)
        {
            // Focuses on the Booknametxtbox (makes the text box active for user input)
            bookNameComboBox.Focus();            
        }     

        // Event handler for when the studentNamelbl label is clicked
        private void studentNamelbl_Click(object sender, EventArgs e)
        {
            // Focuses on the studentNametxtbox (makes the text box active for user input)
            studentNameComboBox.Focus();
        }
        
        // Event handler for when the ReturnBookForm is clicked (removes focus from any control)
        private void ReturnBookForm_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        // Event handler for when panel2 is clicked (removes focus from any control)
        private void panel2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }


        // Event handler for when the "Save" button is clicked
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            // Check if any required field is empty
            if (string.IsNullOrEmpty(bookNameComboBox.Text) || string.IsNullOrEmpty(Authortxtbox.Text) ||
                string.IsNullOrEmpty(studentNameComboBox.Text) || string.IsNullOrEmpty(publishedDatetxtbox.Text) ||
                string.IsNullOrEmpty(issueDatetxtbox.Text) || string.IsNullOrEmpty(returnDatetxtbox.Text) ||
                string.IsNullOrEmpty(conditiontxtbox.Text))
            {
                // Show a message if any field is empty
                EmptyField emptyField = new EmptyField();
                emptyField.Show();
                return; // Stop the function here
            }

            // SQL query to insert the returned book details into the returnBook table
            string insertQuery = "INSERT INTO returnBook (bookName, author, studentName, publishedDate, issueDate, returnDate, condition) " +
                                 "VALUES(@bookName, @author, @studentName, @publishedDate, @issueDate, @returnDate, @condition)";

            // SQL query to increase the quantity of the returned book in the books table
            string updateQuery = "UPDATE books SET quantity = quantity + 1 WHERE bookName = @bookName";

            // SQL query to remove the returned book entry from the issue table (since it's no longer issued)
            string deleteQuery = "DELETE FROM issue WHERE bookName = @bookName AND studentName = @studentName";

            // Establish connection to the database
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open(); // Open the database connection
                SqlTransaction transaction = connection.BeginTransaction(); // Start a database transaction

                try
                {
                    // Step 1️⃣: Insert the returned book details into the returnBook table
                    using (SqlCommand cmdInsert = new SqlCommand(insertQuery, connection, transaction))
                    {
                        cmdInsert.Parameters.AddWithValue("@bookName", bookNameComboBox.SelectedItem.ToString()); // Book Name
                        cmdInsert.Parameters.AddWithValue("@author", Authortxtbox.Text); // Author Name
                        cmdInsert.Parameters.AddWithValue("@studentName", studentNameComboBox.SelectedItem.ToString()); // Student Name
                        cmdInsert.Parameters.AddWithValue("@publishedDate", publishedDatetxtbox.Text); // Published Date
                        cmdInsert.Parameters.AddWithValue("@issueDate", issueDatetxtbox.Text); // Issue Date
                        cmdInsert.Parameters.AddWithValue("@returnDate", returnDatetxtbox.Text); // Return Date
                        cmdInsert.Parameters.AddWithValue("@condition", conditiontxtbox.Text); // Condition of the Book
                        cmdInsert.ExecuteNonQuery(); // Execute the query to insert data
                    }

                    // Step 2️⃣: Update the books table to increase the book quantity by 1
                    using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, connection, transaction))
                    {
                        cmdUpdate.Parameters.AddWithValue("@bookName", bookNameComboBox.SelectedItem.ToString()); // Book Name
                        cmdUpdate.ExecuteNonQuery(); // Execute the query to update quantity
                    }

                    // Step 3️⃣: Delete the issued book record from the issue table (book is returned)
                    using (SqlCommand cmdDelete = new SqlCommand(deleteQuery, connection, transaction))
                    {
                        cmdDelete.Parameters.AddWithValue("@bookName", bookNameComboBox.SelectedItem.ToString()); // Book Name
                        cmdDelete.Parameters.AddWithValue("@studentName", studentNameComboBox.SelectedItem.ToString()); // Student Name
                        cmdDelete.ExecuteNonQuery(); // Execute the query to delete the issued record
                    }

                    transaction.Commit(); // Commit the transaction to save all changes
                    MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // Success message

                    // Reset form fields and clear input
                    bookNameComboBox.SelectedIndexChanged -= bookNameComboBox_SelectedIndexChanged; // Temporarily remove event handler

                    Authortxtbox.Clear(); // Clear author textbox
                    publishedDatetxtbox.Clear(); // Clear published date textbox
                    issueDatetxtbox.Clear(); // Clear issue date textbox
                    returnDatetxtbox.Clear(); // Clear return date textbox
                    textBox1.Clear(); // Clear additional textbox (if used)
                    textBox2.Clear(); // Clear additional textbox (if used)

                    bookNameComboBox.SelectedIndex = -1; // Reset book selection
                    studentNameComboBox.SelectedIndex = -1; // Reset student selection
                    studentNameComboBox.Items.Clear(); // Clear student list

                    // Make labels visible again
                    Booknamelbl.Visible = true;
                    Authorlbl.Visible = true;
                    studentNamelbl.Visible = true;
                    publishedDatelbl.Visible = true;
                    issueDatelbl.Visible = true;
                    returnDatelbl.Visible = true;

                    conditiontxtbox.Clear(); // Clear condition textbox
                    label2.Visible = true; // Make label visible
                    bookNameComboBox.SelectedIndexChanged += bookNameComboBox_SelectedIndexChanged; // Re-add event handler
                }
                catch (SqlException ex)
                {
                    transaction.Rollback(); // Undo all database changes if an error occurs
                    MessageBox.Show("Database error: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Undo all changes if an unexpected error occurs
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message
                }
            }
        }
        // Event handler for the "ClearBtn" button click
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            bookNameComboBox.SelectedIndexChanged -= bookNameComboBox_SelectedIndexChanged; //Unsubscribe the select event

            // Clear all input fields and reset controls to their default state
            Authortxtbox.Clear();
            publishedDatetxtbox.Clear();
            issueDatetxtbox.Clear();
            returnDatetxtbox.Clear();
            textBox1.Clear();
            textBox2.Clear();

            bookNameComboBox.SelectedIndex = -1;  //unselect the Combo Box
            studentNameComboBox.SelectedIndex = -1;
            studentNameComboBox.Items.Clear(); // Clear student names

            // Make all labels visible again
            Booknamelbl.Visible = true;
            Authorlbl.Visible = true;
            studentNamelbl.Visible = true;
            publishedDatelbl.Visible = true;
            issueDatelbl.Visible = true;
            returnDatelbl.Visible = true;

            conditiontxtbox.Clear(); //Clear the text box inside of Condition
            label2.Visible = true; //Make all label visible again
            bookNameComboBox.SelectedIndexChanged += bookNameComboBox_SelectedIndexChanged; //Subscribe the Select Event

        }

        // Event handler for the "ViewBtn" button click
        private void ViewBtn_Click(object sender, EventArgs e)
        {
            // Open the child form that shows the return book information
            OpenChildForm(new showReturnBook());
        }

        // Method to open a child form inside the current form
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close(); // Close the previously opened child form if it exists
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;  // Set child form to not be top-level (contained in the parent)
            childForm.FormBorderStyle = FormBorderStyle.None;  // Remove border
            childForm.Dock = DockStyle.Fill;  // Fill the panel with the child form
            panel1.Controls.Add(childForm);  // Add the child form to the panel
            panel1.Tag = childForm;  // Tag the panel with the current child form
            childForm.BringToFront();  // Bring the child form to the front
            childForm.Show();  // Display the child form
        }

        // Event handler for when panel1 is clicked (removes focus from any control)
        private void panel1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        // Event handler for when the form is loaded (sets the tab order for controls and other settings)
        private void ReturnBookForm_Load(object sender, EventArgs e)
        {
            // Set the tab order for all controls on the form (used for keyboard navigation)
            Authortxtbox.TabIndex = 0;
            publishedDatetxtbox.TabIndex = 1;
            issueDatetxtbox.TabIndex = 2;
            returnDatetxtbox.TabIndex = 3;

            SaveBtn.TabIndex = 6;
            ViewBtn.TabIndex = 7;
            ClearBtn.TabIndex = 8; 
            
            LoadBookNames();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            conditiontxtbox.Focus(); //focus the condion text box
        }

        private void conditiontxtbox_Enter(object sender, EventArgs e)
        {
            label2.Visible = false; //hide the label
        }

        private void conditiontxtbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conditiontxtbox.Text)) //if the box is empty
            {
                label2.Visible = true; //show the label
            }
        }
        private void bookNameComboBox_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}"); //open the combo box
            Booknamelbl.Visible = false; //hiding the book name label
        }
        private void LoadBookNames()
        {
            //connecting to the Database
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"; 
            string query = "SELECT DISTINCT bookName FROM issue"; // Fetch all book names

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open(); //open the datbase
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read()) // Loop through each book name
                        {
                            bookNameComboBox.Items.Add(reader["bookName"].ToString()); // Add to ComboBox
                        }
                        reader.Close(); // Close the reading
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //Send error message
                    }
                }
            }
        }
        private void bookNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if a book is selected in the ComboBox
            if (bookNameComboBox.SelectedItem != null)
            {
                // Hide labels that display book-related information
                Booknamelbl.Visible = false;
                Authorlbl.Visible = false;
                publishedDatelbl.Visible = false;
                returnDatelbl.Visible = false;

                // Reset the student name ComboBox
                studentNameComboBox.SelectedIndex = -1; // Unselect any previous selection
                studentNameComboBox.Items.Clear(); // Remove any previously loaded student names

                // Show the student name label
                studentNamelbl.Visible = true;

                // Clear any previous text in textBox2
                textBox2.Clear();

                // Show the issue date label and clear any previous date
                issueDatelbl.Visible = true;
                issueDatetxtbox.Clear();

                // Set the return date to today's date and format it
                DateTimePicker dateTimePicker = new DateTimePicker();
                dateTimePicker.Value = DateTime.Now; // Get the current date
                dateTimePicker.Format = DateTimePickerFormat.Short; // Set format to short (MM/DD/YYYY)
                returnDatetxtbox.Text = dateTimePicker.Value.ToString(); // Display the date in the return date textbox

                // Store the selected book name
                string selectedBookName = bookNameComboBox.SelectedItem.ToString();
                textBox1.Text = selectedBookName; // Display selected book name in textBox1

                // SQL query to retrieve book details (author, published date, and issue date)
                string query = "SELECT author, publishedDate, issueDate FROM issue WHERE bookName = @bookName";

                // SQL query to retrieve student names who have borrowed this book
                string studentQuery = "SELECT DISTINCT studentName FROM issue WHERE bookName = @bookName";

                // Create a connection to the database
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    try
                    {
                        conn.Open(); // Open database connection

                        // Fetch Book Details (author, published date, issue date)
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@bookName", selectedBookName); // Set the book name parameter

                            using (SqlDataReader reader = cmd.ExecuteReader()) // Execute the query
                            {
                                if (reader.Read()) // If a record is found
                                {
                                    // Store the retrieved author name in the text box
                                    Authortxtbox.Text = reader["author"].ToString();

                                    // Check if the published date exists in the database and format it properly
                                    publishedDatetxtbox.Text = reader["publishedDate"] != DBNull.Value
                                        ? Convert.ToDateTime(reader["publishedDate"]).ToString("yyyy-MM-dd")
                                        : "N/A";  // If no published date is found, display "N/A"
                                }
                            }
                        }

                        // Fetch Student Names who have borrowed the selected book
                        using (SqlCommand studentCmd = new SqlCommand(studentQuery, conn))
                        {
                            studentCmd.Parameters.AddWithValue("@bookName", selectedBookName); // Set book name parameter

                            using (SqlDataReader studentReader = studentCmd.ExecuteReader()) // Execute the query
                            {
                                studentNameComboBox.Items.Clear(); // Clear any previously loaded student names

                                while (studentReader.Read()) // Loop through each student record
                                {
                                    // Add each student's name to the ComboBox
                                    studentNameComboBox.Items.Add(studentReader["studentName"].ToString());
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Show an error message if something goes wrong
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                // Display a message if no book is selected
                MessageBox.Show("Please select a book first.");
            }
        }

        // When the dropdown list of bookNameComboBox closes
        private void bookNameComboBox_DropDownClosed(object sender, EventArgs e)
        {
            // If no book is selected (ComboBox is empty), show the label
            if (string.IsNullOrEmpty(bookNameComboBox.Text))
            {
                Booknamelbl.Visible = true;
            }
        }

        // When the user opens the dropdown list of bookNameComboBox
        private void bookNameComboBox_DropDown(object sender, EventArgs e)
        {
            // Hide the label when the dropdown opens
            Booknamelbl.Visible = false;
        }

        // When the user clicks textBox1 (which displays the selected book name)
        private void textBox1_Click(object sender, EventArgs e)
        {
            // Move focus to the bookNameComboBox to allow the user to select a book
            bookNameComboBox.Focus();
        }

        // When the user enters the studentNameComboBox (i.e., clicks or tabs into it)
        private void studentNameComboBox_Enter(object sender, EventArgs e)
        {
            // Automatically opens the dropdown list of student names
            SendKeys.Send("{F4}");
        }

        // When the dropdown list of studentNameComboBox opens
        private void studentNameComboBox_DropDown(object sender, EventArgs e)
        {
            // Hide the label when the dropdown opens
            studentNamelbl.Visible = false;
        }

        // When the dropdown list of studentNameComboBox closes
        private void studentNameComboBox_DropDownClosed(object sender, EventArgs e)
        {
            // If no student is selected (ComboBox is empty), show the label
            if (string.IsNullOrEmpty(studentNameComboBox.Text))
            {
                studentNamelbl.Visible = true;
            }
        }

        // When the user clicks on textBox2, set focus to studentNameComboBox
        private void textBox2_Click(object sender, EventArgs e)
        {
            studentNameComboBox.Focus(); // Move cursor to the student name ComboBox
        }

        // Triggered when the user selects a student from the ComboBox
        private void studentNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure that both a student and a book are selected
            if (studentNameComboBox.SelectedItem != null && bookNameComboBox.SelectedItem != null)
            {
                // Hide the issue date label
                issueDatelbl.Visible = false;

                // Store selected student name
                string selectedStudent = studentNameComboBox.SelectedItem.ToString();
                textBox2.Text = selectedStudent; // Display selected student in textBox2

                // Store selected book name
                string selectedBook = bookNameComboBox.SelectedItem.ToString();

                // SQL query to retrieve the issue date of the selected book for the selected student
                string query = "SELECT issueDate FROM issue WHERE bookName = @bookName AND studentName = @studentName";

                // Establish a connection to the database
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    try
                    {
                        conn.Open(); // Open database connection

                        // Create and execute the SQL command
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@bookName", selectedBook); // Add book name as a parameter
                            cmd.Parameters.AddWithValue("@studentName", selectedStudent); // Add student name as a parameter

                            // Execute the query and get the result (issueDate)
                            object result = cmd.ExecuteScalar();

                            if (result != null) // If a matching issue date is found
                            {
                                // Convert and display the issue date in the text box
                                issueDatetxtbox.Text = Convert.ToDateTime(result).ToString("yyyy-MM-dd");
                            }
                            else
                            {
                                // Show a message if no issue date is found
                                MessageBox.Show("Issue date not found.");
                                issueDatetxtbox.Text = ""; // Clear the issue date text box
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Show an error message if something goes wrong
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }
    }
}
