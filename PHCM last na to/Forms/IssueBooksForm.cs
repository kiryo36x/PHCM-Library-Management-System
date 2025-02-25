using PHCM_last_na_to.Other_Toast_Message; // Import the Toast message functionality for adding books (custom message display for book-related actions)
using PHCM_last_na_to.Toast_Message_for_add_books;  // Import the Toast message functionality for adding books (custom message display for book-related actions)
using PHCM_last_na_to.Toast_Message_for_add_student_information;  // Import the Toast message functionality for adding student information (custom message display for student-related actions)
using System;  // Import basic system functionalities (e.g., types like DateTime, String, etc.)
using System.Data;  // Import classes to manage and manipulate data (e.g., DataTable, DataSet for working with tables)
using System.Data.SqlClient;  // Import classes to connect and interact with SQL databases (e.g., SqlConnection for database con
using System.Drawing; // Allows the program to work with images, colors, and drawing operations.
using System.IO; // Enables the program to work with files and folders (for example, reading, writing, or saving files).
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

        private string selectedGenre = "All"; // Default to "All"
        private bool isSelectingRow = false; // Flag to indicate row selection

        private void IssueBooksForm_Load(object sender, EventArgs e)
        {            
            // TODO: This line of code loads data into the 'books.books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.books.books);
            // When the form loads, the following code will run:
            DateTimePicker dateTimePicker = new DateTimePicker();  // Create a new DateTimePicker control (calendar picker).
            dateTimePicker.Value = DateTime.Now;  // Set the current date and time as the default value.
            dateTimePicker.Format = DateTimePickerFormat.Short;  // Set the format to show a short date (e.g., MM/DD/YYYY).
            dateTimePicker.MinDate = DateTime.Now;  // Set the minimum allowed date to today's date.
            issuedDate.Text = "     " + dateTimePicker.Value.ToString();  // Display the selected date on the label `issuedDate` in a specific format.                        
        }

        private void Booknamelbl_Click(object sender, EventArgs e)
        {            
            ShowSelection.Visible = true;  // When the book name label is clicked, show the book selection panel.
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
            SelectBooks.Clear(); // Clear additional textbox (if used)
            AuthortxtBox.Clear(); // Clear author textbox
            studentNametxtbox.Clear(); // Clear student name textbox
            publishedDatetxtBox.Clear(); // Clear published date textbox
            SelectBooks.Clear(); // Clear additional textbox (if used)
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
                if (string.IsNullOrEmpty(SelectBooks.Text) || string.IsNullOrEmpty(AuthortxtBox.Text) ||
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
                        cmdInsert.Parameters.AddWithValue("@bookName", SelectBooks.Text); // Book Name
                        cmdInsert.Parameters.AddWithValue("@author", AuthortxtBox.Text); // Author Name
                        cmdInsert.Parameters.AddWithValue("@studentName", studentNametxtbox.Text); // Student Name
                        cmdInsert.Parameters.AddWithValue("@publishedDate", DateTime.Parse(publishedDatetxtBox.Text).Date); // Published Date
                        cmdInsert.Parameters.AddWithValue("@issueDate", DateTime.Parse(issuedDate.Text).Date); // Issue Date

                        // Set value for the update query                        
                        cmdUpdate.Parameters.AddWithValue("@bookName", SelectBooks.Text); // Book Name
                        cmdInsert.Parameters.AddWithValue("@genre", genretxtbox.Text); // Genre Name

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
                        SelectBooks.Clear(); // Clear additional textbox (if used)
                        AuthortxtBox.Clear(); // Clear author textbox
                        studentNametxtbox.Clear(); // Clear student name textbox
                        publishedDatetxtBox.Clear(); // Clear published date textbox
                        SelectBooks.Clear(); // Clear additional textbox (if used)
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

        private void textBox1_Click(object sender, EventArgs e)
        {
            ShowSelection.Visible = true; // When textBox1 is clicked, show the selection panel (or control) on the screen.
        }

        private void SaveBookbtn_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the books list
            if (SelectingBooks.SelectedRows.Count > 0)
            {
                // Get the first selected row (assuming only one row is selected)
                DataGridViewRow selectedRow = SelectingBooks.SelectedRows[0];

                // Get the book's name from the selected row
                object SelectedBookName = selectedRow.Cells["bookNameDataGridViewTextBoxColumn"].Value;
                // Get the book's author from the selected row
                object DisplayAuthor = selectedRow.Cells["authorDataGridViewTextBoxColumn"].Value;
                // Get the book's publication date from the selected row
                object DisplayDate = selectedRow.Cells["datePickDataGridViewTextBoxColumn"].Value;
                // Get the book's genre from the selected row
                object DisplayGenre = selectedRow.Cells["genreDataGridViewTextBoxColumn"].Value;

                if (SelectedBookName != null)
                {
                    // Set the selected book's name into a TextBox outside the panel
                    SelectBooks.Text = SelectedBookName.ToString();
                    // Hide the label that shows the book name prompt
                    Booknamelbl.Visible = false;
                    // Hide the selection panel
                    ShowSelection.Visible = false;
                }
                else
                {
                    // If no book name is selected, show a message telling the user to select a book first
                    new SelectBooksFirst().Show();
                }
                if (DisplayAuthor != null)
                {
                    // Set the author TextBox with the selected book's author
                    AuthortxtBox.Text = DisplayAuthor.ToString();
                    // Hide the author label (prompt)
                    Authorlbl.Visible = false;
                    // Hide the selection panel
                    ShowSelection.Visible = false;
                }
                else
                {
                    // If no author is found, clear the author TextBox
                    AuthortxtBox.Text = string.Empty;
                }

                if (DisplayDate != null)
                {
                    // Convert and set the publication date in a short date format into the published date TextBox
                    publishedDatetxtBox.Text = Convert.ToDateTime(DisplayDate).ToShortDateString();
                    // Hide the published date label (prompt)
                    publishedDatelbl.Visible = false;
                    // Hide the selection panel
                    ShowSelection.Visible = false;
                }
                else
                {
                    // If no date is found, clear the published date TextBox
                    publishedDatetxtBox.Text = string.Empty;
                }
                if (DisplayGenre != null)
                {
                    // Set the genre TextBox with the selected book's genre
                    genretxtbox.Text = DisplayGenre.ToString();
                    // Hide the genre label (prompt)
                    genrelbl.Visible = false;
                    // Hide the selection panel
                    ShowSelection.Visible = false;
                }
                else
                {
                    // If no genre is found, clear the genre TextBox
                    genretxtbox.Text = string.Empty;
                }
            }
            else
            {
                // If no row is selected, show a message prompting the user to select a book first
                new SelectBooksFirst().Show();
            }
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            // Hide the selection panel when the exit button is clicked
            ShowSelection.Visible = false;
            // If no book has been selected (TextBox is empty), show the book name prompt label
            if (string.IsNullOrEmpty(SelectBooks.Text))
            {
                Booknamelbl.Visible = true;
            }
        }

        private void currentGnre_Click(object sender, EventArgs e)
        {
            // When the current genre control is clicked, show the panel that lets you select a genre
            genreselectorpanel.Visible = true;
            // Bring the genre selection panel to the front so it appears on top of other controls
            genreselectorpanel.BringToFront();
        }

        private void closepnl_Click(object sender, EventArgs e)
        {
            // When the close panel button is clicked, hide the genre selection panel
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
        private void genreHover(object sender, EventArgs e)
        // This method is triggered when the mouse pointer moves over a label (genre).  
        {
            if (sender is Label HoverGenre)
            // Check if the item that triggered this event is a label.  
            {
                HoverGenre.BackColor = Color.FromArgb(76, 75, 105);
                // Change the background color of the label to a darker shade.  
            }
        }

        private void genreOut(object sender, EventArgs e)
        // This method is triggered when the mouse pointer leaves the label (genre).  
        {
            if (sender is Label HoverGenre)
            // Check if the item that triggered this event is a label.  
            {
                HoverGenre.BackColor = Color.FromArgb(31, 30, 68);
                // Restore the background color of the label to its original Color.
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
