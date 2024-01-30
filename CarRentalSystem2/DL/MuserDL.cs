using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem_2_.BL;
using System.IO;

namespace CarRentalSystem_2_.DL
{
    class MuserDL
    {
        private static List<MuserBL> UserList = new List<MuserBL>();

        internal static List<MuserBL> UserList1 { get => UserList; set => UserList = value; }

        public static List<MuserBL> GetUserList()
        {
            return UserList;
        }
        public void SetUserList(List<MuserBL> newlist)
        {
            UserList = newlist;
        }
        public static void AddUserinList(MuserBL m)
        {
            UserList.Add(m);
        }
        public static void LoadData(string Path)
        {
            if (File.Exists(Path))
            {
                StreamReader fileVar = new StreamReader(Path);
                string record = "";
                while ((record = fileVar.ReadLine()) != null)
                {
                    string[] SplittedRecord = record.Split(',');
                    string UserName = SplittedRecord[0];
                    string PassWord = SplittedRecord[1];
                    string UserRole = SplittedRecord[2];
                    MuserBL m = new MuserBL(UserName, PassWord, UserRole);
                    AddUserinList(m);
                }
                fileVar.Close();
            }

        }
        public static void StoreData(string path)
        {
            StreamWriter fileVar = new StreamWriter(path);
            foreach (MuserBL m in UserList)
            {
                string username = m.GetUserName();
                string password = m.GetPassWord();
                string userrole = m.GetUserRole();
                fileVar.WriteLine(username + "," + password + "," + userrole);
                fileVar.Flush();
            }
            fileVar.Close();
        }
        public static MuserBL SignIn(MuserBL m)
        {
            foreach (MuserBL li in UserList)
            {
                if (m.GetUserName() == li.GetUserName() && m.GetPassWord() == li.GetPassWord())
                {
                    return li;
                }
            }
            return null;
        }
        public static MuserBL IsValidUserName(string Username)
        {
            foreach (MuserBL m in UserList)
            {
                if (m.GetUserName() == Username)
                {
                    return m;
                }
            }
            return null;
        }
        public static void UpdateUser(MuserBL Previous,MuserBL Updated)
        {
            foreach(MuserBL u in UserList)
            {
                if(u.UserName1==Previous.UserName1 && u.GetPassWord()==Previous.GetPassWord())
                {
                    u.UserName1 = Updated.UserName1;
                    u.SetPassWord(Updated.GetPassWord());
                    u.SetUserRole(Updated.GetUserRole());
                }
            }
        }
        public static void DeleteAccountFromList(MuserBL user)
        {
            for(int i=0;i<UserList.Count;i++)
            {
                if(UserList[i].UserName1==user.UserName1 && UserList[i].GetPassWord()==user.GetPassWord())
                {
                    UserList.RemoveAt(i);
                }
            }
        }
    }
}
