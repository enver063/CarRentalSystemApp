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
    public partial class UpdateCarForm3 : Form
    {
        string CarPath = "CarDetails.txt";
        public UpdateCarForm3()
        {
            InitializeComponent();
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
            CarBL c = CarDL.IsCarExist(CarName);
            if(c!=null)
            {
                bool flag = Check.SetCarModel(CarModel);
                if(flag)
                {
                    flag = Check.SetCarRent(CarRent);
                    if(flag)
                    {
                        c.UpdateCar(CarType,CarName,CarColor,CarLicense,CarModel,CarRent);
                        CarDL.StoreInFile(CarPath);
                        MessageBox.Show("Car Updated");
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
            }
            else
            {
                MessageBox.Show("Invalid Car Name");
            }
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCarForm3 moreForm = new AddCarForm3();
            moreForm.Show();
        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Generate Bill unless Registration is Done");
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            RegistrationForm more = new RegistrationForm();
            more.Show();
        }

        private void generateBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until registration is done");
        }

        private void addCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until registration is done");
        }

        private void updateCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until registration is done");
        }

        private void deleteCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until registration is done");
        }

        private void easyPaisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until registration is done");
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

        private void paymentDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            AddCarForm3 more = new AddCarForm3();
            more.Show();
        }

        private void updateCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already on this page");
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
            MessageBox.Show("Are you sure you want to logout");
            this.Close();
        }

        private void viewProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewProfileForm more = new ViewProfileForm();
            more.Show();
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MuserDL.DeleteAccountFromList(EmployForm.Previous);
            MuserDL.StoreData("LoginDetails.txt");
            MessageBox.Show("Account Deleted");
            this.Close();
        }

        private void UpdateCarForm3_Load(object sender, EventArgs e)
        {

        }
    }
}
