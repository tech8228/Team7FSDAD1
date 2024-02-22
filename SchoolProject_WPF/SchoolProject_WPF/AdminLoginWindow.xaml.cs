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
    public partial class AdminLoginWindow : Window
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=StudentDb;Integrated Security=True;Encrypt=False");
        public AdminLoginWindow()
        {
            InitializeComponent();
        }

           

        private void BtnAdminLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Name = @username AND Password = @password AND Role =@role";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", TbxUserName.Text);
                cmd.Parameters.AddWithValue("@password", TbxUserPassword.Text);
                cmd.Parameters.AddWithValue("@role", "Admin");

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                con.Close();

                if (count > 0)
                {
                    MessageBox.Show("Logged In", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    MainAdmin adminFrm = new MainAdmin();
                    adminFrm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sir/Madam, Username or Password did not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAdminReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the current window
        }
    }
}
