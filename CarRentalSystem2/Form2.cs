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
    public partial class Form2 : Form
    {
        string LoginPath = "LoginDetails.txt";
        string CarPath = "CarDetails.txt";
        string RegistrationPath = "RegistrationData.txt";
        string BillingPath = "BillingDetails.txt";
        public Form2()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void clearDataFromForm()
        {
            txtusername.Text = "";
            txtpassword.Text = "";
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
        }

        private void linkCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MuserDL.LoadData(LoginPath);
            CarDL.LoadFile(CarPath);
            RegistrationDL.LoadFromFile(RegistrationPath);
            BillingDL.LoadFromFile(BillingPath);
        }

        private void linkCreateAccount_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp MoreForm = new SignUp();
            MoreForm.Show();
        }

        private void btnSignIn_Click_1(object sender, EventArgs e)
        {
            MuserBL Check = new MuserBL();
            string username = txtusername.Text;
            string password = txtpassword.Text;
            bool flag = Check.SetUserName(username);
            if (flag)
            {
                flag = Check.SetPassWord(password);
                if (flag)
                {
                    MuserBL user = new MuserBL(username, password);
                    MuserBL validuser = MuserDL.SignIn(user);
                    if (validuser != null)
                    {
                        string status = validuser.check();
                        if (status == "admin")
                        {
                            MessageBox.Show("You Are Admin");
                        }
                        else if (status == "customer")
                        {
                            CustomerMainForm more = new CustomerMainForm(validuser);
                            more.Show();
                        }
                        else if (status == "employe")
                        {
                            EmployForm moreForm = new EmployForm(validuser);
                            moreForm.Show();
                            //MessageBox.Show("you are employe");
                        }
                        else
                        {
                            MessageBox.Show("invalid username and password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("invalid username and password");
                    }
                }
                else
                {
                    MessageBox.Show("Password must be greater than 8 characters");
                }
            }
            else
            {
                MessageBox.Show("Email must be Valid Format");
            }
            clearDataFromForm();

        }

        private void linkForgotPassword_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordForm moreform = new ForgotPasswordForm();
            moreform.Show();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
