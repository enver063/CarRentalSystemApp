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
    public partial class RegistrationForm : Form
    {
        
        int total = 0;
        string gender = "",License="",RegistrationPath="RegistrationData.txt";
        List<CarBL> SelectedCarList = new List<CarBL>();
        RegistrationBL Transfer=null;
        bool NextForm = false;
        MuserBL Previous;
        public RegistrationForm(/*MuserBL User*/)
        {
            InitializeComponent();
            //Previous = User;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //AddCarForm3 moreForm = new AddCarForm3();
            //moreForm.Show();
            MessageBox.Show("First Complete Registration Procedure");
        }

        private void radioButtonYes_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonYes.Checked)
            {
                License = "Yes";
            }
        }

        private void radioButtonNo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNo.Checked)
            {
                License = "No";
            }
        }

        private void comboBoxCarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> CarNameList;
            if(comboBoxCarType.Text=="Suv")
            {
                CarNameList = CarDL.GetSUVType();
                comboBoxCarName.DataSource = CarNameList;
            }
            else if(comboBoxCarType.Text=="Sedan")
            {
                CarNameList = CarDL.GetSedanType();
                comboBoxCarName.DataSource = CarNameList;
            }
            else if(comboBoxCarType.Text=="Convertible")
            {
                CarNameList = CarDL.GetConvertibleType();
                comboBoxCarName.DataSource = CarNameList;
            }
        }

        private void comboBoxCarName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CarRent = 0;
            string CarName = comboBoxCarName.Text;
            CarRent= CarDL.RetrieveRent(CarName);
            txtCarRent.Text = (CarRent).ToString();
        }

      
        private void btnAddca_Click(object sender, EventArgs e)
        {
            //int count;
            
            if(total>0)
            {
                string CarType = comboBoxCarType.Text;
                string CarName = comboBoxCarName.Text;
                CarBL c = new CarBL(CarType, CarName);
                SelectedCarList.Add(c);
                MessageBox.Show("Car Rented");
                total--;
            }
            else
            {
                MessageBox.Show("All Cars are Rented");
            }
        }

        private void txtTotalcarsToBeRented_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalcarsToBeRented.Text != "")
            {
                total = int.Parse(txtTotalcarsToBeRented.Text);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //txtAddress.Text = (dateTimePicker1.MaxDate-dateTimePicker1.MinDate).ToString();
        }

        private void dateTimePickerEndingDate_ValueChanged(object sender, EventArgs e)
        {
            //txtTotalDays.Text = (dateTimePickerStartingDate.MaxDate).ToString() ;
        }
        public void ClearDataFromForm()
        {
            txtCustomerName.Text = "";
            dateTimePickerCustomerAge.Text = "";
            txtNationalID.Text = "";
            txtPhoneNumber.Text = "";
            gender = "";
            txtFatherName.Text = "";
            txtFatherCNIC.Text = "";
            txtAddress.Text = "";
            txtOccupation.Text = "";
            License = "";
            //SelectedCarList.Clear();
            txtPickUpLocation.Text = "";
            txtDestination.Text = "";
            txtKilometers.Text = "";
            txtStartingDate.Text = "";
            txtEndingDate.Text = "";
            txtTotalDays.Text = "";
            
        }
            private void btnRegistration_Click(object sender, EventArgs e)
            {
                RegistrationBL Check = new RegistrationBL();
                string CustomerName=txtCustomerName.Text;
                string CustomerAge=dateTimePickerCustomerAge.Text;
            
                string CustomerId=txtNationalID.Text;
                bool flag = Check.SetCustomerId(CustomerId);
                try
                {
                    if (flag)
                    {
                        string CustomerPhoneNumber = txtPhoneNumber.Text;
                        flag = Check.SetCustomerId(CustomerPhoneNumber);
                        if (flag)
                        {
                            string Gender = gender;
                            if (Gender != "")
                            {
                                string CustomerFatherName = txtFatherName.Text;
                                string FatherCnic = txtFatherCNIC.Text;
                                flag = Check.SetCustomerId(FatherCnic);
                                if (flag)
                                {
                                    string CustomerAddress = txtAddress.Text;
                                    string CustomerOccupation = txtOccupation.Text;
                                    string CustomerLicense = License;
                                    if (CustomerLicense != "")
                                    {
                                        if (CustomerLicense == "Yes")
                                        {
                                            //string CustomerType;
                                            //string CustomerCar;
                                            List<CarBL> CustomerCarList = SelectedCarList;
                                            if (CustomerCarList != null && CustomerCarList.Count > 0)
                                            {
                                                string PickUp = txtPickUpLocation.Text;
                                                string Destination = txtDestination.Text;
                                                flag = true;
                                                int KiloMeters = int.Parse(txtKilometers.Text);
                                                flag = Check.SetKilometers(KiloMeters);
                                                if (flag)
                                                {
                                                    int StartingDate = int.Parse(txtStartingDate.Text);
                                                    flag = Check.SetDate(StartingDate);
                                                    if (flag)
                                                    {
                                                        int EndingDate = int.Parse(txtEndingDate.Text);
                                                        flag = Check.SetDate(EndingDate);
                                                        if (flag)
                                                        {
                                                            int TotalDays = RegistrationBL.GetTotalDays(StartingDate, EndingDate);

                                                            float TotalRent = TotalDays * CarBL.GetCarRent(CustomerCarList);
                                                            RegistrationBL newRegister = new RegistrationBL(CustomerName, CustomerAge, CustomerId, CustomerPhoneNumber, gender, CustomerFatherName, FatherCnic, CustomerAddress, CustomerOccupation, CustomerLicense, CustomerCarList, PickUp, Destination, KiloMeters, StartingDate, EndingDate, TotalDays, TotalRent);
                                                            RegistrationDL.AddintoRegistrationList(newRegister);
                                                            RegistrationDL.StoreInFile(RegistrationPath);
                                                            Transfer = newRegister;
                                                            MessageBox.Show("Successfully Registered.Proceed to Generate Bill");
                                                            NextForm = true;
                                                            ClearDataFromForm();
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Invalid Ending Date");
                                                            txtEndingDate.Text = "";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Invalid Starting Date");
                                                        txtStartingDate.Text = "";
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Enter valid Kilometers");
                                                    txtKilometers.Text = "";
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("No Cars selected yet");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("You are not Eligible to rent this car");

                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Select License");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Enter Valid Father CNIC");
                                    txtFatherCNIC.Text = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("Select Gender");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter Valid Phone Number");
                            txtPhoneNumber.Text = "";
                        }
                    }

                    else
                    {
                        MessageBox.Show("Enter Valid National ID");
                        txtNationalID.Text = "";
                    }
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.ToString());
                }
            }

            private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
            {
                if(radioButtonMale.Checked)
                {
                    gender = "Male";
                }
            }

            private void txtEndingDate_TextChanged(object sender, EventArgs e)
            {
                if (txtStartingDate.Text != "" && txtEndingDate.Text!="")
                {
                    int starting = int.Parse(txtStartingDate.Text);
                    int ending = int.Parse(txtEndingDate.Text);
                    txtTotalDays.Text = (RegistrationBL.GetTotalDays(starting,ending)).ToString();
                }
            }

        private void txtNationalID_TextChanged(object sender, EventArgs e)
        {
            //RegistrationBL r = new RegistrationBL();
            //bool flag= r.SetCustomerId(txtNationalID.Text);
            //if(!flag)
            //{
            //    MessageBox.Show("Enter Valid National ID");
            //    txtNationalID.Text = "";
            //}
        }

        private void txtNationalID_Click(object sender, EventArgs e)
        {
            
        }

        private void txtCustomerName_Validating(object sender, CancelEventArgs e)
        {
            if(txtCustomerName.Text==string.Empty)
            {
                MessageBox.Show("Full Name is Empty");
            }
        }

        private void txtNationalID_Validating(object sender, CancelEventArgs e)
        {
            if(txtNationalID.Text==string.Empty)
            {
                MessageBox.Show("National Id is empty");
            }
            //RegistrationBL r = new RegistrationBL();
            //bool flag = r.SetCustomerId(txtNationalID.Text);
            //if (flag == false)
            //{
            //    MessageBox.Show("Enter Valid National ID");
            //    txtNationalID.Text = "";
            //}
        }

        private void txtNationalID_Validated(object sender, EventArgs e)
        {
            
        }

        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if(txtPhoneNumber.Text==string.Empty)
            {
                MessageBox.Show("Phone Number is Empty");
            }
        }

        private void dateTimePickerCustomerAge_Validating(object sender, CancelEventArgs e)
        {
            if(dateTimePickerCustomerAge.Text==string.Empty)
            {
                MessageBox.Show("Select Date of Birth");
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if(txtAddress.Text==string.Empty)
            {
                MessageBox.Show("Address is Empty");
            }
        }

        private void txtFatherName_Validating(object sender, CancelEventArgs e)
        {
            if(txtFatherName.Text==string.Empty)
            {
                MessageBox.Show("Father Name is Empty");
            }
        }

        private void txtFatherCNIC_Validating(object sender, CancelEventArgs e)
        {
            if(txtFatherCNIC.Text==string.Empty)
            {
                MessageBox.Show("Father CNIC is Empty");
            }
        }

        private void txtOccupation_Validating(object sender, CancelEventArgs e)
        {
            if(txtOccupation.Text==string.Empty)
            {
                MessageBox.Show("Occupation is Empty");
            }
        }

        private void txtTotalcarsToBeRented_Validating(object sender, CancelEventArgs e)
        {
            if(txtTotalcarsToBeRented.Text==string.Empty)
            {
                MessageBox.Show("Select Total no of Cars");
            }
        }

        private void txtPickUpLocation_Validating(object sender, CancelEventArgs e)
        {
            if(txtPickUpLocation.Text==string.Empty)
            {
                MessageBox.Show("Pick Up location is Empty");
            }
        }

        private void txtDestination_Validating(object sender, CancelEventArgs e)
        {
            if(txtDestination.Text==string.Empty)
            {
                MessageBox.Show("Destination is Empty");
            }
        }

        private void txtKilometers_Validating(object sender, CancelEventArgs e)
        {
            if(txtKilometers.Text==string.Empty)
            {
                MessageBox.Show("Enter Kilometers");
            }
        }

        private void txtStartingDate_Validating(object sender, CancelEventArgs e)
        {
            if(txtStartingDate.Text==string.Empty)
            {
                MessageBox.Show("Enter Starting Date");
            }
        }

        private void txtEndingDate_Validating(object sender, CancelEventArgs e)
        {
            if(txtEndingDate.Text==string.Empty)
            {
                MessageBox.Show("Enter Ending Date");
            }
        }

        private void txtTotalDays_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTotalDays_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //GenerateBillForm MoreForm = new GenerateBillForm(Transfer);
            //MoreForm.Show();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPaymentMethod_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Cannot Proceed until the bill is generated");
        }

        private void btnUpdateCar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First Complete Registration Procedure");
        }

        private void btnViewRecords_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First Complete Registration Procedure");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First Complete Registration Procedure");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First Complete Registration Procedure");
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First Complete Registration Procedure");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already on this Page");
        }

        private void generateBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NextForm == true)
            {
                this.Hide();
                GenerateBillForm MoreForm = new GenerateBillForm(Transfer);
                MoreForm.Show();
            }
            else
            {
                MessageBox.Show("First Complete Registration Process");
            }
        }

        private void addCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until the bill is generated");
        }

        private void updateCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until the bill is generated");
        }

        private void deleteCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until the bill is generated");
        }

        private void easyPaisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot Proceed until the bill is generated");
        }

        private void viewRegistrationDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First Complete Registration Process");
        }

        private void carsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First Complete Registration Process");
        }

        private void paymentDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First Complete Registration Process");
        }

        private void addCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First Complete Registration Process");
        }

        private void updateCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First Complete Registration Process");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First Complete Registration Process");
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First Complete Registration Process");
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First Complete Registration Process");
        }

        private void logoutToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to logout");
            this.Close();
        }

        private void viewProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First Complete Registration Process");
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MuserDL.DeleteAccountFromList(EmployForm.Previous);
            MuserDL.StoreData("LoginDetails.txt");
            MessageBox.Show("Account Deleted");
            this.Close();
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonFemale.Checked)
            {
                gender = "Female";
            }
        }
    }
}
