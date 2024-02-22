namespace StudentAttendenceFrmV
{
    partial class MainForm
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.BtnRegister = new MetroFramework.Controls.MetroButton();
            this.BtnGetValues = new MetroFramework.Controls.MetroButton();
            this.BtnAddStudents = new MetroFramework.Controls.MetroButton();
            this.BtnAddClass = new MetroFramework.Controls.MetroButton();
            this.BtnClear = new MetroFramework.Controls.MetroButton();
            this.BtnSave = new MetroFramework.Controls.MetroButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.studentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateAttendanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attendanceRecordsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new StudentAttendenceFrmV.DataSet1();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.CbxClass = new System.Windows.Forms.ComboBox();
            this.classesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.classesTableAdapter = new StudentAttendenceFrmV.DataSet1TableAdapters.ClassesTableAdapter();
            this.attendanceRecordsTableAdapter = new StudentAttendenceFrmV.DataSet1TableAdapters.AttendanceRecordsTableAdapter();
            this.BtnLogout = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.BtnSignIn = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceRecordsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classesBindingSource)).BeginInit();
            this.metroTabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1210, 813);
            this.metroTabControl1.TabIndex = 0;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.metroButton2);
            this.metroTabPage1.Controls.Add(this.BtnRegister);
            this.metroTabPage1.Controls.Add(this.BtnGetValues);
            this.metroTabPage1.Controls.Add(this.BtnAddStudents);
            this.metroTabPage1.Controls.Add(this.BtnAddClass);
            this.metroTabPage1.Controls.Add(this.BtnClear);
            this.metroTabPage1.Controls.Add(this.BtnSave);
            this.metroTabPage1.Controls.Add(this.dataGridView1);
            this.metroTabPage1.Controls.Add(this.metroLabel2);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.Controls.Add(this.DatePicker);
            this.metroTabPage1.Controls.Add(this.CbxClass);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 39);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1202, 770);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Attendance";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
           
            // 
            // BtnRegister
            // 
            this.BtnRegister.Location = new System.Drawing.Point(652, 33);
            this.BtnRegister.Name = "BtnRegister";
            this.BtnRegister.Size = new System.Drawing.Size(117, 54);
            this.BtnRegister.TabIndex = 12;
            this.BtnRegister.Text = "Register";
            this.BtnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // BtnGetValues
            // 
            this.BtnGetValues.Location = new System.Drawing.Point(302, 74);
            this.BtnGetValues.Name = "BtnGetValues";
            this.BtnGetValues.Size = new System.Drawing.Size(96, 23);
            this.BtnGetValues.TabIndex = 11;
            this.BtnGetValues.Text = "Get Values";
            this.BtnGetValues.Click += new System.EventHandler(this.BtnGetValues_Click);
            // 
            // BtnAddStudents
            // 
            this.BtnAddStudents.Location = new System.Drawing.Point(520, 64);
            this.BtnAddStudents.Name = "BtnAddStudents";
            this.BtnAddStudents.Size = new System.Drawing.Size(112, 23);
            this.BtnAddStudents.TabIndex = 10;
            this.BtnAddStudents.Text = "Add Students";
            this.BtnAddStudents.Click += new System.EventHandler(this.BtnAddStudents_Click);
            // 
            // BtnAddClass
            // 
            this.BtnAddClass.Location = new System.Drawing.Point(520, 33);
            this.BtnAddClass.Name = "BtnAddClass";
            this.BtnAddClass.Size = new System.Drawing.Size(112, 23);
            this.BtnAddClass.TabIndex = 9;
            this.BtnAddClass.Text = "Add Class";
            this.BtnAddClass.Click += new System.EventHandler(this.BtnAddClass_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(100, 74);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(75, 23);
            this.BtnClear.TabIndex = 8;
            this.BtnClear.Text = "Clear";
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(5, 74);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 25);
            this.BtnSave.TabIndex = 7;
            this.BtnSave.Text = "Save";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentIDDataGridViewTextBoxColumn,
            this.classIDDataGridViewTextBoxColumn,
            this.dateAttendanceDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.studentNameDataGridViewTextBoxColumn,
            this.classNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.attendanceRecordsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(-1, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(808, 452);
            this.dataGridView1.TabIndex = 6;
            // 
            // studentIDDataGridViewTextBoxColumn
            // 
            this.studentIDDataGridViewTextBoxColumn.DataPropertyName = "StudentID";
            this.studentIDDataGridViewTextBoxColumn.HeaderText = "StudentID";
            this.studentIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.studentIDDataGridViewTextBoxColumn.Name = "studentIDDataGridViewTextBoxColumn";
            this.studentIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // classIDDataGridViewTextBoxColumn
            // 
            this.classIDDataGridViewTextBoxColumn.DataPropertyName = "ClassID";
            this.classIDDataGridViewTextBoxColumn.HeaderText = "ClassID";
            this.classIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.classIDDataGridViewTextBoxColumn.Name = "classIDDataGridViewTextBoxColumn";
            this.classIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateAttendanceDataGridViewTextBoxColumn
            // 
            this.dateAttendanceDataGridViewTextBoxColumn.DataPropertyName = "DateAttendance";
            this.dateAttendanceDataGridViewTextBoxColumn.HeaderText = "DateAttendance";
            this.dateAttendanceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateAttendanceDataGridViewTextBoxColumn.Name = "dateAttendanceDataGridViewTextBoxColumn";
            this.dateAttendanceDataGridViewTextBoxColumn.Width = 125;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.Width = 125;
            // 
            // studentNameDataGridViewTextBoxColumn
            // 
            this.studentNameDataGridViewTextBoxColumn.DataPropertyName = "StudentName";
            this.studentNameDataGridViewTextBoxColumn.HeaderText = "StudentName";
            this.studentNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.studentNameDataGridViewTextBoxColumn.Name = "studentNameDataGridViewTextBoxColumn";
            this.studentNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // classNameDataGridViewTextBoxColumn
            // 
            this.classNameDataGridViewTextBoxColumn.DataPropertyName = "ClassName";
            this.classNameDataGridViewTextBoxColumn.HeaderText = "ClassName";
            this.classNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.classNameDataGridViewTextBoxColumn.Name = "classNameDataGridViewTextBoxColumn";
            this.classNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // attendanceRecordsBindingSource
            // 
            this.attendanceRecordsBindingSource.DataMember = "AttendanceRecords";
            this.attendanceRecordsBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(167, 11);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(79, 20);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Select Date";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(-1, 11);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(81, 20);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Select Class";
            // 
            // DatePicker
            // 
            this.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatePicker.Location = new System.Drawing.Point(167, 34);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(231, 22);
            this.DatePicker.TabIndex = 3;
            // 
            // CbxClass
            // 
            this.CbxClass.DataSource = this.classesBindingSource;
            this.CbxClass.DisplayMember = "ClassName";
            this.CbxClass.FormattingEnabled = true;
            this.CbxClass.Location = new System.Drawing.Point(3, 34);
            this.CbxClass.Name = "CbxClass";
            this.CbxClass.Size = new System.Drawing.Size(121, 24);
            this.CbxClass.TabIndex = 2;
            this.CbxClass.ValueMember = "ClassID";
            // 
            // classesBindingSource
            // 
            this.classesBindingSource.DataMember = "Classes";
            this.classesBindingSource.DataSource = this.dataSet1;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroButton1);
            this.metroTabPage2.Controls.Add(this.dateTimePicker1);
            this.metroTabPage2.Controls.Add(this.metroLabel4);
            this.metroTabPage2.Controls.Add(this.comboBox1);
            this.metroTabPage2.Controls.Add(this.metroLabel3);
            this.metroTabPage2.Controls.Add(this.listView1);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 39);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(806, 591);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Report";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(462, 38);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(96, 23);
            this.metroButton1.TabIndex = 12;
            this.metroButton1.Text = "Get Values";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(170, 38);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(231, 22);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(170, 13);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(79, 20);
            this.metroLabel4.TabIndex = 7;
            this.metroLabel4.Text = "Select Date";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.classesBindingSource;
            this.comboBox1.DisplayMember = "ClassName";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.ValueMember = "ClassID";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(3, 13);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(81, 20);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Select Class";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 71);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(800, 495);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Student";
            this.columnHeader1.Width = 164;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Present";
            this.columnHeader2.Width = 104;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Absent";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Late";
            this.columnHeader4.Width = 97;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Excused";
            this.columnHeader5.Width = 141;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.StatusLblUser});
            this.statusStrip1.Location = new System.Drawing.Point(20, 847);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1210, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(45, 20);
            this.toolStripStatusLabel1.Text = "User: ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 20);
            // 
            // StatusLblUser
            // 
            this.StatusLblUser.Name = "StatusLblUser";
            this.StatusLblUser.Size = new System.Drawing.Size(0, 20);
            // 
            // classesTableAdapter
            // 
            this.classesTableAdapter.ClearBeforeFill = true;
            // 
            // attendanceRecordsTableAdapter
            // 
            this.attendanceRecordsTableAdapter.ClearBeforeFill = true;
            // 
            // BtnLogout
            // 
            this.BtnLogout.Location = new System.Drawing.Point(676, 31);
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.Size = new System.Drawing.Size(117, 23);
            this.BtnLogout.TabIndex = 2;
            this.BtnLogout.Text = "Sign Out";
            this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(644, 291);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(8, 8);
            this.metroButton2.TabIndex = 13;
            this.metroButton2.Text = "metroButton2";
            // 
            // BtnSignIn
            // 
            this.BtnSignIn.Location = new System.Drawing.Point(544, 31);
            this.BtnSignIn.Name = "BtnSignIn";
            this.BtnSignIn.Size = new System.Drawing.Size(117, 23);
            this.BtnSignIn.TabIndex = 3;
            this.BtnSignIn.Text = "Sign In";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 893);
            this.Controls.Add(this.BtnSignIn);
            this.Controls.Add(this.BtnLogout);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "MainForm";
            this.Text = " Attendance System";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceRecordsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classesBindingSource)).EndInit();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel StatusLblUser;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource classesBindingSource;
        private DataSet1TableAdapters.ClassesTableAdapter classesTableAdapter;
        private System.Windows.Forms.BindingSource attendanceRecordsBindingSource;
        private DataSet1TableAdapters.AttendanceRecordsTableAdapter attendanceRecordsTableAdapter;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroButton BtnGetValues;
        private MetroFramework.Controls.MetroButton BtnAddStudents;
        private MetroFramework.Controls.MetroButton BtnAddClass;
        private MetroFramework.Controls.MetroButton BtnClear;
        private MetroFramework.Controls.MetroButton BtnSave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAttendanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classNameDataGridViewTextBoxColumn;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DateTimePicker DatePicker;
        private System.Windows.Forms.ComboBox CbxClass;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.ComboBox comboBox1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton BtnRegister;
        private MetroFramework.Controls.MetroButton BtnLogout;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton BtnSignIn;
    }
}

