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
            // TODO: This line of code loads data into the 'studentInformation.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.studentInformation.student);
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
            StudentPanel.Visible = true; // When the student name label is clicked, show the student selection panel.
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

            studentPicture.Image = Properties.Resources.add_pictures; // Set to default

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
            string insertQuery = "INSERT INTO issue (bookName, author, studentName, publishedDate, issueDate, genre, studentImage) " +
                                 "VALUES(@bookName, @author, @studentName, @publishedDate, @issueDate, @genre, @studentImage)";

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

                        studentPicture.Image = Properties.Resources.add_pictures; // Set to default

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
            Categoryselectorpanel.Visible = true;
            // Bring the genre selection panel to the front so it appears on top of other controls
            Categoryselectorpanel.BringToFront();
        }

        private void closepnl_Click(object sender, EventArgs e)
        {
            // When the close panel button is clicked, hide the genre selection panel
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

        private void fictionBtn_Click(object sender, EventArgs e)
        {
            Fictionpnl.Visible = true;
        }

        private void closepnl_Click_1(object sender, EventArgs e)
        {
            Categoryselectorpanel.Visible = false;
        }

        private void closepnl_MouseEnter(object sender, EventArgs e)
        {
            closepnl.IconColor = Color.Black;
            closepnl.Cursor = Cursors.Hand;
        }

        private void closepnl_MouseLeave(object sender, EventArgs e)
        {
            closepnl.IconColor = Color.White;
            closepnl.Cursor = Cursors.Default;
        }

        private void fictionBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.Cursor = Cursors.Hand;
                btn.BackColor = Color.FromArgb(57, 57, 101);
            }
        }

        private void fictionBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.Cursor = Cursors.Default;
                btn.BackColor = Color.FromArgb(31, 30, 68);
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

        private void exitFictionbtn_Click(object sender, EventArgs e)
        {
            Fictionpnl.Visible = false;
        }

        private void exitFictionbtn_MouseEnter(object sender, EventArgs e)
        {
            exitFictionbtn.Cursor = Cursors.Hand;
            exitFictionbtn.IconColor = Color.Black;
        }

        private void exitFictionbtn_MouseLeave(object sender, EventArgs e)
        {
            exitFictionbtn.Cursor = Cursors.Default;
            exitFictionbtn.IconColor = Color.White;
        }

        private void exitNonFictionbtn_Click(object sender, EventArgs e)
        {
            nonFictionpnl.Visible = false;
        }

        private void exitNonFictionbtn_MouseEnter(object sender, EventArgs e)
        {
            exitNonFictionbtn.Cursor = Cursors.Hand;
            exitNonFictionbtn.IconColor = Color.Black;
        }

        private void exitNonFictionbtn_MouseLeave(object sender, EventArgs e)
        {
            exitNonFictionbtn.Cursor = Cursors.Default;
            exitNonFictionbtn.IconColor = Color.White;
        }

        private void FictionSelection(object sender, EventArgs e)
        {
            if (sender is Label selectGenre)
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

        private void NonFictionSelection(object sender, EventArgs e)
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

        private void NonFictionHover(object sender, EventArgs e)
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
        private void NonFictionLeave(object sender, EventArgs e)
        {
            if (sender is Label HoverGenre) // Check if the sender is a Label
            {
                HoverGenre.BackColor = Color.FromArgb(31, 30, 68); // Change the background color of the label
                Description.Visible = false;
            }
        }

        private void nonFictionbtn_Click(object sender, EventArgs e)
        {
            nonFictionpnl.Visible = true;
        }

        private void studentNametxtbox_Click(object sender, EventArgs e)
        {
            StudentPanel.Visible = true;
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

                if (SelectedStudentName != null)
                {
                    // Set the selected book's name into a TextBox outside the panel
                    studentNametxtbox.Text = SelectedStudentName.ToString();
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
            }
            else
            {
                // If no row is selected, show a message prompting the user to select a book first
                new SelectBooksFirst().Show();
            }
        }

        private void returnStudentbtn_Click(object sender, EventArgs e)
        {
            StudentPanel.Visible = false;
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
                    SearchStudent(searchTerm); // Call SearchStudent function to search for students
                }
                else
                {
                    LoadAllStudent(); // If the search box is empty, load all students
                }
            }
        }
        private void SearchStudent(string searchTerm)
        {
            Notfound.Visible = false; // Hides the 'not found' message
            Question.Visible = false; // Hides the 'question' message
            try
            {
                DataTable dt = new DataTable(); // Creates a DataTable to store student data
                                                // Connect to the database
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string query = "SELECT id, studentName, StudentNumber, department, studentContact, studentPicture, studentImage FROM student " +
                                   "WHERE studentName LIKE @search OR studentNumber LIKE @search OR department LIKE @search"; // SQL query to search for students by name, number, or department

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%"); // Adds the search term to the query
                        connect.Open(); // Opens the connection to the database
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Executes the query and fills the DataTable with the results
                        adapter.Fill(dt);

                        if (dt.Rows.Count == 0) // If no students are found
                        {
                            Notfound.Visible = true; // Show the 'not found' message
                            Question.Visible = true; // Show the 'question' message
                        }

                        // Convert Image Data from BYTE[] to Bitmap
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["studentImage"] != DBNull.Value) // Check if the student has an image
                            {
                                byte[] imageBytes = (byte[])row["studentImage"]; // Get the image bytes from the database
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms); // Convert byte array to Image

                                    // Convert the Image back to byte array to store it in the DataTable
                                    using (MemoryStream saveStream = new MemoryStream())
                                    {
                                        img.Save(saveStream, img.RawFormat); // Save the image to a memory stream
                                        byte[] imageBytesToStore = saveStream.ToArray(); // Convert the image back to a byte array
                                        row["studentImage"] = imageBytesToStore; // Store the byte array in the DataTable
                                    }
                                }
                            }
                        }

                        // Refresh DataGridView to display updated student data
                        studentDataTable.DataSource = dt;
                        studentDataTable.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                // If an error occurs, show an error message
                MessageBox.Show("Error: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void srcbtn_Click(object sender, EventArgs e)
        {
            SearchStudent(searchbox.Text); // Trigger search with the current text in the search box
        }
        private void LoadAllStudent()
        {
            try
            {
                DataTable dt = new DataTable(); // Create a new DataTable
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    // SQL query to select all student records
                    string query = "SELECT studentPicture, studentName, studentNumber, department, studentContact, studentImage FROM student";
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        connect.Open(); // Open the connection to the database
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Use an adapter to fill data into the DataTable
                        adapter.Fill(dt); // Fill the data

                        // Display the data in the DataGridView
                        studentDataTable.DataSource = dt;
                        studentDataTable.Refresh(); // Refresh the DataGridView to show the data
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message if something goes wrong
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
                SearchStudent(searchbox.Text);
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
            searchbox.Clear();
            searchbox.ForeColor = Color.Black;
        }

        private void searchbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchbox.Text))
            {
                searchbox.ForeColor = Color.DimGray; // Change the text color to dim gray
                searchbox.Text = "Search"; // Set the placeholder text
            }
        }
    }
}
