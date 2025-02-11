namespace PHCM_last_na_to.Forms
{
    partial class ViewBooksForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ReturnAddBooks = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Question = new FontAwesome.Sharp.IconPictureBox();
            this.Notfound = new System.Windows.Forms.Label();
            this.srcbtn = new FontAwesome.Sharp.IconPictureBox();
            this.searchbox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.booksBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.dataBooks = new PHCM_last_na_to.DataBooks();
            this.booksTableAdapter3 = new PHCM_last_na_to.DataBooksTableAdapters.booksTableAdapter();
            this.booksTableAdapter2 = new PHCM_last_na_to.BooksDatabaseTableAdapters.booksTableAdapter();
            this.booksBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.booksDatabase = new PHCM_last_na_to.BooksDatabase();
            this.logInCapstoneDataSet2 = new PHCM_last_na_to.LogInCapstoneDataSet2();
            this.booksTableAdapter1 = new PHCM_last_na_to.LogInCapstoneDataSet4TableAdapters.booksTableAdapter();
            this.logInCapstoneDataSet1 = new PHCM_last_na_to.LogInCapstoneDataSet1();
            this.booksBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.logInCapstoneDataSet4 = new PHCM_last_na_to.LogInCapstoneDataSet4();
            this.booksTableAdapter = new PHCM_last_na_to.LogInCapstoneDataSet3TableAdapters.booksTableAdapter();
            this.booksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.logInCapstoneDataSet3 = new PHCM_last_na_to.LogInCapstoneDataSet3();
            this.logInCapstoneDataSet = new PHCM_last_na_to.LogInCapstoneDataSet();
            this.decreasequantitybtn = new System.Windows.Forms.Button();
            this.Addquantitybtn = new System.Windows.Forms.Button();
            this.pictureDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datePickDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel11.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Question)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logInCapstoneDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logInCapstoneDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logInCapstoneDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logInCapstoneDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logInCapstoneDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ReturnAddBooks
            // 
            this.ReturnAddBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.ReturnAddBooks.FlatAppearance.BorderSize = 0;
            this.ReturnAddBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReturnAddBooks.Font = new System.Drawing.Font("Nirmala UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnAddBooks.ForeColor = System.Drawing.Color.White;
            this.ReturnAddBooks.Location = new System.Drawing.Point(1113, 670);
            this.ReturnAddBooks.Name = "ReturnAddBooks";
            this.ReturnAddBooks.Size = new System.Drawing.Size(154, 66);
            this.ReturnAddBooks.TabIndex = 21;
            this.ReturnAddBooks.Text = "return";
            this.ReturnAddBooks.UseVisualStyleBackColor = false;
            this.ReturnAddBooks.Click += new System.EventHandler(this.ReturnAddBooks_Click);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Controls.Add(this.Addquantitybtn);
            this.panel11.Controls.Add(this.decreasequantitybtn);
            this.panel11.Controls.Add(this.panel1);
            this.panel11.Controls.Add(this.ReturnAddBooks);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(20, 20, 20, 80);
            this.panel11.Size = new System.Drawing.Size(1287, 744);
            this.panel11.TabIndex = 2;
            this.panel11.Click += new System.EventHandler(this.panel11_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.Question);
            this.panel1.Controls.Add(this.Notfound);
            this.panel1.Controls.Add(this.srcbtn);
            this.panel1.Controls.Add(this.searchbox);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 65, 10, 25);
            this.panel1.Size = new System.Drawing.Size(1247, 644);
            this.panel1.TabIndex = 22;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // Question
            // 
            this.Question.BackColor = System.Drawing.Color.White;
            this.Question.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Question.IconChar = FontAwesome.Sharp.IconChar.PersonCircleQuestion;
            this.Question.IconColor = System.Drawing.SystemColors.ControlText;
            this.Question.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Question.IconSize = 84;
            this.Question.Location = new System.Drawing.Point(954, 136);
            this.Question.Name = "Question";
            this.Question.Size = new System.Drawing.Size(91, 84);
            this.Question.TabIndex = 6;
            this.Question.TabStop = false;
            this.Question.Visible = false;
            // 
            // Notfound
            // 
            this.Notfound.AutoSize = true;
            this.Notfound.BackColor = System.Drawing.Color.White;
            this.Notfound.Font = new System.Drawing.Font("Nirmala UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Notfound.Location = new System.Drawing.Point(276, 152);
            this.Notfound.Name = "Notfound";
            this.Notfound.Size = new System.Drawing.Size(675, 45);
            this.Notfound.TabIndex = 5;
            this.Notfound.Text = "BOOKS NOT FOUND! TRY CREATING ONE?";
            this.Notfound.Visible = false;
            // 
            // srcbtn
            // 
            this.srcbtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.srcbtn.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.srcbtn.IconColor = System.Drawing.Color.White;
            this.srcbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.srcbtn.IconSize = 31;
            this.srcbtn.Location = new System.Drawing.Point(1200, 13);
            this.srcbtn.Name = "srcbtn";
            this.srcbtn.Size = new System.Drawing.Size(32, 31);
            this.srcbtn.TabIndex = 2;
            this.srcbtn.TabStop = false;
            this.srcbtn.Click += new System.EventHandler(this.srcbtn_Click);
            // 
            // searchbox
            // 
            this.searchbox.Font = new System.Drawing.Font("Nirmala UI", 13F);
            this.searchbox.ForeColor = System.Drawing.Color.DimGray;
            this.searchbox.Location = new System.Drawing.Point(969, 13);
            this.searchbox.Name = "searchbox";
            this.searchbox.Size = new System.Drawing.Size(231, 36);
            this.searchbox.TabIndex = 1;
            this.searchbox.Text = "Search";
            this.searchbox.TextChanged += new System.EventHandler(this.searchbox_TextChanged);
            this.searchbox.Enter += new System.EventHandler(this.searchbox_Enter);
            this.searchbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchbox_KeyPress);
            this.searchbox.Leave += new System.EventHandler(this.searchbox_Leave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 38;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pictureDataGridViewImageColumn,
            this.idDataGridViewTextBoxColumn,
            this.bookNameDataGridViewTextBoxColumn,
            this.authorDataGridViewTextBoxColumn,
            this.datePickDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.booksBindingSource3;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.LightGray;
            this.dataGridView1.Location = new System.Drawing.Point(10, 65);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Nirmala UI", 15F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.DividerHeight = 2;
            this.dataGridView1.RowTemplate.Height = 250;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1227, 554);
            this.dataGridView1.TabIndex = 0;
            // 
            // booksBindingSource3
            // 
            this.booksBindingSource3.DataMember = "books";
            this.booksBindingSource3.DataSource = this.dataBooks;
            // 
            // dataBooks
            // 
            this.dataBooks.DataSetName = "DataBooks";
            this.dataBooks.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // booksTableAdapter3
            // 
            this.booksTableAdapter3.ClearBeforeFill = true;
            // 
            // booksTableAdapter2
            // 
            this.booksTableAdapter2.ClearBeforeFill = true;
            // 
            // booksBindingSource2
            // 
            this.booksBindingSource2.DataMember = "books";
            // 
            // booksDatabase
            // 
            this.booksDatabase.DataSetName = "BooksDatabase";
            this.booksDatabase.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // logInCapstoneDataSet2
            // 
            this.logInCapstoneDataSet2.DataSetName = "LogInCapstoneDataSet2";
            this.logInCapstoneDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // booksTableAdapter1
            // 
            this.booksTableAdapter1.ClearBeforeFill = true;
            // 
            // logInCapstoneDataSet1
            // 
            this.logInCapstoneDataSet1.DataSetName = "LogInCapstoneDataSet1";
            this.logInCapstoneDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // booksBindingSource1
            // 
            this.booksBindingSource1.DataMember = "books";
            // 
            // logInCapstoneDataSet4
            // 
            this.logInCapstoneDataSet4.DataSetName = "LogInCapstoneDataSet4";
            this.logInCapstoneDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // booksTableAdapter
            // 
            this.booksTableAdapter.ClearBeforeFill = true;
            // 
            // booksBindingSource
            // 
            this.booksBindingSource.DataMember = "books";
            // 
            // logInCapstoneDataSet3
            // 
            this.logInCapstoneDataSet3.DataSetName = "LogInCapstoneDataSet3";
            this.logInCapstoneDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // logInCapstoneDataSet
            // 
            this.logInCapstoneDataSet.DataSetName = "LogInCapstoneDataSet";
            this.logInCapstoneDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // decreasequantitybtn
            // 
            this.decreasequantitybtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.decreasequantitybtn.FlatAppearance.BorderSize = 0;
            this.decreasequantitybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decreasequantitybtn.Font = new System.Drawing.Font("Nirmala UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decreasequantitybtn.ForeColor = System.Drawing.Color.White;
            this.decreasequantitybtn.Location = new System.Drawing.Point(953, 670);
            this.decreasequantitybtn.Name = "decreasequantitybtn";
            this.decreasequantitybtn.Size = new System.Drawing.Size(154, 66);
            this.decreasequantitybtn.TabIndex = 23;
            this.decreasequantitybtn.Text = "Decrease";
            this.decreasequantitybtn.UseVisualStyleBackColor = false;
            this.decreasequantitybtn.Click += new System.EventHandler(this.decreasequantitybtn_Click);
            // 
            // Addquantitybtn
            // 
            this.Addquantitybtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.Addquantitybtn.FlatAppearance.BorderSize = 0;
            this.Addquantitybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Addquantitybtn.Font = new System.Drawing.Font("Nirmala UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addquantitybtn.ForeColor = System.Drawing.Color.White;
            this.Addquantitybtn.Location = new System.Drawing.Point(793, 670);
            this.Addquantitybtn.Name = "Addquantitybtn";
            this.Addquantitybtn.Size = new System.Drawing.Size(154, 66);
            this.Addquantitybtn.TabIndex = 24;
            this.Addquantitybtn.Text = "Add";
            this.Addquantitybtn.UseVisualStyleBackColor = false;
            this.Addquantitybtn.Click += new System.EventHandler(this.Addquantitybtn_Click);
            // 
            // pictureDataGridViewImageColumn
            // 
            this.pictureDataGridViewImageColumn.DataPropertyName = "picture";
            this.pictureDataGridViewImageColumn.FillWeight = 150F;
            this.pictureDataGridViewImageColumn.HeaderText = "Picture";
            this.pictureDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.pictureDataGridViewImageColumn.MinimumWidth = 6;
            this.pictureDataGridViewImageColumn.Name = "pictureDataGridViewImageColumn";
            this.pictureDataGridViewImageColumn.ReadOnly = true;
            this.pictureDataGridViewImageColumn.Width = 300;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // bookNameDataGridViewTextBoxColumn
            // 
            this.bookNameDataGridViewTextBoxColumn.DataPropertyName = "bookName";
            this.bookNameDataGridViewTextBoxColumn.FillWeight = 120F;
            this.bookNameDataGridViewTextBoxColumn.HeaderText = "Book Name";
            this.bookNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.bookNameDataGridViewTextBoxColumn.Name = "bookNameDataGridViewTextBoxColumn";
            this.bookNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.bookNameDataGridViewTextBoxColumn.Width = 250;
            // 
            // authorDataGridViewTextBoxColumn
            // 
            this.authorDataGridViewTextBoxColumn.DataPropertyName = "author";
            this.authorDataGridViewTextBoxColumn.FillWeight = 120F;
            this.authorDataGridViewTextBoxColumn.HeaderText = "author";
            this.authorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.authorDataGridViewTextBoxColumn.Name = "authorDataGridViewTextBoxColumn";
            this.authorDataGridViewTextBoxColumn.ReadOnly = true;
            this.authorDataGridViewTextBoxColumn.Width = 250;
            // 
            // datePickDataGridViewTextBoxColumn
            // 
            this.datePickDataGridViewTextBoxColumn.DataPropertyName = "datePick";
            this.datePickDataGridViewTextBoxColumn.HeaderText = "Date";
            this.datePickDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.datePickDataGridViewTextBoxColumn.Name = "datePickDataGridViewTextBoxColumn";
            this.datePickDataGridViewTextBoxColumn.ReadOnly = true;
            this.datePickDataGridViewTextBoxColumn.Width = 250;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 250;
            // 
            // ViewBooksForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PHCM_last_na_to.Properties.Resources.Loading;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1287, 744);
            this.Controls.Add(this.panel11);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewBooksForm";
            this.Text = "View Books";
            this.Load += new System.EventHandler(this.ViewBooksForm_Load);
            this.panel11.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Question)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logInCapstoneDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logInCapstoneDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logInCapstoneDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logInCapstoneDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logInCapstoneDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button ReturnAddBooks;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private FontAwesome.Sharp.IconPictureBox srcbtn;
        private System.Windows.Forms.TextBox searchbox;
        private DataBooks dataBooks;
        private System.Windows.Forms.BindingSource booksBindingSource3;
        private DataBooksTableAdapters.booksTableAdapter booksTableAdapter3;
        private BooksDatabaseTableAdapters.booksTableAdapter booksTableAdapter2;
        private System.Windows.Forms.BindingSource booksBindingSource2;
        private BooksDatabase booksDatabase;
        private LogInCapstoneDataSet2 logInCapstoneDataSet2;
        private LogInCapstoneDataSet4TableAdapters.booksTableAdapter booksTableAdapter1;
        private LogInCapstoneDataSet1 logInCapstoneDataSet1;
        private System.Windows.Forms.BindingSource booksBindingSource1;
        private LogInCapstoneDataSet4 logInCapstoneDataSet4;
        private LogInCapstoneDataSet3TableAdapters.booksTableAdapter booksTableAdapter;
        private System.Windows.Forms.BindingSource booksBindingSource;
        private LogInCapstoneDataSet3 logInCapstoneDataSet3;
        private LogInCapstoneDataSet logInCapstoneDataSet;
        private FontAwesome.Sharp.IconPictureBox Question;
        private System.Windows.Forms.Label Notfound;
        private System.Windows.Forms.Button decreasequantitybtn;
        private System.Windows.Forms.Button Addquantitybtn;
        private System.Windows.Forms.DataGridViewImageColumn pictureDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datePickDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
    }
}