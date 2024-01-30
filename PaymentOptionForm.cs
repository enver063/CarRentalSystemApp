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
    public partial class PaymentOptionForm : Form
    {
        string BillingPath = "BillingDetails.txt";
        RegistrationBL r;
        public PaymentOptionForm(RegistrationBL paymentMethod)
        {
            InitializeComponent();
            r = paymentMethod;
            txtTotalAmount.Text = (r.TotalRent1).ToString();
        }
        public void ClearDataFromForm()
        {
            txtAccountNo.Text = "";
            txtCVV.Text = "";
            txtFullName.Text = "";
            txtTotalAmount.Text = "";
            ExpiryDateYear.Text = "";
        }
        private void btnProceedPayment_Click(object sender, EventArgs e)
        {
            CreditorDebitCard check = new CreditorDebitCard();
            string name = txtFullName.Text;
            string AccountNo = txtAccountNo.Text;
            bool flag = check.SetAccountNo(AccountNo);
            if (flag)
            {
                string expiry = ExpiryDateYear.Text;
                if (expiry != "")
                {
                    string cvv = txtCVV.Text;
                    flag = check.SetCVV(cvv);
                    if (flag)
                    {
                        CreditorDebitCard c = new CreditorDebitCard(name, AccountNo, expiry, cvv);
                        BillingDL.AddIntoList(c);
                        BillingDL.StoreCreditorDebitCardInFile(BillingPath);
                        MessageBox.Show("Transaction Successfully");
                        ClearDataFromForm();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid CVV");
                        txtCVV.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Enter Expiry ");
                }
            }
            else
            {
                MessageBox.Show("Invalid Account No");
                txtAccountNo.Text = "";
            }
        }

        private void txtFullName_Validating(object sender, CancelEventArgs e)
        {
            if(txtFullName.Text==string.Empty)
            {
                MessageBox.Show("Name is Empty");
            }
        }

        private void txtAccountNo_Validating(object sender, CancelEventArgs e)
        {
            if(txtAccountNo.Text==string.Empty)
            {
                MessageBox.Show("Account No is Empty");
            }
        }

        private void txtCVV_Validating(object sender, CancelEventArgs e)
        {
            if(txtCVV.Text==string.Empty)
            {
                MessageBox.Show("CVV is Empty");
            }
        }

        private void PaymentOptionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
