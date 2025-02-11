using System; // Includes basic system-level classes and types such as strings, exceptions, etc.
using System.Data; // Includes classes used for handling data, like DataTables, DataSets, etc.
using System.Data.SqlClient; // Includes classes for connecting to and working with SQL Server databases.
using System.Drawing; // Includes classes for working with graphics, colors, and drawing objects.
using System.Windows.Forms; // Includes classes for creating and managing Windows Forms applications and their components.

namespace PHCM_last_na_to.Forms
{
    public partial class showReturnBook : Form
    {
        private Form currentChildForm; // A variable to keep track of the currently open child form.
        public showReturnBook()
        {
            InitializeComponent(); // Initializes the form components, like buttons, textboxes, etc.
        }
        private void ReturnAddStudent_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReturnBookForm()); // Opens the 'ReturnBookForm' when the button is clicked.
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close(); // Closes the currently opened form, if any.
            }
            currentChildForm = childForm; // Sets the new form as the current child form.
            childForm.TopLevel = false; // Makes the new form a child form inside the current form.
            childForm.FormBorderStyle = FormBorderStyle.None; // Removes the border from the form.
            childForm.Dock = DockStyle.Fill; // Makes the form fill up the available space.
            this.Controls.Add(childForm); // Adds the form as a child to the current form.
            this.Tag = childForm; // Sets a tag to refer to the child form.
            childForm.BringToFront(); // Brings the child form to the front.
            childForm.Show(); // Shows the child form on the screen.
        }
        private void showReturnBook_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'returnBook.returnBook' table. You can move, or remove it, as needed.
            this.returnBookTableAdapter.Fill(this.returnBook.returnBook);
        }
        private void SearchBooks(string searchTerm)
        {
            Notfound.Visible = false; // Hides the "not found" message.
            Question.Visible = false; // Hides the "question" message.
            try
            {
                DataTable dt = new DataTable(); // Creates a new table to hold the search results.
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    // SQL query to search for books by name, author, student name, or condition.
                    string query = "SELECT id, bookName, author, studentName, publishedDate, issueDate, returnDate, condition FROM returnBook " +
                                   "WHERE bookName LIKE @search OR author LIKE @search OR studentName LIKE @search OR condition LIKE @search";

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%"); // Binds the search term to the SQL query.

                        connect.Open(); // Opens the connection to the database.
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Executes the query and fills the data table.
                        adapter.Fill(dt); // Fills the data table with the query results.

                        if (dt.Rows.Count == 0)
                        {
                            Notfound.Visible = true; // Shows "not found" message if no results are found.
                            Question.Visible = true; // Shows "question" message.
                        }

                        dataGridView1.DataSource = dt; // Displays the results in the DataGridView.
                        dataGridView1.Refresh(); // Refreshes the DataGridView to show the updated data.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Shows an error message if something goes wrong.
            }
        }
        private void srcbtn_Click(object sender, EventArgs e)
        {
            SearchBooks(searchbox.Text); // Calls the search function when the search button is clicked.
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchbox.Text))
            {
                Notfound.Visible = false; // Hides the "not found" message when the search box is empty.
                Question.Visible = false; // Hides the "question" message.
                string searchTerm = searchbox.Text.Trim(); // Gets the search text, removing extra spaces.

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    SearchBooks(searchTerm); // Calls the search function if there’s text entered.
                }
                else
                {
                    LoadAllBooks(); // Calls a function to load all books if the search box is empty.
                }
            }
        }
        private void LoadAllBooks()
        {
            try
            {
                DataTable dt = new DataTable(); // Creates a new table to load all books.
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string query = "SELECT id, bookName, author, studentName, publishedDate, issueDate, returnDate, condition FROM returnBook"; // SQL query to get all books.
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        connect.Open(); // Opens the connection to the database.
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Executes the query to load all books.
                        adapter.Fill(dt); // Fills the data table with all book records.

                        dataGridView1.DataSource = dt; // Displays the data in the DataGridView.
                        dataGridView1.Refresh(); // Refreshes the DataGridView to show the updated data.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Shows an error message if something goes wrong.
            }
        }
        private void searchbox_Enter(object sender, EventArgs e)
        {
            searchbox.ForeColor = Color.Black; // Changes text color to black when the search box is focused.
            searchbox.Clear(); // Clears the search box when it is clicked.
        }
        private void searchbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchbox.Text))
            {
                searchbox.ForeColor = Color.DimGray; // Changes text color to dim gray when the search box is not focused.
                searchbox.Text = "Search"; // Sets the placeholder text when the search box is empty.
            }
        }
        private void searchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // Checks if the Enter key is pressed.
            {
                SearchBooks(searchbox.Text); // Calls the search function when Enter is pressed.
            }
        }
        private void panel2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null; // Removes focus from the active control (like the search box) when panel2 is clicked.
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null; // Removes focus from the active control when panel1 is clicked.
        }
    }
}
