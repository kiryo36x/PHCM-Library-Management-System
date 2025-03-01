using System; // Import the System namespace which provides fundamental classes for the program.
using System.Data; // Import the System.Data namespace which allows working with data (e.g., databases).
using System.Data.SqlClient; // Import the SqlClient namespace for working with SQL Server databases.
using System.Drawing; // Import the System.Drawing namespace to work with images and graphics.
using System.Windows.Forms; // Import the Windows Forms namespace to create and manage the graphical user interface (GUI).
using System.IO;
using PHCM_last_na_to.Toast_Message_for_add_student_information;
using PHCM_last_na_to.Toast_Message_for_add_books;
using System.Linq;
using FontAwesome.Sharp; // Import the System.IO namespace to handle input/output operations like reading from and writing to files.

namespace PHCM_last_na_to.Forms
{
    public partial class ViewBooksForm : Form
    {
        private Form currentChildForm; // Holds a reference to the currently open child form.

        public ViewBooksForm()
        {
            InitializeComponent(); // Initializes the form components.
        }
        private string selectedGenre = "All"; // Default to "All"
        private bool isSelectingRow = false; // Flag to indicate row selection

        private void ReturnAddBooks_Click(object sender, EventArgs e)
        {
            // If AddBooksForm is not found, create a new one and show it
            OpenChildForm(new AddBooksForm());
            ReturnAddBooks.Enabled = false; // Disable the button to prevent reopening
        }

        private void OpenChildForm(Form childForm)
        {
            // If a form is already open, close it first
            if (currentChildForm != null)
            {
                currentChildForm.Close(); // Close the existing form
            }
            currentChildForm = childForm; // Set the new form as the current one
            childForm.TopLevel = false; // Set form properties to make it a child form
            childForm.FormBorderStyle = FormBorderStyle.None; // Remove border for the child form
            childForm.Dock = DockStyle.Fill; // Make the child form fill its container
            this.Controls.Add(childForm); // Add the child form to the parent form's controls
            this.Tag = childForm; // Store the reference in the parent form's tag
            childForm.BringToFront(); // Bring the child form to the front
            childForm.Show(); // Show the child form
        }

        private void ViewBooksForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'books.books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.books.books);
            panel11.Visible = true; // Show a specific panel
            panel11.Enabled = true; // Enable the panel
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Nirmala UI", 14, FontStyle.Bold); // Set the font for the column headers
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
                        dataGridView1.DataSource = dt; // Set the DataGridView's data source
                        dataGridView1.Refresh(); // Refresh the DataGridView to show the updated data
                    }
                }
            }
            catch (Exception ex)
            {
                // If an error occurs, show the error message
                MessageBox.Show("Error: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        dataGridView1.DataSource = dt; // Display all books in the DataGridView
                        dataGridView1.Refresh(); // Refresh the DataGridView to show the updated data
                    }
                }
            }
            catch (Exception ex)
            {
                // If an error occurs, show the error message
                MessageBox.Show("Error: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchbox_Enter(object sender, EventArgs e)
        {
            // Clear the search box when it receives focus
            searchbox.ForeColor = Color.Black;
            searchbox.Clear();
        }

        private void searchbox_Leave(object sender, EventArgs e)
        {
            // If the search box is empty, reset the placeholder text
            if (string.IsNullOrEmpty(searchbox.Text))
            {
                searchbox.ForeColor = Color.DimGray;
                searchbox.Text = "Search"; // Set the default placeholder text
            }
        }


        private void panel11_Click(object sender, EventArgs e)
        {
            // Disable the active control (e.g., text box) when clicking on the panel
            this.ActiveControl = null;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            // Disable the active control (e.g., text box) when clicking on the panel
            this.ActiveControl = null;
        }

        private void Addquantitybtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)  // Ensure a row is selected
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Assuming the quantity is in the second column (adjust the column index if needed)
                int currentQuantity = Convert.ToInt32(selectedRow.Cells["quantitydataGridViewTextBoxColumn4"].Value);

                // Decrease the quantity
                selectedRow.Cells["quantitydataGridViewTextBoxColumn4"].Value = currentQuantity + 1;  // Decrease by 1 (or any value you want)                
                UpdateQuantityInDatabase(selectedRow, currentQuantity + 1);
            }
            else
            {
                MessageBox.Show("Please select a row to update the quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void decreasequantitybtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)  // Ensure a row is selected
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Assuming the quantity is in the second column (adjust the column index if needed)
                int currentQuantity = Convert.ToInt32(selectedRow.Cells["quantitydataGridViewTextBoxColumn4"].Value);

                if (currentQuantity > 0)  // Prevent the quantity from going below 0
                {
                    // Decrease the quantity
                    selectedRow.Cells["quantitydataGridViewTextBoxColumn4"].Value = currentQuantity - 1;  // Decrease by 1
                    UpdateQuantityInDatabase(selectedRow, currentQuantity - 1); //update the database
                }
                else
                {
                    MessageBox.Show("Quantity cannot be less than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update the quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateQuantityInDatabase(DataGridViewRow selectedRow, int newQuantity)
        {
            // Assuming the primary key (ID) of the book is in the first column (adjust if needed)
            int bookId = Convert.ToInt32(selectedRow.Cells["idDataGridViewTextBoxColumn1"].Value);

            string updateQuery = "UPDATE books SET quantity = @newQuantity WHERE id = @bookId";

            try
            {
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@newQuantity", newQuantity);
                        cmd.Parameters.AddWithValue("@bookId", bookId); // Using book ID to identify the row

                        cmd.ExecuteNonQuery();  // Execute the update query
                    }

                    MessageBox.Show("Quantity updated in the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CurrentGenre(object sender, EventArgs e)
        {
            Categoryselectorpanel.Visible = true;
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
                        dataGridView1.DataSource = dt; // Set the DataGridView's data source
                        dataGridView1.Refresh(); // Refresh the DataGridView to show the updated data
                    }
                }
            }
            catch (Exception ex)
            {
                // If an error occurs, show the error message
                MessageBox.Show("Error: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            isSelectingRow = true; // Set the flag to true when a row is selected
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isSelectingRow = false; // Reset the flag when a cell is clicked
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

        private void srcbtn_Click(object sender, EventArgs e)
        {
            SearchBooks(searchbox.Text); // Calls the search function when the search button is clicked.
        }

        private void EditAndDelete(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Text == "Edit")
                {
                    // Check if a row is selected in the DataGridView
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        currentGnre.Enabled = false; // Disable the genre selector
                        // Get the selected row from the grid
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                        // Populate the textboxes with values from the selected row
                        bookNametxtbox.Text = selectedRow.Cells["booknamedataGridViewTextBoxColumn1"].Value?.ToString() ?? "";
                        authortxtbox.Text = selectedRow.Cells["authordataGridViewTextBoxColumn2"].Value?.ToString() ?? "";
                        if (selectedRow.Cells["datepickdataGridViewTextBoxColumn3"].Value != null && DateTime.TryParse(selectedRow.Cells["datepickdataGridViewTextBoxColumn3"].Value.ToString(), out DateTime parsedDate))
                        {
                            datePublished.Value = parsedDate;
                        }
                        quantitytxtbox.Text = selectedRow.Cells["quantitydataGridViewTextBoxColumn4"].Value?.ToString() ?? "";
                        genretxtbox.Text = selectedRow.Cells["genredataGridViewTextBoxColumn5"].Value?.ToString() ?? "";

                        // Check if there's an image associated with the row
                        if (selectedRow.Cells["dataGridViewImageColumn1"].Value != DBNull.Value)
                        {
                            byte[] imageData = (byte[])selectedRow.Cells["dataGridViewImageColumn1"].Value; // Get image data from the database
                            using (MemoryStream ms = new MemoryStream(imageData)) // Convert byte data to image
                            {
                                Image originalImage = Image.FromStream(ms); // Create an image object from the byte data

                                // Resize the image to fit the PictureBox size
                                Bitmap resizedImage = new Bitmap(picture.Width, picture.Height);
                                using (Graphics g = Graphics.FromImage(resizedImage))
                                {
                                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                    g.DrawImage(originalImage, 0, 0, picture.Width, picture.Height); // Draw the resized image
                                }

                                picture.Image = resizedImage; // Display the resized image in the PictureBox
                            }
                        }
                    }
                    EditPanel.Visible = true; // Make the edit panel visible
                }
                else if (btn.Text == "Delete")
                {
                    // Check if a row is selected in the DataGridView
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        // Ask user for confirmation before deleting the data
                        DialogResult askUSR = MessageBox.Show("Do you wish to delete the selected Data?", "You're About to Delete a Data!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (askUSR == DialogResult.Yes)
                        {
                            // Get the selected row from the grid
                            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                            // Retrieve the ID of the selected row
                            int id = Convert.ToInt32(selectedRow.Cells["idDataGridViewTextBoxColumn1"].Value); // Get the ID

                            // Call DeleteRow method to delete the record from the database
                            DeleteRow(id);
                            dataGridView1.Rows.Remove(selectedRow); // Remove the row from the grid
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a row to delete."); // Prompt if no row is selected
                    }
                }                
            }
        }
        private void DeleteRow(int id)
        {
            string query = "DELETE FROM books WHERE id = @id"; // SQL query to delete a record based on ID

            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30")) // Connect to the database
            {
                SqlCommand cmd = new SqlCommand(query, connection); // Create the SQL command
                cmd.Parameters.AddWithValue("@id", id); // Add the ID parameter to the command

                try
                {
                    connection.Open(); // Open the database connection
                    cmd.ExecuteNonQuery(); // Execute the delete query
                    MessageBox.Show("Record deleted successfully!"); // Show confirmation message
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message); // Show error message in case of failure
                }
            }
        }
        private void EditpanelButton(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Text == "Exit")
                {
                    currentGnre.Enabled = true; // Enable the genre selector
                    EditPanel.Visible = false; // Hide the edit panel                    
                }
                else if (btn.Text == "Save")
                {
                    // Check if any field is empty
                    if (string.IsNullOrEmpty(bookNametxtbox.Text) || string.IsNullOrEmpty(authortxtbox.Text) || string.IsNullOrEmpty(quantitytxtbox.Text) || string.IsNullOrEmpty(genretxtbox.Text))
                    {
                        new EmptyField().Show(); // Show error message for empty fields
                    }
                    else if (authortxtbox.Text.Any(Char.IsDigit)) // Check if author contains digits
                    {
                        new Author().Show(); // Show error message for invalid author name
                    }
                    else if (quantitytxtbox.Text.Any(Char.IsLetter)) // Check if Quantity contains letters
                    {
                        new Quantity().Show(); // Show error message for invalid Quantity
                    }
                    else
                    {
                        // Ask user for confirmation before saving the data
                        DialogResult askUSR = MessageBox.Show("Do you wish to change the date?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (askUSR == DialogResult.Yes)
                        {                            
                            // Get the row index of the selected cell
                            int rowIndex = dataGridView1.CurrentCell.RowIndex;

                            // Retrieve the ID of the selected record
                            int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["idDataGridViewTextBoxColumn1"].Value);

                            // Call UpdateRow method to update the record in the database
                            UpdateRow(id);

                            // Update the data grid with the new values
                            dataGridView1.Rows[rowIndex].Cells["booknamedataGridViewTextBoxColumn1"].Value = bookNametxtbox.Text;
                            dataGridView1.Rows[rowIndex].Cells["authordataGridViewTextBoxColumn2"].Value = authortxtbox.Text;
                            dataGridView1.Rows[rowIndex].Cells["datepickdataGridViewTextBoxColumn3"].Value = datePublished.Value;
                            dataGridView1.Rows[rowIndex].Cells["quantitydataGridViewTextBoxColumn4"].Value = quantitytxtbox.Text;
                            dataGridView1.Rows[rowIndex].Cells["genredataGridViewTextBoxColumn5"].Value = genretxtbox.Text;
                            dataGridView1.Rows[rowIndex].Cells["dataGridViewImageColumn1"].Value = picture.Image;
                            LoadData(); // Reload the data
                        }
                    }
                }
                else if (btn.Text == "Change Picture")
                {
                    Stream myStream = null;
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Image File(*.jpg; *jpeg;) | *.jpg; *.jpeg;"; // Filter for only jpg/jpeg images

                    if (openFileDialog.ShowDialog(this) == DialogResult.OK) // Open file dialog to select image
                    {
                        try
                        {
                            if ((myStream = openFileDialog.OpenFile()) != null) // Open the selected file
                            {
                                string Filename = openFileDialog.FileName; // Get the file name

                                // Check if the file size exceeds the limit (512KB)
                                if (myStream.Length > 512000)
                                {
                                    MessageBox.Show("File Size limit exceeded"); // Show error if file is too large
                                }
                                else
                                {
                                    picture.Load(Filename); // Load the selected image into the PictureBox
                                }
                            }
                        }
                        catch (Exception ex) // Catch errors if any occur during the process
                        {
                            MessageBox.Show(ex.Message); // Show the error message                            
                        }
                    }
                }
            }
        }
        private void UpdateRow(int id)
        {
            // SQL query to update a record in the database based on ID
            string query = "UPDATE books SET bookName = @bookName, author = @author, datePick = @datePick, quantity = @quantity, Picture = @Picture, genre = @genre WHERE id = @id";

            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30")) // Connect to the database
            {
                SqlCommand cmd = new SqlCommand(query, connection); // Create the SQL command

                byte[] imageBytes = ImageToByteArray(picture.Image);

                // Bind values to parameters
                cmd.Parameters.AddWithValue("@bookName", bookNametxtbox.Text);
                cmd.Parameters.AddWithValue("@author", authortxtbox.Text);
                cmd.Parameters.AddWithValue("@datePick", datePublished.Value.Date);
                cmd.Parameters.AddWithValue("@quantity", quantitytxtbox.Text);
                cmd.Parameters.AddWithValue("@Picture", imageBytes); // Convert image to byte array
                cmd.Parameters.AddWithValue("@genre", genretxtbox.Text);
                cmd.Parameters.AddWithValue("@id", id); // Bind the ID to the query

                try
                {
                    connection.Open(); // Open the database connection
                    cmd.ExecuteNonQuery(); // Execute the update query
                    currentGnre.Enabled = true; // Enable the genre selector
                    EditPanel.Visible = false; // Hide the edit panel
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message); // Show error message if update fails                 
                }
            }
        }
        // This function converts an image into a byte array (a format suitable for storing in a database)
        private byte[] ImageToByteArray(Image image)
        {
            // If the image is null (does not exist), return null
            if (image == null)
                return null;

            // Create a memory stream (a temporary storage in memory)
            using (MemoryStream ms = new MemoryStream())
            {
                // Save the image into the memory stream in JPEG format
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                // Convert the memory stream data into a byte array and return it
                return ms.ToArray();
            }
        }

        private void LoadData()
        {
            string query = "SELECT * FROM books"; // SQL query to fetch all records from the student table

            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30")) // Connect to the database
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection); // Create a data adapter to fetch data
                DataTable dt = new DataTable(); // Create a DataTable to store the data
                adapter.Fill(dt); // Fill the DataTable with data from the query
                dataGridView1.DataSource = dt; // Set the data grid view's data source to the DataTable
            }
        }        

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

        private void nonFictionLeave(object sender, EventArgs e)
        {
            if (sender is Label HoverGenre) // Check if the sender is a Label
            {
                HoverGenre.BackColor = Color.FromArgb(31, 30, 68); // Change the background color of the label
                Description.Visible = false;
            }
        }

        private void nonFictionSelected(object sender, EventArgs e)
        {
            if (sender is Label selectGenre)
            {
                if (currentGnre.Enabled == true)
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
                else
                {
                    Categoryselectorpanel.Visible = false;
                    nonFictionpnl.Visible = false;
                    genretxtbox.Text = selectGenre.Text;
                }
            }
        }

        private void exitNonFictionbtn_Click(object sender, EventArgs e)
        {
            // Hides the Non-Fiction panel when the exit button is clicked
            nonFictionpnl.Visible = false;
        }

        private void exitNonFictionbtn_MouseEnter(object sender, EventArgs e)
        {
            // Changes the cursor to a hand symbol when hovering over the exit button
            exitNonFictionbtn.Cursor = Cursors.Hand;

            // Changes the exit button icon color to black when hovered
            exitNonFictionbtn.IconColor = Color.Black;
        }

        private void exitNonFictionbtn_MouseLeave(object sender, EventArgs e)
        {
            // Changes the cursor back to default when the mouse leaves the exit button
            exitNonFictionbtn.Cursor = Cursors.Default;

            // Changes the exit button icon color back to white when the mouse leaves
            exitNonFictionbtn.IconColor = Color.White;
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

        private void fictionSelected(object sender, EventArgs e)
        {
            if (sender is Label selectGenre)
            {
                if (currentGnre.Enabled == true)
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
                else
                {
                    Categoryselectorpanel.Visible = false;
                    Fictionpnl.Visible = false;
                    genretxtbox.Text = selectGenre.Text;
                }
                
            }
        }

        private void exitFictionbtn_Click(object sender, EventArgs e)
        {
            // Hides the Fiction panel when the exit button is clicked
            Fictionpnl.Visible = false;
        }

        private void exitFictionbtn_MouseEnter(object sender, EventArgs e)
        {
            // Changes the cursor to a hand symbol when hovering over the exit button
            exitFictionbtn.Cursor = Cursors.Hand;

            // Changes the exit button icon color to black when hovered
            exitFictionbtn.IconColor = Color.Black;
        }

        private void exitFictionbtn_MouseLeave(object sender, EventArgs e)
        {
            // Changes the cursor back to default when the mouse leaves the exit button
            exitFictionbtn.Cursor = Cursors.Default;

            // Changes the exit button icon color back to white when the mouse leaves
            exitFictionbtn.IconColor = Color.White;
        }

        private void selectCategoryClickedControls(object sender, EventArgs e)
        {
            // Checks if the clicked element is a Button
            if (sender is Button btn)
            {
                // If the button text is "Non-Fiction" (ignoring case), show the Non-Fiction panel
                if (btn.Text.ToLower() == "non-fiction")
                {
                    nonFictionpnl.Visible = true;
                }
                // If the button text is "Fiction" (ignoring case), show the Fiction panel
                else if (btn.Text.ToLower() == "fiction")
                {
                    Fictionpnl.Visible = true;
                }
            }
            // Checks if the clicked element is an IconPictureBox
            else if (sender is IconPictureBox icon)
            {
                // Hides the category selection panel when the icon is clicked
                Categoryselectorpanel.Visible = false;
            }
        }

        private void selectCategoryHoverControls(object sender, EventArgs e)
        {
            // Checks if the sender is both a Button and an IconPictureBox (which is not possible)
            if (sender is Button btn && sender is IconPictureBox icon)
            {
                // Changes the button's cursor to a hand symbol when hovered
                btn.Cursor = Cursors.Hand;

                // Changes the button's background color to a different shade
                btn.BackColor = Color.FromArgb(57, 57, 101);

                // Changes the icon's cursor to a hand symbol when hovered
                icon.Cursor = Cursors.Hand;
            }
        }

        private void selectCategoryLeaveControls(object sender, EventArgs e)
        {
            // Checks if the sender is both a Button and an IconPictureBox (which is not possible)
            if (sender is Button btn && sender is IconPictureBox icon)
            {
                // Changes the button's cursor back to default when the mouse leaves
                btn.Cursor = Cursors.Default;

                // Resets the button's background color when the mouse leaves
                btn.BackColor = Color.FromArgb(31, 30, 68);

                // Changes the icon's cursor back to default when the mouse leaves
                icon.Cursor = Cursors.Default;
            }
        }

        private void genretxtbox_Click(object sender, EventArgs e)
        {
            // Shows the category selection panel when the text box is clicked
            Categoryselectorpanel.Visible = true;

            // Brings the category selection panel to the front to make it visible
            Categoryselectorpanel.BringToFront();
        }
    }
}
