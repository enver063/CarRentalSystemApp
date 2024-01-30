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
    public partial class PaymentMethodForm : Form
    {
        RegistrationBL paymentmethod;
        public PaymentMethodForm(RegistrationBL thisformregistration)
        {
            InitializeComponent();
            paymentmethod = thisformregistration;
        }

        private void PaymentMethodForm_Load(object sender, EventArgs e)
        {

        }

        private void LinkCreditCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PaymentOptionForm moreForm = new PaymentOptionForm(paymentmethod);
            moreForm.Show();
        }

        private void LinkDebitCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PaymentOptionForm moreForm = new PaymentOptionForm(paymentmethod);
            moreForm.Show();
        }

        private void LinkJazzCash_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PaymentJazzCashForm moreForm = new PaymentJazzCashForm(paymentmethod);
            moreForm.Show();
        }

        private void linkEasyPaisa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PaymentJazzCashForm moreForm = new PaymentJazzCashForm(paymentmethod);
            moreForm.Show();
        }
    }
}
