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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolProject_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StudentLogin_Click(object sender, RoutedEventArgs e)
        {
            var studentLoginWindow = new StudentLoginWindow();
            studentLoginWindow.Closed += (s, args) => this.Show();
            this.Hide();
            studentLoginWindow.Show();
        }

        private void AdminLogin_Click(object sender, RoutedEventArgs e)
        {
            var adminLoginWindow = new AdminLoginWindow();
            adminLoginWindow.Closed += (s, args) => this.Show();
            this.Hide();
            adminLoginWindow.Show();
        }

        private void TeacherLogin_Click(object sender, RoutedEventArgs e)
        {
            var teacherLoginWindow = new TeacherLoginWindow();
            teacherLoginWindow.Closed += (s, args) => this.Show();
            this.Hide();
            teacherLoginWindow.Show();
        }

        
        private void RegisterStudent_Click(object sender, RoutedEventArgs e)
        {
            var studentRegisterWindow = new RegStudentFrm();
            studentRegisterWindow.Closed += (s, args) => this.Show();
            this.Hide();
            studentRegisterWindow.Show();
        }
    }
}
