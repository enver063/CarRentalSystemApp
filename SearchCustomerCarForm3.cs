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
    public partial class SearchCustomerCarForm3 : Form
    {
        public SearchCustomerCarForm3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CarType = txtCarType.Text;
            string CarName = txtCarName.Text;
            CarBL Car = CarDL.RetrieveCarObject(CarType, CarName);
            if (Car != null)
            {
                GVSearchCars.DataSource = new List<CarBL> { Car };
            }
            else
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void GVSearchCars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearchCustomerCarForm3_Load(object sender, EventArgs e)
        {

        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MuserDL.DeleteAccountFromList(CustomerMainForm.Previous);
            MuserDL.StoreData("LoginDetails.txt");
            MessageBox.Show("Account Deleted");
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
            CustomerBookingForm3 more = new CustomerBookingForm3();
            more.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            this.Close();
            CustomerFeedbackForm3 more = new CustomerFeedbackForm3();
            more.Show();
        }

        private void viewProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewCustomerProfileForm3 more = new ViewCustomerProfileForm3();
            more.Show();
        }

        private void logoutToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
