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
    public partial class SearchRegisteredData : Form
    {
        string RegistrationPath = "RegistrationData.txt";
        public SearchRegisteredData()
        {
            InitializeComponent();
        }
        public void DataBind()
        {
            GVRegistration.DataSource = null;
            GVRegistration.DataSource = RegistrationDL.RegistrationList1;
            GVRegistration.Refresh();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RegistrationBL Register = (RegistrationBL)GVRegistration.CurrentRow.DataBoundItem;
            if(GVRegistration.Columns["Delete"].Index==e.ColumnIndex)
            {
                RegistrationDL.DeleteRegisterFromList(Register);
                RegistrationDL.StoreInFile(RegistrationPath);
                DataBind();
            }
            else if (GVRegistration.Columns["Edit"].Index == e.ColumnIndex)
            {
                RegistrationUpdate moreForm = new RegistrationUpdate(Register);
                moreForm.Show();
                RegistrationDL.StoreInFile(RegistrationPath);
                DataBind();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string cnic = txtCNIC.Text;
            RegistrationBL register = RegistrationBL.GetRegister(cnic);
            if (register != null)
            {              
                GVRegistration.DataSource = new List<RegistrationBL>{register};
                
            }
            else
            {
                MessageBox.Show("Invalid CNIC");
                txtCNIC.Text = "";
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            RegistrationForm more = new RegistrationForm();
            more.Show();
        }

        private void generateBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until registration is done");
        }

        private void addCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until registration is done");
        }

        private void updateCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until registration is done");
        }

        private void deleteCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until registration is done");
        }

        private void easyPaisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until registration is done");
        }

        private void viewRegistrationDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewRecordsForm more = new ViewRecordsForm();
            more.Show();
        }

        private void carsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewCarsDataForm more = new ViewCarsDataForm();
            more.Show();
        }

        private void addCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            AddCarForm3 more = new AddCarForm3();
            more.Show();
        }

        private void updateCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            UpdateCarForm3 more = new UpdateCarForm3();
            more.Show();
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already on this Page");
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SearchcarForm more = new SearchcarForm();
            more.Show();
        }

        private void viewProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewProfileForm more = new ViewProfileForm();
            more.Show();
        }

        private void logoutToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MuserDL.DeleteAccountFromList(EmployForm.Previous);
            MuserDL.StoreData("LoginDetails.txt");
            MessageBox.Show("Account Deleted");
            this.Close();
        }

        private void SearchRegisteredData_Load(object sender, EventArgs e)
        {

        }
    }
}
