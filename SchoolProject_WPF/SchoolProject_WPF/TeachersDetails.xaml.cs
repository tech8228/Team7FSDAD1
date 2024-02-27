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
    /// Interaction logic for TeachersDetails.xaml
    /// </summary>
    public partial class TeachersDetails : Window
    {
        
        public TeachersDetails()
        {
            InitializeComponent();
            ListTeacherDetails();
        }
        private void ListTeacherDetails()
        {


            using (SqlConnection con = new SqlConnection(DbString.conString))
            {
                try
                {
                    con.Open();

                    string query1 = @"SELECT UserID AS ID, Name , DateOfBirth, Email FROM Users WHERE Role = 'Teacher'";

                    //string query1 = @"SELECT CourseID, CourseName AS [Course Name], DaysOfWeek  FROM Courses ;

                    using (SqlCommand cmd1 = new SqlCommand(query1, con))
                    {
                       

                        using (SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1))
                        {
                            DataTable teachersDetailsTable = new DataTable();
                            adapter1.Fill(teachersDetailsTable);

                            if (teachersDetailsTable.Rows.Count > 0)
                            {
                                DgTeacher.ItemsSource = teachersDetailsTable.DefaultView;
                                
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

        private void BtnNewTeacher_Click(object sender, RoutedEventArgs e)
        {
            RegTeacherFrm regTeacherFrm = new RegTeacherFrm();
            regTeacherFrm.ShowDialog();
        }

        private void DgTeacher_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DgTeacher.SelectedItem != null)
            {
                DataRowView row = (DataRowView)DgTeacher.SelectedItem;
                int userId = Convert.ToInt32(row["ID"]);
                EditTeacherDetailsFrm editTeacherFrm = new EditTeacherDetailsFrm(userId);
                editTeacherFrm.ShowDialog();
            }
        }

        private void BtnFrmRefresh_Click(object sender, RoutedEventArgs e)
        {
            ListTeacherDetails();
        }
    }
}
