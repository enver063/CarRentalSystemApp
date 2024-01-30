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
    public partial class CustomerMainForm : Form
    {
        string LoginPath = "LoginDetails.txt";
        public static MuserBL Previous;
        public CustomerMainForm(MuserBL user)
        {
            InitializeComponent();
            Previous = user;
        }

        private void logoutToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            CustomerFeedbackForm3 more = new CustomerFeedbackForm3();
            more.Show();
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteAccount();
            MessageBox.Show("Account Deleted");
            this.Close();
        }
        public void DeleteAccount()
        {
            MuserDL.DeleteAccountFromList(Previous);
            MuserDL.StoreData(LoginPath);
        }

        private void viewProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewCustomerProfileForm3 more = new ViewCustomerProfileForm3();
            more.Show();
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SearchCustomerCarForm3 more = new SearchCustomerCarForm3();
            more.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
            CustomerBookingForm3 more = new CustomerBookingForm3();
            more.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomerMainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
