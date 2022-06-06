using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace NewATM
{
    public class Bank
    {
        public void CreatAccount()
        {
            bool FileExist = File.Exists("../../../JsonFile/UserData/UserInfo.json");
            if( FileExist == false)
            {
                var bankList = new List<UserAccount>();
                bankList.Add(new UserAccount( "Mehrshad", "6104123443210987", "1234", "1000"));
                bankList.Add(new UserAccount("Aria", "6104123443216576", "0000", "300"));
                bankList.Add(new UserAccount("Bahar", "6104123447813245", "4554", "700"));
                SaveUsers(bankList);
            }
        }

        public bool Validation( string NumberCardVal , string PasswordVal )
        {
            CreatAccount();
            var json = File.ReadAllText("../../../JsonFile/UserData/UserInfo.json");
            List<UserAccount> banklist = JsonConvert.DeserializeObject<List<UserAccount>>(json);


            foreach (UserAccount bank in banklist)
            {
                if (NumberCardVal == bank.NumberCard && PasswordVal == bank.Password)
                {
                    //bank.Name = "MeinFreundin";
                    //SaveUsers(banklist);
                    return true;
                }
            }
            return false;
            //we have qustion from froeach

        }

        public void SaveJson(List<UserAccount> data , string path)
        {

            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, jsonString);
        }

        public void SaveUsers(List<UserAccount> data)
        {
            SaveJson(data, "../../../JsonFile/UserData/UserInfo.json");
        }
    }
}
