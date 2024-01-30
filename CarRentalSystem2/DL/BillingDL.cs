using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem_2_.BL;
using System.IO;

namespace CarRentalSystem_2_.DL
{
    class BillingDL
    {
        private static List<BillingBL> PaymentList = new List<BillingBL>();
        internal static List<BillingBL> PaymentList1 { get => PaymentList; set => PaymentList = value; }
        public static void AddIntoList(BillingBL b)
        {
            PaymentList.Add(b);
        }
        public static void StoreCreditorDebitCardInFile(string Path)
        {
            StreamWriter f = new StreamWriter(Path);
            foreach (CreditorDebitCard b in PaymentList)
            {
                f.WriteLine(b.GetRecipientName() + "|" + b.GetRecipientCardNo() + "|" + b.GetCardExpiryYear() + "|" + b.GetCVV());
                f.Flush();
            }
            f.Close();
        }
        public static void StoreJazzCashorEasyPaisaInFile(string Path)
        {
            StreamWriter f = new StreamWriter(Path);
            foreach (JazzCashorEasyPaisa b in PaymentList)
            {
                f.WriteLine(b.GetRecipientName() + "|" + b.GetPhoneNumber() + "|" + b.GetCNIC() + "|" + b.GetMPIN());
                f.Flush();
            }
            f.Close();
        }
        public static void LoadFromFile(string Path)
        {
            if (File.Exists(Path))
            {
                StreamReader f = new StreamReader(Path);
                string Record = "";
                while ((Record = f.ReadLine()) != null)
                {
                    string[] SplittedRecord = Record.Split('|');
                    //string PaymentMethod = SplittedRecord[0];
                    string RecipientName = SplittedRecord[0];
                    string RecipientCardNo = SplittedRecord[1];
                    string CardExpiryYear = SplittedRecord[2];
                    string CVV = SplittedRecord[3];
                    CreditorDebitCard b = new CreditorDebitCard(RecipientName, RecipientCardNo, CardExpiryYear, CVV);
                    AddIntoList(b);
                }
                f.Close();
            }
        }
    }
}
