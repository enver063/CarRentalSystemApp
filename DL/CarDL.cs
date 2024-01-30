using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem_2_.BL;
using System.IO;

namespace CarRentalSystem_2_.DL
{
    class CarDL
    {
        private static List<CarBL> CarList = new List<CarBL>();

        internal static List<CarBL> CarList1 { get => CarList; set => CarList = value; }

        public static List<CarBL> GetCarList()
        {
            return CarList;
        }
        public static void AddIntoList(CarBL c)
        {
            CarList.Add(c);
        }
        public static void StoreInFile(string path)
        {
            StreamWriter FileVar = new StreamWriter(path);
            foreach (CarBL c in CarList)
            {
                FileVar.WriteLine(c.CarType + "," + c.CarName + "," + c.CarColor + "," + c.CarLicense + "," + c.CarModel1 + "," + c.CarRent);
                FileVar.Flush();
            }
            FileVar.Close();
        }
        public static void LoadFile(string Path)
        {
            if (File.Exists(Path))
            {
                StreamReader FileVar = new StreamReader(Path);
                string Record = "";
                while ((Record = FileVar.ReadLine()) != null)
                {
                    string[] SplittedRecord = Record.Split(',');
                    String carType = SplittedRecord[0];
                    String carName = SplittedRecord[1];
                    String carColor = SplittedRecord[2];
                    String carLicense = SplittedRecord[3];
                    int carModel = int.Parse(SplittedRecord[4]);
                    int carRent = int.Parse(SplittedRecord[5]);
                    CarBL c = new CarBL(carType, carName, carColor, carLicense, carModel, carRent);
                    AddIntoList(c);
                }
                FileVar.Close();
            }

        }
        public static List<string> GetSedanType()
        {
            List<string> SedanList = new List<string>();
            foreach (CarBL c in CarList)
            {
                if (c.CarType == "Sedan" || c.CarType == "sedan" || c.CarType == "SEDAN")
                {
                    SedanList.Add(c.CarName);
                }
            }
            return SedanList;
        }
        public static List<string> GetSUVType()
        {
            List<string> SUVList = new List<string>();
            foreach (CarBL c in CarList)
            {
                if (c.CarType == "SUV" || c.CarType == "suv" || c.CarType == "Suv")
                {
                    SUVList.Add(c.CarName);
                }
            }
            return SUVList;
        }
        public static List<string> GetConvertibleType()
        {
            List<string> ConvertibleList = new List<string>();
            foreach (CarBL c in CarList)
            {
                if (c.CarType == "CONVERTIBLE" || c.CarType == "Convertible" || c.CarType == "convertible")
                {
                    ConvertibleList.Add(c.CarName);
                }
            }
            return ConvertibleList;
        }
        public static int RetrieveRent(string CarName)
        {
            foreach (CarBL c in CarList)
            {
                if (c.CarName == CarName)
                {
                    return c.CarRent;
                }
            }
            return 0;
        }
        public static bool findSedanCar(string CarName)
        {
            for (int i = 0; i < CarList.Count; i++)
            {
                if (CarList[i].CarName == CarName && (CarList[i].CarType == "Sedan" || CarList[i].CarType == "sedan" || CarList[i].CarType == "SEDAN"))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool findSUVCar(string CarName)
        {
            for (int i = 0; i < CarList.Count; i++)
            {
                if (CarList[i].CarName == CarName && (CarList[i].CarType == "SUV" || CarList[i].CarType == "suv" || CarList[i].CarType == "Suv"))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool findConvertibleCar(string CarName)
        {
            for (int i = 0; i < CarList.Count; i++)
            {
                if (CarList[i].CarName == CarName && (CarList[i].CarType == "Convertible" || CarList[i].CarType == "convertible" || CarList[i].CarType == "CONVERTIBLE"))
                {
                    return true;
                }
            }
            return false;
        }
        public static CarBL IsCarExist(string CarName)
        {
            foreach (CarBL c in CarList)
            {
                if (c.CarName == CarName)
                {
                    return c;
                }
            }
            return null;
        }
        public static void RemoveCarFromList(CarBL Car)
        {
            for(int i=0;i<CarList.Count;i++)
            {
                if(CarList[i].CarName==Car.CarName && CarList[i].CarType==Car.CarType && CarList[i].CarLicense==Car.CarLicense)
                {
                    CarList.RemoveAt(i);
                }
            }
        }
        public static CarBL RetrieveCarObject(string CarType,string CarName)
        {
            foreach(CarBL c in CarList)
            {
                if(c.CarType==CarType && c.CarName==CarName)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
