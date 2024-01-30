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
    public partial class SearchcarForm : Form
    {
        string CarPath = "CarDetails.txt";
        public SearchcarForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CarType = txtCarType.Text;
            string CarName = txtCarName.Text;
            CarBL Car = CarDL.RetrieveCarObject(CarType, CarName);
            if(Car!=null)
            {
                GVSearchCars.DataSource = new List<CarBL> { Car };
            }
            else
            {
                MessageBox.Show("Invalid Input");
            }
        }
        public void DataBind()
        {
            GVSearchCars.DataSource = null;
            GVSearchCars.DataSource = null;
            GVSearchCars.Refresh();
        }
        private void GVSearchCars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CarBL Car = (CarBL)GVSearchCars.CurrentRow.DataBoundItem;
            if (Car != null)
            {
                if (GVSearchCars.Columns["Delete"].Index == e.ColumnIndex)
                {
                    CarDL.RemoveCarFromList(Car);
                    CarDL.StoreInFile(CarPath);
                    DataBind();
                }
            }
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            RegistrationForm moreForm = new RegistrationForm();
            moreForm.Show();
        }

        private void generateBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot proceed until registration is done");
        }

        private void addCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot proceed until registration is done");
        }

        private void updateCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot proceed until registration is done");
        }

        private void deleteCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot proceed until registration is done");
        }

        private void easyPaisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot proceed until registration is done");
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
            MessageBox.Show("Already on this page");
        }

        private void viewProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewProfileForm more = new ViewProfileForm();
            more.Show();
        }

        private void logoutToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchcarForm_Load(object sender, EventArgs e)
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
