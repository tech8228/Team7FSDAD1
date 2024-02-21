namespace StudentAttendenceFrmV
{
    partial class RegisterFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TbxUserName = new MetroFramework.Controls.MetroTextBox();
            this.TbxPassword = new MetroFramework.Controls.MetroTextBox();
            this.TbxConfirmPassword = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.BtnUserRegister = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // TbxUserName
            // 
            this.TbxUserName.Location = new System.Drawing.Point(43, 46);
            this.TbxUserName.Name = "TbxUserName";
            this.TbxUserName.Size = new System.Drawing.Size(363, 23);
            this.TbxUserName.TabIndex = 0;
            // 
            // TbxPassword
            // 
            this.TbxPassword.Location = new System.Drawing.Point(43, 107);
            this.TbxPassword.Name = "TbxPassword";
            this.TbxPassword.PasswordChar = '+';
            this.TbxPassword.Size = new System.Drawing.Size(363, 23);
            this.TbxPassword.TabIndex = 1;
            this.TbxPassword.Click += new System.EventHandler(this.TbxPassword_Click);
            // 
            // TbxConfirmPassword
            // 
            this.TbxConfirmPassword.Location = new System.Drawing.Point(43, 156);
            this.TbxConfirmPassword.Name = "TbxConfirmPassword";
            this.TbxConfirmPassword.PasswordChar = '+';
            this.TbxConfirmPassword.Size = new System.Drawing.Size(363, 23);
            this.TbxConfirmPassword.TabIndex = 2;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(43, 23);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(80, 20);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "User Name";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(43, 84);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(73, 20);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Password: ";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(40, 133);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(126, 20);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Confirm Password: ";
            // 
            // BtnUserRegister
            // 
            this.BtnUserRegister.Location = new System.Drawing.Point(128, 218);
            this.BtnUserRegister.Name = "BtnUserRegister";
            this.BtnUserRegister.Size = new System.Drawing.Size(180, 38);
            this.BtnUserRegister.TabIndex = 6;
            this.BtnUserRegister.Text = "Accept";
            this.BtnUserRegister.Click += new System.EventHandler(this.BtnUserRegister_Click);
            // 
            // RegisterFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(459, 330);
            this.Controls.Add(this.BtnUserRegister);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.TbxConfirmPassword);
            this.Controls.Add(this.TbxPassword);
            this.Controls.Add(this.TbxUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RegisterFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox TbxUserName;
        private MetroFramework.Controls.MetroTextBox TbxPassword;
        private MetroFramework.Controls.MetroTextBox TbxConfirmPassword;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton BtnUserRegister;
    }
}