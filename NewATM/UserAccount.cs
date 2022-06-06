namespace NewATM
{
    public class UserAccount
    {
        public string Name { get; set; }
        public string NumberCard { get; set; }
        public string Password { get; set; }
        public string Money { get; set; }

        //Constructor For add info from Bank.CreateAccount
        public UserAccount( string NameVal , string NumberCardVal , string PasswordVal , string MoneyVal)
        {
            Name = NameVal;
            NumberCard = NumberCardVal;
            Password = PasswordVal;
            Money = MoneyVal;
        }
    }
}