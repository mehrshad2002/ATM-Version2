using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NewATM
{
    public class WriteRead
    {

        public void SaveJson(List<UserAccount> data, string path)
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
