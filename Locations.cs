using System;
using System.Numerics;

namespace Another_World_Adventure

{
	public class Locations
	{
        public static void LoadAllLocationsMenu()
        {
            RunAllLocationsMenu();
        }

        public static void RunAllLocationsMenu()
		{
            while (true)
            {
                Program.SlowTextAnimation("You arrive back to the village square.");
                Console.WriteLine();
                Program.QsCharacterDialog("\"So many things to see, so many things to do. Where are we going?\"");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("        Village        ");
                Console.WriteLine("=======================");
                Console.WriteLine("|     			      ");
                Console.WriteLine("| (T)avern             ");
                Console.WriteLine("|    			      ");
                Console.WriteLine("| (S)hop			      ");
                Console.WriteLine("|    			      ");
                Console.WriteLine("| (A)rena     	      ");
                Console.WriteLine("|      			      ");
                Console.WriteLine("|        		      ");
                Console.WriteLine("| (Q)uit			      ");
                Console.WriteLine("|    			      ");
                Console.WriteLine("=======================");
                Console.WriteLine();
                Console.WriteLine();


                string locationsInput = Console.ReadLine().ToLower();

                if (locationsInput == "t" || locationsInput == "tavern")
                {
                    Tavern.LoadTavern(Program.currentPlayer);
                }
                else if (locationsInput == "s" || locationsInput == "shop")
                {
                    Shop.LoadShop(Program.currentPlayer);
                }
                else if (locationsInput == "a" || locationsInput == "arena")
                {
                    Encounters.ArenaEncounter();
                }
                else if (locationsInput == "q" || locationsInput == "quit" || locationsInput == "save")
                {
                    Program.Quit();
                }
            }
        }

    }
}

