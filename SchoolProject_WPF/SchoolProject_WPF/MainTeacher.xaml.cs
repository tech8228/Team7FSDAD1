using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchoolProject_WPF
{
    /// <summary>
    /// Interaction logic for MainTeacher.xaml
    /// </summary>
    public partial class MainTeacher : Window
    {
        private int courseId;
        public List<CourseInfo> listCourse { get; set; }
        public string teacherName { get; set; }
        public int teacherLog { get; set; }

        public MainTeacher(int teacherLogged, string name)
        {
            InitializeComponent();
            teacherLog = teacherLogged;
            teacherName = name;
            TeacherDetails();
            DataContext = this; 

           
        }
        private void TeacherDetails()
        {
            TbxTeacher.Text = teacherName;
            SqlConnection con = new SqlConnection(DbString.conString);
            try
            {
                con.Open();

                string query1 = @"SELECT CourseID, CourseName
                              FROM Courses WHERE TeacherID = @teacherID";

                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@teacherID", teacherLog);

                SqlDataReader reader = cmd1.ExecuteReader();
                listCourse = new List<CourseInfo>();
                while (reader.Read())
                {
                    //listCourse.Add((int)reader["CourseID"]);
                    listCourse.Add(new CourseInfo
                    {
                        CourseId = (int)reader["CourseID"],
                        CourseName = (string)reader["CourseName"]
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void CourseButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            CourseInfo course = (CourseInfo)clickedButton.DataContext;
            courseId = course.CourseId;
            string courseName = course.CourseName;
            LblSubject.Content = courseName;
            string query = @"SELECT Registrations.StudentID , Students.Name AS StudentName, Registrations.[Final Grade] AS Grade
                                FROM Registrations
                                        INNER JOIN Students ON Registrations.StudentID = Students.StudentID
                                        WHERE Registrations.CourseID = @courseID AND Registrations.TeacherID = @teacherID";

            DataTable dataTable = new DataTable();
            using (SqlConnection con = new SqlConnection(DbString.conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@courseID", courseId);
                    cmd.Parameters.AddWithValue("@teacherID", teacherLog);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dataTable.Load(reader);
                }
            }
            DgTeacher.ItemsSource = dataTable.DefaultView;

            // Do something with the courseId and courseName
            //MessageBox.Show("Course ID: " + courseId + ", Course Name: " + courseName + " clicked.");
            DgTeacher.IsReadOnly = false; // Enable editing


        }



        

        private void BtnFrmCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public class CourseInfo
        {
            public int CourseId { get; set; }
            public string CourseName { get; set; }
        }

        private void DgTeacher_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DgTeacher.SelectedItem != null)
            {
                DataRowView row = (DataRowView)DgTeacher.SelectedItem;
                int studentId = Convert.ToInt32(row["StudentID"]);
                string studentName = row["StudentName"].ToString();

                // Open GradeEntryWindow
                Grade gradeFrm = new Grade();
                if (gradeFrm.ShowDialog() == true)
                {
                    if (int.TryParse(gradeFrm.gradeValue, out int newGradeValue))
                    {
                        // Update the grade in the database
                        string updateQuery = @"UPDATE Registrations
                                       SET [Final Grade] = @newGradeValue
                                       WHERE CourseID = @courseID AND StudentID = @studentID AND TeacherID = @teacherID";

                        using (SqlConnection con = new SqlConnection(DbString.conString))
                        {
                            using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                            {
                                cmd.Parameters.AddWithValue("@newGradeValue", newGradeValue); // Use newGradeValue here
                                cmd.Parameters.AddWithValue("@courseID", courseId);
                                cmd.Parameters.AddWithValue("@studentID", studentId);
                                cmd.Parameters.AddWithValue("@teacherID", teacherLog);
                                con.Open();

                                int rowsAffected = cmd.ExecuteNonQuery();
                                con.Close();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show($"Grade for student {studentName} updated to {newGradeValue}", "Grade Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                else
                                {
                                    Console.WriteLine("No rows updated.");
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid integer grade.", "Invalid Grade", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a student to update the grade.", "No Student Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            TeacherDetails();
        }
    }
}
