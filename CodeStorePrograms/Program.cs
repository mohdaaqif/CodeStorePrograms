using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStorePrograms
{
    class Program
    {
        static void CarInsurancePremiumCalculator()
        {
            Console.Write("Enter Ex Showroom Price : ");
            int showRoomPrice = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Personal Accident Cover Price : ");
            int personalAccidentCoverPrice = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Third Party Cover Price : ");
            int thirdPartyCoverPrice = Convert.ToInt32(Console.ReadLine());
            CarInsurancePremiumCalculator carInsurancePremiumCalculator = new CarInsurancePremiumCalculator(showRoomPrice, personalAccidentCoverPrice, thirdPartyCoverPrice);
            Console.WriteLine("Total Premium : " + carInsurancePremiumCalculator.TotalPremium());
        }
        
        static async Task RollDices()
        {
            Console.WriteLine("Rolls Dice Start");
            Dice dice = new Dice();
            int sumOfTotalDice = await dice.RollAndSumFiveDive();
            Console.WriteLine("Rolls Dice End");
            Console.WriteLine("Sum Of Totol Dice : " + sumOfTotalDice);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1. Dice Program");
            Console.WriteLine("2. Basic Car Insurance Premium Calculator Program");
            Console.WriteLine("Enter Your Choise");
            string response = "";
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1" :
                    RollDices().Wait();
                    break;
                case "2" :
                    CarInsurancePremiumCalculator();
                    break;
                default :
                    Console.Clear();
                    Main(new string[1]);
                    break;
            }

            //restart based on choice
            Console.WriteLine("Press Y to try again...");
            response = Console.ReadLine();
            if (response.ToUpper() == "Y")
            { 
                Console.Clear();
                Main(new string[1]);
            }
        }

    }
}
