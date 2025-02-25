using System;  // Provides fundamental classes like system types (e.g., String, Int, DateTime) and basic functionalities.
using System.Data;  // Provides classes for data-related operations, such as working with databases (e.g., DataTable, DataSet).
using System.Linq;  // Provides LINQ functionality for querying data in collections (e.g., lists, arrays) using query expressions.
using System.Windows.Forms;  // Provides classes for creating Windows Forms applications (e.g., Form, Button, TextBox).
using System.IO;  // Allows for file input/output operations, like reading/writing files (e.g., File, FileStream, StreamReader).
using System.Data.SqlClient;  // Includes classes needed to interact with SQL Server databases (e.g., SqlConnection, SqlCommand).
using PHCM_last_na_to.Toast_Messsage_Form;  // Custom class for displaying toast messages related to a specific form in your project (e.g., notifications).
using PHCM_last_na_to.Toast_Message_for_add_student_information; // This allows the program to use a feature (likely a pop-up message or notification system)  
using AForge.Video.DirectShow; // This is used to access and control video devices (such as webcams).  
using AForge.Video; // This provides tools for working with video streams (such as capturing live video).  
using System.Drawing; // This allows the program to handle images, colors, and graphics.  
using System.Threading.Tasks; // This allows the program to run tasks in the background without slowing down the main program.  

namespace PHCM_last_na_to.Forms
{
    public partial class AddStudentInformationForm : Form
    {
        //Connection to the database
        SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blood\\OneDrive\\Documents\\LogInCapstone.mdf;Integrated Security=True;Connect Timeout=30");
        // This variable holds the currently opened child form
        private Form currentChildForm;

        VideoCaptureDevice Capture; // This creates a variable named "Capture" that will be used to control the webcam.          
        FilterInfoCollection info; // This creates a variable named "info" that will store a list of all available cameras on the computer.          

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

        // Event handler to change the image when the "Change Image" button is clicked
        private void changeImagebtn_Click(object sender, EventArgs e)
        {
            // Create a variable for the file stream (used to read the file)
            Stream myStream = null;
            // Create a dialog window for the user to select a file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Set the file dialog to allow only .jpg or .jpeg image files
            openFileDialog.Filter = "Image File(*.jpg; *jpeg;) | *.jpg; *.jpeg;";

            // Show the file dialog; if the user clicks OK (chooses a file)
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    // Open the selected file and assign it to myStream if possible
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        // Get the full path of the selected file
                        string Filename = openFileDialog.FileName;
                        // Display the file path in a textbox (ImagePath)
                        ImagePath.Text = Filename;
                        // Check if the file size is larger than 500 KB (512000 bytes)
                        if (myStream.Length > 512000)
                        {
                            // Inform the user that the file is too big
                            MessageBox.Show("File Size limit exceeded");
                        }
                        else
                        {
                            // Load the image into a temporary Bitmap to prevent locking the file
                            using (var temp = new Bitmap(Filename))
                            {
                                // Set the Picture control's image to the new image
                                Picture.Image = new Bitmap(temp);
                            }
                            // Change the button text to "Change Picture" after a successful load
                            changeImagebtn.Text = "Change Picture";
                        }
                    }
                }
                catch (Exception ex) // If an error occurs during this process
                {
                    // Show the error message to the user
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Save Button Click Event (Insert data into the database)
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            // Check if the student's name textbox contains any digits (which is not allowed)
            if (Nametxtbox.Text.Any(Char.IsDigit))
            {
                // Show a message window indicating the student name is invalid
                new StudentName().Show();
                return; // Stop further execution
            }
            // Check if the contact textbox contains any letters (which is not allowed)
            else if (Contacttxtbox.Text.Any(Char.IsLetter))
            {
                // Show a message window indicating the student contact is invalid
                new StudentContact1().Show();
                return;
            }
            // Check if any of the three parts of the student number contain letters (which is not allowed)
            else if (FirstNumbertxtbox.Text.Any(Char.IsLetter) || SecondNumbertxtbox.Text.Any(Char.IsLetter) || ThirdNumbertxtbox.Text.Any(Char.IsLetter))
            {
                // Show a message window indicating the student number is invalid
                new StudentNumber().Show();
                return;
            }
            // Check if the image path textbox is empty (i.e., no picture was chosen)
            else if (string.IsNullOrEmpty(ImagePath.Text))
            {
                // Show a message window indicating an image must be added
                new EmptyPicture().Show();
                return;
            }
            // Check if any required textboxes (name, student numbers, department, contact) are empty
            else if (string.IsNullOrEmpty(Nametxtbox.Text) || string.IsNullOrEmpty(FirstNumbertxtbox.Text) ||
                     string.IsNullOrEmpty(SecondNumbertxtbox.Text) || string.IsNullOrEmpty(ThirdNumbertxtbox.Text) ||
                     string.IsNullOrEmpty(Departmenttxtbox.Text) || string.IsNullOrEmpty(Contacttxtbox.Text))
            {
                // Show a message window indicating that required fields are missing
                new EmptyField().Show();
                return;
            }

            try
            {
                // Combine parts of the student number into one string using labels and textboxes
                string StudentNumber = startingIndexLbl.Text + FirstNumbertxtbox.Text + secondIndexLbl.Text + SecondNumbertxtbox.Text + thirdIndexLbl.Text + ThirdNumbertxtbox.Text;

                // Create a SQL query string to check if the student number already exists in the database
                string CheckExistedID = "Select * FROM student WHERE studentNumber = '" + StudentNumber + "'";

                // Prepare a SQL command using the query above and the database connection "connect"
                using (SqlCommand checkID = new SqlCommand(CheckExistedID, connect))
                {
                    // Create an adapter to retrieve data from the database using the SQL command
                    SqlDataAdapter adapter = new SqlDataAdapter(checkID);
                    // Create a table to store the retrieved data
                    DataTable newtable = new DataTable();
                    // Fill the table with the results of the SQL query
                    adapter.Fill(newtable);
                    // If there is at least one row (meaning the student number exists)
                    if (newtable.Rows.Count >= 1)
                    {
                        // Show a message window indicating that the student number already exists
                        new StudentNumberAlreadyExist().Show();
                    }
                    else
                    {
                        // Create a SQL query string to insert new student information into the database
                        string insertData = "INSERT INTO student (studentName, studentNumber, department, studentContact, studentPicture, studentImage) " +
                                    "VALUES(@studentName, @studentNumber, @department, @studentContact, @studentPicture, @studentImage)";
                        // Prepare a SQL command for inserting data using the insertData query and the connection
                        using (SqlCommand cmd = new SqlCommand(insertData, connect))
                        {
                            // Set the parameter for student name with the value from Nametxtbox
                            cmd.Parameters.AddWithValue("@studentName", Nametxtbox.Text);
                            // Set the parameter for student number with the combined student number
                            cmd.Parameters.AddWithValue("@studentNumber", StudentNumber);
                            // Set the parameter for department with the value from Departmenttxtbox
                            cmd.Parameters.AddWithValue("@department", Departmenttxtbox.Text);
                            // Set the parameter for student contact with the value from Contacttxtbox
                            cmd.Parameters.AddWithValue("@studentContact", Contacttxtbox.Text);
                            // Set the parameter for student picture (the file path) from ImagePath textbox
                            cmd.Parameters.AddWithValue("@studentPicture", ImagePath.Text);

                            // Use a memory stream to convert the image into a byte array for storing in the database
                            using (MemoryStream ms = new MemoryStream())
                            {
                                // Check if there is an image in the Picture control
                                if (Picture.Image != null)
                                {
                                    // Create a new bitmap (a copy of the image) so that the file is not locked
                                    using (Bitmap imageToSave = new Bitmap(Picture.Image))
                                    {
                                        // Save the image into the memory stream in JPEG format
                                        imageToSave.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    }
                                }
                                // Convert the memory stream into a byte array
                                byte[] imageBytes = ms.ToArray();
                                // Set the parameter for student image with the byte array
                                cmd.Parameters.AddWithValue("@studentImage", imageBytes);
                            }

                            // Open the database connection
                            connect.Open();
                            // Execute the insert command (save the data into the database)
                            cmd.ExecuteNonQuery();

                            // Show a dialog window indicating that registration was successful
                            new Successfully_Registered().ShowDialog();

                            // Clear all the input fields after saving
                            Nametxtbox.Clear();
                            FirstNumbertxtbox.Clear();
                            SecondNumbertxtbox.Clear();
                            ThirdNumbertxtbox.Clear();
                            Departmenttxtbox.Clear();
                            Contacttxtbox.Clear();
                            ImagePath.Clear();
                            // Reset the button text back to "Add Picture"
                            changeImagebtn.Text = "Add Picture";

                            // Make the labels visible again for name, contact, and department
                            Namelbl.Visible = true;
                            Contactlbl.Visible = true;
                            Departmentlbl.Visible = true;

                            // Reset the Picture control to a default image (stored in resources)
                            Picture.Image = Properties.Resources._16410;
                            // Set the focus back to the name textbox for convenience
                            Nametxtbox.Focus();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // If there's a database-related error, show a message with details about the SQL error
                MessageBox.Show("Database error: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // If any other error occurs, show a general error message with details
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // After everything, if the database connection is still open, close it
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }


        // Click event for the Delete button, which clears all input fields
        private void Deletebtn_Click(object sender, EventArgs e)
        {
            // Clear all textboxes and reset PictureBox image
            Nametxtbox.Clear();
            FirstNumbertxtbox.Clear();
            SecondNumbertxtbox.Clear();
            ThirdNumbertxtbox.Clear();
            Departmenttxtbox.Clear();
            Contacttxtbox.Clear();
            ImagePath.Clear();
            changeImagebtn.Text = "Add Picture"; // Default the text
            Picture.Image = Properties.Resources._16410; // Reset image to default
            Nametxtbox.Focus(); // Focus back on the Name textbox

            // Make sure labels are visible again after saving
            Namelbl.Visible = true;            
            Contactlbl.Visible = true;
            Departmentlbl.Visible = true;
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

        private void takePicture_Click(object sender, EventArgs e)
        {
            CameraPanel.Visible = true; // Show the camera panel on the screen.

            if (Capture != null && Capture.IsRunning) return; // If the camera is already running, do nothing.

            info = new FilterInfoCollection(FilterCategory.VideoInputDevice); // Get a list of all available cameras.
            int usbCameraIndex = -1; // Store the index of a USB camera if found.
            cameraSelection.Items.Clear(); // Clear any previous camera selections in the dropdown menu.

            for (int i = 0; i < info.Count; i++) // Loop through the list of available cameras.
            {
                cameraSelection.Items.Add(info[i].Name); // Add each camera name to the dropdown list.

                if (info[i].Name.ToLower().Contains("usb")) // Check if the camera name contains "USB".
                {
                    usbCameraIndex = i; // If found, store its index.
                }
            }

            // If a USB camera is found, select it. Otherwise, select the first available camera.
            cameraSelection.SelectedIndex = usbCameraIndex != -1 ? usbCameraIndex : 0;

            // Connect to the selected camera.
            Capture = new VideoCaptureDevice(info[cameraSelection.SelectedIndex].MonikerString);
            Capture.NewFrame += Camera_on; // Set up an event to capture frames from the camera.
            Capture.Start(); // Start the camera.
        }


        private void exitCmbtn_Click(object sender, EventArgs e)
        {
            CameraPanel.Visible = false; // Hide the camera panel.
            PictureTake.Visible = false; // Hide the captured image.
            takepicbtn.Text = "TAKE PICTURE"; // Reset the button text.
            PictureTake.Image = null; // Clear the captured image.
            fileName.Clear(); // Clear the filename field.
            StopCamera(); // Stop the camera.
        }

        private void StopCamera()
        {
            if (Capture != null) // Check if the camera is in use.
            {
                if (Capture.IsRunning) // If the camera is running, stop it.
                {
                    Capture.SignalToStop(); // Tell the camera to stop.
                    Capture.WaitForStop(); // Wait for the camera to fully stop.
                }

                Capture.NewFrame -= Camera_on; // Remove the event that captures frames.
                Capture = null; // Clear the camera object.
            }

            if (realTimeCamera.Image != null) // If there's an image being displayed...
            {
                realTimeCamera.Image.Dispose(); // Remove it to free memory.
                realTimeCamera.Image = null; // Clear the image reference.
            }
        }

        private bool IsValidImage(Image image)
        {
            try
            {
                // Try accessing frame dimensions to check if the image is valid.
                var dimensions = image.FrameDimensionsList;
                return dimensions != null && dimensions.Length > 0; // If valid, return true.
            }
            catch
            {
                return false; // If there's an error, the image is invalid.
            }
        }

        private void Camera_on(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone(); // Copy the latest frame from the camera.
            frame.RotateFlip(RotateFlipType.RotateNoneFlipX); // Flip the image horizontally (mirror effect).

            if (IsValidImage(frame)) // Check if the frame is valid before using it.
            {
                if (realTimeCamera.Image != null)
                {
                    realTimeCamera.Image.Dispose(); // Remove the old frame to avoid memory issues.
                }
                realTimeCamera.Image = frame; // Display the new frame in the camera preview.
            }
            else
            {
                MessageBox.Show("Captured frame is invalid."); // Show a message if the frame is invalid.
            }
        }


        private void takepicbtn_Click(object sender, EventArgs e)
        {
            if (takepicbtn.Text == "TAKE PICTURE") // If the button is clicked to take a picture...
            {
                takepicbtn.Enabled = false; // Disable the button temporarily to avoid multiple clicks.
                CaptureImage(); // Call the function to capture the image.
                PictureTake.Visible = true; // Show the captured image.
                takepicbtn.Text = "RESET"; // Change the button text to "RESET".
            }
            else if (takepicbtn.Text == "RESET") // If the button is clicked to reset...
            {
                PictureTake.Visible = false; // Hide the captured image.
                takepicbtn.Text = "TAKE PICTURE"; // Reset the button text.
            }
        }

        private async void CaptureImage()
        {
            pictureEffect.Visible = true; // Show a visual effect to indicate a picture is being taken.
            Image currentFrame = null; // Create a variable to store the captured image.

            lock (realTimeCamera) // Lock the camera to avoid interference while capturing.
            {
                if (realTimeCamera.Image != null && IsValidImage(realTimeCamera.Image)) // Check if the image is valid.
                {
                    try
                    {
                        currentFrame = (Image)realTimeCamera.Image.Clone(); // Copy the current frame.
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error capturing image: " + ex.Message); // Show an error message if capture fails.
                        takepicbtn.Enabled = true; // Re-enable the button.
                        pictureEffect.Visible = false; // Hide the picture effect.
                        return; // Stop execution.
                    }
                }
                else
                {
                    MessageBox.Show("Captured image is invalid."); // Show a message if the image is invalid.
                    takepicbtn.Enabled = true; // Re-enable the button.
                    pictureEffect.Visible = false; // Hide the picture effect.
                    return; // Stop execution.
                }
            }

            PictureTake.Image = currentFrame; // Display the captured image.
            await Task.Delay(1000); // Wait for 1 second before allowing another picture to be taken.
            takepicbtn.Enabled = true; // Re-enable the button.
            pictureEffect.Visible = false; // Hide the picture effect.
        }

        private void saveimgbtn_Click(object sender, EventArgs e)
        {
            if (PictureTake.Image != null) // Check if there is a captured image.
            {
                if (string.IsNullOrEmpty(fileName.Text)) // Check if the filename field is empty.
                {
                    new EmptyField().Show(); // Show a message that the field is empty.
                }
                else
                {
                    // Clean the filename to remove invalid characters.
                    string sanitizedFileName = SanitizeFileName(fileName.Text);
                    // Directory Path to the Student Picture Folder
                    string directoryPath = @"C:\Users\blood\source\repos\PHCM last na to\PHCM last na to\Student Picture\";

                    // Create the full file path with a timestamp to avoid duplicate names.
                    string filePath = Path.Combine(directoryPath, sanitizedFileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg");

                    try
                    {
                        if (!Directory.Exists(directoryPath)) // Check if the folder exists.
                        {
                            Directory.CreateDirectory(directoryPath); // If not, create it.
                        }

                        if (IsValidImage(PictureTake.Image)) // Validate the image before saving.
                        {
                            using (Bitmap imageToSave = new Bitmap(PictureTake.Image)) // Convert to a bitmap format.
                            {
                                imageToSave.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg); // Save the image as a JPG file.
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error: Image is invalid and cannot be saved."); // Show an error message.
                            return; // Stop execution.
                        }

                        // Read the saved image from the file to reload it.
                        byte[] imageData = File.ReadAllBytes(filePath);
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            Picture.Image = new Bitmap(ms); // Display the saved image.
                        }

                        ImagePath.Text = filePath; // Store the image path in a text field.

                        // Reset the interface after saving.
                        PictureTake.Image = null;
                        CameraPanel.Visible = false;
                        PictureTake.Visible = false;
                        takepicbtn.Text = "TAKE PICTURE";
                        fileName.Clear();
                        StopCamera(); // Stop the camera.
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving or loading image: " + ex.Message); // Show an error if saving fails.
                    }
                }
            }
            else
            {
                new EmptyPicture().Show(); // Show a message if no image was taken.
            }
        }


        // Method to sanitize the file name
        private string SanitizeFileName(string fileName)
        {
            foreach (char c in System.IO.Path.GetInvalidFileNameChars()) // Loop through all invalid characters.
            {
                fileName = fileName.Replace(c.ToString(), ""); // Remove them from the filename.
            }
            return fileName; // Return the cleaned filename.
        }


        private void fileName_Enter(object sender, EventArgs e)
        {
            label3.Visible = false; // Hide the placeholder text when the user clicks the textbox.
        }

        private void label3_Click(object sender, EventArgs e)
        {
            fileName.Focus(); // Set focus to the textbox when the label is clicked.
        }

        private void fileName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fileName.Text)) // If the field is empty when leaving
            {
                label3.Visible = true; // Show the placeholder text again.
            }
        }

        private void FirstNumbertxtbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FirstNumbertxtbox.Text)) // If the field is empty...
            {
                FirstNumbertxtbox.BackColor = Color.LightGray; // Change background color to indicate it's empty.
            }
            else if (FirstNumbertxtbox.Text.Any(Char.IsLetter)) // If the user enters letters...
            {
                new StudentNumber().Show(); // Show a warning message.
                FirstNumbertxtbox.Text = new string(FirstNumbertxtbox.Text.Where(char.IsDigit).ToArray()); // Remove letters, keeping only numbers
            }
            else
            {
                FirstNumbertxtbox.BackColor = Color.White; // Restore normal background color.

                if (FirstNumbertxtbox.Text.Length == 2) // If the user enters two digits...
                {
                    SecondNumbertxtbox.Focus(); // Move to the next input box automatically.
                }
                else if (FirstNumbertxtbox.Text.Length > 2) // If more than two digits are entered...
                {
                    FirstNumbertxtbox.Text = FirstNumbertxtbox.Text.Remove(2); // Limit input to two digits.
                }
            }
        }

        private void SecondNumbertxtbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SecondNumbertxtbox.Text)) // If empty...
            {
                SecondNumbertxtbox.BackColor = Color.LightGray; // Change background to gray.
            }
            else if (SecondNumbertxtbox.Text.Any(Char.IsLetter)) // If letters are entered...
            {
                new StudentNumber().Show(); // Show a warning message.
                SecondNumbertxtbox.Text = new string(SecondNumbertxtbox.Text.Where(char.IsDigit).ToArray()); // Remove letters, keeping only numbers
            }
            else
            {
                SecondNumbertxtbox.BackColor = Color.White; // Restore normal background color.

                if (SecondNumbertxtbox.Text.Length == 4) // If four digits are entered...
                {
                    ThirdNumbertxtbox.Focus(); // Move to the next input box automatically.
                }
                else if (SecondNumbertxtbox.Text.Length > 4) // If more than four digits are entered...
                {
                    SecondNumbertxtbox.Text = SecondNumbertxtbox.Text.Remove(4); // Limit input to four digits.
                }
            }
        }

        private void ThirdNumbertxtbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ThirdNumbertxtbox.Text)) // If empty...
            {
                ThirdNumbertxtbox.BackColor = Color.LightGray; // Change background to gray.
            }
            else if (ThirdNumbertxtbox.Text.Any(Char.IsLetter)) // If letters are entered...
            {
                new StudentNumber().Show(); // Show a warning message.
                ThirdNumbertxtbox.Text = new string(ThirdNumbertxtbox.Text.Where(char.IsDigit).ToArray()); // Remove letters, keeping only numbers
            }
            else
            {
                ThirdNumbertxtbox.BackColor = Color.White; // Restore normal background color.

                if (ThirdNumbertxtbox.Text.Length == 3) // If three digits are entered...
                {
                    this.ActiveControl = null; // Remove focus from the input box (entry complete).
                }
                else if (ThirdNumbertxtbox.Text.Length > 3) // If more than three digits are entered...
                {
                    ThirdNumbertxtbox.Text = ThirdNumbertxtbox.Text.Remove(3); // Limit input to three digits.
                }
            }
        }
    }
}