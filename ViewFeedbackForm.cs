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
    public partial class ViewFeedbackForm : Form
    {
        public ViewFeedbackForm()
        {
            InitializeComponent();
        }
        private int xcord = 600, ycord = 300;
        private void ViewFeedbackForm_Load(object sender, EventArgs e)
        {
            if(CustomerFeedbackForm3.FeedbackList.Count>0)
            {
                for(int i=0;i<CustomerFeedbackForm3.FeedbackList.Count;i++)
                {
                    ShowFeedback(i,CustomerFeedbackForm3.FeedbackList[i]);
                }
            }
            else
            {
                MessageBox.Show("No Feedbacks yet");
            }
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MuserDL.DeleteAccountFromList(EmployForm.Previous);
            MuserDL.StoreData("LoginDetails.txt");
            MessageBox.Show("Account Deleted");
            this.Close();
        }

        private void ShowFeedback(int x,string Feedback)
        {
            TextBox txtFeedback = new TextBox();
            txtFeedback.Name = "txtFeedback" + x;
            Point p = new Point(xcord, ycord);
            txtFeedback.Location = p;
           
            
            txtFeedback.ForeColor = Color.Red;
            
            txtFeedback.Text =Feedback;
            this.Controls.Add(txtFeedback);
            //MessageBox.Show(Feedback);
            xcord = xcord + 40;
            ycord = ycord + 20;
        }
    }
}
