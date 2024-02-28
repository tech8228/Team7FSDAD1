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

        public int adminLogged { get; set; }
        public string adminName { get; set; }
        
        public AdminLoginWindow()
        {
            InitializeComponent();
        }

           

        private void BtnAdminLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbxUserName.Text) || string.IsNullOrEmpty(TbxUserPassword.Password))
            {
                MessageBox.Show("Cannot be Empty.");
                return;
            }
            try
            {


                string query = "SELECT Password FROM Users WHERE Name = @username AND Role =@role";

                using (SqlConnection con = new SqlConnection(DbString.conString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", TbxUserName.Text);

                        cmd.Parameters.AddWithValue("@role", "Admin");



                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string foundPassword = reader["Password"].ToString();
                                if (BCrypt.Net.BCrypt.Verify(TbxUserPassword.Password, foundPassword))
                                //if (foundPassword == TbxPassword.Password)
                                {
                                    //adminLogged = Convert.ToInt32(reader["UserID"]);
                                    //adminName = Convert.ToString(reader["Name"]);

                                    //MessageBox.Show("Logged In", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                                    this.Close();
                                    MainAdmin adminFrm = new MainAdmin();
                                    adminFrm.ShowDialog();



                                }
                                else
                                {
                                    MessageBox.Show("Sir/Madam, Username or Password did not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void BtnAdminReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the current window
        }
    }
}
