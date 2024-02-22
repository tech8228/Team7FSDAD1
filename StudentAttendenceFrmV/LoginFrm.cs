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
    public partial class LoginFrm : Form
    {
        
        public bool logingFlag {  get; set; }
        public int UserID {  get; set; }
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.UsersTableAdapter userAda = new DataSet1TableAdapters.UsersTableAdapter();
            DataTable dt = userAda.GetDataByUserAndPass(TbxUser.Text, TbxPassword.Text);

            if (dt.Rows.Count > 0 )
            {
                //valid login
                UserID = int.Parse(dt.Rows[0]["UserID"].ToString());
                MessageBox.Show("Login OK" +UserID.ToString());
                
                logingFlag = true; 
                this.Close();
               
            }
            else
            {
                // not valid login
                MessageBox.Show("Access Denied");
                logingFlag = false;
            }
            
        }


        

        private void BtnLoginCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
