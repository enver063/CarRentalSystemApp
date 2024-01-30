using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem_2_.BL
{
    class BillingBL
    {
        //private string PaymentMethod;
        private string customerName;

        public string CustomerName { get => customerName; set => customerName = value; }

        //public string PaymentMethod1 { get => PaymentMethod; set { if (value == "sd") { PaymentMethod = value; } } }
        public BillingBL( string RecipientName)
        {
            this.CustomerName = RecipientName;
        }
        public BillingBL()
        {

        }
        public string GetRecipientName()
        {
            return CustomerName;
        }
        
    }
    class JazzCashorEasyPaisa:BillingBL
    {
        private string PhoneNumber;
        private string CNIC;
        private string MPIN;

        public string PhoneNumber1 { get => PhoneNumber; set => PhoneNumber = value; }
        public string CNIC1 { get => CNIC; set => CNIC = value; }
        public string MPIN1 { get => MPIN; set => MPIN = value; }

        public JazzCashorEasyPaisa(string CustomerName,string PhoneNumber,string CNIC,string MPIN):base(CustomerName)
        {
            this.PhoneNumber = PhoneNumber;
            this.CNIC = CNIC;
            this.MPIN = MPIN;
        }
        public JazzCashorEasyPaisa()
        { }
        public string GetPhoneNumber()
        {
            return PhoneNumber;
        }
        public string GetCNIC()
        {
            return CNIC;
        }
        public string GetMPIN()
        {
            return MPIN;
        }
        public bool SetPhoneNumber(string PhoneNo)
        {
            if(PhoneNo.Length>10 && PhoneNo.Length<15)
            {
                return true;
            }
            return false;
        }
        public bool SetCNIC(string CNIC)
        {
            if(CNIC.Length>11 && CNIC.Length<15)
            {
                return true;
            }return false;
        }
        public bool SetMPIN(string CVV)
        {
            if (CVV.Length > 3 && CVV.Length < 6)
            {
                return true;
            }
            return false;
        }
    }
    class CreditorDebitCard : BillingBL
    {
        private string RecipientCardNo;
        private string CardExpiryYear;
        private string CVV;

        public string RecipientCardNo1 { get => RecipientCardNo; set => RecipientCardNo = value; }
        public string CardExpiryYear1 { get => CardExpiryYear; set => CardExpiryYear = value; }
        public string CVV1 { get => CVV; set => CVV = value; }

        public CreditorDebitCard(string CustomerName, string RecipientCardNo, string CardExpiryYear, string CVV):base(CustomerName)
        {
            this.RecipientCardNo = RecipientCardNo;
            this.CardExpiryYear = CardExpiryYear;
            this.CVV = CVV;
        }
        public CreditorDebitCard()
        {

        }
        public string GetRecipientCardNo()
        {
            return RecipientCardNo;
        }
        public string GetCardExpiryYear()
        {
            return CardExpiryYear;
        }
        public string GetCVV()
        {
            return CVV;
        }
        public bool SetAccountNo(string AccountNo)
        {
            if(AccountNo.Length>12 &&AccountNo.Length<17)
            {
                return true;
            }
            return false;
        }
        public bool SetCVV(string CVV)
        {
            if(CVV.Length>3 && CVV.Length<6)
            {
                return true;
            }
            return false;
        }
    }
}
