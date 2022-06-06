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
            if(numbercardFlag == true)
            {
                Start();
            }
            else
            {
                io.Print("Your password Or Your Card is Invalid!");
            }
        }

        public static  void Start()
        {

        }
    }


}
