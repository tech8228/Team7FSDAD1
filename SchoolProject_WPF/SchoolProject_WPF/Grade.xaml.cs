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
using System.Windows.Shapes;

namespace SchoolProject_WPF
{
    /// <summary>
    /// Interaction logic for Grade.xaml
    /// </summary>
    public partial class Grade : Window
    {
        public string gradeValue { get; set; }
        public Grade()
        {
            InitializeComponent();
        }

        private void BtnGradeUpdate_Click(object sender, RoutedEventArgs e)
        {
            gradeValue =  TbxGrade.Text;
            DialogResult = true;
        }

        private void BtnGradeCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
