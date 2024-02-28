using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SchoolProject_WPF
{
    /// <summary>
    /// Interaction logic for StudentDetailsFrm.xaml
    /// </summary>
    public partial class StudentDetailsFrm : Window
    {
        public StudentDetailsFrm()
        {
            InitializeComponent();
            ListStudentsDetails();
        }
        private void ListStudentsDetails()
        {


            using (SqlConnection con = new SqlConnection(DbString.conString))
            {
                try
                {
                    con.Open();

                    string query1 = @"SELECT StudentID AS ID, Name , Address, DateOfBirth, Email FROM Students";

                    //string query1 = @"SELECT CourseID, CourseName AS [Course Name], DaysOfWeek  FROM Courses ;

                    using (SqlCommand cmd1 = new SqlCommand(query1, con))
                    {


                        using (SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1))
                        {
                            DataTable studentsDetailsTable = new DataTable();
                            adapter1.Fill(studentsDetailsTable);

                            if (studentsDetailsTable.Rows.Count > 0)
                            {
                                DgStudents.ItemsSource = studentsDetailsTable.DefaultView;

                            }

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }

            }


        }

        private void BtnFrmCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnNewStudent_Click(object sender, RoutedEventArgs e)
        {
            RegStudentFrm regStudentFrm = new RegStudentFrm();
            regStudentFrm.ShowDialog();
        }

        private void DgStudent_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DgStudents.SelectedItem != null)
            {
                DataRowView row = (DataRowView)DgStudents.SelectedItem;
                int studentId = Convert.ToInt32(row["ID"]);
                EditStudentDetailsFrm editStudentFrm = new EditStudentDetailsFrm(studentId);
                editStudentFrm.ShowDialog();
            }
        }

        private void BtnFrmRefresh_Click(object sender, RoutedEventArgs e)
        {
            ListStudentsDetails();
        }
    }
}

