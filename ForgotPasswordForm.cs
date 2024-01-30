using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalSystem_2_.BL;
using CarRentalSystem_2_.DL;

namespace CarRentalSystem_2_
{
    public partial class ForgotPasswordForm : Form
    {
        string LoginPath = "LoginDetails.txt";
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }
        private void ClearDataFromForm()
        {
            txtusername.Text = "";
            txtNewPassword.Text = "";
            txtConfirmNewPassword.Text = "";
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnChangePassword_Click_1(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            MuserBL user = MuserDL.IsValidUserName(username);
            if (user != null)
            {
                string newPassword = txtNewPassword.Text;
                bool flag = user.SetPassWord(newPassword);
                if (flag)
                {
                    if (txtNewPassword.Text == txtConfirmNewPassword.Text)
                    {
                        user.SetPassWord(txtNewPassword.Text);
                        MuserDL.StoreData(LoginPath);
                        MessageBox.Show("Password changed successfully");
                    }
                    else
                    {
                        MessageBox.Show("Both passwords are not same");
                    }
                }
                else
                {
                    MessageBox.Show("Password must be greater tha 8 characters");
                }
            }
            else
            {
                MessageBox.Show("Username is not valid");
            }
            ClearDataFromForm();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
