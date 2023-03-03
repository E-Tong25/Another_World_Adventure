using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another_World_Adventure
{
	public class Shop
	{

		public static void LoadShop(Player p)
		{
			RunShop(p);
		}

		public static void RunShop(Player p)
		{
			int potionP;
			int weaponUpgradeP;
			//int weaponTradeP;

			while (true)
			{
                potionP = 100 + 10 * p.mods;
                weaponUpgradeP = 100 * p.weaponStrength;

                // Need to set up TradeWeapon method
				//weaponTradeP = ;

                Console.WriteLine("          Shop         ");
                Console.WriteLine("=======================");
                Console.WriteLine("| (P)otions:          $" + potionP);
                Console.WriteLine("| (U)pgrade Weapon:   $" + weaponUpgradeP);
                // Console.WriteLine("| (T)rade Weapon:     $" + weaponTradeP);
                Console.WriteLine("| (E)xit			      ");
                Console.WriteLine("=======================");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(p.name + "'s Stats");
                Console.WriteLine("=======================");
                Console.WriteLine("| Current Health:      " + p.health);
                Console.WriteLine("| 			          ");
                Console.WriteLine("| Current Hunger:	  " + p.hunger);
                Console.WriteLine("| Current Soberness:   " + p.soberness);
                Console.WriteLine("| 			          ");
                Console.WriteLine("| Guild Affiliation:   " + p.guildName);
                Console.WriteLine("| Strength Skill:      " + p.strength);
                Console.WriteLine("| Knowledge Skill:     " + p.knowledge);
                Console.WriteLine("| Charm Skill:		  " + p.charm);
                Console.WriteLine("| 			          ");
                Console.WriteLine("| Weapon Name:		  " + p.weaponName);
                Console.WriteLine("| Weapon Type:		  " + p.weaponType);
                Console.WriteLine("| Weapon Strength:     " + p.strength);
                Console.WriteLine("| 			          ");
                Console.WriteLine("| Potions:			  " + p.potion);
                Console.WriteLine("| Coins:			     $" + p.coins);
                Console.WriteLine("=======================");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("=======================");
                Console.WriteLine("| 			          ");
                Console.WriteLine("| (Q)uit Game          ");
                Console.WriteLine("| 			          ");
                Console.WriteLine("=======================");



                //Wait for input
                string input = Console.ReadLine().ToLower();
				if (input == "p" || input == "potion")
				{
                    TryBuy("potion", potionP, p);
				}
                else if (input == "u" || input == "upgrade" || input == "upgrade weapon")
                {
                    TryBuy("upgrade weapon", weaponUpgradeP, p);
                }
                //else if (input == "t" || input == "trade" || input == "trade weapon")
                //{
                //    TryBuy("trade weapon", weaponTradeP, p);

                //}
                else if (input == "q" || input == "quit" || input == "save")
                {
                    Program.Quit();
                }
                else if (input == "e" || input == "exit")
                {
                    break;
                }
                else if (input == "" || input == "")
                {

                }
     
            }
			
        }
        static void TryBuy(string item,int cost, Player p)
        {
            if(p.coins >= cost)
            {
                if (item == "potion")
                    p.potion++;
                else if (item == "upgrade weapon")
                    p.weaponStrength++;
                //else if (item == "trade weapon")
                //    p.weaponTrade();

                p.coins -= cost;

            }
            else
            {
                Console.WriteLine("\"Can you imagine being too poor to purchase this? Not me.\"\n\"Maybe try earning more coins at the Arena.\"");
                Console.ReadKey();
            }
        }
	}
}

