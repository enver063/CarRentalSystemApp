using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalSystem_2_.BL;
using CarRentalSystem_2_.DL;

namespace CarRentalSystem_2_
{
    public partial class GenerateBillForm : Form
    {
        RegistrationBL thisformregistration;
        bool Proceed = false;
        public GenerateBillForm(RegistrationBL Transfer)
        {
            InitializeComponent();
            thisformregistration = Transfer;
            SetValues(Transfer);
        }

        private void GenerateBillForm_Load(object sender, EventArgs e)
        {

        }
        public void SetValues(RegistrationBL Transfer)
        {
            txtCustomerName.Text = Transfer.CustomerName1;
            txtCustomerID.Text = Transfer.CustomerId1;
            txtCustomerPhoneNumber.Text = Transfer.CustomerPhoneNumber1;
            txtFatherName.Text = Transfer.CustomerFatherName1;
            txtAddress.Text = Transfer.CustomerAddress1;
            txtCustomerPickUp.Text = Transfer.PickUp1;
            txtCustomerDestination.Text = Transfer.Destination1;
            int startingDate = Transfer.StartingDate1;
            int EndingDate = Transfer.EndingDate1;
            int TotalDays = RegistrationBL.GetTotalDays(startingDate, EndingDate);
            txtTotalDays.Text = TotalDays.ToString();
            List<CarBL> SelectedCarList = Transfer.CustomerCarList1;
            comboBoxCarSelected.DataSource = SelectedCarList.Select(c=>new {c.CarName}).ToList();

        }

        private void btnAddca_Click(object sender, EventArgs e)
        {
            txttotalamount.Text = (thisformregistration.TotalRent1).ToString();
            MessageBox.Show("Proceed to payment method");
            Proceed = true;
        }

        private void btnPaymentMethod_Click(object sender, EventArgs e)
        {
            this.Hide();
            PaymentMethodForm moreForm = new PaymentMethodForm(thisformregistration);
            moreForm.Show();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First Complete Payment Method");
        }

        private void generateBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already on this Page");
        }

        private void addCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Proceed==true)
            {
                //this.Close();
                PaymentOptionForm moreForm = new PaymentOptionForm(thisformregistration);
                moreForm.Show();
                Proceed = false;
            }
            else
            {
                MessageBox.Show("First Generate Total");
            }
        }

        private void updateCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Proceed == true)
            {
                //this.Close();
                PaymentOptionForm moreForm = new PaymentOptionForm(thisformregistration);
                moreForm.Show();
            }
            else
            {
                MessageBox.Show("First Generate Total");
            }
        }

        private void deleteCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Proceed==true)
            {
                //this.Close();
                PaymentJazzCashForm moreForm = new PaymentJazzCashForm(thisformregistration);
                moreForm.Show();
            }
            else
            {
                MessageBox.Show("First Generate Total");
            }
        }

        private void easyPaisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Proceed == true)
            {
                //this.Close();
                PaymentJazzCashForm moreForm = new PaymentJazzCashForm(thisformregistration);
                moreForm.Show();
            }
            else
            {
                MessageBox.Show("First Generate Total");
            }
        }

        private void viewRegistrationDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Proceed == true)
            {
                this.Close();
                ViewRecordsForm more = new ViewRecordsForm();
                more.Show();
            }
            else
            {
                MessageBox.Show("First Complete Payment Method");
            }
        }

        private void carsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Proceed == true)
            {
                this.Close();
                ViewCarsDataForm more = new ViewCarsDataForm();
                more.Show();
            }
            else
            {
                MessageBox.Show("First Complete Payment Method");
            }
        }

        private void paymentDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Proceed == true)
            {

            }
            else
            {
                MessageBox.Show("First Complete Payment Method");
            }
        }

        private void addCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Proceed == true)
            {
                this.Close();
                AddCarForm3 more = new AddCarForm3();
                more.Show();
            }
            else
            {
                MessageBox.Show("First Complete Payment Method");
            }
        }

        private void updateCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Proceed == true)
            {
                this.Close();
                UpdateCarForm3 more = new UpdateCarForm3();
                more.Show();
            }
            else
            {
                MessageBox.Show("First Complete Payment Method");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Proceed == true)
            {

            }
            else
            {
                MessageBox.Show("First Complete Payment Method");
            }
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Proceed == true)
            {
                this.Close();
                SearchRegisteredData more = new SearchRegisteredData();
                more.Show();
            }
            else
            {
                MessageBox.Show("First Complete Payment Method");
            }
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Proceed == true)
            {
                this.Close();
                SearchcarForm more = new SearchcarForm();
                more.Show();
            }
            else
            {
                MessageBox.Show("First Complete Payment Method");
            }
        }

        private void viewProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Proceed == true)
            {
                this.Close();
                ViewProfileForm more = new ViewProfileForm();
                more.Show();
            }
            else
            {
                MessageBox.Show("First Complete Payment Method");
            }
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
