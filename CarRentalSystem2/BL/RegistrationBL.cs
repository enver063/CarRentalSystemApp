using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem_2_.DL;

namespace CarRentalSystem_2_.BL
{
    public class RegistrationBL
    {
        private string CustomerName;
        private string CustomerAge;
        private string CustomerId;
        private string CustomerPhoneNumber;
        private string Gender;
        private string CustomerFatherName;
        private string FatherCnic;
        private string CustomerAddress;
        private string CustomerOccupation;
        private string CustomerLicense;
        //private string CustomerType;
        //private string CustomerCar;
        private List<CarBL> CustomerCarList;
        private string PickUp;
        private string Destination;
        private int KiloMeters;
        private int StartingDate;
        private int EndingDate;
        private int TotalDays;
        private float TotalRent;
        public RegistrationBL(string CustomerName, string CustomerAge, string CustomerId, string CustomerPhoneNumber, string Gender, string CustomerFatherName,string FatherCnic, string CustomerAddress, string CustomerOccupation, string CustomerLicense, List<CarBL> CustomerCarList, string PickUp, string Destination, int KiloMeters, int StartingDate, int EndingDate, int TotalDays, float TotalRent)
        {
            this.CustomerName = CustomerName;
            this.CustomerAge = CustomerAge;
            this.CustomerId = CustomerId;
            this.CustomerPhoneNumber = CustomerPhoneNumber;
            this.Gender = Gender;
            this.CustomerFatherName = CustomerFatherName;
            this.FatherCnic = FatherCnic;
            this.CustomerAddress = CustomerAddress;
            this.CustomerOccupation = CustomerOccupation;
            this.CustomerLicense = CustomerLicense;
            //this.CustomerType = CustomerType;
            //this.CustomerCar = CustomerCar;
            this.CustomerCarList = CustomerCarList;
            this.PickUp = PickUp;
            this.Destination = Destination;
            this.KiloMeters = KiloMeters;
            this.StartingDate = StartingDate;
            this.EndingDate = EndingDate;
            this.TotalDays = TotalDays;
            this.TotalRent = TotalRent;
        }
        public RegistrationBL()
        {

        }
        public string CustomerName1 { get => CustomerName; set => CustomerName = value; }
        public string CustomerAge1 { get => CustomerAge; set => CustomerAge = value; }
        public string CustomerId1 { get => CustomerId; set => CustomerId = value; }
        public string CustomerPhoneNumber1 { get => CustomerPhoneNumber; set => CustomerPhoneNumber = value; }
        public string CustomerFatherName1 { get => CustomerFatherName; set => CustomerFatherName = value; }
        public string CustomerAddress1 { get => CustomerAddress; set => CustomerAddress = value; }
        public string CustomerOccupation1 { get => CustomerOccupation; set => CustomerOccupation = value; }
        public string CustomerLicense1 { get => CustomerLicense; set => CustomerLicense = value; }
        public string PickUp1 { get => PickUp; set => PickUp = value; }
        public string Destination1 { get => Destination; set => Destination = value; }
        public int KiloMeters1 { get => KiloMeters; set => KiloMeters = value; }
        public int StartingDate1 { get => StartingDate; set => StartingDate = value; }
        public int EndingDate1 { get => EndingDate; set => EndingDate = value; }
        public int TotalDays1 { get => TotalDays; set => TotalDays = value; }
        public float TotalRent1 { get => TotalRent; set => TotalRent = value; }
        public string Gender1 { get => Gender; set => Gender = value; }
        public string FatherCnic1 { get => FatherCnic; set => FatherCnic = value; }

        //public string CustomerType1 { get => CustomerType; set => CustomerType = value; }
        //public string CustomerCar1 { get => CustomerCar; set => CustomerCar = value; }
        internal List<CarBL> CustomerCarList1 { get => CustomerCarList; set => CustomerCarList = value; }
        public bool SetCustomerId(string id)
        {
            if(id.Length>10 && id.Length<15)
            {
                return true;
            }
            return false;
        }
        public bool SetKilometers(int Kilometers)
        {
            if(KiloMeters>=0)
            {
                return true;
            }
            return false;
        }
        public List<CarBL> GetCarList()
        {
            return CustomerCarList;
        }
        public bool SetDate(int Dates)
        {
            if(Dates>0 && Dates<=31)
            {
                return true;
            }
            return false;
        }
        public static int GetTotalDays(int Starting, int Ending)
        {
            int days;
            if (Starting > Ending)
            {
                int d = 31 - Starting;
                days = d + Ending;
            }
            else
            {
                days = Ending - Starting;
            }
            return days;
        }
        public static RegistrationBL GetRegister(string CNIC)
        {
            foreach(RegistrationBL r in RegistrationDL.RegistrationList1)
            {
                if(r.CustomerId1==CNIC)
                {
                    return r;
                }
            }
            return null;
        }
    }
}
