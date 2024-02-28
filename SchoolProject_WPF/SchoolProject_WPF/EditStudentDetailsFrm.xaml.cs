using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BCrypt.Net;

namespace SchoolProject_WPF
{
    /// <summary>
    /// Interaction logic for EditStudentDetailsFrm.xaml
    /// </summary>
    public partial class EditStudentDetailsFrm : Window
    {
        public int studentId;
        public EditStudentDetailsFrm(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            LoadStudentDetails(studentId);
        }

        private void LoadStudentDetails(int studentId)
        {
            using (SqlConnection con = new SqlConnection(DbString.conString))
            {
                try
                {
                    con.Open();
                    string query = @"SELECT Name, Address, DateOfBirth, Email FROM Students WHERE StudentID = @studentId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            TbxStudentName.Text = reader["Name"].ToString();
                            TbxFrmAddress.Text = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : "";
                            if (reader["DateOfBirth"] != DBNull.Value && reader["DateOfBirth"] != null)
                            {
                                TbxRegDatePicker.SelectedDate = Convert.ToDateTime(reader["DateOfBirth"]);
                            }
                            TbxFrmEmail.Text = reader["Email"].ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void BtnFrmEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidName(TbxStudentName.Text.ToString()) || !IsValidEmail(TbxFrmEmail.Text.ToString()))
            {
                return;
            }

            string passwordHash = null;
            if (!string.IsNullOrEmpty(TbxFrmPassword.Password)){
                 //passwordHash = TbxFrmPassword.Password.ToString();
                //
                 passwordHash = BCrypt.Net.BCrypt.HashPassword(TbxFrmPassword.Password);
            }
            else
            {
                 passwordHash = null;
            }


            string query = "UPDATE Students SET Name = @name, Address=@address, DateOfBirth = @dob, Email = @email";
            if (!string.IsNullOrEmpty(passwordHash))
            {
                query += ", Password = @password";
            }

            query += " WHERE StudentID = @userId";

            using (SqlConnection con = new SqlConnection(DbString.conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", TbxStudentName.Text);
                    cmd.Parameters.AddWithValue("@address", TbxFrmAddress.Text ?? (Object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@dob", TbxRegDatePicker.SelectedDate ?? (Object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", TbxFrmEmail.Text);
                    cmd.Parameters.AddWithValue("@userId", studentId);

                    // Add the password parameter only if it's being updated
                    if (!string.IsNullOrEmpty(passwordHash))
                    {
                        cmd.Parameters.AddWithValue("@password", passwordHash);
                    }

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Student details updated successfully");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
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

        private void BtnFrmCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnFrmDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this student?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(DbString.conString))
                    {
                        con.Open();

                        //Delete related records from Registrations table
                        string deleteRegQuery = @"DELETE FROM Registrations WHERE StudentID = @studentId";
                        using (SqlCommand deleteRegCmd = new SqlCommand(deleteRegQuery, con))
                        {
                            deleteRegCmd.Parameters.AddWithValue("@studentId", studentId);
                            deleteRegCmd.ExecuteNonQuery();
                        }

                        //Delete student from Students table
                        string deleteStudentQuery = @"DELETE FROM Students WHERE StudentID = @studentId";
                        using (SqlCommand cmd = new SqlCommand(deleteStudentQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@studentId", studentId);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Student deleted successfully");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}