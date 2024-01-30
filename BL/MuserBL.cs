using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem_2_.BL
{
    public class MuserBL
    {
        private string UserName;
        private string PassWord;
        private string UserRole;

        public string UserName1 { get => UserName; set => UserName = value; }

        public MuserBL(string UserName, string PassWord, string UserRole)
        {
            this.UserName = UserName;
            this.PassWord = PassWord;
            this.UserRole = UserRole;
        }
        public MuserBL(string UserName, string PassWord)
        {
            this.UserName = UserName;
            this.PassWord = PassWord;
        }
        public MuserBL()
        {

        }
        public string GetUserName()
        {
            return UserName;
        }
        public string GetPassWord()
        {
            return PassWord;
        }
        public string GetUserRole()
        {
            return UserRole;
        }
        public bool SetUserName(string UserName)
        {
            if(UserName.Length>13)
            {
                this.UserName = UserName;
                return true;
            }
            return false;
            
        }
        public bool SetPassWord(string PassWord)
        {
            if (PassWord.Length > 7)
            {
                this.PassWord = PassWord;
                return true;
            }
            return false;
        }
        public void SetUserRole(string UserRole)
        {
            this.UserRole = UserRole;
        }
        public String check()
        {
            if (UserRole == "Admin" || UserRole == "admin" || UserRole == "ADMIN")
            {
                return "admin";
            }
            else if(UserRole=="Employe" || UserRole=="employe" || UserRole=="EMPLOYE")
            {
                return "employe";
            }
            else if (UserRole == "Customer" || UserRole == "customer" || UserRole == "CUSTOMER")
            {
                return "customer";
            }
            return null;
        }
    }
}
