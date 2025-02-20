using PHCM_last_na_to.Toast_Message_for_add_books;  // Import the Toast message functionality for adding books (custom message display for book-related actions)
using PHCM_last_na_to.Toast_Message_for_add_student_information;  // Import the Toast message functionality for adding student information (custom message display for student-related actions)
using PHCM_last_na_to.Toast_Messsage_Form;  // Import the Toast message form for showing popup messages (a custom UI form)
using System;  // Import basic system functionalities (e.g., types like DateTime, String, etc.)
using System.Data;  // Import classes to manage and manipulate data (e.g., DataTable, DataSet for working with tables)
using System.Data.SqlClient;  // Import classes to connect and interact with SQL databases (e.g., SqlConnection for database connection)
using System.Drawing;  // Import classes for working with graphics, colors, and images (e.g., Color for color-related operations)
using System.Linq;  // Import classes that help with querying and manipulating data, especially collections (e.g., LINQ queries)
using System.Windows.Forms;  // Import Windows Forms-related classes for building GUI applications (e.g., Form, Button, TextBox)

namespace PHCM_last_na_to.Forms
{
    public partial class IssueBooksForm : Form
    {
        public IssueBooksForm()
        {
            InitializeComponent();
        }
        //connecting the database
        SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30");
        private Form currentChildForm;  // Declaring a variable to hold the current child form.

        private void IssueBooksForm_Load(object sender, EventArgs e)
        {
            // When the form loads, the following code will run:
            DateTimePicker dateTimePicker = new DateTimePicker();  // Create a new DateTimePicker control (calendar picker).
            dateTimePicker.Value = DateTime.Now;  // Set the current date and time as the default value.
            dateTimePicker.Format = DateTimePickerFormat.Short;  // Set the format to show a short date (e.g., MM/DD/YYYY).
            dateTimePicker.MinDate = DateTime.Now;  // Set the minimum allowed date to today's date.
            issuedDate.Text = "     " + dateTimePicker.Value.ToString();  // Display the selected date on the label `issuedDate` in a specific format.            
            LoadBooks();
        }

        private void Booknamelbl_Click(object sender, EventArgs e)
        {
            // When the book name label is clicked, set focus to the book name text box.
            bookNameComboBox.Focus();
        }

        private void studentNamelbl_Click(object sender, EventArgs e)
        {
            // When the student name label is clicked, set focus to the student name text box.
            studentNametxtbox.Focus();
        }

        private void studentNametxtbox_Enter(object sender, EventArgs e)
        {
            // When the student name text box gains focus, hide the label.
            studentNamelbl.Visible = false;
        }

        private void studentNametxtbox_Leave(object sender, EventArgs e)
        {
            // When the student name text box loses focus, show the label if the text box is empty.
            if (string.IsNullOrEmpty(studentNametxtbox.Text))
            {
                studentNamelbl.Visible = true;
            }
        }

        private void ButtonPanel_Click(object sender, EventArgs e)
        {
            // When the button panel is clicked, remove the focus from any active control (text box).
            this.ActiveControl = null;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            // When the panel1 is clicked, remove the focus from any active control.
            this.ActiveControl = null;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            // When the panel2 is clicked, remove the focus from any active control.
            this.ActiveControl = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // When label1 is clicked, remove the focus from any active control.
            this.ActiveControl = null;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            // Reset form fields
            bookNameComboBox.SelectedIndex = -1; // Reset book selection
            AuthortxtBox.Clear(); // Clear author textbox
            studentNametxtbox.Clear(); // Clear student name textbox
            publishedDatetxtBox.Clear(); // Clear published date textbox
            textBox1.Clear(); // Clear additional textbox (if used)
            genretxtbox.Clear(); // Clear genre textbox

            // Make labels visible again
            Booknamelbl.Visible = true;
            Authorlbl.Visible = true;
            studentNamelbl.Visible = true;
            publishedDatelbl.Visible = true;
            genrelbl.Visible = true;
            publishedDatelbl.BringToFront(); // Bring label to front
        }

        // Event handler for when the "Save" button is clicked
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            // SQL query to insert the issued book details into the "issue" table
            string insertQuery = "INSERT INTO issue (bookName, author, studentName, publishedDate, issueDate, genre) " +
                                 "VALUES(@bookName, @author, @studentName, @publishedDate, @issueDate, @genre)";

            // SQL query to reduce the book quantity in the "books" table (only if stock is available)
            string updateQuery = "UPDATE books SET quantity = quantity - 1 WHERE bookName = @bookName AND quantity > 0";

            try
            {
                // Check if any required field is empty
                if (string.IsNullOrEmpty(bookNameComboBox.Text) || string.IsNullOrEmpty(AuthortxtBox.Text) ||
                    string.IsNullOrEmpty(studentNametxtbox.Text))
                {
                    // Show a message if any field is empty
                    EmptyField emptyField = new EmptyField();
                    emptyField.Show();
                }
                else
                {

                    // Create SQL commands for inserting and updating the database
                    using (SqlCommand cmdInsert = new SqlCommand(insertQuery, connect))
                    using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, connect))
                    {                                                
                        // Set values for the insert query
                        cmdInsert.Parameters.AddWithValue("@bookName", bookNameComboBox.SelectedItem.ToString()); // Book Name
                        cmdInsert.Parameters.AddWithValue("@author", AuthortxtBox.Text); // Author Name
                        cmdInsert.Parameters.AddWithValue("@studentName", studentNametxtbox.Text); // Student Name
                        cmdInsert.Parameters.AddWithValue("@publishedDate", DateTime.Parse(publishedDatetxtBox.Text).Date); // Published Date
                        cmdInsert.Parameters.AddWithValue("@issueDate", DateTime.Parse(issuedDate.Text).Date); // Issue Date

                        // Set value for the update query
                        cmdUpdate.Parameters.AddWithValue("@bookName", bookNameComboBox.SelectedItem.ToString()); // Book Name
                        cmdInsert.Parameters.AddWithValue("@genre", genretxtbox.Text); // Student Name

                        connect.Open(); // Open the database connection

                        int rowsAffected = cmdUpdate.ExecuteNonQuery(); // Execute update query to decrease stock

                        if (rowsAffected > 0) // Check if there was enough stock
                        {
                            cmdInsert.ExecuteNonQuery(); // Insert the issued book details
                            AddedSuccessfully addedSuccessfully = new AddedSuccessfully();
                            addedSuccessfully.ShowDialog(); // Show success message
                        }
                        else
                        {
                            // Show message if no stock is available
                            MessageBox.Show("No available stock for the selected book.", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        // Reset form fields
                        bookNameComboBox.SelectedIndex = -1; // Reset book selection
                        AuthortxtBox.Clear(); // Clear author textbox
                        studentNametxtbox.Clear(); // Clear student name textbox
                        publishedDatetxtBox.Clear(); // Clear published date textbox
                        textBox1.Clear(); // Clear additional textbox (if used)
                        genretxtbox.Clear(); // Clear genre textbox

                        // Make labels visible again
                        Booknamelbl.Visible = true;
                        Authorlbl.Visible = true;
                        studentNamelbl.Visible = true;
                        publishedDatelbl.Visible = true;
                        genrelbl.Visible = true;
                        publishedDatelbl.BringToFront(); // Bring label to front
                    }
                }
            }
            catch (SqlException ex)
            {
                // Show error message if there's a database issue
                MessageBox.Show("Database error: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Show error message for any unexpected issues
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the database connection is closed after use
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void ViewBtn_Click(object sender, EventArgs e)
        {
            // When the "View" button is clicked, open a form that shows the issued book data.
            OpenChildForm(new ShowIssueBookData());
        }

        private void OpenChildForm(Form childForm)
        {
            // If a child form is already open, close it before opening a new one.
            if (currentChildForm != null)
            {
                currentChildForm.Close(); // Close the current child form.
            }
            // Set the new child form to be the current form.
            currentChildForm = childForm;
            childForm.TopLevel = false;  // Set the child form to be inside the parent form (not a separate window).
            childForm.FormBorderStyle = FormBorderStyle.None;  // Remove the form border.
            childForm.Dock = DockStyle.Fill;  // Make the form fill the available space.
            panel1.Controls.Add(childForm);  // Add the child form to the panel.
            panel1.Tag = childForm;  // Set the panel’s tag to the new child form.
            childForm.BringToFront();  // Bring the child form to the front.
            childForm.Show();  // Display the child form.
        }

        private void bookNameComboBox_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void bookNameComboBox_DropDown(object sender, EventArgs e)
        {
            Booknamelbl.Visible = false;
        }

        private void bookNameComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bookNameComboBox.Text))
            {
                Booknamelbl.Visible = true;
            }
        }
        private void bookNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {           
            if (bookNameComboBox.SelectedIndex != -1)
            {
                Booknamelbl.Visible = false;
                Authorlbl.Visible = false;
                publishedDatelbl.Visible = false;
                genrelbl.Visible = false;

                // Get selected book name
                string selectedBookName = bookNameComboBox.SelectedItem.ToString();
                textBox1.Text = selectedBookName;
                // Fetch the details for the selected book
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30";
                string query = "SELECT datePick, author, genre FROM books WHERE bookName = @bookName";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@bookName", selectedBookName);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Display datePick and author in their respective TextBoxes
                        publishedDatetxtBox.Text = reader["datePick"].ToString();
                        AuthortxtBox.Text = reader["author"].ToString();
                        genretxtbox.Text = reader["genre"].ToString();
                    }
                    connection.Close();
                }
            }
        }

        private void LoadBooks()
        {
            //connecting to the Database
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30";
            string query = "SELECT DISTINCT bookName FROM books"; // Fetch all book names

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read()) // Loop through each book name
                        {
                            bookNameComboBox.Items.Add(reader["bookName"].ToString()); // Add to ComboBox
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            bookNameComboBox.Focus();
        }
    }
}
