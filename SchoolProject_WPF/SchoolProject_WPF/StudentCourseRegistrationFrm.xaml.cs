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
    /// <summary>
    /// Interaction logic for StudentCourseRegistrationFrm.xaml
    /// </summary>
    public partial class StudentCourseRegistrationFrm : Window
    {
        public StudentCourseRegistrationFrm()
        {
            InitializeComponent();
            LoadCourseList();
            SetDate();

        }

        private void LoadCourseList()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbString.conString))
                {
                    con.Open();
                    string query = "SELECT CourseID, CourseName FROM Courses";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int courseId = reader.GetInt32(reader.GetOrdinal("CourseID"));
                                string courseName = reader.GetString(reader.GetOrdinal("CourseName"));

                                // Create a custom object to hold course information
                                var courseInfo = new { courseId, courseName };
                                //var courseInfo = new { CourseID = courseId, CourseName = courseName };
                                LbxCourseName.Items.Add(courseInfo);
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

        private void LbxCourseName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbxCourseName.SelectedItem != null)
            {
                //string selectedCourseName = LbxCourseName.SelectedItem.ToString();
                dynamic selectedCourse = LbxCourseName.SelectedItem;
                int courseId = selectedCourse.courseId;
                string courseName = selectedCourse.courseName;

                LoadStudentsForCourse(courseId, courseName);
                LoadStudentsNotInCourse(courseId, courseName);

            }
        }

        private void LoadStudentsForCourse(int courseId, string courseName)
        {
            try
            {
                LbxInStudentName.Items.Clear(); // Clear previous items

                using (SqlConnection con = new SqlConnection(DbString.conString))
                {
                    con.Open();
                    string query = @"SELECT s.Name, c.CourseID, s.StudentID
                             FROM Students s
                             INNER JOIN Registrations r ON s.StudentID = r.StudentID
                             INNER JOIN Courses c ON r.CourseID = c.CourseID
                             WHERE c.CourseName = @courseName";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@courseName", courseName);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string studentName = reader["Name"].ToString();
                               
                                int studentId = Convert.ToInt32(reader["StudentID"]);

                                // Create a custom object to hold student information
                                var studentInfo = new { studentId, studentName};
                                //var studentInfo = new { Name = studentName, CourseID = courseId, StudentID = studentId };
                                LbxInStudentName.Items.Add(studentInfo);
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

        private void LoadStudentsNotInCourse(int courseId, string courseName)
        {
            try
            {
                LbxStudentName.Items.Clear(); // Clear previous items

                using (SqlConnection con = new SqlConnection(DbString.conString))
                {
                    con.Open();
                    string query = @"SELECT s.Name, s.StudentID
                             FROM Students s
                             WHERE s.StudentID NOT IN 
                             (
                                 SELECT r.StudentID 
                                 FROM Registrations r 
                                 INNER JOIN Courses c ON r.CourseID = c.CourseID
                                 WHERE c.CourseName = @courseName
                             )";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@courseName", courseName);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string studentName = reader["Name"].ToString();
                                int studentId = Convert.ToInt32(reader["StudentID"]);

                                // Create a custom object to hold student information
                                var studentInfo = new { studentId, studentName  };
                                //var studentInfo = new { Name = studentName, StudentID = studentId };
                                LbxStudentName.Items.Add(studentInfo);
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

        private void LbxStudentName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbxStudentName.SelectedItem != null)
            {
                dynamic selectedStudent = LbxStudentName.SelectedItem;
                int studentId = selectedStudent.studentId;
                string studentName = selectedStudent.studentName;

                // Check if the student ID is already in the list
                bool studentExists = LbxSelectedStudents.Items.Cast<dynamic>()
                                        .Any(item => item.studentId == studentId);

                // If the student is not already in the list, add it
                if (!studentExists)
                {
                    // Create a custom object to hold selected student information
                    var selectedStudentInfo = new { studentId, studentName };

                    // Add the selected student to the LbxSelectedStudents ListBox
                    LbxSelectedStudents.Items.Add(selectedStudentInfo);
                }
            }
        }

        private void LbxSelectedStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LbxSelectedStudents.SelectedItem != null)
            {
                // Get the selected item
                dynamic selectedItem = LbxSelectedStudents.SelectedItem;

                // Remove the selected item from the ListBox
                LbxSelectedStudents.Items.Remove(selectedItem);
            }
        }

        private void SetDate()
        {
            TbxSetDate.Text = "Date:- " + DateTime.Today.ToShortDateString();
        }

        

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (LbxCourseName.SelectedItem != null && LbxSelectedStudents.Items.Count > 0)
            {
                dynamic selectedCourse = LbxCourseName.SelectedItem;
                int courseId = selectedCourse.courseId;

                // Check if the course has a teacher associated with it
                int teacherId = GetTeacherIdForCourse(courseId);

                // Get the current date
                DateTime currentDate = DateTime.Today;

                try
                {
                    using (SqlConnection con = new SqlConnection(DbString.conString))
                    {
                        con.Open();
                        string query = "INSERT INTO Registrations (CourseID, StudentID, TeacherID, RegistrationDate) VALUES (@CourseID, @StudentID, @TeacherID, @RegistrationDate)";
                        foreach (dynamic selectedItem in LbxSelectedStudents.Items)
                        {
                            int studentId = selectedItem.studentId;

                            // Insert registration data into the database
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@CourseID", courseId);
                                cmd.Parameters.AddWithValue("@StudentID", studentId);

                                // Check if the course has a teacher
                                if (teacherId != -1)
                                {
                                    cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@TeacherID", DBNull.Value); // Insert NULL for TeacherID
                                }

                                cmd.Parameters.AddWithValue("@RegistrationDate", currentDate);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Registration completed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LbxSelectedStudents.Items.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a course and at least one student to register.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
        private int GetTeacherIdForCourse(int courseId)
        {
            int teacherId = -1; // Default value if no teacher is found

            try
            {
                using (SqlConnection con = new SqlConnection(DbString.conString))
                {
                    con.Open();
                    string query = "SELECT TeacherID FROM Courses WHERE CourseID = @CourseID AND TeacherID IS NOT NULL";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CourseID", courseId);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            teacherId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving teacher information: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return teacherId;
        }


        private void DeregisterStudent()
        {
            if (LbxInStudentName.SelectedItem != null)
            {
                // Get the selected item
                dynamic selectedItem = LbxInStudentName.SelectedItem;
                int studentId = selectedItem.studentId;

                dynamic selectedCourse = LbxCourseName.SelectedItem;
                int courseId = selectedCourse.courseId;

                // Prompt the user to confirm deletion
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this student's registration?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        // Delete the registration data from the database
                        using (SqlConnection con = new SqlConnection(DbString.conString))
                        {
                            con.Open();
                            string query = "DELETE FROM Registrations WHERE CourseID = @CourseID AND StudentID = @StudentID";
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@CourseID", courseId); // You need to define the courseId variable here
                                cmd.Parameters.AddWithValue("@StudentID", studentId);
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Registration deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                                    LoadCourseList();
                                    LbxCourseName_SelectionChanged(this, null);
                                }
                                else
                                {
                                    MessageBox.Show("No registration found for the selected student.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please, Select the Student from Registered Students", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnDeregister_Click(object sender, RoutedEventArgs e)
        {
            DeregisterStudent();
        }

        private void LbxInStudentName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbxInStudentName.SelectedItem != null)
            {
                dynamic selectedStudent = LbxInStudentName.SelectedItem;
                int studentId = selectedStudent.studentId;

                dynamic selectedCourse = LbxCourseName.SelectedItem;
                int courseId = selectedCourse.courseId;

                try
                {
                    using (SqlConnection con = new SqlConnection(DbString.conString))
                    {
                        con.Open();
                        string query = @"SELECT RegistrationDate FROM Registrations WHERE CourseID = @CourseID AND StudentID = @StudentID";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@CourseID", courseId);
                            cmd.Parameters.AddWithValue("@StudentID", studentId);

                            object result = cmd.ExecuteScalar();
                            if (result != DBNull.Value)
                            
                            {
                                DateTime registrationDate = Convert.ToDateTime(result);
                                LblRegDate.Content =  registrationDate.ToShortDateString();
                            }
                            else
                            {
                                LblRegDate.Content = string.Empty;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                LblRegDate.Content = string.Empty; // Clear the label if no student is selected
            }
        }


        }
    
}
