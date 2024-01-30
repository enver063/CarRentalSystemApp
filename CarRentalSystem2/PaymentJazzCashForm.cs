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
    public partial class PaymentJazzCashForm : Form
    {
        string BillingPath = "BillingDetails.txt";
        RegistrationBL r;
        public PaymentJazzCashForm(RegistrationBL paymentMethod)
        {
            InitializeComponent();
            r = paymentMethod;
            txtTotalAmount.Text = (r.TotalRent1).ToString();
        }
        public void ClearDataFromForm()
        {
            txtFullName.Text = "";
            txtPhoneNo.Text = "";
            txtCNIC.Text = "";
            txtMPIN.Text = "";
        }
        private void btnProceedPayment_Click(object sender, EventArgs e)
        {
            JazzCashorEasyPaisa Check = new JazzCashorEasyPaisa();
            string Name=txtFullName.Text;
            string PhoneNumber = txtPhoneNo.Text;
            bool flag = Check.SetPhoneNumber(PhoneNumber);
            if (flag)
            {
                string CNIC = txtCNIC.Text;
                flag = Check.SetCNIC(CNIC);
                if (flag)
                {
                    string MPIN = txtMPIN.Text;
                    flag = Check.SetMPIN(MPIN);
                    if(flag)
                    {
                        JazzCashorEasyPaisa p = new JazzCashorEasyPaisa(Name, PhoneNumber, CNIC, MPIN);
                        BillingDL.AddIntoList(p);
                        BillingDL.StoreJazzCashorEasyPaisaInFile(BillingPath);
                        MessageBox.Show("Payment Proceeded");
                        ClearDataFromForm();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid MPIN");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid CNIC");
                }
            }
            else
            {
                MessageBox.Show("Invalid Phone Number");
            }

        }

        private void txtFullName_Validating(object sender, CancelEventArgs e)
        {
            if(txtFullName.Text==string.Empty)
            {
                MessageBox.Show("Name is Empty");
            }
        }

        private void txtPhoneNo_Validating(object sender, CancelEventArgs e)
        {
            if(txtPhoneNo.Text==string.Empty)
            {
                MessageBox.Show("Phone Number is Empty");
            }
        }

        private void txtCNIC_Validating(object sender, CancelEventArgs e)
        {
            if(txtCNIC.Text==string.Empty)
            {
                MessageBox.Show("CNIC is empty");
            }
        }

        private void txtMPIN_Validating(object sender, CancelEventArgs e)
        {
            if(txtMPIN.Text==string.Empty)
            {
                MessageBox.Show("MPIN is Empty");
            }
        }

        private void PaymentJazzCashForm_Load(object sender, EventArgs e)
        {

        }
    }
}
