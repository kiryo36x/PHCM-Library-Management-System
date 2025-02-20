using System; // Includes basic classes for general functionalities (e.g., working with strings, exceptions).
using System.Data; // Allows working with databases and data tables.
using System.Data.SqlClient; // Enables connecting to and interacting with SQL Server databases.
using System.Drawing; // Provides tools to work with graphics and images.
using System.IO; // Allows working with files and data streams (e.g., reading/writing files).
using System.Windows.Forms; // Provides classes for creating and managing Windows Forms applications (the user interface).

namespace PHCM_last_na_to.Forms
{
    public partial class ViewStudent : Form
    {
        private Form currentChildForm; // Declares a variable to hold the current child form
        public ViewStudent()
        {
            InitializeComponent(); // Initializes the form's components (UI elements)
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentInformation.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.studentInformation.student);            
        }

        private void ReturnAddStudent_Click(object sender, EventArgs e)
        {
            // Opens the AddStudentInformationForm as a child form
            OpenChildForm(new AddStudentInformationForm());
        }

        private void OpenChildForm(Form childForm)
        {
            // If there is an already opened child form, close it
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm; // Set the new form as the current child form
            childForm.TopLevel = false; // Makes the form a child form (not a top-level form)
            childForm.FormBorderStyle = FormBorderStyle.None; // Removes the border from the child form
            childForm.Dock = DockStyle.Fill; // Makes the form fill the parent container
            this.Controls.Add(childForm); // Adds the child form to the parent container
            this.Tag = childForm; // Stores the child form in the 'Tag' property
            childForm.BringToFront(); // Brings the child form to the front
            childForm.Show(); // Shows the child form
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
                        dataGridView1.DataSource = dt;
                        dataGridView1.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                // If an error occurs, show an error message
                MessageBox.Show("Error: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
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

        private void LoadAllStudent()
        {
            try
            {
                DataTable dt = new DataTable(); // Creates a DataTable to store all student data
                                                // Connect to the database
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string query = "SELECT studentPicture, studentName, studentNumber, department, studentContact, studentImage FROM student"; // SQL query to get all students
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        connect.Open(); // Opens the connection to the database
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Executes the query and fills the DataTable with all student data
                        adapter.Fill(dt);

                        // Displays all the student data in the DataGridView
                        dataGridView1.DataSource = dt;
                        dataGridView1.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                // If an error occurs, show an error message
                MessageBox.Show("Error: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void srcbtn_Click(object sender, EventArgs e)
        {
            // Calls the SearchStudent function when the search button is clicked
            SearchStudent(searchbox.Text);
        }

        private void searchbox_Enter(object sender, EventArgs e)
        {
            searchbox.ForeColor = Color.Black; // Change the text color to black when the search box is clicked
            searchbox.Clear(); // Clears the default text in the search box
        }

        private void searchbox_Leave(object sender, EventArgs e)
        {
            // If the search box is empty, reset the placeholder text
            if (string.IsNullOrEmpty(searchbox.Text))
            {
                searchbox.ForeColor = Color.DimGray; // Change the text color to dim gray
                searchbox.Text = "Search"; // Set the placeholder text
            }
        }

        private void searchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the Enter key is pressed, perform the search
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchStudent(searchbox.Text);
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null; // Removes focus from the active control (e.g., the search box) when the panel is clicked
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null; // Removes focus from the active control when the panel is clicked
        }
    }
}
