using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Xml.Linq;
using BCrypt.Net;

namespace SchoolProject_WPF
{
    
    public partial class StudentLoginWindow : Window
    {
        public int studentLogged { get; set; }
        string sqlString ="Data Source=.;Initial Catalog=StudentDb;Integrated Security=True;Encrypt=False";
        public StudentLoginWindow()
        {
            InitializeComponent();
        }

        private void BtnStudentLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbxStudentName.Text) || string.IsNullOrEmpty(TbxPassword.Text))
            {
                MessageBox.Show("Cannot be Empty.");
                return ;
            }
            

                try
                {
                string query = "SELECT Password, StudentID FROM Students WHERE Name = @username";

                using (SqlConnection con = new SqlConnection(sqlString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", TbxStudentName.Text);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string foundPassword = reader["Password"].ToString();

                                //if (BCrypt.Net.BCrypt.Verify(TbxPassword.Text, foundPassword))
                                if (foundPassword == TbxPassword.Text)
                                {
                                    studentLogged = Convert.ToInt32(reader["StudentID"]);
                                    MessageBox.Show("Logged In", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                                    this.Close();
                                    MainStudent studentFrm = new MainStudent(studentLogged);
                                    studentFrm.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("Password did not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

      

        private void BtnStudentReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the current window
        }

        private bool IsValueNull(string name)
        {
            // Implement your password validation logic here
            // For example, check if the password meets certain criteria like length, contains special characters, etc.
            if (name.Length < 3 || name.Length > 100 || name.Contains(";"))
            {

                MessageBox.Show("Name must be 3-100 characters long, no semicolons");
                return false;
            }
            return true;
        }

    }
}
