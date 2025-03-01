using System; // Imports the System namespace for basic functionality like console IO, basic types (e.g., string, int)
using System.Data; // Imports the System.Data namespace for data-related functionalities like working with databases
using System.Data.SqlClient; // Imports the namespace for SQL Server-specific data operations
using System.Drawing; // Imports the System.Drawing namespace for working with graphics, colors, and images
using System.Windows.Forms; // Imports the Windows Forms namespace for creating and managing forms, controls, and events in a Windows desktop application


namespace PHCM_last_na_to.Forms
{
    public partial class ReturnDetailsForm : Form
    {
        //connecting to the database
        private string connect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30";
        private Form currentChildForm;  // Declares a variable to store the current open form

        public ReturnDetailsForm()
        {
            InitializeComponent();  // Initializes the components (UI elements like buttons, textboxes, etc.)
        }

        private void next_Click(object sender, EventArgs e)  // This runs when the "next" button is clicked
        {
            OpenChildForm(new StudentDetailsForm());  // Opens the StudentDetailsForm in the current form
        }

        private void OpenChildForm(Form childForm)  // Opens a new form inside the current one
        {
            if (currentChildForm != null)  // Checks if there's already a form open
            {
                currentChildForm.Close();  // Closes the current open form
            }
            currentChildForm = childForm;  // Sets the new form as the current open form
            childForm.TopLevel = false;  // Makes sure the new form is inside the current form (not on top)
            childForm.FormBorderStyle = FormBorderStyle.None;  // Removes the borders of the new form
            childForm.Dock = DockStyle.Fill;  // Makes the new form fill the whole space of the current form
            this.Controls.Add(childForm);  // Adds the new form to the current form’s control
            this.Tag = childForm;  // Tags the form (for future reference)
            childForm.BringToFront();  // Brings the new form to the front
            childForm.Show();  // Displays the new form
            childForm.Focus();
        }

        private void previous_Click(object sender, EventArgs e)  // This runs when the "previous" button is clicked
        {
            OpenChildForm(new QuickOverviewForm());  // Opens another form called QuickOverviewForm
        }

        private void ReturnDetailsForm_Load(object sender, EventArgs e)  // This runs when the form loads
        {
            // TODO: This line of code loads data into the 'returnBookUpdate.returnBook' table. You can move, or remove it, as needed.
            this.returnBookTableAdapter.Fill(this.returnBookUpdate.returnBook);                    
        }

        private void searchbox_Enter(object sender, EventArgs e)  // This runs when you click inside the search box
        {
            searchbox.ForeColor = Color.Black;  // Changes the color of the text to black
            searchbox.Clear();  // Clears the search box so you can type in it
        }

        private void searchbox_Leave(object sender, EventArgs e)  // This runs when you click out of the search box
        {
            if (string.IsNullOrEmpty(searchbox.Text))  // Checks if the search box is empty
            {
                searchbox.ForeColor = Color.DimGray;  // Changes the text color to gray
                searchbox.Text = "Search";  // Sets the text back to "Search"
            }
        }

        private void searchbox_TextChanged(object sender, EventArgs e)  // This runs every time you type something in the search box
        {
            if (string.IsNullOrEmpty(searchbox.Text))  // Checks if the search box is empty
            {
                Notfound.Visible = false;  // Hides the "Not Found" message
                Question.Visible = false;  // Hides the "Question" message
                string searchTerm = searchbox.Text.Trim();  // Gets the search text and removes any extra spaces

                if (!string.IsNullOrEmpty(searchTerm))  // If there's text in the search box
                {
                    SearchBooks(searchTerm);  // Calls the function to search for books
                }
                else
                {
                    LoadAllBooks();  // If the search box is empty, it reloads all books
                }
            }
        }

        private void searchbox_KeyPress(object sender, KeyPressEventArgs e)  // This runs when you press a key inside the search box
        {
            if (e.KeyChar == (char)Keys.Enter)  // If the "Enter" key is pressed
            {
                SearchBooks(searchbox.Text);  // Calls the search function
            }
        }

        private void srcbtn_Click(object sender, EventArgs e)  // This runs when you click the search button
        {
            SearchBooks(searchbox.Text);  // Calls the function to search for books
        }

        private void SearchBooks(string searchTerm)  // This function searches for books based on the search term
        {
            Notfound.Visible = false;  // Hides the "Not Found" message
            Question.Visible = false;  // Hides the "Question" message
            try
            {
                DataTable dt = new DataTable();  // Creates a new table to hold the search results
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string query = "SELECT id, bookName, author, studentName, publishedDate, issueDate, returnDate, condition, studentImage, genre FROM returnBook " +
                                   "WHERE bookName LIKE @search OR author LIKE @search OR studentName LIKE @search OR condition LIKE @search OR genre LIKE @search";  // SQL query to search for books

                    using (SqlCommand cmd = new SqlCommand(query, connect))  // Executes the SQL query
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");  // Adds the search term to the query

                        connect.Open();  // Opens the database connection
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);  // Executes the query and fills the data table
                        adapter.Fill(dt);

                        if (dt.Rows.Count == 0)  // If no results are found
                        {
                            Notfound.Visible = true;  // Shows the "Not Found" message
                            Question.Visible = true;  // Shows the "Question" message
                        }

                        dataGridView1.DataSource = dt;  // Updates the data grid with the search results
                        dataGridView1.Refresh();  // Refreshes the data grid to show the latest data
                    }
                }
            }
            catch (Exception ex)  // If there’s an error
            {
                MessageBox.Show("Error: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Show an error message
            }
        }

        private void LoadAllBooks()  // This function loads all books from the database
        {
            try
            {
                DataTable dt = new DataTable();  // Creates a new table for all the books
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string query = "SELECT id, bookName, author, studentName, publishedDate, issueDate, returnDate, condition, genre, studentImage FROM returnBook";  // SQL query to get all books
                    using (SqlCommand cmd = new SqlCommand(query, connect))  // Executes the SQL query
                    {
                        connect.Open();  // Opens the database connection
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);  // Executes the query and fills the data table
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;  // Updates the data grid with all the books
                        dataGridView1.Refresh();  // Refreshes the data grid to show the latest data
                    }
                }
            }
            catch (Exception ex)  // If there’s an error
            {
                MessageBox.Show("Error: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Show an error message
            }
        }

        private void DeleteRow(int id)
        {
            string query = "DELETE FROM returnBook WHERE id = @id"; // SQL query to delete data from the table where the id matches

            using (SqlConnection connection = new SqlConnection(connect)) // Connects to the database
            {
                SqlCommand cmd = new SqlCommand(query, connection); // Prepares the SQL command to be executed
                cmd.Parameters.AddWithValue("@id", id); // Adds the id to the command (binds it)

                try
                {
                    connection.Open(); // Opens the connection to the database
                    cmd.ExecuteNonQuery(); // Executes the delete query
                    MessageBox.Show("Record deleted successfully!"); // Displays a success message
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message); // Shows an error message if something goes wrong
                }
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            // Ensures that a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult askUSR = MessageBox.Show("Do you wish to delete the selected Data?", "You're About to Delete a Data!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (askUSR == DialogResult.Yes)  // If user confirms deletion
                {
                    // Gets the selected row
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Retrieves the id from the selected row in the DataGridView
                    int id = Convert.ToInt32(selectedRow.Cells["idDataGridViewTextBoxColumn"].Value); // Gets the id

                    // Calls the DeleteRow method with the id of the selected row
                    DeleteRow(id);
                    dataGridView1.Rows.Remove(selectedRow); // Removes the row from the DataGridView
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");  // Shows a message if no row is selected
            }
        }

        private void ReturnDetailsForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Left)
            {
                OpenChildForm(new QuickOverviewForm());
            }
            else if (e.KeyChar == (char)Keys.Right)
            {
                OpenChildForm(new StudentDetailsForm());
            }
        }
    }
}
