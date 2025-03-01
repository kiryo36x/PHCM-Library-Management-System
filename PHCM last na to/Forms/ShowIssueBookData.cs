using System; // Basic system functionalities like data types, console output, etc.
using System.Data; // Provides classes for working with databases (e.g., DataTables, DataAdapters)
using System.Data.SqlClient; // Allows for interaction with SQL Server databases (e.g., executing SQL commands)
using System.Drawing; // Provides classes for handling graphics (e.g., working with images, drawing shapes, etc.)
using System.Windows.Forms; // Provides classes for building Windows Forms applications (e.g., creating buttons, labels, forms)

namespace PHCM_last_na_to.Forms
{
    public partial class ShowIssueBookData : Form
    {
        private Form currentChildForm; // Declares a variable to hold the current child form.
        public ShowIssueBookData() // Constructor to initialize the form.
        {
            InitializeComponent(); // This initializes the components on the form (like buttons, textboxes, etc.).
        }
        private void ReturnAddStudent_Click(object sender, EventArgs e)
        {
            OpenChildForm(new IssueBooksForm()); // When the button is clicked, open a new form (IssueBooksForm).
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null) // If there’s already a child form open...
            {
                currentChildForm.Close(); // Close it.
            }
            currentChildForm = childForm; // Set the new form as the current child form.
            childForm.TopLevel = false; // The form won't be a top-level window.
            childForm.FormBorderStyle = FormBorderStyle.None; // Remove borders from the form.
            childForm.Dock = DockStyle.Fill; // Make the form fill the entire container.
            this.Controls.Add(childForm); // Add the form to the parent form's controls.
            this.Tag = childForm; // Tag the form with its reference (useful for some operations).
            childForm.BringToFront(); // Bring the form to the front of all others.
            childForm.Show(); // Display the form.
        }
        private void ShowIssueBookData_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'issuedBooks.issue' table. You can move, or remove it, as needed.
            this.issueTableAdapter.Fill(this.issuedBooks.issue);
            // TODO: This line of code loads data into the 'issuedBooks.issue' table. You can move, or remove it, as needed.
            this.issueTableAdapter.Fill(this.issuedBooks.issue);
            // TODO: This line of code loads data into the 'issuedBooks.issue' table. You can move, or remove it, as needed.
            this.issueTableAdapter.Fill(this.issuedBooks.issue);
            // TODO: This line of code loads data into the 'issuedBooks.issue' table. You can move, or remove it, as needed.
            this.issueTableAdapter.Fill(this.issuedBooks.issue);                     
        }

        private void srcbtn_Click(object sender, EventArgs e)
        {
            SearchBooks(searchbox.Text); // When the search button is clicked, search for books based on the text in the search box.
        }

        private void SearchBooks(string searchTerm)
        {
            Notfound.Visible = false; // Hide the 'not found' message.
            Question.Visible = false; // Hide the 'question' message.

            try
            {
                DataTable dt = new DataTable(); // Create a table to hold search results.
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30")) // Connect to the database.
                {
                    // SQL query to search the 'issue' table based on book name, author, or student name.
                    string query = "SELECT id, bookName, author, studentName, publishedDate, issueDate, studentImage, genre FROM issue WHERE bookName LIKE @search OR author LIKE @search OR studentName LIKE @search OR genre LIKE @search";
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%"); // Use the search term in the query.

                        connect.Open(); // Open the connection to the database.
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Set up a data adapter to fill the DataTable.
                        adapter.Fill(dt); // Fill the DataTable with the results of the query.

                        // If no results, show the 'not found' message.
                        if (dt.Rows.Count == 0)
                        {
                            Notfound.ForeColor = Color.Black;
                            Notfound.Visible = true;
                            Question.Visible = true;
                        }

                        // Display the results in the DataGridView.
                        dataGridView1.DataSource = dt;
                        dataGridView1.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchbox.Text)) // If the search box is empty...
            {
                Notfound.Visible = false; // Hide the 'not found' message.
                Question.Visible = false; // Hide the 'question' message.

                string searchTerm = searchbox.Text.Trim(); // Remove any extra spaces.

                if (!string.IsNullOrEmpty(searchTerm)) // If there is something typed in the search box...
                {
                    SearchBooks(searchTerm); // Perform the search.
                }
                else
                {
                    LoadAllBooks(); // If the search box is empty, reload all books.
                }
            }
        }
        private void LoadAllBooks()
        {
            try
            {
                DataTable dt = new DataTable(); // Create a new table to hold all book data.
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30")) // Connect to the database.
                {
                    string query = "SELECT id, bookName, author, studentName, publishedDate, issueDate, genre,studentImage FROM issue"; // Query to get all books.
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        connect.Open(); // Open the connection to the database.
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Set up a data adapter to fill the DataTable.
                        adapter.Fill(dt); // Fill the table with all books.

                        // Display the results in the DataGridView.
                        dataGridView1.DataSource = dt;
                        dataGridView1.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show an error if something goes wrong.
            }
        }
        private void searchbox_Enter(object sender, EventArgs e)
        {
            searchbox.ForeColor = Color.Black; // Change text color to black when the user focuses on the search box.
            searchbox.Clear(); // Clear the search box.
        }
        private void searchbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchbox.Text)) // If the search box is empty...
            {
                searchbox.ForeColor = Color.DimGray; // Change text color to dim gray.
                searchbox.Text = "Search"; // Set the placeholder text.
            }
        }

        private void searchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchBooks(searchbox.Text);
            }
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null; // Remove focus from any control when the panel is clicked.
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null; // Remove focus from any control when the second panel is clicked.
        }
    }
}
