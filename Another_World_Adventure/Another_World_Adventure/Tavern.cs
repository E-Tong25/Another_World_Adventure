using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another_World_Adventure
{
    public class Tavern
    {

        public static void LoadTavern(Player p)
        {
            RunTavern(p);
        }

        public static void RunTavern(Player p)
        {
            int wineP;
            int foodP;

            while (true)
            {
                wineP = 100 + 10 * p.mods;
                foodP = 100 * p.mods;

                Console.WriteLine("        Tavern         ");
                Console.WriteLine("=======================");
                Console.WriteLine("| (W)ine:              $" + wineP);
                Console.WriteLine("| (F)ood:              $" + foodP);
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
                Console.WriteLine("| Coins:			      " + p.coins);
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
                else if (input == "e" || input == "exit")
                {
                    break;
                }
                else if (input == "" || input == "")
                {

                }
            }

        }
        static void TryBuy(string item, int cost, Player p)
        {
            if (p.coins >= cost)
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

