using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem_2_.BL;
using System.IO;

namespace CarRentalSystem_2_.DL
{
    class RegistrationDL
    {
        private static List<RegistrationBL> RegistrationList = new List<RegistrationBL>();

        internal static List<RegistrationBL> RegistrationList1 { get => RegistrationList; set => RegistrationList = value; }

        public static void AddintoRegistrationList(RegistrationBL r)
        {
            RegistrationList.Add(r);
        }
        public static void StoreInFile(string Path)
        {
            StreamWriter FileVar = new StreamWriter(Path);
            foreach (RegistrationBL r in RegistrationList)
            {
                string CustomerName = r.CustomerName1;
                string CustomerAge = r.CustomerAge1;
                string CustomerId = r.CustomerId1;
                string CustomerPhoneNumber = r.CustomerPhoneNumber1;
                string Gender = r.Gender1;
                string CustomerFatherName = r.CustomerFatherName1;
                string FatherCnic = r.FatherCnic1;
                string CustomerAddress = r.CustomerAddress1;
                string CustomerOccupation = r.CustomerOccupation1;
                string CustomerLicense = r.CustomerLicense1;
                //string CustomerType=r.CustomerType1;
                //string CustomerCar=r.CustomerCar1;
                string CarName = "";
                for (int i = 0; i < r.CustomerCarList1.Count - 1; i++)
                {
                    CarName = CarName + r.CustomerCarList1[i].CarName + ";";
                }
                CarName = CarName + r.CustomerCarList1[r.CustomerCarList1.Count - 1].CarName;
                string PickUp=r.PickUp1;
                string Destination=r.Destination1;
                int KiloMeters=r.KiloMeters1;
                int StartingDate=r.StartingDate1;
                int EndingDate=r.EndingDate1;
                int TotalDays=r.TotalDays1;
                float TotalRent=r.TotalRent1;
                FileVar.WriteLine(CustomerName + "|" + CustomerAge + "|" + CustomerId + "|" + CustomerPhoneNumber+"|"+Gender + "|" + CustomerFatherName+"|"+FatherCnic + "|" + CustomerAddress + "|" + CustomerOccupation + "|" + CustomerLicense + "|" + CarName +"|"+PickUp+"|"+Destination+"|"+KiloMeters+"|"+StartingDate+"|"+EndingDate+"|"+TotalDays+"|"+TotalRent);
                FileVar.Flush();
            }
            FileVar.Close();
        }
        public static void LoadFromFile(string path)
        {
            if (File.Exists(path))
            {
                StreamReader FileVar = new StreamReader(path);
                string Record = "";
                while ((Record = FileVar.ReadLine()) != null)
                {
                    string[] SplittedRecord = Record.Split('|');
                    string CustomerName = SplittedRecord[0];
                    string CustomerAge = SplittedRecord[1];
                    string CustomerId = SplittedRecord[2];
                    string CustomerPhoneNumber = SplittedRecord[3];
                    string Gender = SplittedRecord[4];
                    string CustomerFatherName = SplittedRecord[5];
                    string FatherCnic = SplittedRecord[6];
                    string CustomerAddress = SplittedRecord[7];
                    string CustomerOccupation = SplittedRecord[8];
                    string CustomerLicense = SplittedRecord[9];
                    //string CustomerType = SplittedRecord[8];
                    //string CustomerCar = SplittedRecord[9];
                    string[] SplittedRecordforCar = SplittedRecord[10].Split(';');
                    List<CarBL> CustomerCarList = new List<CarBL>();
                    for (int i = 0; i < SplittedRecordforCar.Length; i++)
                    {
                        CarBL c = CarDL.IsCarExist(SplittedRecordforCar[i]);
                        if (c != null)
                        {
                            CustomerCarList.Add(c);
                        }
                        else
                        {
                            Console.WriteLine("Car DoesNot Exist");
                        }
                    }
                    string PickUp=SplittedRecord[11];
                    string Destination=SplittedRecord[12];
                    int KiloMeters=int.Parse(SplittedRecord[13]);
                    int StartingDate=int.Parse(SplittedRecord[14]);
                    int EndingDate=int.Parse(SplittedRecord[15]);
                    int TotalDays=int.Parse(SplittedRecord[16]);
                    float TotalRent=float.Parse(SplittedRecord[17]);
                    RegistrationBL r = new RegistrationBL(CustomerName, CustomerAge, CustomerId, CustomerPhoneNumber,Gender, CustomerFatherName,FatherCnic, CustomerAddress, CustomerOccupation, CustomerLicense, CustomerCarList,PickUp,Destination,KiloMeters,StartingDate,EndingDate,TotalDays,TotalRent);
                    AddintoRegistrationList(r);
                }
                FileVar.Close();
            }
        }
        public static void DeleteRegisterFromList(RegistrationBL Register)
        {
            for(int i=0;i<RegistrationList.Count;i++)
            {
                if(RegistrationList[i].CustomerName1==Register.CustomerName1 && RegistrationList[i].CustomerId1==Register.CustomerId1)
                {
                    RegistrationList.RemoveAt(i);
                }
            }
        }
        public static void EditRegisterFromList(RegistrationBL Previous,RegistrationBL Updated)
        {
            foreach(RegistrationBL r in RegistrationList)
            {
                if(r.CustomerName1==Previous.CustomerName1 && r.CustomerId1==Previous.CustomerId1)
                {
                    r.CustomerName1 = Updated.CustomerName1;
                    r.CustomerAge1 = Updated.CustomerAge1;
                    r.CustomerId1 = Updated.CustomerId1;
                    r.CustomerPhoneNumber1 = Updated.CustomerPhoneNumber1;
                    r.Gender1 = Updated.Gender1;
                    r.CustomerFatherName1 = Updated.CustomerFatherName1;
                    r.FatherCnic1 = Updated.FatherCnic1;
                    r.CustomerAddress1 = Updated.CustomerAddress1;
                    r.CustomerOccupation1 = Updated.CustomerOccupation1;
                    r.CustomerLicense1 = Updated.CustomerLicense1;
                    r.CustomerCarList1 = Updated.CustomerCarList1;
                    r.PickUp1 = Updated.PickUp1;
                    r.Destination1 = Updated.Destination1;
                    r.KiloMeters1 = Updated.KiloMeters1;
                    r.StartingDate1 = Updated.StartingDate1;
                    r.EndingDate1 = Updated.EndingDate1;
                    r.TotalRent1 = Updated.TotalRent1;

                }
            }
        }
    }
}
