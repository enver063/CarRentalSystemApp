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
    public partial class SignUp : Form
    {
        string LoginPath = "LoginDetails.txt";
        public SignUp()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void cleardatafromform()
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            comboBoxUserRole.Text = "";
        }
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            MuserBL Check = new MuserBL();
            string username = txtusername.Text;
            string password = txtpassword.Text;
            string userrole = comboBoxUserRole.Text;
            bool flag = Check.SetUserName(username);
            if (flag)
            {
                flag = Check.SetPassWord(password);
                if (flag)
                {
                    MuserBL newUser = new MuserBL(username, password, userrole);
                    MuserDL.AddUserinList(newUser);
                    MuserDL.StoreData(LoginPath);
                    MessageBox.Show("User added");
                }
                else
                {
                    MessageBox.Show("Password must be greater than 8 characters");
                }
            }
            else
            {
                MessageBox.Show("Email must be in Valid Format");
            }
            cleardatafromform();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
