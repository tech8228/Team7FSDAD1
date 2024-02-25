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
using System.Net.NetworkInformation;

namespace SchoolProject_WPF
{
    /// <summary>
    /// Interaction logic for MainStudent.xaml
    /// </summary>
    public partial class MainStudent : Window
    {

        public int studentLog { get; set; }
        String conString = "Data Source=.;Initial Catalog=StudentDb;Integrated Security=True;Encrypt=False";
        public MainStudent(int studentLogged)
        {
            InitializeComponent();
            studentLog = studentLogged;
            StudentDetails();
        }

        private void StudentDetails()
        {


            SqlConnection con = new SqlConnection(conString);
            {
                try
                {
                    con.Open();

                    string query1 = @"SELECT s.StudentID, s.Name AS StudentName, s.Address, s.DateOfBirth, s.Email
                                     FROM Students s WHERE s.StudentID = @studentID";

                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.Parameters.AddWithValue("@studentID", studentLog);

                    SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                    DataTable studentDetailsTable1 = new DataTable();
                    adapter1.Fill(studentDetailsTable1);

                    TbxStudent.Text = studentDetailsTable1.Rows[0]["StudentName"].ToString();

                    
                    // Construct the SQL query with joins
                    string query = @"SELECT c.CourseName, c.DaysOfWeek, r.[Final Grade]
                                     FROM Students s
                                     INNER JOIN Registrations r ON s.StudentID = r.StudentID
                                     INNER JOIN Courses c ON r.CourseID = c.CourseID
                                     WHERE s.StudentID = @studentID";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@studentID", studentLog);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable studentDetailsTable = new DataTable();
                    adapter.Fill(studentDetailsTable);
                    string studentName = string.Empty;
                    if (studentDetailsTable.Rows.Count > 0)
                    {
                        
                        DgStudent.ItemsSource = studentDetailsTable.DefaultView;
                        DgStudent.IsReadOnly = false;
                    }
                    else
                    {
                        MessageBox.Show("You have not been registered to any Courses yet");
                    }

                    
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close(); // Close the connection after use
                }
            }
        

        }

        private void BtnFrmCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            StudentDetails();
        }
    }
}
