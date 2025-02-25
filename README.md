# **PHCM Library Management System**  

The **PHCM Library Management System** is a digital solution designed to streamline book lending, student record management, and administrative tasks within the **Perpetual Help College of Manila** library. This system ensures efficient tracking of books, borrowing records, and user accounts, enhancing the overall library experience for both students and administrators.  

## **Features and Menu Tabs**  

### **1. Home**  
- Displays the **Vision and Mission** of Perpetual Help College of Manila.  
- Serves as the main landing page of the system.  

### **2. Administrator** *(Admin-Only Access)*  
- Allows admins to view and manage all signed-in accounts.  
- Ensures system security by restricting unauthorized access.  

### **3. Books**  
- Displays a list of all available books in the library.  
- Allows admins to **add new books** to the database.  
- Provides functions to **increase or decrease book quantity** as needed.  

### **4. Student Information**  
- Stores student details when they borrow books.  
- Helps librarians contact students regarding their borrowed books.  

### **5. Issued Books**  
- Allows students to **borrow books** from the library.  
- Tracks which books are currently borrowed and by whom.  

### **6. Return Books**  
- Enables students to **return borrowed books** efficiently.  
- Updates the system once a book is returned.  

### **7. Quick Overview** *(Data Summary Section)*  
- Displays a **consolidated view** of important records, including:  
  - **Issued Books** (Currently borrowed books)  
  - **Returned Books** (Books that have been returned)  
  - **Student Information** (Borrower details)  

## **System Benefits**  
✅ **Efficient Book Management** – Helps librarians keep track of book availability and inventory.  
✅ **Organized Student Records** – Ensures accurate borrower tracking and easy communication.  
✅ **User-Friendly Interface** – Simple navigation for both admins and students.  
✅ **Improved Library Workflow** – Reduces manual paperwork and speeds up book transactions.  

This system is designed to enhance the **library experience** at PHCM, making borrowing and returning books more efficient while ensuring proper management of student and book records. 

### **ABOUT ADMINISTRATION MENU** ###
To Access the Administration Menu. 
Open Database, Find:
"
Where admin
SET isAdmin = 1
WHERE surname = 'catana';
"

Edit the surname and enter your existed account. 


### FOR creating shortcut of this Project ###
1. Import this Repository to you Visual studio
2. Open Project in Visual Studio 2022
3. Find the Drop-Down Box that says Debug, Near the Start Button.Change it from Debug to Release then Build (Ctrl + Shift + B).
4. Close the Visual Studio 2022 then open File Explorer and find your project. Normally it's located in source\repos\(project name)
5. open the folder > PHCM last na to > bin > Release
6. Righ Click the Application type and More options, Click "Send To" then Desktop (Shortcut)
7. Open the Project
