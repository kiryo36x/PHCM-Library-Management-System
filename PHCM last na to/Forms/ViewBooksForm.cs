using System; // Import the System namespace which provides fundamental classes for the program.
using System.Data; // Import the System.Data namespace which allows working with data (e.g., databases).
using System.Data.SqlClient; // Import the SqlClient namespace for working with SQL Server databases.
using System.Drawing; // Import the System.Drawing namespace to work with images and graphics.
using System.Windows.Forms; // Import the Windows Forms namespace to create and manage the graphical user interface (GUI).
using System.IO; // Import the System.IO namespace to handle input/output operations like reading from and writing to files.

namespace PHCM_last_na_to.Forms
{
    public partial class ViewBooksForm : Form
    {
        private Form currentChildForm; // Holds a reference to the currently open child form.

        public ViewBooksForm()
        {
            InitializeComponent(); // Initializes the form components.
        }

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
            // Load data into the books table from the database
            this.booksTableAdapter3.Fill(this.dataBooks.books);
            this.booksTableAdapter2.Fill(this.booksDatabase.books);
            panel11.Visible = true; // Show a specific panel
            panel11.Enabled = true; // Enable the panel
        }

        private void srcbtn_Click(object sender, EventArgs e)
        {
            // When the search button is clicked, search for books based on the text in the search box
            SearchBooks(searchbox.Text);
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
                    // Prepare a query to search books by name or author
                    string query = "SELECT id, bookName, author, datePick, quantity, bookPicture, picture FROM books " +
                                   "WHERE bookName LIKE @search OR author LIKE @search";

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

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            // If the search box is empty, hide the messages and reload all books
            if (string.IsNullOrEmpty(searchbox.Text))
            {
                Notfound.Visible = false;
                Question.Visible = false;
                string searchTerm = searchbox.Text.Trim(); // Get user input and remove leading/trailing spaces

                if (!string.IsNullOrEmpty(searchTerm)) // If there's input, perform search
                {
                    SearchBooks(searchTerm);
                }
                else
                {
                    LoadAllBooks(); // Otherwise, reload all books
                }
            }
        }

        private void LoadAllBooks()
        {
            try
            {
                DataTable dt = new DataTable(); // Create a new DataTable for all books
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string query = "SELECT id, bookName, author, datePick, quantity, bookPicture, picture FROM books"; // Query to fetch all books
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

        private void searchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the Enter key is pressed, perform the search
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchBooks(searchbox.Text); // Perform the search
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
                int currentQuantity = Convert.ToInt32(selectedRow.Cells["quantityDataGridViewTextBoxColumn"].Value);                
                
                // Decrease the quantity
                selectedRow.Cells["quantityDataGridViewTextBoxColumn"].Value = currentQuantity + 1;  // Decrease by 1 (or any value you want)                
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
                int currentQuantity = Convert.ToInt32(selectedRow.Cells["quantityDataGridViewTextBoxColumn"].Value);

                if (currentQuantity > 0)  // Prevent the quantity from going below 0
                {
                    // Decrease the quantity
                    selectedRow.Cells["quantityDataGridViewTextBoxColumn"].Value = currentQuantity - 1;  // Decrease by 1
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
            int bookId = Convert.ToInt32(selectedRow.Cells["idDataGridViewTextBoxColumn"].Value);

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
    }
}
