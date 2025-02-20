using System; // Import the basic system functionalities, like handling data types and exceptions.
using System.Data; // Import functionalities related to working with data, such as interacting with databases.
using System.Data.SqlClient; // Import functionalities for connecting to SQL Server databases and executing queries.
using System.Drawing; // Import functionalities related to graphics, such as colors and drawing elements.
using System.Windows.Forms; // Import the Windows Forms namespace for creating forms and managing user interfaces in a desktop application.

namespace PHCM_last_na_to.Forms
{
    public partial class QuickOverviewForm : Form
    {
        //connecting to the database
        private string connect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30";
        private Form currentChildForm; // Variable to keep track of the current child form being displayed.

        public QuickOverviewForm()
        {
            InitializeComponent(); // Initializes the form components.                              
        }

        private void QuickOverviewForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'issuedBooks.issue' table. You can move, or remove it, as needed.
            this.issueTableAdapter.Fill(this.issuedBooks.issue);                                    
        }        

        private void next_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReturnDetailsForm()); // Opens a new form (ReturnDetailsForm) when the next button is clicked.
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null) //if the curret form is still open
            {
                currentChildForm.Close(); // Close the current form before opening a new one.
            }
            currentChildForm = childForm; // Set the new form as the current one.
            childForm.TopLevel = false; // Makes the new form a child of the current form.
            childForm.FormBorderStyle = FormBorderStyle.None; // Removes borders around the child form.
            childForm.Dock = DockStyle.Fill; // Makes the child form fill the space available.
            this.Controls.Add(childForm); // Adds the child form to the parent form.
            this.Tag = childForm; // Assigns a tag to the child form for identification.
            childForm.BringToFront(); // Brings the child form to the front of the other controls.
            childForm.Show(); // Displays the child form.            
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

        private void searchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Trigger search when the Enter key is pressed.
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchBooks(searchbox.Text); // Calls SearchBooks function with the current text in the search box.
            }
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            // Runs whenever the text in the search box changes.
            if (string.IsNullOrEmpty(searchbox.Text))
            {
                Notfound.Visible = false; // Hides 'Not found' label if the search box is empty.
                Question.Visible = false; // Hides the 'question' label.
                string searchTerm = searchbox.Text.Trim(); // Removes leading/trailing spaces from user input.

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    SearchBooks(searchTerm); // Calls SearchBooks to search with the input text.
                }
                else
                {
                    LoadAllBooks(); // Loads all books if the search box is empty.
                }
            }
        }

        private void LoadAllBooks()
        {
            try
            {
                DataTable dt = new DataTable(); // Creates a new DataTable to hold the data.
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    // SQL query to select all book details.
                    string query = "SELECT id, bookName, author, studentName, publishedDate, issueDate FROM issue";
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        connect.Open(); // Opens the database connection.
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Uses the adapter to fill the data into the DataTable.
                        adapter.Fill(dt); // Fills the DataTable with the query results.

                        dataGridView1.DataSource = dt; // Displays the data in the DataGridView control.
                        dataGridView1.Refresh(); // Refreshes the DataGridView to show updated data.
                    }
                }
            }
            catch (Exception ex)
            {
                // Displays an error message if something goes wrong.
                MessageBox.Show("Error: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void srcbtn_Click(object sender, EventArgs e)
        {
            SearchBooks(searchbox.Text); // Calls SearchBooks when the search button is clicked.
        }

        private void SearchBooks(string searchTerm)
        {
            Notfound.Visible = false; // Hides 'Not found' label initially.
            Question.Visible = false; // Hides the 'question' label initially.
            try
            {
                DataTable dt = new DataTable(); // Creates a new DataTable to hold the search results.
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    // SQL query to search for books based on the search term.
                    string query = "SELECT id, bookName, author, studentName, publishedDate, issueDate FROM issue " +
                                   "WHERE bookName LIKE @search OR author LIKE @search OR studentName LIKE @search";
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%"); // Adds the search term with wildcards to the query.

                        connect.Open(); // Opens the database connection.
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Uses the adapter to fill the data into the DataTable.
                        adapter.Fill(dt); // Fills the DataTable with the query results.

                        if (dt.Rows.Count == 0)
                        {
                            Notfound.Visible = true; // Shows 'Not found' label if no results are returned.
                            Question.Visible = true; // Shows the 'question' label if no results are found.
                        }

                        dataGridView1.DataSource = dt; // Displays the search results in the DataGridView.
                        dataGridView1.Refresh(); // Refreshes the DataGridView to show the updated data.
                    }
                }
            }
            catch (Exception ex)
            {
                // Displays an error message if something goes wrong.
                MessageBox.Show("Error: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Ask the user if they are sure about deleting the record
                DialogResult askUSR = MessageBox.Show("Do you wish to delete this account?", "You're About to Delete a Data!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (askUSR == DialogResult.Yes)
                {
                    // Get the selected row from the DataGridView
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Get the 'id' value from the selected row to identify the record to delete
                    int id = Convert.ToInt32(selectedRow.Cells["idDataGridViewTextBoxColumn"].Value);

                    // Call the DeleteRow method to delete the record from the database
                    DeleteRow(id);
                    dataGridView1.Rows.Remove(selectedRow); // Remove the row from the DataGridView display
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete."); // Show an error if no row is selected
            }
        }

        private void DeleteRow(int id)
        {
            string query = "DELETE FROM issue WHERE id = @id"; // SQL query to delete a record by id

            using (SqlConnection connection = new SqlConnection(connect)) // Establishing the connection to the database
            {
                SqlCommand cmd = new SqlCommand(query, connection); // Prepare the SQL command
                cmd.Parameters.AddWithValue("@id", id); // Bind the id to the SQL command

                try
                {
                    connection.Open(); // Open the database connection
                    cmd.ExecuteNonQuery(); // Execute the delete command
                    MessageBox.Show("Record deleted successfully!"); // Notify the user that the record was deleted
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message); // Show an error message if something goes wrong
                }
            }
        }
    }
}    