using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another_World_Adventure
{
	public class Shop
	{

		public static void LoadShop(Player player)
		{
			RunShop(player);
		}

		public static void RunShop(Player player)
		{
			int potionPrice;
			int weaponUpgradePrice;
			//int weaponTradeP;

			while (true)
			{
                potionPrice = 100 + 10 * player.mods;
                weaponUpgradePrice = 100 * player.playerWeaponStrength;

                // Need to set up TradeWeapon method
				//weaponTradeP = ;

                Console.WriteLine("          Shop         ");
                Console.WriteLine("=======================");
                Console.WriteLine("| (P)otions:          $" + potionPrice);
                Console.WriteLine("| (U)pgrade Weapon:   $" + weaponUpgradePrice);
                // Console.WriteLine("| (T)rade Weapon:     $" + weaponTradeP);
                Console.WriteLine("| (E)xit			      ");
                Console.WriteLine("=======================");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(player.playerName + "'s Stats");
                Console.WriteLine("=======================");
                Console.WriteLine("| Current Health:              " + player.playerHealth);
                Console.WriteLine("| 			                                        ");
                Console.WriteLine("| Current Hunger:	          " + player.playerHunger);
                Console.WriteLine("| Current Drunkness:        " + player.playerDrunkness);
                Console.WriteLine("| 			                                        ");
                Console.WriteLine("| Guild Affiliation:        " + player.playerGuildName);
                Console.WriteLine("| Strength Skill:            " + player.playerStrength);
                Console.WriteLine("| Knowledge Skill:          " + player.playerKnowledge);
                Console.WriteLine("| Charm Skill:		           " + player.playerCharm);
                Console.WriteLine("| 			                                        ");
                Console.WriteLine("| Weapon Name:		      " + player.playerWeaponName);
                Console.WriteLine("| Weapon Type:		      " + player.playerWeaponType);
                Console.WriteLine("| Weapon Strength:     " + player.playerWeaponStrength);
                Console.WriteLine("| 			                                        ");
                Console.WriteLine("| Potions:			          " + player.playerPotion);
                Console.WriteLine("| Coins:			              $" + player.playerCoins);
                Console.WriteLine("=======================");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("=======================");
                Console.WriteLine("| 			          ");
                Console.WriteLine("| (Q)uit Game          ");
                Console.WriteLine("| 			          ");
                Console.WriteLine("=======================");


                //Wait for input

                string shopInput = Console.ReadLine().ToLower();
				if (shopInput == "p" || shopInput == "potion")
				{
                    TryBuy("potion", potionPrice, player);
				}
                else if (shopInput == "u" || shopInput == "upgrade" || shopInput == "upgrade weapon")
                {
                    TryBuy("upgrade weapon", weaponUpgradePrice, player);
                }
                //else if (input == "t" || input == "trade" || input == "trade weapon")
                //{
                //    TryBuy("trade weapon", weaponTradeP, p);

                //}
                else if (shopInput == "q" || shopInput == "quit" || shopInput == "save")
                {
                    Program.Quit();
                }
                else if (shopInput == "e" || shopInput == "exit")
                {
                    break;
                }
                else if (shopInput == "" || shopInput == "")
                {

                }
     
            }
			
        }
        static void TryBuy(string item,int cost, Player player)
        {
            if(player.playerCoins >= cost)
            {
                if (item == "potion")
                    player.playerPotion++;
                else if (item == "upgrade weapon")
                    player.playerWeaponStrength++;
                //else if (item == "trade weapon")
                //    p.weaponTrade();

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

