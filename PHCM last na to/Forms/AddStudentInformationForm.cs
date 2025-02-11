using System;  // Provides fundamental classes like system types (e.g., String, Int, DateTime) and basic functionalities.
using System.Data;  // Provides classes for data-related operations, such as working with databases (e.g., DataTable, DataSet).
using System.Linq;  // Provides LINQ functionality for querying data in collections (e.g., lists, arrays) using query expressions.
using System.Windows.Forms;  // Provides classes for creating Windows Forms applications (e.g., Form, Button, TextBox).
using System.IO;  // Allows for file input/output operations, like reading/writing files (e.g., File, FileStream, StreamReader).
using System.Data.SqlClient;  // Includes classes needed to interact with SQL Server databases (e.g., SqlConnection, SqlCommand).
using PHCM_last_na_to.Toast_Messsage_Form;  // Custom class for displaying toast messages related to a specific form in your project (e.g., notifications).
using PHCM_last_na_to.Toast_Message_for_add_student_information;  // Custom class for showing toast messages related to adding student information.

namespace PHCM_last_na_to.Forms
{
    public partial class AddStudentInformationForm : Form
    {
        //Connection to the database
        SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30");
        // This variable holds the currently opened child form
        private Form currentChildForm;

        // Constructor for AddStudentInformationForm - Initializes the form
        public AddStudentInformationForm()
        {
            InitializeComponent(); // Initialize the form components (UI elements)
        }

        // Event handler for Name label click - Focus on the Name textbox when clicked
        private void Namelbl_Click(object sender, EventArgs e)
        {
            Nametxtbox.Focus(); // Focus on the Name textbox
            Namelbl.Visible = false; // Hide the Name label when the textbox is focused
        }

        // Event handler for Student Number label click - Focus on the Student Number textbox when clicked
        private void Numberlbl_Click(object sender, EventArgs e)
        {
            Numbertxtbox.Focus(); // Focus on the Number textbox
            Numberlbl.Visible = false; // Hide the Number label when the textbox is focused
        }

        // Event handler for Department label click - Focus on the Department textbox when clicked
        private void Departmentlbl_Click(object sender, EventArgs e)
        {
            Departmenttxtbox.Focus(); // Focus on the Department textbox
            Departmentlbl.Visible = false; // Hide the Department label when the textbox is focused
        }

        // Event handler for Contact label click - Focus on the Contact textbox when clicked
        private void Contactlbl_Click(object sender, EventArgs e)
        {
            Contacttxtbox.Focus(); // Focus on the Contact textbox
            Contactlbl.Visible = false; // Hide the Contact label when the textbox is focused
        }

        // Event handler for Name textbox focus - Hide the label when the textbox is focused
        private void Nametxtbox_Enter(object sender, EventArgs e)
        {
            Namelbl.Visible = false; // Hide the Name label when the textbox is focused
        }

        // Event handler for Student Number textbox focus - Hide the label when the textbox is focused
        private void Numbertxtbox_Enter(object sender, EventArgs e)
        {
            Numberlbl.Visible = false; // Hide the Number label when the textbox is focused
        }

        // Event handler for Department textbox focus - Hide the label when the textbox is focused
        private void Departmenttxtbox_Enter(object sender, EventArgs e)
        {
            Departmentlbl.Visible = false; // Hide the Department label when the textbox is focused
        }

        // Event handler for Contact textbox focus - Hide the label when the textbox is focused
        private void Contacttxtbox_Enter(object sender, EventArgs e)
        {
            Contactlbl.Visible = false; // Hide the Contact label when the textbox is focused
        }

        // Event handler for Name textbox losing focus - Show the label again if the textbox is empty
        private void Nametxtbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Nametxtbox.Text)) // Check if the textbox is empty
            {
                Namelbl.Visible = true; // Show the Name label if the textbox is empty
            }
        }

        // Event handler for Student Number textbox losing focus - Show the label again if the textbox is empty
        private void Numbertxtbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Numbertxtbox.Text)) // Check if the textbox is empty
            {
                Numberlbl.Visible = true; // Show the Number label if the textbox is empty
            }
        }

        // Event handler for Department textbox losing focus - Show the label again if the textbox is empty
        private void Departmenttxtbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Departmenttxtbox.Text)) // Check if the textbox is empty
            {
                Departmentlbl.Visible = true; // Show the Department label if the textbox is empty
            }
        }

        // Event handler for Contact textbox losing focus - Show the label again if the textbox is empty
        private void Contacttxtbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Contacttxtbox.Text)) // Check if the textbox is empty
            {
                Contactlbl.Visible = true; // Show the Contact label if the textbox is empty
            }
        }

        // Event handler to remove focus from all textboxes when clicked anywhere on the form
        private void AddStudentInformationForm_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null; // Remove focus from any active textbox
        }

        // Event handler to remove focus from all textboxes when clicked on panel1
        private void panel1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null; // Remove focus from any active textbox
        }

        // Event handler to remove focus from all textboxes when clicked on iconPictureBox1
        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null; // Remove focus from any active textbox
        }

        // Event handler to remove focus from all textboxes when clicked on iconPictureBox2
        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null; // Remove focus from any active textbox
        }

        // Event handler to change the image when the "Change Image" button is clicked
        private void changeImagebtn_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image File(*.jpg; *jpeg;) | *.jpg; *.jpeg;"; // Allow only image files with .jpg or .jpeg extensions

            // Show file dialog to choose an image
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    // Check if a file is selected and open it
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        string Filename = openFileDialog.FileName; // Get the selected file's path
                        ImagePath.Text = Filename; // Store the file path in the textbox

                        // Check if the file size exceeds the limit (512KB)
                        if (myStream.Length > 512000) // 512KB size limit
                        {
                            MessageBox.Show("File Size limit exceeded"); // Show error message if file is too large
                        }
                        else
                        {
                            Picture.Load(Filename); // Load the image into the PictureBox
                            changeImagebtn.Text = "Change Picture"; // Change the button text after the image is selected
                        }
                    }
                }
                catch (Exception ex) // Show error message if there's an issue
                {
                    MessageBox.Show(ex.Message); // Display the exception message
                }
            }
        }
        // Save Button Click Event (Insert data into the database)
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            // Check if the student's name contains digits (invalid)
            if (Nametxtbox.Text.Any(Char.IsDigit))
            {
                StudentName studentName = new StudentName();
                studentName.Show(); // Show error message about name containing digits
            }
            // Check if the contact number contains letters (invalid)
            else if (Contacttxtbox.Text.Any(Char.IsLetter))
            {
                StudentContact1 studentContact1 = new StudentContact1();
                studentContact1.Show(); // Show error message about invalid contact number
            }
            // Check if image path is empty
            else if (string.IsNullOrEmpty(ImagePath.Text))
            {
                EmptyPicture emptyPicture = new EmptyPicture();
                emptyPicture.Show(); // Show error message about missing picture
            }
            // Check if any of the essential fields (name, number, department, contact) are empty
            else if (Nametxtbox.Text == "" || Numbertxtbox.Text == "" || Departmenttxtbox.Text == "" || Contacttxtbox.Text == "")
            {
                EmptyField emptyField = new EmptyField();
                emptyField.Show(); // Show error message about missing fields
            }
            else
            {
                try
                {
                    // SQL query to insert student data into the database
                    string insertData = "INSERT INTO student (studentName, studentNumber, department, studentContact, studentPicture, studentImage) " +
                                        "VALUES(@studentName, @studentNumber, @department, @studentContact, @studentPicture, @studentImage)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        // Add values to the SQL query parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@studentName", Nametxtbox.Text);
                        cmd.Parameters.AddWithValue("@studentNumber", Numbertxtbox.Text);
                        cmd.Parameters.AddWithValue("@department", Departmenttxtbox.Text);
                        cmd.Parameters.AddWithValue("@studentContact", Contacttxtbox.Text);
                        cmd.Parameters.AddWithValue("@studentPicture", ImagePath.Text);  // Store file path of the image
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Convert the picture to byte array and store it in the database
                            Picture.Image.Save(ms, Picture.Image.RawFormat);
                            byte[] imageBytes = ms.ToArray();
                            cmd.Parameters.AddWithValue("@studentImage", imageBytes); // Store the image as a byte array in the database
                        }

                        // Open database connection and execute the SQL query
                        connect.Open();
                        cmd.ExecuteNonQuery(); // Execute the SQL insert command

                        // Show success message after student data is saved successfully
                        Successfully_Registered successfully_Registered = new Successfully_Registered();
                        successfully_Registered.ShowDialog();

                        // Clear input fields after saving the data
                        Nametxtbox.Text = "";
                        Numbertxtbox.Text = "";
                        Departmenttxtbox.Text = "";
                        Contacttxtbox.Text = "";
                        ImagePath.Text = "";
                        changeImagebtn.Text = "Add Picture";

                        // Make sure labels are visible again after saving
                        Namelbl.Visible = true;
                        Numberlbl.Visible = true;
                        Contactlbl.Visible = true;
                        Departmentlbl.Visible = true;

                        // Reset PictureBox image to default
                        Picture.Image = Properties.Resources._16410;
                        Nametxtbox.Focus(); // Focus on the Name textbox for the next entry
                    }
                }
                catch (SqlException ex)
                {
                    // Show an error message if there's a problem with the database
                    MessageBox.Show("Database error: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Show a general error message for any other unexpected errors
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Make sure the database connection is closed
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
            }
        }

        // Click event for the Delete button, which clears all input fields
        private void Deletebtn_Click(object sender, EventArgs e)
        {
            // Clear all textboxes and reset PictureBox image
            Nametxtbox.Text = "";
            Numbertxtbox.Text = "";
            Departmenttxtbox.Text = "";
            Contacttxtbox.Text = "";
            ImagePath.Text = "";
            changeImagebtn.Text = "Add Picture";
            Picture.Image = Properties.Resources._16410; // Reset image to default
            Nametxtbox.Focus(); // Focus back on the Name textbox
        }

        // Click event for the PictureBox, prevents it from receiving focus when clicked
        private void Picture_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null; // Deselect the PictureBox
        }

        // Method to open a new child form (e.g., for viewing students)
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close(); // Close any currently open child form
            }
            currentChildForm = childForm; // Set the new child form
            childForm.TopLevel = false; // Make it a child of the parent form
            childForm.FormBorderStyle = FormBorderStyle.None; // Remove the border of the child form
            childForm.Dock = DockStyle.Fill; // Make the child form fill the parent container
            panel11.Controls.Add(childForm); // Add the child form to the panel
            panel11.Tag = childForm; // Store reference to the child form
            childForm.BringToFront(); // Bring the child form to the front
            childForm.Show(); // Show the child form
        }

        // Click event to open the ViewStudent form (view student information)
        private void View_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new ViewStudent());
        }

        // Automatically focus on the Name textbox when the form loads
        private void AddStudentInformationForm_Load(object sender, EventArgs e)
        {
            Nametxtbox.Focus(); // Focus on the Name textbox for user input
        }

    }
}