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
    public partial class CustomerBookingForm3 : Form
    {
        public CustomerBookingForm3()
        {
            InitializeComponent();
        }

        private void CustomerBookingForm3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cnic = txtCNIC.Text;
            RegistrationBL register = RegistrationBL.GetRegister(cnic);
            if (register != null)
            {
                GVRegistration.DataSource = new List<RegistrationBL> { register };
                List<CarBL> Selected = register.CustomerCarList1;
                comboBoxSelectedCars.DataSource = Selected.Select(c=>new { c.CarName}).ToList();
            }
            else
            {
                MessageBox.Show("No Bookings");
                txtCNIC.Text = "";
            }
        }
        public void DataBind()
        {
            GVRegistration.DataSource = null;
            GVRegistration.DataSource = null/*RegistrationDL.RegistrationList1*/;
            GVRegistration.Refresh();
        }
        private void GVRegistration_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RegistrationBL Register = (RegistrationBL)GVRegistration.CurrentRow.DataBoundItem;
            if(GVRegistration.Columns["CancelBooking"].Index==e.ColumnIndex)
            {
                RegistrationDL.DeleteRegisterFromList(Register);
                RegistrationDL.StoreInFile("RegistrationData.txt");
                DataBind();
                MessageBox.Show("Booking Canceled");
            }
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteAccount();
            MessageBox.Show("Account Deleted");
            this.Close();
        }
        
        public void DeleteAccount()
        {
            MuserDL.DeleteAccountFromList(CustomerMainForm.Previous);
            MuserDL.StoreData("LoginDetails.txt");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("already on this page");
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SearchCustomerCarForm3 more = new SearchCustomerCarForm3();
            more.Show();
        }

        private void viewProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewCustomerProfileForm3 more = new ViewCustomerProfileForm3();
            more.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            this.Close();
            CustomerFeedbackForm3 more = new CustomerFeedbackForm3();
            more.Show();
        }

        private void logoutToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
