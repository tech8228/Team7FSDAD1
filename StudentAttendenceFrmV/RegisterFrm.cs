using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentAttendenceFrmV
{
    public partial class RegisterFrm : Form
    {
        public RegisterFrm()
        {
            InitializeComponent();
        }

        private void TbxPassword_Click(object sender, EventArgs e)
        {

        }

        private void BtnUserRegister_Click(object sender, EventArgs e)
        {
            if (TbxPassword.Text != TbxConfirmPassword.Text)
            {
                MessageBox.Show("Password did not Match");
                return;
            }
            DataSet1TableAdapters.UsersTableAdapter ada = new DataSet1TableAdapters.UsersTableAdapter();
            ada.InsertQuery(TbxUserName.Text, TbxPassword.Text);
            MessageBox.Show("Registration Succesfull");
            Close();

        }
    }
}
