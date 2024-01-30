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
    public partial class ViewPaymentData : Form
    {
        string BillingPath = "BillingDetails.txt";
        public ViewPaymentData()
        {
            InitializeComponent();
        }

        private void GVRegistration_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ViewPaymentData_Load(object sender, EventArgs e)
        {
            BillingDL.LoadFromFile(BillingPath);
            List<BillingBL> b = BillingDL.PaymentList1;
            GVRegistration.DataSource =b.Select(c=>new { c.CustomerName}).ToList() ;
        }

        private void GVRegistration_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
