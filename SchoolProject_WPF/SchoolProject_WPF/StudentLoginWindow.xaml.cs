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

namespace SchoolProject_WPF
{
    public partial class StudentLoginWindow : Window
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=StudentDb;Integrated Security=True;Encrypt=False");
        public StudentLoginWindow()
        {
            InitializeComponent();
        }

        private void BtnStudentLogin_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                string query = "SELECT COUNT(*) FROM Students WHERE Name = @username AND Password = @password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", TbxStudentName.Text);
                cmd.Parameters.AddWithValue("@password", TbxPassword.Text);

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                con.Close();

                if (count > 0)
                {
                    MessageBox.Show("Logged In", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    MainStudent studentFrm = new MainStudent();
                    studentFrm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username or Password did not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

    }
}
