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
    public partial class AddCarForm3 : Form
    {
        string CarPath = "CarDetails.txt";
        public AddCarForm3()
        {
            InitializeComponent();
        }
        public void ClearDataFromForm()
        {
            comboBoxCarType.Text = "";
            txtCarName.Text = "";
            txtCarColor.Text = "";
            txtLicenseNo.Text = "";
            txtCarModel.Text = "";
            txtCarRent.Text = "";
        }
        private void btnAddca_Click(object sender, EventArgs e)
        {
            CarBL Check = new CarBL();
            string CarType = comboBoxCarType.Text;
            string CarName = txtCarName.Text;
            string CarColor = txtCarColor.Text;
            string CarLicense = txtLicenseNo.Text;
            int CarModel = int.Parse(txtCarModel.Text);
            int CarRent = int.Parse(txtCarRent.Text);
            bool flag = Check.SetCarModel(CarModel);
            if(flag)
            {
                flag = Check.SetCarRent(CarRent);
                if(flag)
                {
                    CarBL c = new CarBL(CarType, CarName, CarColor, CarLicense, CarModel, CarRent);
                    CarDL.AddIntoList(c);
                    CarDL.StoreInFile(CarPath);
                    MessageBox.Show("Car Added");
                }
                else
                {
                    MessageBox.Show("Invalid Car Rent");
                }
            }
            else
            {
                MessageBox.Show("Invalid Car Model");
            }
            ClearDataFromForm();
        }

        private void AddCarForm3_Load(object sender, EventArgs e)
        {
            //CarDL.LoadFile(CarPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrationForm moreForm = new RegistrationForm();
            moreForm.Show();
        }

        private void btnUpdateCar_Click(object sender, EventArgs e)
        {
            UpdateCarForm3 moreForm = new UpdateCarForm3();
            moreForm.Show();
        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Generate Bill unless Registration is Done");
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            RegistrationForm moreForm = new RegistrationForm();
            moreForm.Show();
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

        }

        private void addCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already on this page");
        }

        private void updateCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void registerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            RegistrationForm moreForm = new RegistrationForm();
            moreForm.Show();
        }

        private void generateBillToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until registration is done");
        }

        private void addCarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until registration is done");
        }

        private void updateCarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until registration is done");
        }

        private void deleteCarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until registration is done");
        }

        private void easyPaisaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until registration is done");
        }

        private void viewRegistrationDataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            ViewRecordsForm moreForm = new ViewRecordsForm();
            moreForm.Show();
        }

        private void carsDataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            ViewCarsDataForm more = new ViewCarsDataForm();
            more.Show();
        }

        private void paymentDataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void addCarsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Already on this Page");
        }

        private void updateCarsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            UpdateCarForm3 more = new UpdateCarForm3();
            more.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void viewProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewProfileForm more = new ViewProfileForm();
            more.Show();
        }

        private void logoutToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to logout");
            this.Close();
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteAccount();
            MessageBox.Show("Account Deleted");
            this.Close();
        }
        public void DeleteAccount()
        {
            MuserDL.DeleteAccountFromList(EmployForm.Previous);
            MuserDL.StoreData("LoginDetails.txt");
        }
    }
}
