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
using System.Xml.Linq;

namespace SchoolProject_WPF
{
    /// <summary>
    /// Interaction logic for EditCourseFrm.xaml
    /// </summary>
    public partial class EditCourseFrm : Window
    {
        public int courseId;
        public EditCourseFrm(int courseId)
        {
            InitializeComponent();
            List<string> listDays = new List<string>()
            {
                "Monday", "Tuesday","Wednesday","Thursday","Friday"
            };
            this.LbxWeekdays.ItemsSource = listDays;
            this.courseId = courseId;
            LoadCourseDetails(courseId);
        }

        private void LoadCourseDetails(int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbString.conString))
                {
                    con.Open();
                    
                    string query = @"SELECT CourseName,TeacherID, DaysOfWeek FROM Courses WHERE CourseID = @courseId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@courseId", courseId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                LblName.Content = reader["CourseName"].ToString();
                                object teacherIdObject = reader["TeacherID"]; // Handle DBNull
                                if (teacherIdObject != DBNull.Value)
                                {
                                    int teacherId = (int)teacherIdObject;
                                    LoadTeacherName(teacherId);
                                }
                                else
                                {
                                    LoadTeachers(); // Load list of teachers
                                }
                            }
                        }
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void LoadTeacherName(int teacherId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbString.conString))
                {
                    con.Open();
                    string query = @"SELECT Name FROM Users WHERE UserID = @teacherId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@teacherId", teacherId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string teacherName = reader["Name"].ToString();
                                
                                CbxCourseTeacher.SelectedItem = teacherName;
                                LoadTeachers();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void LoadTeachers()
        {
            try
            {
                // Clear existing items
                CbxCourseTeacher.Items.Clear();

                using (SqlConnection con = new SqlConnection(DbString.conString))
                {
                    con.Open();
                    string query = @"SELECT Name FROM Users WHERE Role='Teacher'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string teacherName = reader["Name"].ToString();
                                CbxCourseTeacher.Items.Add(teacherName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void BtnFrmCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnFrmEdit_Click(object sender, RoutedEventArgs e)
        {
            

            if ((LbxWeekdays.SelectedItems.Count != 0)) { 

                List<string> selectedDays = new List<string>();
                foreach (var item in LbxWeekdays.SelectedItems)
                {
                    selectedDays.Add(item.ToString());
                }
                string listWeek = string.Join(",", selectedDays);

                if (CbxCourseTeacher.SelectedItem != null)
                {
                    int idTeacher = FindTeacherID(CbxCourseTeacher.SelectedItem.ToString());

                    string registrationquery = @"UPDATE Registrations SET TeacherID = @idTeacher WHERE CourseID = @courseId AND (TeacherID IS NULL OR TeacherID = 0)";

                    string coursequery = @"UPDATE Courses SET TeacherID = @idTeacher, DaysOfWeek =@daysOfWeek WHERE CourseID =@courseId";
                    using (SqlConnection con = new SqlConnection(DbString.conString))
                    {
                        con.Open();
                        using (SqlCommand cmdRegistration = new SqlCommand(registrationquery, con))
                        {
                            cmdRegistration.Parameters.AddWithValue("@idTeacher", idTeacher);
                            cmdRegistration.Parameters.AddWithValue("@courseId", courseId);
                            try
                            {
                                int countRegistrations = cmdRegistration.ExecuteNonQuery();

                                using (SqlCommand cmdCourses = new SqlCommand(coursequery, con))
                                {
                                    cmdCourses.Parameters.AddWithValue("@idTeacher", idTeacher);
                                    cmdCourses.Parameters.AddWithValue("@daysOfWeek", listWeek);
                                    cmdCourses.Parameters.AddWithValue("@courseId", courseId);

                                    // Execute the update query for Courses table
                                    int countCourses = cmdCourses.ExecuteNonQuery();
                                    // Optionally, you can check the number of rows affected

                                    MessageBox.Show("Updated Successfully:- " + countRegistrations + "in Registration and " + countCourses +" in Courses." );
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
                else
                {
                    string query = @"UPDATE Courses SET  DaysOfWeek =@daysOfWeek WHERE CourseID =@courseId";
                    using (SqlConnection con = new SqlConnection(DbString.conString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            
                            cmd.Parameters.AddWithValue("@daysOfWeek", listWeek);
                            cmd.Parameters.AddWithValue("@courseId", courseId);

                            try
                            {
                                con.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Teacher details updated successfully");
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                if (CbxCourseTeacher.SelectedItem == null)
                {
                    return;
                }
                else
                {


                    int idTeacher = FindTeacherID(CbxCourseTeacher.SelectedItem.ToString());

                    string registrationquery = @"UPDATE Registrations SET TeacherID = @idTeacher WHERE CourseID = @courseId ";

                    string coursequery = @"UPDATE Courses SET TeacherID = @idTeacher WHERE CourseID =@courseId";
                    using (SqlConnection con = new SqlConnection(DbString.conString))
                    {
                        con.Open();
                        using (SqlCommand cmdRegistration = new SqlCommand(registrationquery, con))
                        {
                            cmdRegistration.Parameters.AddWithValue("@idTeacher", idTeacher);
                            cmdRegistration.Parameters.AddWithValue("@courseId", courseId);
                            try
                            {
                                int countRegistrations = cmdRegistration.ExecuteNonQuery();

                                using (SqlCommand cmdCourses = new SqlCommand(coursequery, con))
                                {
                                    cmdCourses.Parameters.AddWithValue("@idTeacher", idTeacher);
                                    
                                    cmdCourses.Parameters.AddWithValue("@courseId", courseId);

                                    // Execute the update query for Courses table
                                    int countCourses = cmdCourses.ExecuteNonQuery();
                                    // Optionally, you can check the number of rows affected

                                    MessageBox.Show("Updated Successfully:- " + countRegistrations + "in Registration and " + countCourses + " in Courses.");
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
            
        }


        private int FindTeacherID(string name)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbString.conString))
                {
                    con.Open();
                    string query = @"SELECT UserID FROM Users WHERE Name=@name and Role= 'Teacher'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return (int)reader["UserID"];
                            }
                            else
                            {
                                // Teacher not found
                                throw new InvalidOperationException("Teacher not found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                // Return a default value or throw an exception as per your application logic
                return -1; // Default value or throw an exception
            }
        }
    }
    
}
