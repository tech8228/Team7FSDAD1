namespace StudentAttendenceFrmV
{
    partial class AddClass
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
            this.TbxAddClassName = new MetroFramework.Controls.MetroTextBox();
            this.BtnAccept = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // TbxAddClassName
            // 
            this.TbxAddClassName.Location = new System.Drawing.Point(68, 52);
            this.TbxAddClassName.Name = "TbxAddClassName";
            this.TbxAddClassName.Size = new System.Drawing.Size(346, 23);
            this.TbxAddClassName.TabIndex = 0;
            // 
            // BtnAccept
            // 
            this.BtnAccept.Location = new System.Drawing.Point(304, 105);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(110, 23);
            this.BtnAccept.TabIndex = 1;
            this.BtnAccept.Text = "Accept";
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(68, 26);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(82, 20);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Class Name";
            // 
            // AddClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(492, 253);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.TbxAddClassName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddClass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox TbxAddClassName;
        private MetroFramework.Controls.MetroButton BtnAccept;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}