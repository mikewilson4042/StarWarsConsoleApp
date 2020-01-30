using System;
using SharpTrooper.Core;

namespace StarWars
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter expected passenger count for your flight and press enter:  ");
                string input = Console.ReadLine();

                Console.WriteLine("Please enter expected cargo count for your flight and press enter:  ");
                string inputCargo = Console.ReadLine();

                //inform user
                Console.WriteLine("Retrieving Flight Data...");
                Console.WriteLine("    ");

                int userPassengerRequirement = Utilities.ValidateCount(input);
                int userCargoRequirement = Utilities.ValidateCount(inputCargo);
                if (userPassengerRequirement > 0 || userCargoRequirement > 0)
                {
                    //get actual ship data
                    GetShipData(userPassengerRequirement, userCargoRequirement);
                }
                else
                {
                    Console.WriteLine("Data entered is invalid for starship evaluation...Please type \"y\" to continue or press any other key to exit");
                    ConsoleKeyInfo keyEntered = Console.ReadKey();
                    if (keyEntered.Key.ToString().ToUpper() == "Y")
                    {
                        Console.WriteLine("......");
                        Console.WriteLine("Continuing...");
                        
                        //restart ship data retrieval
                        RestartProcess();
                    }
                    else
                    {
                        Console.WriteLine("Exiting...");
                        System.Environment.Exit(-1);
                    }
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void RestartProcess()
        {
            //restart ship data retrieval
            string[] recall = new string[0];
            Main(recall);
        }
        private static void GetShipData(int userPassengerRequirement, int userCargoRequirement)
        {
            try
            {
                Starships shipData = new Starships();
                var displayData = shipData.GetStarshipData(userPassengerRequirement, userCargoRequirement);
                int i = 0;
                //display ship data
                foreach (string data in displayData)
                {
                    Console.WriteLine(data);
                    i++;
                }

                Console.WriteLine(" ");
                Console.WriteLine("--------------");
                Console.WriteLine("Please type \"y\" to continue or press any other key to exit");

                //string userEntry = Console.ReadLine();
                ConsoleKeyInfo keyEntered = Console.ReadKey();
                if (keyEntered.Key.ToString().ToUpper() == "Y")
                {
                    Console.WriteLine("......");
                    Console.WriteLine("Continuing...");
                    //restart ship data retrieval
                    RestartProcess();
                }
                else
                {
                    //exit
                    Console.WriteLine("Exiting...");
                    System.Environment.Exit(-1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}