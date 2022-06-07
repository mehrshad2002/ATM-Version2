using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NewATM
{
    public class Command
    {
        //our secret !!
        private string number; 
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        
        public bool CallValidation( string numberVal , string passVal )
        {
            //validation our secret !
            Number = numberVal;

            Bank bank = new Bank();
            bool Falg = bank.Validation(numberVal, passVal);
            return Falg ;

        }

        public bool DoCommand(string commandVal)
        {
            throw new NotImplementedException();
        }

        public string Account()
        {
            var json = File.ReadAllText("../../../JsonFile/UserData/UserInfo.json");
            List<UserAccount> UserList = JsonConvert.DeserializeObject<List<UserAccount>>(json);

            foreach( UserAccount User in UserList)
            {
                if( number == User.NumberCard)
                {
                    return User.Money;
                }
            }return "No Data!";
        }

        public bool GetMoney( string MoneyWantVal )
        {
            string CurrentMoney;
            var json = File.ReadAllText("../../../JsonFile/UserData/UserInfo.json");
            List<UserAccount> UserList = JsonConvert.DeserializeObject<List<UserAccount>>(json);

            foreach( UserAccount User in UserList)
            {
                if( number == User.NumberCard)
                {
                    int NowMoney = Convert.ToInt32(User.Money);
                    int IntMoneyWantVal = Convert.ToInt32(MoneyWantVal);
                    if ( NowMoney > IntMoneyWantVal)
                    {
                        WriteRead wr = new WriteRead();
                        int SumMoney = NowMoney - IntMoneyWantVal;
                        User.Money = Convert.ToString(SumMoney);
                        wr.SaveUsers(UserList);
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool SendMoney(string secendNumberCard , string TradeMoney )
        {
            int Falg1 = 0;
            int Flag2 = 0;
            var json = File.ReadAllText("../../../JsonFile/UserData/UserInfo.json");
            List<UserAccount> UserList = JsonConvert.DeserializeObject<List<UserAccount>>(json);

            foreach( UserAccount User in UserList)
            {
                if( number == User.NumberCard)
                {
                    WriteRead wr = new WriteRead();
                    int NowMoney = Convert.ToInt32(User.Money);
                    int IntTradeMoney = Convert.ToInt32(TradeMoney);
                    if ( NowMoney > IntTradeMoney)
                    {
                        User.Money = Convert.ToString(NowMoney - IntTradeMoney);
                        wr.SaveUsers(UserList);
                        Falg1 = 1;
                    }
                    
                }
            }

            foreach( UserAccount User in UserList )
            {
                if(secendNumberCard == User.NumberCard)
                {
                    Flag2 = 1;
                }
            } 
            
            if( Falg1 == 1 && Flag2 == 1)
            {

                foreach( UserAccount User in UserList)
                {
                    if(secendNumberCard == User.NumberCard)
                    {
                        WriteRead wr = new WriteRead();
                        int SumMoney = Convert.ToInt32(User.Money);
                        int IntTradeMoney = Convert.ToInt32(TradeMoney);
                        SumMoney += IntTradeMoney;
                        User.Money = Convert.ToString(SumMoney);
                        wr.SaveUsers(UserList);
                        return true;
                    }
                }
            }return false;
        }
    }
}
