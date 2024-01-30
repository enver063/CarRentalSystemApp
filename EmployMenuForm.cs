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
    public partial class EmployMenuForm : Form
    {
        MuserBL LoginUser = null;
        public EmployMenuForm(MuserBL User)
        {
            InitializeComponent();
            LoginUser = User;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //label2.Text = "Welcome " + LoginUser.GetUserName();
        }

        private void EmployMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
