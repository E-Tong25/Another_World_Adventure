using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another_World_Adventure
{
    public class Tavern
    {

        public static void LoadTavern(Player player)
        {
            RunTavern( player);
        }

        public static void RunTavern(Player player, Wine wine)
        {
            int winePrice;
            int foodPrice;

            while (true)
            {
                winePrice = 0; // Need to figure out how to grab values from List in Wine Class
                foodPrice = 0;

                Console.WriteLine("        Tavern         ");
                Console.WriteLine("=======================");
                Console.WriteLine("| (W)ine:              $" + winePrice);
                Console.WriteLine("|    -                 $" );
                Console.WriteLine("| (W)ine:              $" + winePrice);
                Console.WriteLine("| (W)ine:              $" + winePrice);
                Console.WriteLine("| (W)ine:              $" + winePrice);
                Console.WriteLine("|--------------------------------------------");
                Console.WriteLine("| (F)ood:              $" + foodPrice);
                Console.WriteLine("| (F)ood:              $" + foodPrice);
                Console.WriteLine("| (F)ood:              $" + foodPrice);
                Console.WriteLine("| (F)ood:              $" + foodPrice);
                Console.WriteLine("| (F)ood:              $" + foodPrice);
                Console.WriteLine("| (F)ood:              $" + foodPrice);

                Console.WriteLine("| (E)xit			      ");
                Console.WriteLine("=======================");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(player.playerName + "'s Stats");
                Console.WriteLine("=======================");
                Console.WriteLine("| Current Health:      " + player.playerHealth);
                Console.WriteLine("| 			          ");
                Console.WriteLine("| Current Hunger:	  " + player.playerHunger);
                Console.WriteLine("| Current Soberness:   " + player.playerDrunkness);
                Console.WriteLine("| 			          ");
                Console.WriteLine("| Guild Affiliation:   " + player.playerGuildName);
                Console.WriteLine("| Strength Skill:      " + player.playerStrength);
                Console.WriteLine("| Knowledge Skill:     " + player.playerKnowledge);
                Console.WriteLine("| Charm Skill:		  " + player.playerCharm);
                Console.WriteLine("| 			          ");
                Console.WriteLine("| Weapon Name:		  " + player.playerWeaponName);
                Console.WriteLine("| Weapon Type:		  " + player.playerWeaponType);
                Console.WriteLine("| Weapon Strength:     " + player.playerStrength);
                Console.WriteLine("| 			          ");
                Console.WriteLine("| Potions:			  " + player.playerPotion);
                Console.WriteLine("| Coins:			      " + player.playerCoins);
                Console.WriteLine("=======================");

                //Wait for input

                string? input = Console.ReadLine()?.ToLower();
                if (input == "w" || input == "wine")
                {
                    TryBuy("wine", winePrice, player);
                }
                else if (input == "f" || input == "food")
                {
                    TryBuy("food", foodPrice, player);

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
        static void TryBuy(string item, int cost, Player player)
        {
            if (player.playerCoins >= cost)
            {
                if (item == "wine")
                    player.playerDrunkness++;
                else if (item == "food")
                    player.playerHunger++;

                player.playerCoins -= cost;

            }
            else
            {
                Program.QsCharacterDialog("\"Can you imagine being too poor to purchase this? Not me.\"\n\"Maybe try earning more coins at the Arena.\"");
                Console.ReadKey();
            }
        }
    }
}

