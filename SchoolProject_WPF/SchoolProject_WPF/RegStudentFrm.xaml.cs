using System;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using BCrypt.Net;

namespace SchoolProject_WPF
{
    /// <summary>
    /// Interaction logic for RegStudentFrm.xaml
    /// </summary>
    public partial class RegStudentFrm : Window
    {
        public RegStudentFrm()
        {
            InitializeComponent();
        }

        private void ResetFields()
        {
            TbxFrmName.Text = "";
            TbxFrmAddress.Text ="";
            TbxRegDatePicker.SelectedDate=null;
            TbxFrmEmail.Text="";
            TbxFrmPassword.Text="";
            TbxFrmConfirmPassword.Text="";
        }

        private void BtnFrmRegister_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidName(TbxFrmName.Text.ToString()) || !IsValidEmail(TbxFrmEmail.Text.ToString()) || !IsValidPassword(TbxFrmPassword.Text.ToString()))
            {
                return;
            }
            if (!TbxFrmPassword.Text.ToString().Equals(TbxFrmConfirmPassword.Text.ToString()))
            {
                MessageBox.Show("Passwords do not match. Please enter matching passwords.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(TbxFrmPassword.Text, 10);
            string passwordHash =BCrypt.Net.BCrypt.HashPassword(TbxFrmPassword.Text);

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=StudentDb;Integrated Security=True;Encrypt=False");
            string query = "INSERT INTO Students (Name, Address, DateOfBirth, Email, Password) VALUES (@name, @address, @dob, @email, @password)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", TbxFrmName.Text);
            cmd.Parameters.AddWithValue("@address", string.IsNullOrEmpty(TbxFrmAddress.Text) ? (object)DBNull.Value : TbxFrmAddress.Text);
            cmd.Parameters.AddWithValue("@dob", TbxRegDatePicker.SelectedDate == null ? (object)DBNull.Value : ((DateTime)TbxRegDatePicker.SelectedDate).Date);
            cmd.Parameters.AddWithValue("@email", TbxFrmEmail.Text);
            cmd.Parameters.AddWithValue("@password", passwordHash);
            try
            {

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
          
                MessageBox.Show("You are Registered Successfully");
                ResetFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
    
        }

        private void BtnFrmCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the current window
        }


        private bool IsValidName(string name)
        {
            // Implement your password validation logic here
            // For example, check if the password meets certain criteria like length, contains special characters, etc.
            if (name.Length < 3|| name.Length > 100 || name.Contains(";"))
            {

                MessageBox.Show("Name must be 3-100 characters long, no semicolons");
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
            if (!validRegex.IsMatch(password)) {
                MessageBox.Show("Password must be 4 characters long");
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


    }
}
