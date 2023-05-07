using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BusinessLogic;

namespace Test2Prep
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            BusinessLogicClass BusinessLogicObject = new BusinessLogicClass();
            while (true)
            {
                Console.Write("Choose 1 to register a new user or 2 to login if you are an existing user or enter 0 to exit: ");
                string input = Console.ReadLine();
                //Exiting application
                if (input == "0")
                {
                    break;
                }
                //Register new user
                else if (input == "1")
                {
                    //Register user by taking their fullnames,email,password
                    BusinessLogicObject.RegisterUser();
                    Console.WriteLine("===========================================================\n\n");
                }
                else if (input == "2")
                {
                    //Login user(Check if the user already exist in the user DB/TextFile)
                    Console.Write("Enter your email: ");
                    string Email = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    string Password = Console.ReadLine();
                    Console.WriteLine("=========================================================\n\n");
                    BusinessLogicObject.LoginUser(Email,Password);

                }
            }
            
            Console.ReadKey();
        }
    }
}
