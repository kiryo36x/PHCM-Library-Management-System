using PHCM_last_na_to.Toast_Message_for_add_student_information; // Includes the namespace that likely handles showing toast messages when student information is added.
using PHCM_last_na_to.Toast_Messsage_Form; // Includes the namespace that might handle the design or display of the toast message form.
using System; // Includes basic functionalities like data types, system-level functionalities (e.g., exceptions).
using System.Data; // Includes functionalities related to handling data (e.g., DataTables).
using System.Data.SqlClient; // Allows interaction with SQL Server databases (e.g., executing queries).
using System.Drawing; // Provides functionalities related to handling images, colors, and drawing operations.
using System.IO; // Includes functionalities to work with input and output, like reading and writing to files.
using System.Linq; // Allows LINQ operations for querying data (e.g., filtering collections).
using System.Windows.Forms; // Includes all the Windows Forms controls, components, and functionalities for building Windows-based user interfaces.

namespace PHCM_last_na_to.Forms
{
    public partial class StudentDetailsForm : Form
    {
        //connecting to database
        private string connect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30";
        // Holds the current child form being displayed in the panel
        private Form currentChildForm;

        // Constructor: Initializes the StudentDetailsForm
        public StudentDetailsForm()
        {
            InitializeComponent(); // Sets up the components of the form
        }

        // Event handler for when the 'previous' button is clicked
        private void previous_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReturnDetailsForm()); // Opens the ReturnDetailsForm
        }

        // Method to open a new form as a child within the current form
        private void OpenChildForm(Form childForm)
        {
            // Close the previous form if there's one open
            if (currentChildForm != null)
            {
                currentChildForm.Close(); // Close the previous form
            }

            // Set the new form as the current child form
            currentChildForm = childForm;
            childForm.TopLevel = false; // Make the form a child, not a top-level window
            childForm.FormBorderStyle = FormBorderStyle.None; // Remove borders for the child form
            childForm.Dock = DockStyle.Fill; // Fill the parent container with the child form
            this.Controls.Add(childForm); // Add the child form to the parent container
            this.Tag = childForm; // Tag the form for identification
            childForm.BringToFront(); // Bring the child form to the front
            childForm.Show(); // Display the form
            childForm.Focus();
        }

        // Event handler for when the StudentDetailsForm is loaded
        private void StudentDetailsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentInformation.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.studentInformation.student);                   
        }

        // Event handler when the user clicks into the search box
        private void searchbox_Enter(object sender, EventArgs e)
        {
            searchbox.ForeColor = Color.Black; // Change text color to black
            searchbox.Clear(); // Clear the search box when clicked
        }

        // Event handler for when the user clicks out of the search box
        private void searchbox_Leave(object sender, EventArgs e)
        {
            // If search box is empty, set placeholder text back
            if (string.IsNullOrEmpty(searchbox.Text))
            {
                searchbox.ForeColor = Color.DimGray; // Set color to dim gray
                searchbox.Text = "Search"; // Restore the placeholder text
            }
        }

        // Event handler for when the text in the search box changes
        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            // If the search box is empty, hide search results or load all students
            if (string.IsNullOrEmpty(searchbox.Text))
            {
                Notfound.Visible = false; // Hide "not found" message
                Question.Visible = false; // Hide "question" message
                string searchTerm = searchbox.Text.Trim(); // Remove spaces from search term

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    SearchStudent(searchTerm); // Search based on user input
                }
                else
                {
                    LoadAllStudent(); // Load all students if search box is empty
                }
            }
        }

        // Event handler for when the search button is clicked
        private void srcbtn_Click(object sender, EventArgs e)
        {
            SearchStudent(searchbox.Text); // Trigger search with the current text in the search box
        }

        // Search for student details based on the search term
        private void SearchStudent(string searchTerm)
        {
            Notfound.Visible = false; // Hide the "Not found" message
            Question.Visible = false; // Hide the "Question" message
            try
            {
                DataTable dt = new DataTable(); // Create a new DataTable to store the results
                                                // Create a connection to the database
                using (SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    // SQL query to search students by name, student number, or department
                    string query = "SELECT id, studentName, StudentNumber, department, studentContact, studentPicture, studentImage FROM student " +
                                   "WHERE studentName LIKE @search OR studentNumber LIKE @search OR department LIKE @search";

                    // Execute the query with the search term as a parameter
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%"); // Add the search term to the query

                        connect.Open(); // Open the connection to the database
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Create an adapter to fill the data
                        adapter.Fill(dt); // Fill the data into the DataTable

                        if (dt.Rows.Count == 0)
                        {
                            Notfound.Visible = true; // Show the "Not found" message if no results
                            Question.Visible = true; // Show a question mark message
                        }

                        // Convert image data to a usable format (if present)
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["studentImage"] != DBNull.Value) // Check if the image exists
                            {
                                byte[] imageBytes = (byte[])row["studentImage"]; // Get the image as bytes
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    // Convert byte array to Image
                                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                                    // Convert the Image back to byte array to store it in the DataTable
                                    using (MemoryStream saveStream = new MemoryStream())
                                    {
                                        img.Save(saveStream, img.RawFormat);
                                        byte[] imageBytesToStore = saveStream.ToArray();

                                        // Store the byte array back in the 'studentImage' column
                                        row["studentImage"] = imageBytesToStore;
                                    }
                                }
                            }
                        }

                        // Update the DataGridView with the new data
                        dataGridView1.DataSource = dt;
                        dataGridView1.Refresh(); // Refresh the grid to show updated data
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error if something goes wrong
            }
        }

        // Event handler for when the user presses a key in the search box
        private void searchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // If 'Enter' is pressed
            {
                SearchStudent(searchbox.Text); // Trigger the search function
            }
        }

        // Load all students' data if no search term is provided
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
                        dataGridView1.DataSource = dt;
                        dataGridView1.Refresh(); // Refresh the DataGridView to show the data
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message if something goes wrong
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row from the grid
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Populate the textboxes with values from the selected row
                studentNametxtbox.Text = selectedRow.Cells["dataGridViewTextBoxColumn1"].Value?.ToString() ?? "";
                studentNumbertxtbox.Text = selectedRow.Cells["dataGridViewTextBoxColumn2"].Value?.ToString() ?? "";
                departmenttxtbox.Text = selectedRow.Cells["dataGridViewTextBoxColumn3"].Value?.ToString() ?? "";
                contacttxtbox.Text = selectedRow.Cells["dataGridViewTextBoxColumn4"].Value?.ToString() ?? "";

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

        private void exiteditpanel_Click(object sender, EventArgs e)
        {            
            dataupdated.Visible = false; // Hide the data updated message
            EditPanel.Visible = false; // Hide the edit panel
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Ask user for confirmation before deleting the data
                DialogResult askUSR = MessageBox.Show("Do you wish to delete this account?", "You're About to Delete a Data!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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

        private void DeleteRow(int id)
        {
            string query = "DELETE FROM student WHERE id = @id"; // SQL query to delete a record based on ID

            using (SqlConnection connection = new SqlConnection(connect)) // Connect to the database
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

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            // Check if any field is empty
            if (string.IsNullOrEmpty(studentNametxtbox.Text) || string.IsNullOrEmpty(studentNumbertxtbox.Text) || string.IsNullOrEmpty(departmenttxtbox.Text) || string.IsNullOrEmpty(contacttxtbox.Text))
            {
                EmptyField emptyField = new EmptyField(); // Show error message for empty fields
                emptyField.Show();
            }
            else if (studentNametxtbox.Text.Any(Char.IsDigit)) // Check if student name contains digits
            {
                StudentName studentName = new StudentName(); // Show error message for invalid student name
                studentName.Show();
            }
            else if (contacttxtbox.Text.Any(Char.IsLetter)) // Check if contact number contains letters
            {
                StudentContact1 contact1 = new StudentContact1(); // Show error message for invalid contact number
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
                    dataGridView1.Rows[rowIndex].Cells["dataGridViewTextBoxColumn1"].Value = studentNametxtbox.Text;
                    dataGridView1.Rows[rowIndex].Cells["dataGridViewTextBoxColumn2"].Value = studentNumbertxtbox.Text;
                    dataGridView1.Rows[rowIndex].Cells["dataGridViewTextBoxColumn3"].Value = departmenttxtbox.Text;
                    dataGridView1.Rows[rowIndex].Cells["dataGridViewTextBoxColumn4"].Value = contacttxtbox.Text;
                    dataGridView1.Rows[rowIndex].Cells["dataGridViewImageColumn1"].Value = picture.Image;
                    LoadData(); // Reload the data
                }
            }
        }

        private void UpdateRow(int id)
        {
            // SQL query to update a record in the database based on ID
            string query = "UPDATE student SET studentName = @studentName, studentNumber = @studentNumber, department = @department, studentContact = @studentContact, studentImage = @studentImage WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(connect)) // Connect to the database
            {
                SqlCommand cmd = new SqlCommand(query, connection); // Create the SQL command

                // Bind values to parameters
                cmd.Parameters.AddWithValue("@studentName", studentNametxtbox.Text);
                cmd.Parameters.AddWithValue("@studentNumber", studentNumbertxtbox.Text);
                cmd.Parameters.AddWithValue("@department", departmenttxtbox.Text);
                cmd.Parameters.AddWithValue("@studentContact", contacttxtbox.Text);
                cmd.Parameters.AddWithValue("@studentImage", ImageToByteArray(picture.Image)); // Convert image to byte array
                cmd.Parameters.AddWithValue("@id", id); // Bind the ID to the query

                try
                {
                    connection.Open(); // Open the database connection
                    cmd.ExecuteNonQuery(); // Execute the update query
                    dataupdated.Visible = true; // Show success message
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message); // Show error message if update fails
                }
            }
        }

        private void changeimage_Click(object sender, EventArgs e)
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

        private byte[] ImageToByteArray(Image img)
        {
            // Resize the image to match the PictureBox size
            using (Bitmap newImage = new Bitmap(picture.Width, picture.Height))
            {
                using (Graphics g = Graphics.FromImage(newImage))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(img, 0, 0, picture.Width, picture.Height); // Resize the image
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Save resized image as JPEG
                    return ms.ToArray(); // Return the byte array of the image
                }
            }
        }

        private void LoadData()
        {
            string query = "SELECT * FROM student"; // SQL query to fetch all records from the student table

            using (SqlConnection connection = new SqlConnection(connect)) // Connect to the database
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection); // Create a data adapter to fetch data
                DataTable dt = new DataTable(); // Create a DataTable to store the data
                adapter.Fill(dt); // Fill the DataTable with data from the query
                dataGridView1.DataSource = dt; // Set the data grid view's data source to the DataTable
            }
        }

        private void StudentDetailsForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Left)
            {
                OpenChildForm(new ReturnDetailsForm());
            }
        }
    }
}
