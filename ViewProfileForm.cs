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
    public partial class ViewProfileForm : Form
    {
        //MuserBL Previous;
        public ViewProfileForm()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewProfileForm_Load(object sender, EventArgs e)
        {
            MuserBL User= EmployForm.Previous;
            txtEmail.Text = User.UserName1;
            txtpassword.Text = User.GetPassWord();
            txtUserRole.Text = User.GetUserRole();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            //this.Close();
            UpdateViewProfileForm3 moreForm = new UpdateViewProfileForm3(EmployForm.Previous);
            moreForm.Show();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            RegistrationForm more = new RegistrationForm();
            more.Show();
        }

        private void generateBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until Registration is done");
        }

        private void addCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until Registration is done");
        }

        private void updateCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until Registration is done");
        }

        private void deleteCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until Registration is done");
        }

        private void easyPaisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until Registration is done");
        }

        private void viewRegistrationDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewRecordsForm more = new ViewRecordsForm();
            more.Show();
        }

        private void carsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewCarsDataForm more = new ViewCarsDataForm();
            more.Show();
        }

        private void addCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            AddCarForm3 more = new AddCarForm3();
            more.Show();
        }

        private void updateCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            UpdateCarForm3 more = new UpdateCarForm3();
            more.Show();
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            SearchRegisteredData more = new SearchRegisteredData();
            more.Show();
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SearchcarForm more = new SearchcarForm();
            more.Show();
        }

        private void logoutToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already on this page");
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MuserDL.DeleteAccountFromList(EmployForm.Previous);
            MuserDL.StoreData("LoginDetails.txt");
            MessageBox.Show("Account Deleted");
            this.Close();
        }
    }
}
