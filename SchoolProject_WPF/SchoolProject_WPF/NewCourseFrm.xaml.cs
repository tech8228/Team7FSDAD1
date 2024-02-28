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
    /// Interaction logic for NewCourseFrm.xaml
    /// </summary>
    public partial class NewCourseFrm : Window
    {
        public NewCourseFrm()
        {
            InitializeComponent();
            List<string> listDays = new List<string>()
            {
                "Monday", "Tueday","Wednesday","Thursday","Friday"
            };
            this.LbxWeekdays.ItemsSource = listDays;
        }

        private void ResetFields()
        {
            TbxCourseName.Text = "";
            
            LbxWeekdays.SelectedItems.Clear() ;

        }
        private void BtnFrmCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnFrmRegister_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbxCourseName.Text) || (LbxWeekdays.SelectedItems.Count==0))
            {
                MessageBox.Show("Details is missing");
                return;
            }


            List<string> selectedDays = new List<string>();
            foreach (var item in LbxWeekdays.SelectedItems)
            {
                selectedDays.Add(item.ToString());
            }
            string listWeek = string.Join(",", selectedDays);
            string query = "INSERT INTO Courses (CourseName, DaysOfWeek) VALUES (@name, @daysofweek)";

            using (SqlConnection con = new SqlConnection(DbString.conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", TbxCourseName.Text);
                   
                    cmd.Parameters.AddWithValue("@DaysOfWeek", listWeek);
                    

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("You are Registered Successfully");
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
    
}
