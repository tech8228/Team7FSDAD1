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
using System.Text.RegularExpressions;
using BCrypt.Net;

namespace SchoolProject_WPF
{
    /// <summary>
    /// Interaction logic for RegTeacherFrm.xaml
    /// </summary>
    public partial class RegTeacherFrm : Window
    {
        
        public RegTeacherFrm()
        {
            InitializeComponent();
            List<string> listRole = new List<string>()
            {
                "Teacher", "Admin"
            };
            this.CbxRole.ItemsSource = listRole;
        }

        private void ResetFields()
        {
            TbxRegTeacherName.Text = "";
            TbxRegDatePicker.SelectedDate = null;
            TbxFrmEmail.Text = "";
            CbxRole.SelectedValue = null;
           
        }

        private void BtnFrmRegister_Click(object sender, RoutedEventArgs e)
        {
            
            if (!IsValidName(TbxRegTeacherName.Text.ToString()) || !IsValidEmail(TbxFrmEmail.Text.ToString()) || !IsValidPassword(TbxFrmPassword.Password.ToString()))
            {
                return;
            }
           

            //string passwordHash = TbxFrmPassword.Password.ToString();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(TbxFrmPassword.Password);

            string userRole = CbxRole.SelectedItem?.ToString() ?? "Teacher";
            string query = "INSERT INTO Users (Name, DateOfBirth, Email, Role, Password) VALUES ( @name,  @dob, @email, @role, @password)";

            using (SqlConnection con = new SqlConnection(DbString.conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", TbxRegTeacherName.Text);
                   
                    cmd.Parameters.AddWithValue("@dob", TbxRegDatePicker.SelectedDate == null ? (object)DBNull.Value : ((DateTime)TbxRegDatePicker.SelectedDate).Date);
                    cmd.Parameters.AddWithValue("@email", TbxFrmEmail.Text);
                    cmd.Parameters.AddWithValue("@role",userRole);
                    cmd.Parameters.AddWithValue("@password", passwordHash);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("You are Registered Successfully");
                        ResetFields();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void BtnFrmCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool IsValidName(string name)
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
        

        private bool IsValidEmail(string email)
        {

            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);


            if (!regex.IsMatch(email))
            {
                MessageBox.Show("Not a valid Email");
                return false;
            }
            return true;
        }

        private bool IsValidPassword(string password)
        {
            //Has minimum 8 characters in length.Adjust it by modifying { 8,}
            //At least one uppercase English letter. You can remove this condition by removing(?=.*?[A - Z])
            //At least one lowercase English letter.  You can remove this condition by removing(?=.*?[a - z])
            //At least one digit. You can remove this condition by removing(?=.*?[0 - 9])
            //At least one special character,  You can remove this condition by removing(?=.*?[#?!@$%^&*-])


            //var validRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            var validRegex = new Regex("(.*).{4,}$");
            if (!validRegex.IsMatch(password))
            {
                MessageBox.Show("Password must be 4 characters long");
                return false;
            }
            return true;


        }

    }
}
