using PHCM_last_na_to.Other_Toast_Message; // Importing basic namespaces required for working with data, graphics, and user interface components in a Windows Forms application
using PHCM_last_na_to.Toast_Message_for_add_student_information; // Importing basic namespaces required for working with data, graphics, and user interface components in a Windows Forms application
using System;  // This is for basic programming functionality
using System.Data; // Provides classes for managing and working with data, such as datasets, data tables, and database connections.
using System.Data.SqlClient;  // This is for connecting to and interacting with a SQL database
using System.Drawing;  // This helps in working with colors, fonts, and other visual elements
using System.IO; // Enables the program to work with files and directories (e.g., reading, writing, or saving files).
using System.Windows.Forms;

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
            returnBookTitle.Location = new System.Drawing.Point((mainReturnBook.Size.Width - returnBookTitle.Size.Width) / 2, 9);
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
            StudentPanel.Visible = true;
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
                string.IsNullOrEmpty(DisplayStudenttxtbox.Text) || string.IsNullOrEmpty(publishedDatetxtBox.Text) ||
                string.IsNullOrEmpty(issueDatetxtbox.Text) || string.IsNullOrEmpty(returnDatetxtbox.Text) ||
                string.IsNullOrEmpty(conditiontxtbox.Text) || studentPicture.Image == Properties.Resources.add_pictures)
            {
                // Show a message if any field is empty
                EmptyField emptyField = new EmptyField();
                emptyField.Show();
                return; // Stop the function here
            }

            // SQL query to insert the returned book details into the returnBook table
            string insertQuery = "INSERT INTO returnBook (bookName, author, studentName, publishedDate, issueDate, returnDate, condition, genre, studentImage) " +
                                 "VALUES(@bookName, @author, @studentName, @publishedDate, @issueDate, @returnDate, @condition, @genre, @studentImage)";

            // SQL query to increase the quantity of the returned book in the books table
            string updateQuery = "UPDATE books SET quantity = quantity + 1 WHERE bookName = @bookName";

            // SQL query to remove the returned book entry from the issue table (since it's no longer issued)
            string deleteQuery = "DELETE FROM issue WHERE bookName = @bookName AND studentName = @studentName";

            // Establish connection to the database
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
                "C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
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
                        cmdInsert.Parameters.AddWithValue("@studentName", DisplayStudenttxtbox.Text); // Student Name
                        cmdInsert.Parameters.AddWithValue("@publishedDate", DateTime.Parse(publishedDatetxtBox.Text).Date); // Published Date
                        cmdInsert.Parameters.AddWithValue("@issueDate", DateTime.Parse(issueDatetxtbox.Text).Date); // Issue Date
                        cmdInsert.Parameters.AddWithValue("@returnDate", DateTime.Parse(returnDatetxtbox.Text).Date); // Return Date
                        cmdInsert.Parameters.AddWithValue("@condition", conditiontxtbox.Text); // Condition of the Book
                        cmdInsert.Parameters.AddWithValue("@genre", genretxtbox.Text); // Author Name                                            
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Check if there is an image in the Picture control
                            if (studentPicture.Image != null)
                            {
                                // Create a new bitmap (a copy of the image) so that the file is not locked
                                using (Bitmap imageToSave = new Bitmap(studentPicture.Image))
                                {
                                    // Save the image into the memory stream in JPEG format
                                    imageToSave.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                }
                            }
                            // Convert the memory stream into a byte array
                            byte[] imageBytes = ms.ToArray();
                            // Set the parameter for student image with the byte array
                            cmdInsert.Parameters.AddWithValue("@studentImage", imageBytes);
                        }
                        cmdInsert.ExecuteNonQuery(); // Execute the query to insert the returned book details
                    }

                    // Update the books table to increase the book quantity by 1
                    using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, connection, transaction))
                    {
                        cmdUpdate.Parameters.AddWithValue("@bookName", SelectBooks.Text); // Book Name
                        cmdUpdate.ExecuteNonQuery(); // Execute the query to update quantity
                    }

                    // Delete the issued book record from the issue table (book is returned)
                    using (SqlCommand cmdDelete = new SqlCommand(deleteQuery, connection, transaction))
                    {
                        cmdDelete.Parameters.AddWithValue("@bookname", SelectBooks.Text); // Book Name
                        cmdDelete.Parameters.AddWithValue("@studentName", DisplayStudenttxtbox.Text); // Student Name
                        cmdDelete.ExecuteNonQuery(); // Execute the query to delete the issued record
                    }

                    transaction.Commit(); // Commit the transaction to save all changes
                    System.Windows.Forms.MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // Success message

                    // Reset form fields and clear input                   

                    AuthortxtBox.Clear(); // Clear author textbox
                    publishedDatetxtBox.Clear(); // Clear published date textbox
                    issueDatetxtbox.Clear(); // Clear issue date textbox
                    returnDatetxtbox.Clear(); // Clear return date textbox
                    SelectBooks.Clear(); // Clear additional textbox (if used)
                    DisplayStudenttxtbox.Clear(); // Clear additional textbox (if used)
                    genretxtbox.Clear(); // Clear genre textbox
                    SelectBooks.Clear(); // Clear book name textbox                   

                    // Reset the student picture to the default image
                    studentPicture.Image = Properties.Resources.add_pictures;

                    // Make labels visible again
                    Booknamelbl.Visible = true;
                    Authorlbl.Visible = true;
                    studentNamelbl.Visible = true;
                    publishedDatelbl.Visible = true;
                    issueDatelbl.Visible = true;
                    returnDatelbl.Visible = true;
                    genrelbl.Visible = true;
                    DisplayStudenttxtbox.Enabled = false; // Disable the student name textbox
                    studentNamelbl.Enabled = false; // Disable the student name label

                    conditiontxtbox.Clear(); // Clear condition textbox
                    EnterConditionlbl.Visible = true; // Make label visible
                    
                }
                catch (SqlException ex)
                {
                    transaction.Rollback(); // Undo all database changes if an error occurs
                    System.Windows.Forms.MessageBox.Show("Database error: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Undo all changes if an unexpected error occurs
                    System.Windows.Forms.MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message
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
            DisplayStudenttxtbox.Clear();
            genretxtbox.Clear();

            studentPicture.Image = Properties.Resources.add_pictures; // Reset the student picture to the default image
            DisplayStudenttxtbox.Enabled = false; // Disable the student name text box
            studentNamelbl.Enabled = false; // Disable the student name label

            // Make all labels visible again
            Booknamelbl.Visible = true;
            Authorlbl.Visible = true;
            studentNamelbl.Visible = true;
            publishedDatelbl.Visible = true;
            issueDatelbl.Visible = true;
            returnDatelbl.Visible = true;
            genrelbl.Visible = true;

            conditiontxtbox.Clear(); //Clear the text box inside of Condition
            EnterConditionlbl.Visible = true; //Make all label visible again
            

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
            mainReturnBook.Controls.Add(childForm);  // Add the child form to the panel
            mainReturnBook.Tag = childForm;  // Tag the panel with the current child form
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
            // TODO: This line of code loads data into the 'issuedBooks.issue' table. You can move, or remove it, as needed.
            this.issueTableAdapter.Fill(this.issuedBooks.issue);
            // TODO: This line of code loads data into the 'books.books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.books.books);
            // TODO: This line of code loads data into the 'studentInformation.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.studentInformation.student);            
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
            EnterConditionlbl.Visible = false; //hide the label
        }

        private void conditiontxtbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conditiontxtbox.Text)) //if the box is empty
            { 
                EnterConditionlbl.Visible = true; //show the label
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

        // When the user clicks on textBox2, set focus to studentNameComboBox
        private void textBox2_Click(object sender, EventArgs e)
        {

        }
        private void SelectingBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isSelectingRow = false; // Reset the flag when a cell is clicked
            }
        }

        // Event triggered when the selection in "SelectingBooks" changes
        private void SelectingBooks_SelectionChanged(object sender, EventArgs e)
        {
            isSelectingRow = true; // Set the flag to true when a row is selected
        }

        // Event triggered when the "currentGnre" button is clicked
        private void currentGnre_Click(object sender, EventArgs e)
        {
            Categoryselectorpanel.Visible = true; // Show the category selection panel
            Categoryselectorpanel.BringToFront(); // Bring the panel to the front
        }

        // Method to set the current date in the return date text box
        private void CurrentDate()
        {
            returnDatetxtbox.Text = DateTime.Now.ToString("yyyy-MM-dd"); // Set current date in "yyyy-MM-dd" format
            returnDatelbl.Visible = false; // Hide the return date label
        }
        private void SaveBookbtn_Click(object sender, EventArgs e)
        {
            if (SelectingBooks.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = SelectingBooks.SelectedRows[0];
                object SelectedBookName = selectedRow.Cells["bookNameDataGridViewTextBoxColumn"].Value;
                object DisplayAuthor = selectedRow.Cells["authorDataGridViewTextBoxColumn"].Value;
                object DisplayDatePublished = selectedRow.Cells["datePickDataGridViewTextBoxColumn"].Value;
                object DisplayGenre = selectedRow.Cells["genreDataGridViewTextBoxColumn"].Value;

                if (SelectedBookName != null)
                {
                    SelectBooks.Text = SelectedBookName.ToString();
                    Booknamelbl.Visible = false;
                    ShowSelection.Visible = false;
                    AuthortxtBox.Text = DisplayAuthor.ToString();
                    publishedDatetxtBox.Text = DisplayDatePublished.ToString();
                    genretxtbox.Text = DisplayGenre.ToString();
                    DisplayStudenttxtbox.Enabled = true;
                    studentNamelbl.Enabled = true;
                    Authorlbl.Visible = false;
                    publishedDatelbl.Visible = false;
                    genrelbl.Visible = false;

                    CurrentDate();

                    // Call the method to load students who borrowed the selected book
                    LoadStudentsWhoBorrowedBook(SelectedBookName.ToString());
                }
                else
                {
                    new SelectBooksFirst().Show();
                }
            }
            else
            {
                new SelectBooksFirst().Show();
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

        // When the label is clicked
        private void closepnl_Click(object sender, EventArgs e)
        {
            // Close the Category Selector Panel
            Categoryselectorpanel.Visible = false;
        }

        private void genreSelection(object sender, EventArgs e)
        {
            if (sender is Label selectGenre)
            {
                selectedGenre = selectGenre.Text; // Store the selected genre
                currentGnre.Text = selectGenre.Text; // Update the UI to show the selected genre
                Categoryselectorpanel.Visible = false; // Hide the genre selection panel
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
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
                    "C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
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
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchBooks(string searchTerm)
        {
            Notfound.Visible = false; // Hide 'Not Found' message
            Question.Visible = false; // Hide 'Question' message
            try
            {
                DataTable dt = new DataTable(); // Create a new DataTable to store search results
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
                    "C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
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
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event triggered when the mouse enters the "currentGnre" button
        private void currentGnre_MouseEnter(object sender, EventArgs e)
        {
            currentGnre.BackColor = Color.FromArgb(76, 75, 105); // Change background color to a lighter shade
            currentGnre.Cursor = System.Windows.Forms.Cursors.Hand; // Change cursor to a hand icon
        }

        // Event triggered when the mouse leaves the "currentGnre" button
        private void currentGnre_MouseLeave(object sender, EventArgs e)
        {
            currentGnre.BackColor = Color.FromArgb(30, 31, 68); // Revert background color to original
            currentGnre.Cursor = System.Windows.Forms.Cursors.Default; // Reset cursor to default
        }

        private void searchbox_Enter(object sender, EventArgs e)
        {
            searchbox.ForeColor = Color.Black; // Changes text color to black when the user clicks the search box.
            searchbox.Clear(); // Clears the text box when clicked.
        }

        private void searchbox_Leave(object sender, EventArgs e)
        {
            // Restores placeholder text and color when the search box is left empty.
            if (string.IsNullOrEmpty(searchbox.Text))
            {
                searchbox.ForeColor = Color.DimGray; // Changes text color to gray for the placeholder.
                searchbox.Text = "Search"; // Restores placeholder text.
            }
        }
        // Event triggered when the mouse enters the "closepnl" button
        private void closepnl_MouseEnter(object sender, EventArgs e)
        {
            closepnl.IconColor = Color.Black; // Change the icon color to black
            closepnl.Cursor = System.Windows.Forms.Cursors.Hand; // Change cursor to hand icon
        }

        // Event triggered when the mouse leaves the "closepnl" button
        private void closepnl_MouseLeave(object sender, EventArgs e)
        {
            closepnl.IconColor = Color.White; // Change the icon color back to white
            closepnl.Cursor = System.Windows.Forms.Cursors.Default; // Reset cursor to default
        }

        // Event triggered when the mouse hovers over a category selection button
        private void categorySelectHover(object sender, EventArgs e)
        {
            if (sender is Button btn) // Check if the sender is a button
            {
                btn.Cursor = System.Windows.Forms.Cursors.Hand; // Change cursor to hand icon
                btn.BackColor = Color.FromArgb(57, 57, 101); // Change background color to a lighter shade
            }
        }

        // Event triggered when the mouse leaves a category selection button
        private void categorySelectLeave(object sender, EventArgs e)
        {
            if (sender is Button btn) // Check if the sender is a button
            {
                btn.Cursor = System.Windows.Forms.Cursors.Default; // Reset cursor to default
                btn.BackColor = Color.FromArgb(31, 30, 68); // Revert background color to original
            }
        }

        // Event triggered when the "Fiction" button is clicked
        private void fictionBtn_Click(object sender, EventArgs e)
        {
            Fictionpnl.Visible = true; // Show the Fiction panel
        }

        // Event triggered when the "Fiction Exit" button is clicked
        private void fictionExit(object sender, EventArgs e)
        {
            Fictionpnl.Visible = false; // Hide the Fiction panel
        }

        // Event triggered when the mouse hovers over the "Exit Fiction" button
        private void exitFictionHover(object sender, EventArgs e)
        {
            exitFictionbtn.Cursor = System.Windows.Forms.Cursors.Hand; // Change cursor to hand icon
            exitFictionbtn.IconColor = Color.Black; // Change icon color to black
        }

        // Event triggered when the mouse leaves the "Exit Fiction" button
        private void exitFictionLeave(object sender, EventArgs e)
        {
            exitFictionbtn.Cursor = System.Windows.Forms.Cursors.Default; // Reset cursor to default
            exitFictionbtn.IconColor = Color.White; // Change icon color back to white
        }

        private void FictionSelection(object sender, EventArgs e)
        {
            if (sender is Label selectGenre) // Check if the sender is a label
            {
                selectedGenre = selectGenre.Text; // Store the selected genre
                currentGnre.Text = selectGenre.Text; // Update the UI to show the selected genre
                Fictionpnl.Visible = false; // Hide the genre selection panel
                Categoryselectorpanel.Visible = false;

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

        private void fictionHover(object sender, EventArgs e)
        {
            if (sender is Label HoverGenre) // Check if the sender is a Label
            {
                // Set the description based on the text of the hovered label
                Description2.Visible = true;
                HoverGenre.BackColor = Color.FromArgb(76, 75, 105); // Change the background color of the label
                if (HoverGenre.Text.ToLower() == "all")
                {
                    Description2.Text = "Shows all the Books Genre";
                }
                else if (HoverGenre.Text.ToLower() == "adventuren fiction")
                {
                    Description2.Text = "Exciting quests, daring journeys.";
                }
                else if (HoverGenre.Text.ToLower() == "children's fiction")
                {
                    Description2.Text = "Stories for young readers.";
                }
                else if (HoverGenre.Text.ToLower() == "classics")
                {
                    Description2.Text = "Timeless, influential literature.";
                }
                else if (HoverGenre.Text.ToLower() == "contemporary")
                {
                    Description2.Text = "Modern, realistic storytelling.";
                }
                else if (HoverGenre.Text.ToLower() == "crime fiction")
                {
                    Description2.Text = "Criminals, investigations, justice.";
                }
                else if (HoverGenre.Text.ToLower() == "drama")
                {
                    Description2.Text = "Emotional, character-driven narratives";
                }
                else if (HoverGenre.Text.ToLower() == "dystopian")
                {
                    Description2.Text = " Oppressive societies, survival themes.";
                }
                else if (HoverGenre.Text.ToLower() == "fairy tales")
                {
                    Description2.Text = "Magical, folklore-inspired stories.";
                }
                else if (HoverGenre.Text.ToLower() == "fantasy")
                {
                    Description2.Text = "Mythical worlds, magic, supernatural.";
                }
                else if (HoverGenre.Text.ToLower() == "historical fiction")
                {
                    Description2.Text = " Fiction set in the past.";
                }
                else if (HoverGenre.Text.ToLower() == "horror")
                {
                    Description2.Text = "Fear, suspense, supernatural elements.";
                }
                else if (HoverGenre.Text.ToLower() == "mystery")
                {
                    Description2.Text = "Puzzles, secrets, detective work.";
                }               
                else if (HoverGenre.Text.ToLower() == "manga")
                {
                    Description2.Text = "Japanese comic-style storytelling.";
                }
                else if (HoverGenre.Text.ToLower() == "psychological fiction")
                {
                    Description2.Text = "Deep mental, emotional exploration.";
                }
                else if (HoverGenre.Text.ToLower() == "romance")
                {
                    Description2.Text = "Love, relationships, emotional connections.";
                }
                else if (HoverGenre.Text.ToLower() == "satire")
                {
                    Description2.Text = "Humor, social criticism, irony.";
                }
                else if (HoverGenre.Text.ToLower() == "science fiction")
                {
                    Description2.Text = " Futuristic, technology, space, time travel.";
                }
                else if (HoverGenre.Text.ToLower() == "short story")
                {
                    Description2.Text = "Brief, impactful narratives.";
                }
                if (HoverGenre.Text.ToLower() == "thriller")
                {
                    Description2.Text = "Suspense, tension, fast-paced action.";
                }
                else if (HoverGenre.Text.ToLower() == "literary fiction")
                {
                    Description2.Text = "Deep themes, character-driven stories.";
                }
                else if (HoverGenre.Text.ToLower() == "western fiction")
                {
                    Description2.Text = "Cowboys, frontier life, adventure.";
                }
                else if (HoverGenre.Text.ToLower() == "magical realism")
                {
                    Description2.Text = "Reality with subtle magical elements.";
                }
                else if (HoverGenre.Text.ToLower() == "young adult")
                {
                    Description2.Text = "Teen-focused themes and storytelling.";
                }
            }
        }

        private void fictionLeave(object sender, EventArgs e)
        {
            if (sender is Label HoverGenre) // Check if the sender is a Label
            {
                HoverGenre.BackColor = Color.FromArgb(31, 30, 68); // Change the background color of the label
                Description2.Visible = false;
            }
        }

        // When the "Non-Fiction" button is clicked, show the nonFiction panel
        private void nonFictionbtn_Click(object sender, EventArgs e)
        {
            nonFictionpnl.Visible = true; // Make the panel visible
        }

        // When the exit button is clicked, hide the nonFiction panel
        private void nonFictionExit(object sender, EventArgs e)
        {
            nonFictionpnl.Visible = false; // Hide the panel
        }

        // When the mouse hovers over the exit button, change the cursor and icon color
        private void nonFictionExitHover(object sender, EventArgs e)
        {
            exitNonFictionbtn.Cursor = System.Windows.Forms.Cursors.Hand; // Change cursor to hand
            exitNonFictionbtn.IconColor = Color.Black; // Change icon color to black
        }

        // When the mouse leaves the exit button, reset the cursor and icon color
        private void nonFictionExitLeave(object sender, EventArgs e)
        {
            exitNonFictionbtn.Cursor = System.Windows.Forms.Cursors.Default; // Reset cursor to default
            exitNonFictionbtn.IconColor = Color.White; // Change icon color back to white
        }


        private void nonFictionSelection(object sender, EventArgs e)
        {
            if (sender is Label selectGenre)
            {
                selectedGenre = selectGenre.Text; // Store the selected genre
                currentGnre.Text = selectGenre.Text; // Update the UI to show the selected genre
                nonFictionpnl.Visible = false; // Hide the genre selection panel
                Categoryselectorpanel.Visible = false;
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

        // When the mouse hovers/entered the exit label
        private void nonFictionHover(object sender, EventArgs e)
        {
            if (sender is Label HoverGenre) // Check if the sender is a Label
            {
                // Set the description based on the text of the hovered label
                Description.Visible = true;
                HoverGenre.BackColor = Color.FromArgb(76, 75, 105); // Change the background color of the label
                if (HoverGenre.Text.ToLower() == "all")
                {
                    Description.Text = "Shows all the Books Genre";
                }
                else if (HoverGenre.Text.ToLower() == "autobiography")
                {
                    Description.Text = "Self-written life story.";
                }
                else if (HoverGenre.Text.ToLower() == "biography")
                {
                    Description.Text = "Life story written by another.";
                }
                else if (HoverGenre.Text.ToLower() == "business")
                {
                    Description.Text = "Entrepreneurship, finance, leadership, strategy.";
                }
                else if (HoverGenre.Text.ToLower() == "cook books")
                {
                    Description.Text = "Recipes, cooking techniques, cuisine.";
                }
                else if (HoverGenre.Text.ToLower() == "essay collections")
                {
                    Description.Text = "Personal insights, opinions, reflections.";
                }
                else if (HoverGenre.Text.ToLower() == "graphic non-fiction")
                {
                    Description.Text = "Illustrated storytelling, sequential art, comics.";
                }
                else if (HoverGenre.Text.ToLower() == "health and wellness")
                {
                    Description.Text = "Fitness, nutrition, self-care.";
                }
                else if (HoverGenre.Text.ToLower() == "history")
                {
                    Description.Text = "Past events, civilizations, historical analysis.";
                }
                else if (HoverGenre.Text.ToLower() == "memoir")
                {
                    Description.Text = "Personal experiences, life stories, reflections.";
                }
                else if (HoverGenre.Text.ToLower() == "philosophy")
                {
                    Description.Text = "Existence, knowledge, reasoning, ethics.";
                }
                else if (HoverGenre.Text.ToLower() == "poetry")
                {
                    Description.Text = "Expressive, rhythmic, literary art.";
                }
                else if (HoverGenre.Text.ToLower() == "political")
                {
                    Description.Text = "Government, policies, political analysis.";
                }
                else if (HoverGenre.Text.ToLower() == "reference books")
                {
                    Description.Text = "Facts, information, research resources.";
                }
                else if (HoverGenre.Text.ToLower() == "science")
                {
                    Description.Text = "Experiments, discoveries, natural laws.";
                }
                else if (HoverGenre.Text.ToLower() == "self-help")
                {
                    Description.Text = "Personal growth, motivation, success.";
                }
                else if (HoverGenre.Text.ToLower() == "spirituality")
                {
                    Description.Text = "Faith, inner peace, beliefs.";
                }
                else if (HoverGenre.Text.ToLower() == "true crime")
                {
                    Description.Text = "Real cases, investigations, criminals.";
                }
                else if (HoverGenre.Text.ToLower() == "western")
                {
                    Description.Text = "Cowboys, frontier life, adventure.";
                }               
            }
        }

        // When the mouse leave the exit label
        private void nonFictionLeave(object sender, EventArgs e)
        {
            if (sender is Label HoverGenre) // Check if the sender is a Label
            {
                HoverGenre.BackColor = Color.FromArgb(31, 30, 68); // Change the background color of the label
                Description.Visible = false;
            }
        }

        private void DisplayStudenttxtbo_Click(object sender, EventArgs e)
        {
            StudentPanel.Visible = true; // Show the student panel
            LoadStudentsWhoBorrowedBook(SelectBooks.Text); // Load students who borrowed the selected book
        }

        private void returnStudentbtn_Click(object sender, EventArgs e)
        {
            StudentPanel.Visible = false; // Hide the student panel
        }

        private void saveStudentbtn_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the books list
            if (studentDataTable.SelectedRows.Count > 0)
            {
                // Get the first selected row (assuming only one row is selected)
                DataGridViewRow selectedRow = studentDataTable.SelectedRows[0];

                // Get the student's name from the selected row
                object SelectedStudentName = selectedRow.Cells["studentNameDataGridViewTextBoxColumn"].Value;
                // Get the book's author from the selected row
                object DisplayStudentImage = selectedRow.Cells["studentImageDataGridViewImageColumn"].Value;
                // Get the issued date from the selected row
                object DisplayIssueDate = selectedRow.Cells["issueDate"].Value;

                if (SelectedStudentName != null)
                {
                    // Set the selected book's name into a TextBox outside the panel
                    DisplayStudenttxtbox.Text = SelectedStudentName.ToString();
                    // Hide the label that shows the book name prompt
                    studentNamelbl.Visible = false;
                    // Hide the selection panel
                    StudentPanel.Visible = false;
                }
                else
                {
                    // If no book name is selected, show a message telling the user to select a book first
                    new SelectStudentFirst().Show();
                }
                if (DisplayStudentImage != null)
                {
                    if (DisplayStudentImage is Image studentImage)
                    {
                        studentPicture.Image = studentImage;
                    }
                    else if (DisplayStudentImage is byte[] imageBytes)
                    {
                        // Convert byte array to image
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            studentPicture.Image = Image.FromStream(ms);
                        }
                    }
                    // Hide the selection panel
                    StudentPanel.Visible = false;
                }
                else
                {
                    new EmptyField().Show();
                }
                if (DisplayIssueDate != null)
                {
                    // Set the selected book's name into a TextBox outside the panel
                    issueDatetxtbox.Text = DisplayIssueDate.ToString();
                    // Hide the label that shows the book name prompt
                    issueDatelbl.Visible = false;
                    // Hide the selection panel
                    StudentPanel.Visible = false;
                }
                else
                {
                    // If no book name is selected, show a message telling the user to select a book first
                    new SelectStudentFirst().Show();
                }
            }
            else
            {
                // If no row is selected, show a message prompting the user to select a book first
                new SelectBooksFirst().Show();
            }
        }

        private void searchStudent_TextChanged(object sender, EventArgs e)
        {
            // If the search box is empty, hide the 'not found' and 'question' messages
            if (string.IsNullOrEmpty(searchbox.Text))
            {
                Notfound.Visible = false;
                Question.Visible = false;
                string searchTerm = searchbox.Text.Trim(); // Get user input and remove leading/trailing spaces

                if (!string.IsNullOrEmpty(searchTerm)) // If there's input in the search box
                {
                    SearchStudent(SelectBooks.Text,searchTerm); // Call SearchStudent function to search for students
                }
                else
                {
                    LoadAllStudent(); // If the search box is empty, load all students
                }
            }
        }

        private void LoadStudentsWhoBorrowedBook(string bookName)
        {
            try
            {
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connect.Open();

                    // Query to get students who borrowed the selected book including picture
                    string query = @"
            SELECT studentName, studentImage, issueDate
            FROM issue 
            WHERE bookName = @bookName";

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@bookName", bookName);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // ✅ Make sure the "Image" column exists before processing images
                        if (!dt.Columns.Contains("Image"))
                            dt.Columns.Add("Image", typeof(Image));

                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["studentImage"] != DBNull.Value)
                            {
                                byte[] imgBytes = (byte[])row["studentImage"];
                                using (MemoryStream ms = new MemoryStream(imgBytes))
                                {
                                    row["Image"] = Image.FromStream(ms); // ✅ Use existing "Image" column
                                }
                            }
                            else
                            {
                                row["Image"] = null; // Prevent errors if image is NULL
                            }
                        }

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No students have borrowed this book.", "No Borrowers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Bind results to DataGridView
                        studentDataTable.DataSource = dt;
                        studentDataTable.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SearchStudent(string bookName, string searchTerm)
        {
            Notfound.Visible = false;
            Question.Visible = false;

            try
            {
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connect.Open();

                    // Base query: Get all students who borrowed the selected book
                    string query = @"
            SELECT studentName, issueDate, studentImage
            FROM issue
            WHERE bookName = @bookName";

                    // Apply search filter only if searchTerm is provided
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " AND (studentName LIKE @search)";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@bookName", bookName);

                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Ensure the image column is added AFTER filling the DataTable
                        if (!dt.Columns.Contains("StudentPicture"))
                            dt.Columns.Add("StudentPicture", typeof(Image));

                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["studentImage"] != DBNull.Value)
                            {
                                byte[] imgBytes = (byte[])row["studentImage"];
                                using (MemoryStream ms = new MemoryStream(imgBytes))
                                {
                                    row["StudentPicture"] = Image.FromStream(ms);
                                }
                            }
                        }

                        dt.Columns.Remove("studentImage"); // Remove original binary column

                        if (dt.Rows.Count == 0)
                        {
                            Notfound.Visible = true;
                            Question.Visible = true;
                        }

                        // Bind the results to the DataGridView
                        studentDataTable.DataSource = dt;

                        // Ensure DataGridView has a valid image column
                        if (!studentDataTable.Columns.Contains("StudentPicture"))
                        {
                            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                            {
                                Name = "StudentPicture",
                                HeaderText = "Picture",
                                DataPropertyName = "StudentPicture",
                                ImageLayout = DataGridViewImageCellLayout.Zoom
                            };
                            studentDataTable.Columns.Add(imgColumn);
                        }

                        studentDataTable.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void searchStudent_Enter(object sender, EventArgs e)
        {
            searchStudent.Clear();
            searchStudent.ForeColor = Color.Black;
        }

        private void searchStudent_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchStudent.Text))
            {
                searchStudent.ForeColor = Color.DimGray; // Change the text color to dim gray
                searchStudent.Text = "Search"; // Set the placeholder text
            }
        }

        private void searchStudent_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the Enter key is pressed, perform the search
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchStudent(SelectBooks.Text,searchbox.Text);
            }
        }

        private void srcbtn_Click(object sender, EventArgs e)
        {
            SearchStudent(SelectBooks.Text,searchbox.Text); // Trigger search with the current text in the search box
        }
        private void LoadAllStudent(string bookName = null)
        {
            try
            {
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connect.Open();

                    // SQL query to select students who borrowed books, including their picture
                    string query = @"
            SELECT studentName, studentImage
            FROM issue";

                    if (!string.IsNullOrEmpty(bookName))
                    {
                        query += " WHERE bookName = @bookName";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        if (!string.IsNullOrEmpty(bookName))
                        {
                            cmd.Parameters.AddWithValue("@bookName", bookName);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Ensure the image column is added AFTER filling the DataTable
                        if (!dt.Columns.Contains("StudentPicture"))
                            dt.Columns.Add("StudentPicture", typeof(Image));

                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["studentImage"] != DBNull.Value)
                            {
                                byte[] imgBytes = (byte[])row["studentImage"];
                                using (MemoryStream ms = new MemoryStream(imgBytes))
                                {
                                    row["StudentPicture"] = Image.FromStream(ms);
                                }
                            }
                        }

                        dt.Columns.Remove("studentImage"); // Remove original binary column

                        // Bind the results to the DataGridView
                        studentDataTable.DataSource = dt;

                        // Ensure DataGridView has a valid image column
                        if (!studentDataTable.Columns.Contains("StudentPicture"))
                        {
                            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                            {
                                Name = "StudentPicture",
                                HeaderText = "Picture",
                                DataPropertyName = "StudentPicture",
                                ImageLayout = DataGridViewImageCellLayout.Zoom
                            };
                            studentDataTable.Columns.Add(imgColumn);
                        }

                        studentDataTable.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void srcbtn_MouseEnter(object sender, EventArgs e)
        {
            srcbtn.BackColor = Color.FromArgb(76, 75, 105); // Change icon color to black
            srcbtn.Cursor = System.Windows.Forms.Cursors.Hand; // Change cursor to hand icon
        }

        private void srcbtn_MouseLeave(object sender, EventArgs e)
        {
            srcbtn.BackColor = Color.FromArgb(53, 53, 113); // Change icon color to black
            srcbtn.Cursor = System.Windows.Forms.Cursors.Default; // Change cursor to hand icon
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            searchbox.Text = "Search"; // Clear the search box
            searchbox.ForeColor = Color.DimGray; // Change the text color to dim gray
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

        private void clearButton_MouseEnter(object sender, EventArgs e)
        {
            clearButton.BackColor = Color.FromArgb(76, 75, 105); // Change the background color of the button
            Cursor = Cursors.Hand; // Change the cursor to a hand pointer
        }

        private void clearButton_MouseLeave(object sender, EventArgs e)
        {
            clearButton.BackColor = Color.FromArgb(53, 53, 113); // Change the background color of the button
            Cursor = Cursors.Default; // Change the cursor to the default pointer
        }
    }
}
