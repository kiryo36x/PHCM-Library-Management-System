using System;  // Provides fundamental classes like system types (e.g., String, Int, DateTime) and basic functionalities
using System.Data;  // Provides classes for data-related operations, such as working with databases (e.g., DataTable, DataSet)
using System.Data.SqlClient;  // Includes classes needed to interact with SQL Server databases (e.g., SqlConnection, SqlCommand)
using System.Drawing;  // Provides access to drawing-related functionality like images and colors (e.g., Image, Graphics, Color)
using System.Linq;  // Provides LINQ functionality for querying data in collections (e.g., lists, arrays) using query expressions
using System.Windows.Forms;  // Provides classes for creating Windows Forms applications (e.g., Form, Button, TextBox)
using System.IO;  // Allows for file input/output operations, like reading/writing files (e.g., File, FileStream, StreamReader)
using PHCM_last_na_to.Toast_Message_for_add_student_information;  // Custom class for displaying toast messages when adding student information
using PHCM_last_na_to.Toast_Message_for_add_books;  // Custom class for displaying toast messages when adding books

namespace PHCM_last_na_to.Forms
{
    // The AddBooksForm class handles the form for adding a new book
    public partial class AddBooksForm : Form
    {
        SqlConnection connect = new SqlConnection ("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30");
        public AddBooksForm()
        {
            InitializeComponent();  // Initializes the form components (like buttons, labels, etc.)
        }
        
        // Establishes a connection to the database

        private Form currentChildForm;  // Stores the current child form being displayed

        private void AddBooksForm_Load(object sender, EventArgs e)
        {
            // When the form loads, it sets up the interface
            panel1.Enabled = true;  // Enables a panel on the form
            panel1.Visible = true;  // Makes the panel visible            
            Booknametxtbox.Focus();  // Focuses on the book name text box (makes it ready for typing)
        }

        private void ClosedDate()
        {
            this.ActiveControl = null;  // Removes focus from the current active control (e.g., text box)

            // Checks if any required fields are empty and shows labels to inform the user
            if (string.IsNullOrEmpty(Booknametxtbox.Text))
            {
                Booknamelbl.Visible = true;  // Makes the book name label visible if text box is empty
            }
            else if (string.IsNullOrEmpty(Authortxtbox.Text))
            {
                Authorlbl.Visible = true;  // Shows the author label if the author's text box is empty
            }
            else if (string.IsNullOrEmpty(Conditiontxtbox.Text))
            {
                Conditionlbl.Visible = true;  // Shows the condition label if the condition text box is empty
            }
        }

        // Allows users to change the book's image by selecting a file
        private void changeImagebtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "Image Files(*.jpg; *.jpeg) | *.jpg; *.jpeg";  // Filters to only allow image files

            if (openfd.ShowDialog() == DialogResult.OK)
            {
                ImagePath.Text = openfd.FileName;  // Displays the selected image file path
                Picture.Image = new Bitmap(openfd.FileName);  // Sets the selected image as the picture
                Picture.ImageLocation = openfd.FileName;  // Specifies the image file location
                Picture.SizeMode = PictureBoxSizeMode.StretchImage;  // Stretches the image to fit the picture box
            }
        }

        private void AddBooksForm_Click(object sender, EventArgs e)
        {
            ClosedDate();  // Calls the method to check if any fields are empty
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ClosedDate();  // Same as above, checks fields if user clicks on the picture box
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            ClosedDate();  // Checks if any fields are empty when clicking on the panel
        }

        private void Picture_Click(object sender, EventArgs e)
        {
            ClosedDate();  // Checks fields when clicking on the picture
        }

        // Saves the book details to the database
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            // Validation: Ensures that text boxes contain correct values
            if (Authortxtbox.Text.Any(Char.IsDigit))
            {
                Author author = new Author();
                author.Show();  // Shows an error message if the author contains digits
            }
            else if (Conditiontxtbox.Text.Any(Char.IsLetter))
            {
                Quantity quantity = new Quantity();
                quantity.Show();  // Shows an error message if the condition contains letters
            }
            else if (string.IsNullOrEmpty(Booknametxtbox.Text) || string.IsNullOrEmpty(Authortxtbox.Text) ||
                     string.IsNullOrEmpty(Conditiontxtbox.Text) || string.IsNullOrEmpty(genretxtbox.Text))
            {
                EmptyField emptyField = new EmptyField();
                emptyField.Show();  // Shows an error if any required field is empty
            }
            else if (string.IsNullOrEmpty(ImagePath.Text))
            {
                EmptyPicture emptyPicture = new EmptyPicture();
                emptyPicture.Show();  // Shows an error if no image is selected
            }
            else
            {
                try
                {
                    string finalFilePath = ImagePath.Text;  // Get the path of the image file to be used
                    connect.Open();  // Open the connection to the database

                    // SQL query to check if the book already exists in the database
                    string checkQuery = "SELECT quantity FROM books WHERE bookName = @bookName";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connect))
                    {
                        checkCmd.Parameters.AddWithValue("@bookName", Booknametxtbox.Text);  // Add the book name to the query
                        object result = checkCmd.ExecuteScalar(); // Execute the query to check if the book is already in the database

                        if (result != null) // If the book already exists, update its quantity
                        {
                            int existingQuantity = Convert.ToInt32(result);  // Get the current quantity of the book
                            int newQuantity = existingQuantity + Convert.ToInt32(Conditiontxtbox.Text);  // Calculate the new quantity

                            string updateQuery = "UPDATE books SET quantity = @newQuantity WHERE bookName = @bookName";
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, connect))
                            {
                                updateCmd.Parameters.AddWithValue("@newQuantity", newQuantity);  // Add the new quantity to the query
                                updateCmd.Parameters.AddWithValue("@bookName", Booknametxtbox.Text);  // Add the book name to the query
                                updateCmd.ExecuteNonQuery();  // Update the quantity in the database
                            }
                        }
                        else // If the book does not exist, insert a new record
                        {
                            // Define the path where the image will be saved
                            string fileOpen = "C:\\Users\\blood\\source\\repos\\PHCM last na to\\PHCM last na to\\Picture of the books\\" + Path.GetFileName(ImagePath.Text);

                            if (File.Exists(fileOpen)) // Check if the file already exists in the folder
                            {
                                // Ask the user if they want to delete the existing image
                                DialogResult Ask = MessageBox.Show("The File you have chosen already exists! Would you like to delete it?", "Notice", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                                if (Ask == DialogResult.Yes) // If the user wants to delete the file
                                {
                                    try
                                    {
                                        File.Delete(fileOpen);  // Delete the existing image file
                                        MessageBox.Show("The image has been deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);  // Show success message
                                        return;  // Exit the method after deletion
                                    }
                                    catch (Exception ex)  // If an error occurs during file deletion
                                    {
                                        MessageBox.Show("An error occurred while deleting the image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Show error message
                                        return;  // Exit the method
                                    }
                                }
                                else if (Ask == DialogResult.No)  // If the user does not want to delete the file
                                {
                                    DialogResult Askagain = MessageBox.Show("Would you like to replace it?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);  // Ask if they want to replace the image
                                    if (Askagain == DialogResult.Yes)  // If the user wants to replace the image
                                    {
                                        File.Delete(fileOpen);  // Delete the existing image
                                        File.Copy(ImagePath.Text, fileOpen);  // Copy the new image to the location
                                        finalFilePath = fileOpen;  // Set the final file path
                                    }
                                    else if (Askagain == DialogResult.No)  // If the user does not want to replace the image
                                    {
                                        string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");  // Get a timestamp for unique naming
                                        string openCopy = "C:\\Users\\blood\\source\\repos\\PHCM last na to\\PHCM last na to\\Picture of the books\\" + Path.GetFileNameWithoutExtension(ImagePath.Text) + "_" + timestamp + Path.GetExtension(ImagePath.Text);  // Create a new name for the copied image
                                        File.Copy(ImagePath.Text, openCopy);  // Copy the new image to the location with the new name
                                        finalFilePath = openCopy;  // Set the final file path
                                    }
                                    else if (Askagain == DialogResult.Cancel)  // If the user cancels
                                    {
                                        return;  // Exit the method
                                    }
                                }
                                else if (Ask == DialogResult.Cancel)  // If the user cancels the initial prompt
                                {
                                    return;  // Exit the method
                                }
                            }
                            else  // If the image does not exist in the folder
                            {
                                File.Copy(ImagePath.Text, fileOpen);  // Copy the image to the folder
                                finalFilePath = fileOpen;  // Set the final file path
                            }

                            // SQL query to insert the new book into the database
                            string insertQuery = "INSERT INTO books (bookName, author, datePick, quantity, bookPicture, picture, genre) VALUES (@bookName, @author, @datePick, @quantity, @bookPicture, @picture, @genre)";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, connect))
                            {
                                insertCmd.Parameters.AddWithValue("@bookName", Booknametxtbox.Text);  // Add the book name to the query
                                insertCmd.Parameters.AddWithValue("@author", Authortxtbox.Text);  // Add the author's name to the query
                                insertCmd.Parameters.AddWithValue("@datePick", publishedDate.Value.Date);  // Add the date selected to the query
                                insertCmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(Conditiontxtbox.Text));  // Add the quantity to the query
                                insertCmd.Parameters.AddWithValue("@bookPicture", finalFilePath);  // Add the path of the image to the query
                                insertCmd.Parameters.AddWithValue("@genre", genretxtbox.Text);  // Add the author's name to the query

                                // Save the image as a byte array
                                if (Picture.Image != null)
                                {
                                    // Save the image as a byte array
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        Picture.Image.Save(ms, Picture.Image.RawFormat);  // Save the image to the memory stream
                                        byte[] imageBytes = ms.ToArray();  // Convert the image to a byte array

                                        insertCmd.Parameters.AddWithValue("@picture", imageBytes);  // Add the image byte array to the query
                                    }
                                }
                                else
                                {
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        Properties.Resources._16410.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Save the image in a specific format (like Jpeg)
                                        byte[] defaultImageBytes = ms.ToArray(); // Convert the image to a byte array

                                        insertCmd.Parameters.AddWithValue("@picture", defaultImageBytes); // Use default image byte array
                                    }
                                }
                                insertCmd.ExecuteNonQuery();  // Insert the new book into the database
                            }
                        }
                    }

                    // Show a success message when the book is added
                    AddedSuccessfully addedSuccessfully = new AddedSuccessfully();
                    addedSuccessfully.ShowDialog();  // Display the success message dialog

                    // Clear the input fields after saving the book
                    Booknametxtbox.Clear();
                    Authortxtbox.Clear();
                    Conditiontxtbox.Clear();
                    ImagePath.Clear();
                    genretxtbox.Clear();
                    changeImagebtn.Text = "Add Picture";
                    publishedDate.TextColor = Color.White;
                    textBox1.Clear();

                    // Reset the labels and picture
                    Booknamelbl.Visible = true;
                    Authorlbl.Visible = true;
                    Datelbl.Visible = true;
                    Conditionlbl.Visible = true;
                    genrelbl.Visible = true;
                    Picture.Image = Properties.Resources._16410;  // Set a default image
                    Booknametxtbox.Focus();  // Focus on the book name text box again
                }
                catch (SqlException ex)  // If a database error occurs
                {
                    MessageBox.Show("Database error: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Show error message
                }
                catch (Exception ex)  // If any other unexpected error occurs
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Show error message
                }
                finally
                {
                    // Ensure the connection is always closed
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();  // Close the database connection
                    }
                }
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            // Resets all the input fields and image
            Booknametxtbox.Clear();
            Authortxtbox.Clear();
            Conditiontxtbox.Clear();
            ImagePath.Clear();
            genretxtbox.Clear();
            changeImagebtn.Text = "Add Picture";
            publishedDate.TextColor = Color.White;
            textBox1.Clear();

            // Reset the labels and picture
            Booknamelbl.Visible = true;
            Authorlbl.Visible = true;
            Datelbl.Visible = true;
            Conditionlbl.Visible = true;
            genrelbl.Visible = true;
            Picture.Image = Properties.Resources._16410;
            Booknametxtbox.Focus();  // Focus on the book name text box again
        }

        // Focus management for each input field, showing or hiding labels as needed
        private void Booknamelbl_Click(object sender, EventArgs e)
        {
            Booknametxtbox.Focus();
        }

        private void Booknametxtbox_Enter(object sender, EventArgs e)
        {
            Booknamelbl.Visible = false;  // Hide label when text box is focused
        }

        private void Booknametxtbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Booknametxtbox.Text))
            {
                Booknamelbl.Visible = true;  // Show label if text box is empty
            }
        }

        private void Authorlbl_Click(object sender, EventArgs e)
        {
            Authortxtbox.Focus();
        }

        private void Authortxtbox_Enter(object sender, EventArgs e)
        {
            Authorlbl.Visible = false;  // Hide label when text box is focused
        }

        private void Authortxtbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Authortxtbox.Text))
            {
                Authorlbl.Visible = true;  // Show label if text box is empty
            }
        }

        private void Conditionlbl_Click(object sender, EventArgs e)
        {
            Conditiontxtbox.Focus();
        }

        private void Conditiontxtbox_Enter(object sender, EventArgs e)
        {
            Conditionlbl.Visible = false;  // Hide label when text box is focused
        }

        private void Conditiontxtbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Conditiontxtbox.Text))
            {
                Conditionlbl.Visible = true;  // Show label if text box is empty
            }
        }
        // This method is triggered when the 'ViewBooks' button is clicked
        private void ViewBooks_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ViewBooksForm());  // Opens the ViewBooksForm (the page to view books)
        }

        // This method is responsible for opening a child form within a panel
        private void OpenChildForm(Form childForm)
        {
            // Checks if there's already an open child form
            if (currentChildForm != null)
            {
                currentChildForm.Close();  // Closes the previously opened form to ensure only one form is displayed
            }

            // Sets the new form as the current child form
            currentChildForm = childForm;

            // Prepares the new form to be shown inside the panel
            childForm.TopLevel = false;  // This removes the form's border and title bar
            childForm.FormBorderStyle = FormBorderStyle.None;  // Removes the border around the form
            childForm.Dock = DockStyle.Fill;  // Makes the form fill the entire panel

            // Adds the new form to the panel where it will be displayed
            panel11.Controls.Add(childForm);
            panel11.Tag = childForm;  // Stores the form in the panel's tag property

            childForm.BringToFront();  // Brings the new form to the front to make it visible
            childForm.Show();  // Displays the form
        }

        // This method is triggered when the panel11 is clicked
        private void panel11_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;  // Removes focus from any control that might be currently selected (e.g., a text box)
        }

        // This method is triggered when the panel10 is clicked
        private void panel10_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;  // Removes focus from any control in panel10
        }

        private void publishedDate_CloseUp(object sender, EventArgs e)
        {
            if (publishedDate.TextColor == Color.White)
            {
                Datelbl.Visible = true;
            }
        }
        private void publishedDate_DropDown(object sender, EventArgs e)
        {
            Datelbl.Visible = false;
        }

        private void publishedDate_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            publishedDate.Focus();
        }

        private void publishedDate_ValueChanged(object sender, EventArgs e)
        {
            publishedDate.TextColor = Color.Black;
            textBox1.Text = publishedDate.Value.ToString();
        }

        private void Datelbl_Click(object sender, EventArgs e)
        {
            publishedDate.Focus();
        }

        private void genrelbl_Click(object sender, EventArgs e)
        {
            genreselectorpanel.Visible = true;
        }

        private void genretxtbox_Click(object sender, EventArgs e)
        {
            genreselectorpanel.Visible = true;
        }

        private void closepnl_Click(object sender, EventArgs e)
        {
            genreselectorpanel.Visible = false;
        }

        private void hoverSelection(object sender, EventArgs e) // If the mouse hover is entered from the label  
        {
            if (sender is Label Hover)
            {
                Hover.BackColor = Color.FromArgb(76, 75, 105);
            }
        }

        private void genreSelection(object sender, EventArgs e) // when the label is pressed
        { 
            if (sender is Label selection)
            {
                genretxtbox.Text = selection.Text;
                genrelbl.Visible = false;
                genreselectorpanel.Visible = false;
            }
        }

        private void label44_MouseLeave(object sender, EventArgs e) // If the mouse hover is removed from the label       
        {
            if (sender is Label Hover)
            {
                Hover.BackColor = Color.FromArgb(31, 30, 68);
            }   
        }
    }
}
