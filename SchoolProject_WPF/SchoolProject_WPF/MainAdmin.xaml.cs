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
    /// Interaction logic for MainAdmin.xaml
    /// </summary>
    public partial class MainAdmin : Window
    {
        public MainAdmin()
        {
            InitializeComponent();
            ListCoursesDetails();
        }
        private void ListCoursesDetails()
        {


            using (SqlConnection con = new SqlConnection(DbString.conString))
            {
                try
                {
                    con.Open();

                    string query1 = @"SELECT c.CourseID, c.CourseName AS [Course Name], c.DaysOfWeek, ISNULL(u.Name, '') AS TeacherName
                                        FROM Courses c LEFT JOIN Users u ON c.TeacherID = u.UserID ";

                    //string query1 = @"SELECT CourseID, CourseName AS [Course Name], DaysOfWeek  FROM Courses ;

                    using (SqlCommand cmd1 = new SqlCommand(query1, con))
                    {


                        using (SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1))
                        {
                            DataTable CoursesDetailsTable = new DataTable();
                            adapter1.Fill(CoursesDetailsTable);

                            if (CoursesDetailsTable.Rows.Count > 0)
                            {
                                DgCourses.ItemsSource = CoursesDetailsTable.DefaultView;

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

       
        private void DgCourse_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DgCourses.SelectedItem != null)
            {
                DataRowView row = (DataRowView)DgCourses.SelectedItem;
                int courseId = Convert.ToInt32(row["CourseID"]);
                EditCourseFrm editCourseFrm = new EditCourseFrm(courseId);
                editCourseFrm.ShowDialog();
            }
        }

        private void BtnFrmRefresh_Click(object sender, RoutedEventArgs e)
        {
            ListCoursesDetails();
        }

        private void BtnAddCourse_Click(object sender, RoutedEventArgs e)
        {
            NewCourseFrm newCourseFrm = new NewCourseFrm();
            newCourseFrm.ShowDialog();
        }

        private void BtnStudentProfile_Click(object sender, RoutedEventArgs e)
        {
            StudentDetailsFrm DetailsFrm = new StudentDetailsFrm();
            DetailsFrm.ShowDialog();
        }

        private void BtnTeacherProfile_Click(object sender, RoutedEventArgs e)
        {
            TeachersDetails teacherDetailsFrm = new TeachersDetails();
            teacherDetailsFrm.ShowDialog();

            
        }

        private void BtnRegisterStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentCourseRegistrationFrm registerStudent = new StudentCourseRegistrationFrm();
            registerStudent.ShowDialog();
        }
    }
}
