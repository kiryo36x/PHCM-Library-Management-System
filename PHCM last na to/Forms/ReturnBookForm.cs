using PHCM_last_na_to.Other_Toast_Message; // Importing basic namespaces required for working with data, graphics, and user interface components in a Windows Forms application
using PHCM_last_na_to.Toast_Message_for_add_student_information; // Importing basic namespaces required for working with data, graphics, and user interface components in a Windows Forms application
using System;  // This is for basic programming functionality
using System.Data; // Provides classes for managing and working with data, such as datasets, data tables, and database connections.
using System.Data.SqlClient;  // This is for connecting to and interacting with a SQL database
using System.Drawing;  // This helps in working with colors, fonts, and other visual elements
using System.IO; // Enables the program to work with files and directories (e.g., reading, writing, or saving files).
using System.Windows.Forms;  // This is for creating windows (forms) and controls, like buttons and text boxes, that users interact with in the application


namespace PHCM_last_na_to.Forms
{
    public partial class ReturnBookForm : Form
    {       
        // Declaring a variable to hold the current form that's being shown inside the parent form
        private Form currentChildForm;
        private string selectedGenre = "All"; // Default to "All"
        private bool isSelectingRow = false; // Flag to indicate row selection

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
            ShowSelection.Visible = true;            
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
            if (string.IsNullOrEmpty(SelectBooks.Text) || string.IsNullOrEmpty(AuthortxtBox.Text) ||
                string.IsNullOrEmpty(studentNameComboBox.Text) || string.IsNullOrEmpty(publishedDatetxtBox.Text) ||
                string.IsNullOrEmpty(issueDatetxtbox.Text) || string.IsNullOrEmpty(returnDatetxtbox.Text) ||
                string.IsNullOrEmpty(conditiontxtbox.Text))
            {
                // Show a message if any field is empty
                EmptyField emptyField = new EmptyField();
                emptyField.Show();
                return; // Stop the function here
            }

            // SQL query to insert the returned book details into the returnBook table
            string insertQuery = "INSERT INTO returnBook (bookName, author, studentName, publishedDate, issueDate, returnDate, condition, genre) " +
                                 "VALUES(@bookName, @author, @studentName, @publishedDate, @issueDate, @returnDate, @condition, @genre)";

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
                        cmdInsert.Parameters.AddWithValue("@bookName", SelectBooks.Text); // Book Name
                        cmdInsert.Parameters.AddWithValue("@author", AuthortxtBox.Text); // Author Name
                        cmdInsert.Parameters.AddWithValue("@studentName", studentNameComboBox.SelectedItem.ToString()); // Student Name
                        cmdInsert.Parameters.AddWithValue("@publishedDate", DateTime.Parse(publishedDatetxtBox.Text).Date); // Published Date
                        cmdInsert.Parameters.AddWithValue("@issueDate", DateTime.Parse(issueDatetxtbox.Text).Date); // Issue Date
                        cmdInsert.Parameters.AddWithValue("@returnDate", DateTime.Parse(returnDatetxtbox.Text).Date); // Return Date
                        cmdInsert.Parameters.AddWithValue("@condition", conditiontxtbox.Text); // Condition of the Book
                        cmdInsert.Parameters.AddWithValue("@genre", genretxtbox.Text); // Author Name
                        cmdInsert.ExecuteNonQuery(); // Execute the query to insert data
                    }

                    // Step 2️⃣: Update the books table to increase the book quantity by 1
                    using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, connection, transaction))
                    {
                        cmdUpdate.Parameters.AddWithValue("@bookName", SelectBooks.Text); // Book Name
                        cmdUpdate.ExecuteNonQuery(); // Execute the query to update quantity
                    }

                    // Step 3️⃣: Delete the issued book record from the issue table (book is returned)
                    using (SqlCommand cmdDelete = new SqlCommand(deleteQuery, connection, transaction))
                    {
                        cmdDelete.Parameters.AddWithValue("@bookname", SelectBooks.Text); // Book Name
                        cmdDelete.Parameters.AddWithValue("@studentName", studentNameComboBox.SelectedItem.ToString()); // Student Name
                        cmdDelete.ExecuteNonQuery(); // Execute the query to delete the issued record
                    }

                    transaction.Commit(); // Commit the transaction to save all changes
                    MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // Success message

                    // Reset form fields and clear input                   

                    AuthortxtBox.Clear(); // Clear author textbox
                    publishedDatetxtBox.Clear(); // Clear published date textbox
                    issueDatetxtbox.Clear(); // Clear issue date textbox
                    returnDatetxtbox.Clear(); // Clear return date textbox
                    SelectBooks.Clear(); // Clear additional textbox (if used)
                    textBox2.Clear(); // Clear additional textbox (if used)
                    genretxtbox.Clear(); // Clear genre textbox
                    SelectBooks.Clear(); // Clear book name textbox

                    studentNameComboBox.SelectedIndex = -1; // Reset student selection
                    studentNameComboBox.Items.Clear(); // Clear student list

                    // Make labels visible again
                    Booknamelbl.Visible = true;
                    Authorlbl.Visible = true;
                    studentNamelbl.Visible = true;
                    publishedDatelbl.Visible = true;
                    issueDatelbl.Visible = true;
                    returnDatelbl.Visible = true;
                    genrelbl.Visible = true;

                    conditiontxtbox.Clear(); // Clear condition textbox
                    label2.Visible = true; // Make label visible
                    
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
            

            // Clear all input fields and reset controls to their default state
            AuthortxtBox.Clear();
            publishedDatetxtBox.Clear();
            issueDatetxtbox.Clear();
            returnDatetxtbox.Clear();
            SelectBooks.Clear();
            textBox2.Clear();
            genretxtbox.Clear();

            
            studentNameComboBox.SelectedIndex = -1;
            studentNameComboBox.Items.Clear(); // Clear student names

            // Make all labels visible again
            Booknamelbl.Visible = true;
            Authorlbl.Visible = true;
            studentNamelbl.Visible = true;
            publishedDatelbl.Visible = true;
            issueDatelbl.Visible = true;
            returnDatelbl.Visible = true;
            genrelbl.Visible = true;

            conditiontxtbox.Clear(); //Clear the text box inside of Condition
            label2.Visible = true; //Make all label visible again
            

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
            // TODO: This line of code loads data into the 'books.books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.books.books);
            // Set the tab order for all controls on the form (used for keyboard navigation)
            AuthortxtBox.TabIndex = 0;
            publishedDatetxtBox.TabIndex = 1;
            issueDatetxtbox.TabIndex = 2;
            returnDatetxtbox.TabIndex = 3;

            SaveBtn.TabIndex = 6;
            ViewBtn.TabIndex = 7;
            ClearBtn.TabIndex = 8;                        
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
        
        // When the user clicks textBox1 (which displays the selected book name)
        private void textBox1_Click(object sender, EventArgs e)
        {
            // Move focus to the bookNameComboBox to allow the user to select a book
            ShowSelection.Visible = true;
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
            if (studentNameComboBox.SelectedItem != null && !string.IsNullOrEmpty(SelectBooks.Text))
            {
                // Hide the issue date label
                issueDatelbl.Visible = false;

                // Store selected student name
                string selectedStudent = studentNameComboBox.SelectedItem.ToString();
                textBox2.Text = selectedStudent; // Display selected student in textBox2

                // Store selected book name                

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
                            cmd.Parameters.AddWithValue("@bookName", SelectBooks.Text); // Add book name as a parameter
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

        private void SelectingBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isSelectingRow = false; // Reset the flag when a cell is clicked
            }
        }

        private void SelectingBooks_SelectionChanged(object sender, EventArgs e)
        {
            isSelectingRow = true; // Set the flag to true when a row is selected
        }

        private void currentGnre_Click(object sender, EventArgs e)
        {
            genreselectorpanel.Visible = true;
            genreselectorpanel.BringToFront();
        }
        private void CurrentDate()
        {
            // Set the current date in the return date text box
            returnDatetxtbox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            returnDatelbl.Visible = false;
        }
        private void SaveBookbtn_Click(object sender, EventArgs e)
        {
            // Check if the user has selected at least one row from the list of books
            if (SelectingBooks.SelectedRows.Count > 0)
            {
                // Get the first selected row (assuming only one row is selected)
                DataGridViewRow selectedRow = SelectingBooks.SelectedRows[0];

                // Retrieve the book name from the selected row
                object SelectedBookName = selectedRow.Cells["bookNameDataGridViewTextBoxColumn"].Value;
                // Retrieve the author from the selected row
                object DisplayAuthor = selectedRow.Cells["authorDataGridViewTextBoxColumn"].Value;
                // Retrieve the publication date from the selected row
                object DisplayDate = selectedRow.Cells["datePickDataGridViewTextBoxColumn"].Value;
                // Retrieve the genre from the selected row
                object DisplayGenre = selectedRow.Cells["genreDataGridViewTextBoxColumn"].Value;

                // If a book name is found in the selected row
                if (SelectedBookName != null)
                {
                    // Display the selected book name in the text box outside the panel
                    SelectBooks.Text = SelectedBookName.ToString();
                    // Hide the label that prompts for the book name
                    Booknamelbl.Visible = false;
                    // Hide the selection panel
                    ShowSelection.Visible = false;
                    // Update the current date or perform a date-related action (via the CurrentDate() method)
                    CurrentDate();
                }
                else
                {
                    // If no book name is found, show a prompt asking to select a book first
                    new SelectBooksFirst().Show();
                }

                // If an author is found in the selected row
                if (DisplayAuthor != null)
                {
                    // Display the author in the appropriate text box
                    AuthortxtBox.Text = DisplayAuthor.ToString();
                    // Hide the label that prompts for the author
                    Authorlbl.Visible = false;
                    // Hide the selection panel
                    ShowSelection.Visible = false;
                    // Update the current date or perform a date-related action
                    CurrentDate();
                }
                else
                {
                    // If no author is found, clear the author text box
                    AuthortxtBox.Text = string.Empty;
                }

                // If a publication date is found in the selected row
                if (DisplayDate != null)
                {
                    // Convert the date to a short date string and display it in the text box
                    publishedDatetxtBox.Text = Convert.ToDateTime(DisplayDate).ToShortDateString();
                    // Hide the label that prompts for the publication date
                    publishedDatelbl.Visible = false;
                    // Hide the selection panel
                    ShowSelection.Visible = false;
                    // Update the current date or perform a date-related action
                    CurrentDate();
                }
                else
                {
                    // If no publication date is found, clear the text box
                    publishedDatetxtBox.Text = string.Empty;
                }

                // If a genre is found in the selected row
                if (DisplayGenre != null)
                {
                    // Display the genre in the appropriate text box
                    genretxtbox.Text = DisplayGenre.ToString();
                    // Hide the label that prompts for the genre
                    genrelbl.Visible = false;
                    // Hide the selection panel
                    ShowSelection.Visible = false;
                    // Update the current date or perform a date-related action
                    CurrentDate();
                }
                else
                {
                    // If no genre is found, clear the text box
                    genretxtbox.Text = string.Empty;
                }

                // Populate the student ComboBox with students who borrowed the selected book
                PopulateStudentComboBox(SelectedBookName.ToString());
            }
            else
            {
                // If no row is selected, show a message asking to select a book first
                new SelectBooksFirst().Show();
            }
        }

        private void PopulateStudentComboBox(string bookName)
        {
            // Remove any previously listed student names from the ComboBox.
            studentNameComboBox.Items.Clear();

            // Define the connection details to the database.
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\blood\OneDrive\Documents\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30";

            // Create an SQL query that gets unique student names from the "issue" table for the given book.
            string query = "SELECT DISTINCT studentName FROM issue WHERE bookName = @bookName";

            // Open a connection to the database using the connection string.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the database connection.
                    conn.Open();

                    // Create an SQL command with the query and the database connection.
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add the book name to the SQL query as a parameter.
                        cmd.Parameters.AddWithValue("@bookName", bookName);

                        // Execute the query and get the results.
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Loop through each record returned by the query.
                            while (reader.Read())
                            {
                                // Get the student name from the current record.
                                string studentName = reader["studentName"].ToString();
                                // Add this student name to the ComboBox list.
                                studentNameComboBox.Items.Add(studentName);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // If an error happens, show an error message with details.
                    MessageBox.Show("An error occurred while retrieving student data: " + ex.Message);
                }
            }

            // If any student names were added, select the first one in the ComboBox.
            if (studentNameComboBox.Items.Count > 0)
            {
                studentNameComboBox.SelectedIndex = 0;
            }
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            // Hide the selection panel.
            ShowSelection.Visible = false;
            // If no book has been selected (the text box is empty), show the book name label as a prompt.
            if (string.IsNullOrEmpty(SelectBooks.Text))
            {
                Booknamelbl.Visible = true;
            }
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            // Skip search logic if a row is being selected
            if (isSelectingRow)
            {
                return; // Exit the method if a row is being selected
            }

            // If the search box is empty, hide the messages and reload books based on the selected genre
            if (string.IsNullOrEmpty(searchbox.Text))
            {
                Notfound.Visible = false;
                Question.Visible = false;

                // Check if the selected genre is "All" or a specific genre
                if (selectedGenre.ToLower() == "all")
                {
                    LoadAllBooks(); // Reload all books if "All" is selected
                }
                else
                {
                    // If a specific genre is selected, filter books by that genre
                    SearchGenre(selectedGenre); // Call the method to search by the selected genre
                }
            }
            else
            {
                SearchBooks(searchbox.Text); // Perform search with the current genre
            }
        }

        private void searchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the Enter key is pressed, perform the search
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Check if the search box is empty
                if (string.IsNullOrEmpty(searchbox.Text) || searchbox.Text.Trim() == "")
                {
                    // If empty, check the selected genre
                    if (selectedGenre.ToLower() == "all")
                    {
                        LoadAllBooks(); // Load all books if "All" is selected
                    }
                    else
                    {
                        SearchGenre(selectedGenre); // Call the method to search by the selected genre
                    }
                }
                else
                {
                    // If not empty, perform a search with the current text
                    SearchBooks(searchbox.Text); // Perform the search
                }
            }
        }

        private void closepnl_Click(object sender, EventArgs e)
        {
            genreselectorpanel.Visible = false;
        }

        private void genreSelection(object sender, EventArgs e)
        {
            if (sender is Label selectGenre)
            {
                selectedGenre = selectGenre.Text; // Store the selected genre
                currentGnre.Text = selectGenre.Text; // Update the UI to show the selected genre
                genreselectorpanel.Visible = false; // Hide the genre selection panel
                searchbox.Text = ""; // Clear the search box
                // Perform a search based on the selected genre
                if (selectedGenre.ToLower() == "all")
                {
                    LoadAllBooks(); // Load all books if "All" is selected
                }
                else
                {
                    SearchGenre(selectedGenre); // Search by the selected genre

                }
            }
        }

        private void genreHover(object sender, EventArgs e) // When the mouse hovers over a genre label
        {
            if (sender is Label HoverGenre) // Check if the sender is a Label
            {
                HoverGenre.BackColor = Color.FromArgb(76, 75, 105); // Change the background color of the label
            }
        }

        private void genreOut(object sender, EventArgs e) // When the mouse leaves a genre label
        {
            if (sender is Label HoverGenre) // Check if the sender is a Label
            {
                HoverGenre.BackColor = Color.FromArgb(31, 30, 68); // Change the background color of the label
            }
        }
        private void SearchGenre(string searchTerm)
        {
            Notfound.Visible = false; // Hide 'Not Found' message
            Question.Visible = false; // Hide 'Question' message
            try
            {
                DataTable dt = new DataTable(); // Create a new DataTable to store search results
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    // Prepare a query to search books by name or author
                    string query = "SELECT id, bookName, author, datePick, quantity, bookPicture, picture, genre FROM books " +
                                   "WHERE genre LIKE @search";

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%"); // Bind search term

                        connect.Open(); // Open connection to the database
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Use adapter to fill the DataTable with results
                        adapter.Fill(dt);

                        // If no records are found, show 'Not Found' message
                        if (dt.Rows.Count == 0)
                        {
                            Notfound.ForeColor = Color.Black; // Set color of message to black
                            Notfound.Visible = true; // Make 'Not Found' message visible
                            Question.Visible = true; // Make 'Question' message visible
                        }

                        // Convert Image Data from BYTE[] to Bitmap
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["picture"] != DBNull.Value) // Check if the row contains an image
                            {
                                byte[] imageBytes = (byte[])row["picture"]; // Retrieve image bytes from the row
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    // Convert byte array to Image
                                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                                    // Convert the Image back to byte array to store it in the DataTable
                                    using (MemoryStream saveStream = new MemoryStream())
                                    {
                                        img.Save(saveStream, img.RawFormat); // Save the image to the stream
                                        byte[] imageBytesToStore = saveStream.ToArray(); // Get byte array

                                        // Store the byte array back in the 'picture' column
                                        row["picture"] = imageBytesToStore;
                                    }
                                }
                            }
                        }

                        // Refresh DataGridView to display changes
                        SelectingBooks.DataSource = dt; // Set the DataGridView's data source
                        SelectingBooks.Refresh(); // Refresh the DataGridView to show the updated data
                    }
                }
            }
            catch (Exception ex)
            {
                // If an error occurs, show the error message
                MessageBox.Show("Error: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadAllBooks()
        {
            try
            {
                Notfound.Visible = false; // Hide 'Not Found' message
                Question.Visible = false; // Hide 'Question' message
                DataTable dt = new DataTable(); // Create a new DataTable for all books
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string query = "SELECT id, bookName, author, datePick, quantity, bookPicture, picture, genre FROM books"; // Query to fetch all books
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        connect.Open(); // Open connection to the database
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Use adapter to fill the DataTable
                        adapter.Fill(dt);

                        SelectingBooks.DataSource = dt; // Display all books in the DataGridView
                        SelectingBooks.Refresh(); // Refresh the DataGridView to show the updated data
                    }
                }
            }
            catch (Exception ex)
            {
                // If an error occurs, show the error message
                MessageBox.Show("Error: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchBooks(string searchTerm)
        {
            Notfound.Visible = false; // Hide 'Not Found' message
            Question.Visible = false; // Hide 'Question' message
            try
            {
                DataTable dt = new DataTable(); // Create a new DataTable to store search results
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    // Prepare a query to search books by name or author, and filter by genre
                    string query = "SELECT id, bookName, author, datePick, quantity, bookPicture, picture, genre FROM books " +
                                   "WHERE (bookName LIKE @search OR author LIKE @search)";

                    // If a specific genre is selected, add it to the query
                    if (selectedGenre.ToLower() != "all")
                    {
                        query += " AND genre LIKE @genre";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%"); // Bind search term

                        // If a specific genre is selected, bind the genre parameter
                        if (selectedGenre.ToLower() != "all")
                        {
                            cmd.Parameters.AddWithValue("@genre", "%" + selectedGenre + "%");
                        }

                        connect.Open(); // Open connection to the database
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Use adapter to fill the DataTable with results
                        adapter.Fill(dt);

                        // If no records are found, show 'Not Found' message
                        if (dt.Rows.Count == 0)
                        {
                            Notfound.ForeColor = Color.Black; // Set color of message to black
                            Notfound.Visible = true; // Make 'Not Found' message visible
                            Question.Visible = true; // Make 'Question' message visible
                        }

                        // Convert Image Data from BYTE[] to Bitmap
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["picture"] != DBNull.Value) // Check if the row contains an image
                            {
                                byte[] imageBytes = (byte[])row["picture"]; // Retrieve image bytes from the row
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    // Convert byte array to Image
                                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                                    // Convert the Image back to byte array to store it in the DataTable
                                    using (MemoryStream saveStream = new MemoryStream())
                                    {
                                        img.Save(saveStream, img.RawFormat); // Save the image to the stream
                                        byte[] imageBytesToStore = saveStream.ToArray(); // Get byte array

                                        // Store the byte array back in the 'picture' column
                                        row["picture"] = imageBytesToStore;
                                    }
                                }
                            }
                        }

                        // Refresh DataGridView to display changes
                        SelectingBooks.DataSource = dt; // Set the DataGridView's data source
                        SelectingBooks.Refresh(); // Refresh the DataGridView to show the updated data
                    }
                }
            }
            catch (Exception ex)
            {
                // If an error occurs, show the error message
                MessageBox.Show("Error: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
