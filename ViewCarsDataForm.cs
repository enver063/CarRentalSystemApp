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
    public partial class ViewCarsDataForm : Form
    {
        string CarPath = "CarDetails.txt";
        public ViewCarsDataForm()
        {
            InitializeComponent();
        }

        private void GVRegistration_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CarBL Car = (CarBL)GVRegistration.CurrentRow.DataBoundItem;
            if(GVRegistration.Columns["Delete"].Index==e.ColumnIndex)
            {
                CarDL.RemoveCarFromList(Car);
                CarDL.StoreInFile(CarPath);
                DataBind();
            }
        }
        public void DataBind()
        {
            GVRegistration.DataSource = null;
            GVRegistration.DataSource = CarDL.CarList1;
            GVRegistration.Refresh();
        }
        private void ViewCarsDataForm_Load(object sender, EventArgs e)
        {
            GVRegistration.DataSource = CarDL.CarList1;
        }

        private void viewRegistrationDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewRecordsForm moreForm = new ViewRecordsForm();
            moreForm.Show();
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
            MessageBox.Show("Cannot Generate Bill until Registration is done");
        }

        private void updateCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Generate Bill until Registration is done");
        }

        private void deleteCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Generate Bill until Registration is done");
        }

        private void easyPaisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Generate Bill until Registration is done");
        }

        private void carsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already on this page");
        }

        private void paymentDataToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            SearchcarForm moreForm = new SearchcarForm();
            moreForm.Show();
        }

        private void viewProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewProfileForm moreForm = new ViewProfileForm();
            moreForm.Show();
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
