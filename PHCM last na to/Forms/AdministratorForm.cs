using System; // Import the basic System namespace that provides access to common classes (like string, int, etc.)
using System.Data; // Import the System.Data namespace, which helps with working with data and databases (like tables and datasets)
using System.Data.SqlClient; // Import the necessary classes for connecting to and interacting with a SQL Server database
using System.Drawing; // Import the System.Drawing namespace, which helps with working with graphics and images
using System.Linq; // Import System.Linq, which provides tools for working with collections of data (like searching or filtering)
using System.Windows.Forms; // Import System.Windows.Forms, which is used for building Windows Forms applications with graphical user interfaces (UI)


namespace PHCM_last_na_to.Forms
{
    public partial class AdministratorForm : Form
    {
        // Connection string to connect to the database
        private string connect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30";

        // Constructor to initialize the form
        public AdministratorForm()
        {
            InitializeComponent();
        }

        // Load data from the database into the DataGridView when the form loads
        private void AdministratorForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'admin.admin' table. You can move, or remove it, as needed.
            this.adminTableAdapter.Fill(this.admin.admin);            
        }

        // Save button click event to check input and save/update the record
        private void SaveBTN_Click(object sender, EventArgs e)
        {
            // Check if any field is empty or contains invalid data
            if (string.IsNullOrEmpty(FirstNameTextBox.Text) || string.IsNullOrEmpty(SurnameTextBox.Text) || //if the textbox is empty or contains the number (except the contact if it containes the letter)
                string.IsNullOrEmpty(ContactTextBox.Text) || string.IsNullOrEmpty(UsernameTextBox.Text) ||
                string.IsNullOrEmpty(PasswordTextBox.Text) || FirstNameTextBox.Text.Any(Char.IsDigit) ||
                MiddleNameTextBox.Text.Any(Char.IsDigit) || SurnameTextBox.Text.Any(Char.IsDigit) ||
                ContactTextBox.Text.Any(Char.IsLetter))

            {                
                if (FirstNameTextBox.Text.Any(Char.IsDigit) ||
                    MiddleNameTextBox.Text.Any(Char.IsDigit) || SurnameTextBox.Text.Any(Char.IsDigit) ||  // if the boxes contains numbers and letters (for contact)
                    ContactTextBox.Text.Any(Char.IsLetter))
                {
                    MessageBox.Show("Input Letters Only!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand); //show message

                    
                    //clearing the text from specific textbox if it triggers
                    if (FirstNameTextBox.Text.Any(Char.IsDigit)) 
                    {
                        FirstNameTextBox.Text = "";
                    }
                    else if (MiddleNameTextBox.Text.Any(Char.IsDigit))
                    {
                        MiddleNameTextBox.Text = "";
                    }
                    else if (SurnameTextBox.Text.Any(Char.IsDigit))
                    {
                        SurnameTextBox.Text = "";
                    }
                    else if (ContactTextBox.Text.Any(Char.IsLetter))
                    {
                        ContactTextBox.Text = "";
                    }
                }

                // Check for specific emptyness and show messages
                else if (string.IsNullOrEmpty(UsernameTextBox.Text))
                {
                    MessageBox.Show("Input Username!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand); //shows message for specific box
                }
                else if (string.IsNullOrEmpty(FirstNameTextBox.Text))
                {
                    MessageBox.Show("Input First Name!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    FirstNameTextBox.Text = "";
                }
                else if (string.IsNullOrEmpty(SurnameTextBox.Text))
                {
                    MessageBox.Show("Input Surname!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    SurnameTextBox.Text = "";
                }
                else if (string.IsNullOrEmpty(ContactTextBox.Text))
                {
                    MessageBox.Show("Input Contact Number!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    ContactTextBox.Text = "";
                }
            }
            else
            {
                // Update the DataGridView with the new or modified values
                DataGridViewCell cell = dataGridView1.CurrentCell;
                int rowIndex = cell.RowIndex; // Get the row index of the clicked cell
                int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["idDataGridViewTextBoxColumn"].Value); // Get the ID of the record

                // Call method to update the database with the new values
                UpdateRow(id);

                // Update the DataGridView with the new values
                dataGridView1.Rows[rowIndex].Cells["firstNameDataGridViewTextBoxColumn"].Value = FirstNameTextBox.Text;
                dataGridView1.Rows[rowIndex].Cells["middleNameDataGridViewTextBoxColumn"].Value = MiddleNameTextBox.Text;
                dataGridView1.Rows[rowIndex].Cells["surnameDataGridViewTextBoxColumn"].Value = SurnameTextBox.Text;
                dataGridView1.Rows[rowIndex].Cells["contactNoDataGridViewTextBoxColumn"].Value = ContactTextBox.Text;
                dataGridView1.Rows[rowIndex].Cells["usernameDataGridViewTextBoxColumn"].Value = UsernameTextBox.Text;
                dataGridView1.Rows[rowIndex].Cells["passowrdDataGridViewTextBoxColumn"].Value = PasswordTextBox.Text;
                dataGridView1.Rows[rowIndex].Cells["isAdminDataGridViewCheckBoxColumn"].Value = isAdminCheckBox.Checked;

                // Clear the input fields after saving the data
                FirstNameTextBox.Text = "";
                MiddleNameTextBox.Text = "";
                SurnameTextBox.Text = "";
                ContactTextBox.Text = "";
                UsernameTextBox.Text = "";
                PasswordTextBox.Text = "";
                isAdminCheckBox.Checked = false;

                // Hide the edit panel after saving the data
                EditPanel.Visible = false;
            }
        }

        // Update the record in the database based on the ID
        private void UpdateRow(int id)
        {
            //taking a specific data from data table
            string query = "UPDATE admin SET firstName = @firstName, middleName = @middleName, surname = @surname, contactNo = @contactNo, username = @username, passowrd = @passowrd, isAdmin = @isAdmin WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(connect)) //connecting the database
            {
                // Create a new SqlCommand object with the query and connection
                SqlCommand cmd = new SqlCommand(query, connection);

                // Add parameters to the command to prevent SQL injection and to bind data from the input fields
                cmd.Parameters.AddWithValue("@firstName", FirstNameTextBox.Text); // Bind First Name
                cmd.Parameters.AddWithValue("@middleName", MiddleNameTextBox.Text); // Bind Middle Name
                cmd.Parameters.AddWithValue("@surname", SurnameTextBox.Text); // Bind Surname
                cmd.Parameters.AddWithValue("@contactNo", ContactTextBox.Text); // Bind Contact Number
                cmd.Parameters.AddWithValue("@username", UsernameTextBox.Text); // Bind Username
                cmd.Parameters.AddWithValue("@passowrd", PasswordTextBox.Text); // Bind Password
                cmd.Parameters.AddWithValue("@isAdmin", isAdminCheckBox.Checked); // Bind Admin status (true/false)
                cmd.Parameters.AddWithValue("@id", id); // Bind the record ID to specify which row to update

                try
                {
                    connection.Open(); // Open the database connection
                    cmd.ExecuteNonQuery(); // Execute the update query
                    MessageBox.Show("Record updated successfully!"); // Notify user
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message); // Show error message
                }
            }
        }

        // Delete a record from the database based on the ID
        private void DeleteRow(int id)
        {
            string query = "DELETE FROM admin WHERE id = @id"; //deleting a data from datatable

            using (SqlConnection connection = new SqlConnection(connect)) //connecting the server
            {
                SqlCommand cmd = new SqlCommand(query, connection); //commanding the sql
                cmd.Parameters.AddWithValue("@id", id); //bindd id

                try
                {
                    connection.Open(); // Open the database connection
                    cmd.ExecuteNonQuery(); // Execute the delete query
                    MessageBox.Show("Record deleted successfully!"); // Notify user
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message); // Show error message
                }
            }
        }

        // Clear the form inputs and hide the edit panel
        private void catana_button1_Click(object sender, EventArgs e)
        {
            FirstNameTextBox.Text = "";
            MiddleNameTextBox.Text = "";
            SurnameTextBox.Text = "";
            ContactTextBox.Text = "";
            EditPanel.Visible = false;
        }        

        // When the search button is clicked, start the search using the text in the search box
        private void srcbtn_Click(object sender, EventArgs e)
        {
            SearchAccount(searchbox.Text); // Call SearchStudent function with the text entered in the search box
        }

        // When the search box gets focus, clear the text and change text color to black
        private void searchbox_Enter(object sender, EventArgs e)
        {
            searchbox.ForeColor = Color.Black; // Change text color to black
            searchbox.Clear(); // Clear any existing text in the search box
        }

        // When the search box loses focus, restore default text ("Search") if box is empty
        private void searchbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchbox.Text)) // Check if the search box is empty
            {
                searchbox.ForeColor = Color.DimGray; // Change text color to gray
                searchbox.Text = "Search"; // Set the text to "Search" as placeholder
            }
        }

        // When the text in the search box changes, perform search or reset based on input
        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchbox.Text)) // Check if the search box is empty
            {
                Notfound.Visible = false; // Hide "Not Found" label
                Question.Visible = false; // Hide question mark label

                string searchTerm = searchbox.Text.Trim(); // Get the search text and remove any extra spaces

                if (!string.IsNullOrEmpty(searchTerm)) // If search box has text
                {
                    SearchAccount(searchTerm); // Perform the search with the entered text
                }
                else
                {
                    LoadAllAccount(); // If the search box is empty, load all students
                }
            }
        }

        // If the Enter key is pressed, perform the search
        private void searchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // If Enter key is pressed
            {
                SearchAccount(searchbox.Text); // Perform the search
            }
        }

        // Function to search students based on the entered search term
        private void SearchAccount(string searchTerm)
        {
            Notfound.Visible = false; // Hide "Not Found" label initially
            Question.Visible = false; // Hide question mark label initially

            try
            {
                DataTable dt = new DataTable(); // Create a DataTable to store the search results

                // Create a connection to the SQL database
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string query = "SELECT id, firstName, middleName, surname, contactNo, username, passowrd, isAdmin FROM admin " +
                                   "WHERE firstName LIKE @search OR middleName LIKE @search OR surname LIKE @search OR contactNo LIKE @search OR username LIKE @search"; // SQL query to search for students

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%"); // Add search term to the query

                        connect.Open(); // Open the database connection
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Create a data adapter to execute the query
                        adapter.Fill(dt); // Fill the DataTable with the search results

                        // If no results were found, show "Not Found" message
                        if (dt.Rows.Count == 0)
                        {
                            Notfound.Visible = true; // Show "Not Found" label
                            Question.Visible = true; // Show question mark label
                        }

                        // Refresh the DataGridView with the search results
                        dataGridView1.DataSource = dt;
                        dataGridView1.Refresh(); // Refresh the DataGridView to show the new data
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message if something goes wrong
            }
        }

        // Function to load all students (if search box is empty)
        private void LoadAllAccount()
        {
            try
            {
                DataTable dt = new DataTable(); // Create a DataTable to store the student data

                // Create a connection to the SQL database
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string query = "SELECT id, firstName, middleName, surname, contactNo, username, passowrd, isAdmin FROM admin"; // SQL query to get all students
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        connect.Open(); // Open the database connection
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Create a data adapter to execute the query
                        adapter.Fill(dt); // Fill the DataTable with the student data

                        // Refresh the DataGridView with all student data
                        dataGridView1.DataSource = dt;
                        dataGridView1.Refresh(); // Refresh the DataGridView to show all data
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message if something goes wrong
            }
        }

        private void ButtonClickedControl(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Text == "Edit")
                {
                    // Check if a row is selected in the DataGridView
                    if (dataGridView1.SelectedRows.Count > 0)
                    {                        
                        // Get the selected row from the grid
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                        // Populate the textboxes with values from the selected row                        
                        FirstNameTextBox.Text = selectedRow.Cells["firstNameDataGridViewTextBoxColumn"].Value?.ToString() ?? ""; // Set First Name
                        MiddleNameTextBox.Text = selectedRow.Cells["middleNameDataGridViewTextBoxColumn"].Value?.ToString() ?? ""; // Set Middle Name
                        SurnameTextBox.Text = selectedRow.Cells["surnameDataGridViewTextBoxColumn"].Value?.ToString() ?? ""; // Set Surname
                        ContactTextBox.Text = selectedRow.Cells["contactNoDataGridViewTextBoxColumn"].Value?.ToString() ?? ""; // Set Contact Number
                        UsernameTextBox.Text = selectedRow.Cells["usernameDataGridViewTextBoxColumn"].Value?.ToString() ?? ""; // Set Username
                        PasswordTextBox.Text = selectedRow.Cells["passowrdDataGridViewTextBoxColumn"].Value?.ToString() ?? ""; // Set Password
                        isAdminCheckBox.Checked = (bool)selectedRow.Cells["isAdminDataGridViewCheckBoxColumn"].Value; // Set Admin status
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
    }
}