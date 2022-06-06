using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewATM
{
    public class ATM
    {
        public static void Main()
        {

            //var bank = new Bank() 
            //{
            //    BankID =  1,
            //    Description = "Description",
            //    Name = "Bank1"
            //};
            //string jsonString = JsonConvert.SerializeObject( bank, Formatting.Indented);
            //File.WriteAllText( "bank.json",jsonString );


            //var json = File.ReadAllText("bank.json");

            //Bank bank2 = JsonConvert.DeserializeObject<Bank>(json);


            //var bankList = new List<Bank>();
            //bankList.Add(new Bank() {  BankID = 1,Description = "Description",Name = "Bank1" });
            //bankList.Add(new Bank() {  BankID = 2,Description = "Description",Name = "Bank2" });
            //bankList.Add(new Bank() {  BankID = 3,Description = "Description",Name = "Bank3" });
            //bankList.Add(new Bank() {  BankID = 4,Description = "Description",Name = "Bank4" });

            //string jsonString = JsonConvert.SerializeObject(bankList, Formatting.Indented);
            //File.WriteAllText("bankList.json", jsonString);


            //var json = File.ReadAllText("bankList.json");

            //List<Bank> bankList2 = JsonConvert.DeserializeObject<List<Bank>>(json);


            // our objects
            IO io = new IO();
            Command command = new Command();


            //Get Number Card or we make Command who Read Card 
            //We can use DoWhile here 
            io.Print("Enter Your CardNumber : ");
            string NumberCard = io.Get();
            io.Print("Enter Password");
            string Password = io.Get(); 

            //Validation from Command
            bool numbercardFlag = command.CallValidation( NumberCard , Password );

            // if cardnuber and password is true so we ready for start Start()!
            if(numbercardFlag == true)
            {
                io.Print("Wait...");
                Start( command );
            }
            else
            {
                io.Print("Your password Or Your Card is Invalid!");
            }
        }

        public static  void Start( Command command)
        {
            //creat flag 
            bool WhileFlag = true;
            while ( WhileFlag == true )
            {
                IO io = new IO();
                io.Print("\n-----\n" +
                    "1-Account\n2-Get Money\n3-Send Money\n0-Exit");
                // we get command code from user until he said EXIT
                io.PrintAt("Enter Your Command: ");
                string commandVal = io.Get();

                //If commandVal == Exit --> break ;
                if(commandVal == "0")
                {
                    break;
                }
                else
                {
                    switch (commandVal)
                    {
                        case "1":
                            // Account Tel us, user Money !
                            string CurrentMoney = command.Account();
                            io.Print($"Your Current Money --> {CurrentMoney}");
                            break;

                        case "2":
                            io.Print("How Many Hezzar Toman You Need: ");
                            string MoneyVal = io.Get();
                            bool GetMoneyFalg = command.GetMoney( MoneyVal);
                            if( GetMoneyFalg == true)
                            {
                                io.Print("Done!");
                            }
                            else
                            {
                                //or bank have no money 
                                io.Print("Your Money is Not Enoght");
                            }
                            break;

                        case "3":
                            io.PrintAt("Enter Secend Number Card : ");
                            string SecendNumberCard = io.Get();

                            io.Print("How many Hezar toman do you want trade ??");
                            string Money = io.Get();


                            // Two factor <1-is secend number is valid
                            //<2-is your money enoghf
                            bool SendMoneyFlag = command.SendMoney(SecendNumberCard , Money );
                            if( SendMoneyFlag == true)
                            {
                                io.Print("Done!");
                            }
                            else
                            {
                                io.Print("Secend Number is Invalid Or Your Money is not Enoght!");
                            }
                            break;

                        default:
                            io.Print("Invalid Command");
                            break;
                    }
                }
            }
        }
    }


}
