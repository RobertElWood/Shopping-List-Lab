using System;
using System.Reflection.Metadata;

namespace Shopping_List_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var runAgain = true;

            var menuItems = new Dictionary<string, decimal>()
            {
                ["goosefeather arrows"] = 10,
                ["adventure rations kit"] = 30,
                ["health potion\t"] = 50,
                ["mana potion\t"] = 50,
                ["dagger of woe\t"] = 90,
                ["combat leathers\t"] = 100,
                ["mail of thorns\t"] = 100,
                ["longbow of warning"] = 150,
                ["longsword of annoyance"] = 150,
                ["greatsword of wrath"] = 175,       
                ["adamantite platemail"] = 300,
                ["robe of useful items"] = 300,
                ["bag of holding\t"] = 500,  
            };

            List <string> shoppingList = new List<string>();

            Console.WriteLine("Greetings! Welcome to Cabelius' Emporium, the realm's foremost outfitter of adventuring supplies, magical curios, and fine weaponry.\n");

            while (runAgain)
            {
                Console.WriteLine("Here is a menu of our current offerings, if you have the coin for them: \n");

                PrintMenu(menuItems);


                Console.WriteLine("Please enter the number of the item you would like to purchase!\n");

                int userChoice = int.Parse(Console.ReadLine());
                

                if (userChoice > menuItems.Count)
                {
                    Console.WriteLine("\nI'm sorry, that doesn't match anything we have. Please enter a different number!");
                    continue;
                } 
                else 
                {
                    shoppingList.Add(menuItems.ElementAt(userChoice-1).Key);
                }

                decimal currentTotal = CalculatePrices(shoppingList, menuItems);

                Console.WriteLine("\nYour current total is: " + currentTotal);

                runAgain = RunAgain();

            }

            decimal finalPrice = CalculatePrices(shoppingList, menuItems);

            Console.WriteLine("Alright, here is your receipt. Please come again!\n");

            PrintReceipt(shoppingList, menuItems);

            Console.WriteLine("\nTotal = " + finalPrice);
            
        }
        public static void PrintMenu (Dictionary<string, decimal> menuList) 
        {
            int num = 1;

            foreach (KeyValuePair<string, decimal> kvp in menuList) 
            {
                Console.WriteLine($"Item {num}: {kvp.Key}\tPrice: {kvp.Value}gp");
                num += 1;
            }
            Console.WriteLine();
        }

        public static decimal CalculatePrices (List <string> shoppingList, Dictionary <string, decimal> menu) 
        {
            decimal sum = 0;

            foreach (string item in shoppingList) 
            { 
                if (menu.ContainsKey(item) == true) 
                { 
                    sum += menu[item];
                }
            }

            return sum;
        }

        public static void PrintReceipt (List <string> shoppingList, Dictionary <string, decimal> menu) 
        {
            Console.WriteLine("Final Receipt: \n");

            foreach (string item in shoppingList) 
            {
                Console.WriteLine($"Item: {item}\tPrice: {menu[item]}gp");
            }

        }
        public static bool RunAgain()
        {
            Console.WriteLine();
            Console.WriteLine("Thank you for your custom!");
            Console.WriteLine("\nWould you like to purchase another item? Y/N?\n");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                Console.WriteLine();
                return true;
            }
            else if (input == "n")
            {
                Console.WriteLine();
                return false;
            }
            else
            {
                Console.WriteLine("I didn't understand that. Please try again!");
                return RunAgain();
            }
        }

    }
}