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
    public partial class ViewCustomerProfileForm3 : Form
    {
        public ViewCustomerProfileForm3()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            UpdateViewProfileForm3 more = new UpdateViewProfileForm3(CustomerMainForm.Previous);
            more.Show();
        }

        private void ViewCustomerProfileForm3_Load(object sender, EventArgs e)
        {
            MuserBL User = CustomerMainForm.Previous;
            txtEmail.Text = User.UserName1;
            txtpassword.Text = User.GetPassWord();
            txtUserRole.Text = User.GetUserRole();
            
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MuserDL.DeleteAccountFromList(CustomerMainForm.Previous);
            MuserDL.StoreData("LoginDetails.txt");
            MessageBox.Show("Account Deleted");
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

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

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SearchCustomerCarForm3 more = new SearchCustomerCarForm3();
            more.Show();
        }

        private void logoutToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
