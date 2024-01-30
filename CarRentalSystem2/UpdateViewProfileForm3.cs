using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalSystem_2_.DL;
using CarRentalSystem_2_.BL;

namespace CarRentalSystem_2_
{
    public partial class UpdateViewProfileForm3 : Form
    {
        MuserBL User;
        public UpdateViewProfileForm3(MuserBL Previous)
        {
            InitializeComponent();
            User = Previous;
        }

        private void UpdateViewProfileForm3_Load(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            MuserBL Check = new MuserBL();
            string Email = txtEmail.Text;
            bool flag = Check.SetUserName(Email);
            if (flag)
            {
                string PassWord = txtpassword.Text;
                flag = Check.SetPassWord(PassWord);
                if (flag)
                {
                    string UserRole = comboBoxUserRole.Text;
                    MuserBL Newuser = new MuserBL(Email, PassWord, UserRole);
                    MuserDL.UpdateUser(User, Newuser);
                    MuserDL.StoreData("LoginDetails.txt");
                    MessageBox.Show("Updated");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Enter Valid Password");
                }
            }
            else
            {
                MessageBox.Show("Enter Valid Email");
            }
        }
    }
}
