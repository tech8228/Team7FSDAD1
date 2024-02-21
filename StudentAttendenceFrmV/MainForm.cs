using StudentAttendenceFrmV.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentAttendenceFrmV
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public int loggedIn {  get; set; } 
        public int UserID {  get; set; }

        public MainForm()
        {

            InitializeComponent();
            loggedIn = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.AttendanceRecords' table. You can move, or remove it, as needed.
          
            // TODO: This line of code loads data into the 'dataSet1.Classes' table. You can move, or remove it, as needed.


        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (loggedIn == 0)
            {


                //Open Login Form
                LoginFrm newLogin = new LoginFrm();
                newLogin.ShowDialog();

                if (newLogin.logingFlag == false)
                {
                    Close();
                }
                else
                {
                    UserID = newLogin.UserID;
                    StatusLblUser.Text = UserID.ToString();
                    loggedIn = 1;


                    this.classesTableAdapter.Fill(this.dataSet1.Classes);
                    classesBindingSource.Filter = "UserID = '" + UserID.ToString() + "'";
                }
            }
        }

        private void BtnAddClass_Click(object sender, EventArgs e)
        {
            AddClass addClass = new AddClass();
            addClass.UserID = this.UserID;
            addClass.ShowDialog();
        }

        private void BtnAddStudents_Click(object sender, EventArgs e)
        {
            StudentFrm students = new StudentFrm();
            students.ClassName = CbxClass.Text;
            students.ClassID = (int)CbxClass.SelectedValue;
            students.ShowDialog();
        }

        private void BtnGetValues_Click(object sender, EventArgs e)
        {
            //if records exits, if exists and if not, create a record and load them
            AttendanceRecordsTableAdapter ada = new AttendanceRecordsTableAdapter();
            DataTable dt = ada.GetDataBy((int)CbxClass.SelectedValue, DatePicker.Text);
            if (dt.Rows.Count > 0)
            {
                //there is records
                DataTable dt_new = ada.GetDataBy((int)CbxClass.SelectedValue, DatePicker.Text);

                dataGridView1.DataSource = dt_new;
            }
            else
            {
                //create record if no record found
                //get student class list
                StudentsTableAdapter stuAdpt = new StudentsTableAdapter();
                DataTable dt_Students = stuAdpt.GetDataByClassID((int)CbxClass.SelectedValue);
                
                foreach (DataRow row in dt_Students.Rows) {
                    //create a new record and insert for such student
                    ada.InsertQuery((int)row[0], (int)CbxClass.SelectedValue, DatePicker.Text, "", row[1].ToString(), CbxClass.Text);


                }
                DataTable dt_new = ada.GetDataBy((int)CbxClass.SelectedValue, DatePicker.Text);

                dataGridView1.DataSource = dt_new;

            }
            this.attendanceRecordsTableAdapter.Fill(this.dataSet1.AttendanceRecords);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            AttendanceRecordsTableAdapter ada = new AttendanceRecordsTableAdapter();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[4].Value != null) 
                { 
                    ada.UpdateQuery(row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(),(int)CbxClass.SelectedValue,DatePicker.Text);
            
                }
            }
            DataTable dt_new = ada.GetDataBy((int)CbxClass.SelectedValue, DatePicker.Text);

            dataGridView1.DataSource = dt_new;

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            AttendanceRecordsTableAdapter ada = new AttendanceRecordsTableAdapter();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    ada.UpdateQuery("", row.Cells[4].Value.ToString(), (int)CbxClass.SelectedValue, DatePicker.Text);

                }
            }
            DataTable dt_new = ada.GetDataBy((int)CbxClass.SelectedValue, DatePicker.Text);

            dataGridView1.DataSource = dt_new;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            // get Students
            StudentsTableAdapter stuAdpt = new StudentsTableAdapter();
            DataTable dt_Students = stuAdpt.GetDataByClassID((int)comboBox1.SelectedValue);
            int P = 0;
            int A = 0;
            int L = 0;
            int E = 0;

            //loop thorugh students and get values
            foreach(DataRow row in dt_Students.Rows)
            {
                // presence count
                P = (int)AttendanceRecordsTableAdapter.GetDataByReport(dateTimePicker1.Value.Month, row[1].ToString(), "Present").Rows[0][6];

                //absence count
                A = (int)AttendanceRecordsTableAdapter.GetDataByReport(dateTimePicker1.Value.Month, row[1].ToString(), "Absent").Rows[0][6];
                //late
                L = (int)AttendanceRecordsTableAdapter.GetDataByReport(dateTimePicker1.Value.Month, row[1].ToString(), "Late").Rows[0][6];

                //Execuse
                E = (int)AttendanceRecordsTableAdapter.GetDataByReport(dateTimePicker1.Value.Month, row[1].ToString(), "Excused").Rows[0][6];
                
                // add to listView
                ListViewItem lsvItem = new ListViewItem();
                lsvItem.Text = row[1].ToString();
                lsvItem.SubItems.Add(P.ToString());
                lsvItem.SubItems.Add(A.ToString());
                lsvItem.SubItems.Add(L.ToString());
                lsvItem.SubItems.Add(E.ToString());
                listView1.Items.Add(lsvItem);

            }

            
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            RegisterFrm regFrm = new RegisterFrm();
            regFrm.ShowDialog();
        }
    }
}
