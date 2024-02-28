using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public partial class TeacherLoginWindow : Window
    {
        public int teacherLogged { get; set; }
        public string teacherName { get; set; }
        
        
        public TeacherLoginWindow()
        {
            InitializeComponent();
        }

        private void BtnUserLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbxUserName.Text) || string.IsNullOrEmpty(TbxUserPassword.Password))
            {
                MessageBox.Show("Cannot be Empty.");
                return;
            }
            try
            {
                string query = "SELECT UserID, Name, Password FROM Users WHERE Name = @username AND Role =@role";

                using (SqlConnection con = new SqlConnection(DbString.conString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", TbxUserName.Text);
                       
                        cmd.Parameters.AddWithValue("@role", "Teacher");
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                    string foundPassword = reader["Password"].ToString();
                                if (BCrypt.Net.BCrypt.Verify(TbxUserPassword.Password, foundPassword))
                                //if (foundPassword == TbxUserPassword.Password)
                                {

                                    teacherLogged = Convert.ToInt32(reader["UserID"]);
                                    teacherName = Convert.ToString(reader["Name"]);
                                

                                    //MessageBox.Show("Logged In", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                                    this.Close();
                                    MainTeacher teacherFrm = new MainTeacher(teacherLogged, teacherName);
                                    teacherFrm.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("Username or Password did not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }

                            }
                            else
                            {
                                MessageBox.Show("User not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }


        private void CourseButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            int courseId = Convert.ToInt32(clickedButton.Content);
            // Do something with the clicked course ID
            MessageBox.Show("Course ID " + courseId + " clicked.");
        }


        private void BtnUserReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the current window
        }
    }
}
