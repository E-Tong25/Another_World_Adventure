using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

            while (true)
            {
                // Need to set up TradeWeapon method
                //weaponTradeP = ;
                Console.WriteLine("          Shop         ");
                Console.WriteLine("=======================");
                Console.WriteLine("| (P)otions:           ");
                Console.WriteLine("| (T)rade Weapon:      ");
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
                Console.WriteLine("| Potions:			          " + player.playerHealthPotion);
                Console.WriteLine("| Coins:			              $" + player.playerCoins);
                Console.WriteLine("=======================");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("=======================");
                Console.WriteLine("| 			          ");
                Console.WriteLine("| (Q)uit Game          ");
                Console.WriteLine("| 			          ");
                Console.WriteLine("=======================");
                Console.WriteLine("\n\nWhich shop inventory would you like to explore?");

                //Wait for input

                string shopInput = Console.ReadLine().ToLower();
                if (shopInput == "p" || shopInput == "potions")
                {
                    PotionsShopWeaponMenu(player);
                }
                else if (shopInput == "t" || shopInput == "trade")
                {
                    WeaponsShopWeaponMenu(player);
                }
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
                    Console.WriteLine("Please type potions, trade, or exit.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
            }
        }

        static void TryBuy(string item, int cost, Player player)
        {
            if (player.playerCoins >= cost)
            {
                if (item == "potion")
                    player.playerHealthPotion++;
                else if (item == "trade weapon sword")
                    BaseWeapon.SwordWeaponPlayerStatUpdate();
                else if (item == "trade weapon bow")
                    BaseWeapon.BowWeaponPlayerStatUpdate();
                else if (item == "trade weapon spear")
                    BaseWeapon.SpearWeaponPlayerStatUpdate();

                player.playerCoins -= cost;

            }
            else
            {
                Program.QsCharacterDialog("\"Can you imagine being too poor to purchase this? Not me.\"\n\"Maybe try earning more coins at the Arena.\"");
                Console.ReadKey();
            }
        }

        public static void PotionsShopWeaponMenu(Player player)
        {
            int potionPrice;

            while (true)
            {
                potionPrice = 100 + 10 * player.mods;
                potionPrice = Potions.Ambrosia.ItemPrice;

                Console.WriteLine("                    Potion Shop Inventory          ");

                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("|  Potions:                        ");
                Console.WriteLine("|                                  ");
                Console.WriteLine("|    " + Potions.Ambrosia.ItemName + "                    $" + Potions.Ambrosia.ItemPrice);
                Console.WriteLine("|          Description: " + Potions.Ambrosia.ItemDescription);
                Console.WriteLine("|                                  ");
                Console.WriteLine("|  (B)uy Potion                    ");
                Console.WriteLine("|                                  ");
                Console.WriteLine("|  (G)o Back                               ");
                Console.WriteLine("----------------------------------------------------------------");
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
                Console.WriteLine("| Potions:			          " + player.playerHealthPotion);
                Console.WriteLine("| Coins:			              $" + player.playerCoins);
                Console.WriteLine("=======================");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("=======================");
                Console.WriteLine("| 			          ");
                Console.WriteLine("| (Q)uit Game          ");
                Console.WriteLine("| 			          ");
                Console.WriteLine("=======================");
                Console.WriteLine("");

                while (true)
                {
                    string? potionShopInventoryInput = Console.ReadLine();

                    if (potionShopInventoryInput == "b" || potionShopInventoryInput == "B" || potionShopInventoryInput == "buy" || potionShopInventoryInput == "Buy")
                    {
                        TryBuy("potion", Potions.Ambrosia.ItemPrice, player);

                        Program.SlowTextAnimation("You pull the " + Potions.Ambrosia.ItemName + " out of the bag and into your small pouch.");
                        BaseWeapon.AmbrosiaPotionPlayerStatUpdate();
                        break;
                    }
                    else if (potionShopInventoryInput == "g" || potionShopInventoryInput == "G" || potionShopInventoryInput == "go back" || potionShopInventoryInput == "Go Back")
                    { 
                        Console.Clear();
                        LoadShop(Program.currentPlayer);
                    }
                    else if (potionShopInventoryInput == "q" || potionShopInventoryInput == "Q" || potionShopInventoryInput == "Quit" || potionShopInventoryInput == "quit")
                    {
                        Program.Quit();
                    }
                    else
                    {
                        Program.QsCharacterDialog("Please type sword, bow, spear, or potion.");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                }
            }
            
        }

        public static void WeaponsShopWeaponMenu(Player player)
        {
            int weaponTradePrice;

            while (true)
            {
                weaponTradePrice = 2 * player.playerWeaponStrength;

                Console.WriteLine("                    Weapon Shop Inventory          ");

                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("|  Tradeable Weapons:                        ");
                Console.WriteLine("|                                  ");
                Console.WriteLine("|  (A) " + Weapons.HephaestusSword.ItemName + "             $" + weaponTradePrice);
                Console.WriteLine("|  " + Weapons.HephaestusSword.WeaponType + " Description: " + Weapons.HephaestusSword.ItemDescription);
                Console.WriteLine("|                                  ");
                Console.WriteLine("|  (B) " + Weapons.ApollosBow.ItemName + "                  $" + weaponTradePrice);
                Console.WriteLine("|  " + Weapons.ApollosBow.WeaponType + " Description: " + Weapons.ApollosBow.ItemDescription);
                Console.WriteLine("|                                  ");
                Console.WriteLine("|  (C) " + Weapons.SpearOfAthena.ItemName+ "                $" + weaponTradePrice);
                Console.WriteLine("|  " + Weapons.SpearOfAthena.WeaponType + " Description: " + Weapons.SpearOfAthena.ItemDescription);
                Console.WriteLine("|                                            ");
                Console.WriteLine("----------------------------------------------------------------");
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
                Console.WriteLine("| Potions:			          " + player.playerHealthPotion);
                Console.WriteLine("| Coins:			              $" + player.playerCoins);
                Console.WriteLine("=======================");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("=======================");
                Console.WriteLine("| 			          ");
                Console.WriteLine("| (Q)uit Game          ");
                Console.WriteLine("| 			          ");
                Console.WriteLine("=======================");

                while (true)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Which item from Cyno's bag do you want to add to your inventory?");
                    string? weaponShopInventoryInput = Console.ReadLine();

                    if (weaponShopInventoryInput == "a" || weaponShopInventoryInput == "A" || weaponShopInventoryInput == "Hephaestus' Sword" || weaponShopInventoryInput == "hephaestus' sword")
                    {
                        TryBuy("trade weapon sword", weaponTradePrice, player);
                        Program.SlowTextAnimation("You pull " + Weapons.HephaestusSword.ItemName + " out of the bag and holster it to your waist.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    }
                    else if (weaponShopInventoryInput == "bow" || weaponShopInventoryInput == "Bow" || weaponShopInventoryInput == "Apollo's Bow" || weaponShopInventoryInput == "apollo's bow")
                    {
                        TryBuy("trade weapon bow", weaponTradePrice, player);
                        Program.SlowTextAnimation("You pull " + Weapons.ApollosBow.ItemName + " out of the bag and sling it across your back.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else if (weaponShopInventoryInput == "spear" || weaponShopInventoryInput == "Spear" || weaponShopInventoryInput == "Athena's Spear" || weaponShopInventoryInput == "athena's spear")
                    {
                        TryBuy("trade weapon spear", weaponTradePrice, player);
                        Program.SlowTextAnimation("You pull the " + Weapons.SpearOfAthena.ItemName + " out of the bag and sling it to across your back.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else if (weaponShopInventoryInput == "g" || weaponShopInventoryInput == "G" || weaponShopInventoryInput == "go back" || weaponShopInventoryInput == "Go Back")
                    {
                        Console.Clear();
                        LoadShop(Program.currentPlayer);
                    }
                    else if (weaponShopInventoryInput == "q" || weaponShopInventoryInput == "Q" || weaponShopInventoryInput == "Quit" || weaponShopInventoryInput == "quit")
                    {
                        Program.Quit();
                    }
                    else
                    {
                        Program.QsCharacterDialog("Please type sword, bow, or spear.");
                        Console.ReadKey();
                        continue;
                    }
                }
            }
            
        }
    }
}

