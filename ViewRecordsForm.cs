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
    public partial class ViewRecordsForm : Form
    {
        string RegistrationPath = "RegistrationData.txt";
        public ViewRecordsForm()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        public void DataBind()
        {
            GVRegistration.DataSource = null;
            GVRegistration.DataSource = RegistrationDL.RegistrationList1;
            GVRegistration.Refresh();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RegistrationBL Register = (RegistrationBL)GVRegistration.CurrentRow.DataBoundItem;
            if(GVRegistration.Columns["Delete"].Index==e.ColumnIndex)
            {
                RegistrationDL.DeleteRegisterFromList(Register);
                RegistrationDL.StoreInFile(RegistrationPath);
                DataBind();
            }
            else if(GVRegistration.Columns["Edit"].Index == e.ColumnIndex)
            {
                RegistrationUpdate moreForm = new RegistrationUpdate(Register);
                moreForm.Show();
                RegistrationDL.StoreInFile(RegistrationPath);
                DataBind();
            }
        }

        private void ViewRecordsForm_Load(object sender, EventArgs e)
        {
            GVRegistration.DataSource = RegistrationDL.RegistrationList1;
        }

        private void paymentMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void carsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewCarsDataForm moreForm = new ViewCarsDataForm();
            moreForm.Show();
        }

        private void paymentDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            //ViewPaymentData MoreForm = new ViewPaymentData();
            //MoreForm.Show();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            RegistrationForm moreForm = new RegistrationForm();
            moreForm.Show();
        }

        private void generateBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Generate Bill until Registration is done");
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
            UpdateCarForm3 MoreForm = new UpdateCarForm3();
            MoreForm.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewFeedbackForm more = new ViewFeedbackForm();
            more.Show();
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            SearchRegisteredData MoreForm = new SearchRegisteredData();
            MoreForm.Show();
            this.Close();
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SearchcarForm moreForm = new SearchcarForm();
            moreForm.Show();
            this.Close();
        }

        private void viewProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            ViewProfileForm moreForm = new ViewProfileForm();
            moreForm.Show();
            this.Close();
        }

        private void logoutToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to Logout");
            this.Close();
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
