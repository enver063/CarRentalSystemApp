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
    public partial class RegistrationUpdate : Form
    {
        int total = 0;
        List<CarBL> SelectedCarList = new List<CarBL>();
        RegistrationBL Reg;
        string gender = "", License = "";
        public RegistrationUpdate(RegistrationBL Register)
        {
            InitializeComponent();
            Reg = Register;
        }

        private void RegistrationUpdate_Load(object sender, EventArgs e)
        {
            txtCustomerName.Text = Reg.CustomerName1;
            dateTimePickerCustomerAge.Text = Reg.CustomerAge1;
            txtNationalID.Text = Reg.CustomerId1;
            txtPhoneNumber.Text = Reg.CustomerPhoneNumber1;
            
            txtFatherName.Text = Reg.CustomerFatherName1;
            txtFatherCNIC.Text = Reg.FatherCnic1;
            txtAddress.Text = Reg.CustomerAddress1;
            txtOccupation.Text = Reg.CustomerOccupation1;
            //License = "";
            //SelectedCarList.Clear();
            txtPickUpLocation.Text = Reg.PickUp1;
            txtDestination.Text = Reg.Destination1;
            txtKilometers.Text = (Reg.KiloMeters1).ToString();
            txtStartingDate.Text = (Reg.StartingDate1).ToString();
            txtEndingDate.Text = (Reg.EndingDate1).ToString();
            int TotalDays = RegistrationBL.GetTotalDays(Reg.StartingDate1, Reg.EndingDate1);
            txtTotalDays.Text = (TotalDays).ToString();
            txtTotalcarsToBeRented.Text = (Reg.CustomerCarList1.Count).ToString();
            total = Reg.CustomerCarList1.Count;
        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonFemale.Checked)
            {
                gender = "Female";
            }
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
            if(radioButtonNo.Checked)
            {
                License = "No";
            }
        }

        private void comboBoxCarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> CarNameList;
            if (comboBoxCarType.Text == "Suv")
            {
                CarNameList = CarDL.GetSUVType();
                comboBoxCarName.DataSource = CarNameList;
            }
            else if (comboBoxCarType.Text == "Sedan")
            {
                CarNameList = CarDL.GetSedanType();
                comboBoxCarName.DataSource = CarNameList;
            }
            else if (comboBoxCarType.Text == "Convertible")
            {
                CarNameList = CarDL.GetConvertibleType();
                comboBoxCarName.DataSource = CarNameList;
            }
        }

        private void comboBoxCarName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CarRent = 0;
            string CarName = comboBoxCarName.Text;
            CarRent = CarDL.RetrieveRent(CarName);
            txtCarRent.Text = (CarRent).ToString();
        }

        private void btnAddca_Click(object sender, EventArgs e)
        {
            if (total > 0)
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
            string CustomerName = txtCustomerName.Text;
            string CustomerAge = dateTimePickerCustomerAge.Text;

            string CustomerId = txtNationalID.Text;
            bool flag = Check.SetCustomerId(CustomerId);
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
                                                    RegistrationDL.EditRegisterFromList(Reg, newRegister);
                                                    //RegistrationDL.AddintoRegistrationList(newRegister);
                                                    //RegistrationDL.StoreInFile(RegistrationPath);
                                                    //Transfer = newRegister;
                                                    MessageBox.Show("Successfully Updated.");
                                                    ClearDataFromForm();
                                                    this.Close();
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

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MuserDL.DeleteAccountFromList(EmployForm.Previous);
            MuserDL.StoreData("LoginDetails.txt");
            MessageBox.Show("Account Deleted");
            this.Close();
        }

        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonMale.Checked)
            {
                gender = "Male";
            }
        }
    }
}
