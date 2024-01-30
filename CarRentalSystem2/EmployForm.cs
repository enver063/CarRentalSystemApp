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
        public partial class EmployForm : Form
        {
            public static MuserBL Previous;
        
            public EmployForm(MuserBL User)
            {
                InitializeComponent();
                Previous = User;
            }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            //AddCarForm3 moreForm = new AddCarForm3();
            //moreForm.Show();
        }

        private void btnUpdateCar_Click(object sender, EventArgs e)
        {
            //UpdateCarForm3 moreForm = new UpdateCarForm3();
            //moreForm.Show();
        }

        private void EmployForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            
        }

        private void btnViewRecords_Click(object sender, EventArgs e)
        {
            //ViewRecordsForm moreForm = new ViewRecordsForm();
            //moreForm.Show();
        }

        private void regToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            RegistrationForm moreForm = new RegistrationForm();
            moreForm.Show();
        }

        private void generateBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Generate Bill Unless Registration is Done");
        }

        private void addCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until Registration is Done");
        }

        private void updateCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until Registration is Done");
        }

        private void deleteCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until Registration is Done");
        }

        private void easyPaisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until Registration is Done");
        }

        private void viewRegistrationDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewRecordsForm moreForm = new ViewRecordsForm();
            moreForm.Show();
        }

        private void carsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewCarsDataForm moreForm = new ViewCarsDataForm();
            moreForm.Show();
        }

        private void paymentDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewPaymentData moreForm = new ViewPaymentData();
            moreForm.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            AddCarForm3 moreForm = new AddCarForm3();
            moreForm.Show();
        }

        private void updateCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            UpdateCarForm3 moreForm = new UpdateCarForm3();
            moreForm.Show();
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            SearchRegisteredData moreForm = new SearchRegisteredData();
            moreForm.Show();
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SearchcarForm MoreForm = new SearchcarForm();
            MoreForm.Show();
        }

        private void viewProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            ViewProfileForm moreForm = new ViewProfileForm();
            moreForm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void logoutToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you Sure you want to Logout");
            this.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
