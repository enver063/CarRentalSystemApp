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
    public partial class CustomerFeedbackForm3 : Form
    {
        public CustomerFeedbackForm3()
        {
            InitializeComponent();
        }
        public static List<string> FeedbackList = new List<string>();
        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string Satisfaction = "";
            string name = txtFullName.Text;
            if(radioButtonVerySatisfied.Checked)
            {
                Satisfaction = "Very Satisfied";
            }
            else if(radioButtonSatisfied.Checked)
            {
                Satisfaction = "Satisfied";
            }
            else if(radioButtonNeutral.Checked)
            {
                Satisfaction="Neutral";
            }
            else if(radioButtonUnsatisfied.Checked)
            {
                Satisfaction = "Unsatisfied";
            }
            else if(radioButtonVeryUnsatisfied.Checked)
            {
                Satisfaction = "Very Unsatisfied";
            }
            string Feedback = txtFeedback.Text;
            string total = " " + name + " is " + Satisfaction + " and its Feedback is: " + Feedback;
            FeedbackList.Add(total);
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
            this.Close();
            CustomerBookingForm3 more = new CustomerBookingForm3();
            more.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already on this page");
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

        private void logoutToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomerFeedbackForm3_Load(object sender, EventArgs e)
        {

        }
    }
}
