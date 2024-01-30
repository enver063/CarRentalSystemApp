using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem_2_.DL;

namespace CarRentalSystem_2_.BL
{
    public class CarBL
    {
        protected String carType;
        protected String carName;
        protected String carColor;
        protected String carLicense;
        private int carModel;
        private int carRent;
        public string CarType { get => carType; set => carType = value; }
        public string CarName { get => carName; set => carName = value; }
        public string CarColor { get => carColor; set => carColor = value; }
        public string CarLicense { get => carLicense; set => carLicense = value; }
        //public string CarModel { get => carModel; set => carModel = value; }
        public int CarRent { get => carRent; set => carRent = value; }
        public int CarModel1 { get => carModel; set => carModel = value; }

        public CarBL()
        { }
        public CarBL(string carType, string carName, string carColor, string carLicense, int carModel, int carRent)
        {
            this.carType = carType;
            this.carName = carName;
            this.carColor = carColor;
            this.carLicense = carLicense;
            this.carModel = carModel;
            this.carRent = carRent;
        }
        public CarBL(string carType, string carName)
        {
            this.carType = carType;
            this.carName = carName;
        }
        public string GetCarType()
        {
            return carType;
        }
        public string GetCarName()
        {
            return carName;
        }
        public bool SetCarModel(int CarModel)
        {
            if(CarModel<2030 || CarModel>2000)
            {
                this.carModel = CarModel;
                return true;
            }
            return false;
        }
        public bool SetCarRent(int CarRent)
        {
            if (CarRent>0)
            {
                this.carRent = CarRent;
                return true;
            }
            return false;
        }
        public bool setCarType(string carType)
        {
            if (carType != "Sedan" && carType != "SEDAN" && carType != "sedan" && carType != "SUV" && carType != "Suv" && carType != "suv" && carType != "CONVERTIBLE" && carType != "Convertible" && carType != "convertible")
            {
                return false;
            }
            else
            {
                this.carType = carType;
                return true;
            }
        }
        public static int GetCarRent(List<CarBL> carList)
        {
            int total = 0;
            for (int j = 0; j < carList.Count; j++)
            {
                for (int i = 0; i < CarDL.CarList1.Count; i++)
                {
                    if (carList[j].CarName == CarDL.CarList1[i].CarName)
                    {
                        total = total + CarDL.CarList1[i].CarRent;
                    }
                }
            }
            return total;
            
        }
        public void UpdateCar(string CarType,string CarName,string CarColor,string CarLicense,int CarModel,int CarRent)
        {
            this.carType = CarType;
            this.carName = CarName;
            this.carColor = CarColor;
            this.carLicense = CarLicense;
            this.carModel = CarModel;
            this.carRent = CarRent;
        }
    }
}
