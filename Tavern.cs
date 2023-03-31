using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another_World_Adventure
{
    public class Tavern
    {

        public static void LoadTavern(Player player)
        {
            RunTavern(player);
        }

        public static void RunTavern(Player player)
        {
            int winePrice;
            int foodPrice;

            while (true)
            {
                

                Console.WriteLine("                     Tavern         ");
                Console.WriteLine("==============================================");
                Console.WriteLine("| Wine:              ");
                Console.WriteLine("|                      ");
                Console.WriteLine("|    - (1) " + Wines.Assyrtiko.ItemName + "        $" + Wines.Assyrtiko.ItemPrice );
                Console.WriteLine("|      " + Wines.Assyrtiko.ItemDescription);
                Console.WriteLine("|                      ");
                Console.WriteLine("|    - (2) " + Wines.Limnio.ItemName + "           $" + Wines.Limnio.ItemPrice);
                Console.WriteLine("|      " + Wines.Limnio.ItemDescription);
                Console.WriteLine("|                      ");
                Console.WriteLine("|    - (3) " + Wines.Liatiko.ItemName + "          $" + Wines.Liatiko.ItemPrice);
                Console.WriteLine("|      " + Wines.Liatiko.ItemDescription);
                Console.WriteLine("|                      ");
                Console.WriteLine("|--------------------------------------------");
                Console.WriteLine("| Food:              ");
                Console.WriteLine("|                      ");
                Console.WriteLine("|    - (4) " + Food.HoneyVinegarCabbage.ItemName + "        $" + Food.HoneyVinegarCabbage.ItemPrice);
                Console.WriteLine("|      " + Food.HoneyVinegarCabbage.ItemDescription);
                Console.WriteLine("|                      ");
                Console.WriteLine("|    - (5) " + Food.BowlOfFruit.ItemName + "           $" + Food.BowlOfFruit.ItemPrice);
                Console.WriteLine("|      " + Food.BowlOfFruit.ItemDescription);
                Console.WriteLine("|                      ");
                Console.WriteLine("|    - (6) " + Food.RoastedLamb.ItemName + "          $" + Food.RoastedLamb.ItemPrice);
                Console.WriteLine("|      " + Food.RoastedLamb.ItemDescription);
                Console.WriteLine("|                      ");
                Console.WriteLine("|                      ");
                Console.WriteLine("|    - (7) " + Food.HipponaxsPanckaes.ItemName + "          $" + Food.HipponaxsPanckaes.ItemPrice);
                Console.WriteLine("|      " + Food.HipponaxsPanckaes.ItemDescription);
                Console.WriteLine("|                      ");

                Console.WriteLine("| (E)xit			      ");
                Console.WriteLine("==============================================");
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
                Console.WriteLine("| Potions:			  " + player.playerHealthPotion);
                Console.WriteLine("| Coins:			      " + player.playerCoins);
                Console.WriteLine("=======================");

                //Wait for input

                string tavernInput = Console.ReadLine();

                //Wine Options
                if (tavernInput == "1")
                {
                    winePrice = Wines.Assyrtiko.ItemPrice;
                    TryBuy("dry wine", winePrice, player);

                }
                else if (tavernInput == "2")
                {
                    winePrice = Wines.Limnio.ItemPrice;
                    TryBuy("sweet wine", winePrice, player);
                }
                else if (tavernInput == "3")
                {
                    winePrice = Wines.Liatiko.ItemPrice;
                    TryBuy("sour wine", winePrice, player);
                }
                //Food Options
                else if (tavernInput == "4")
                {
                    foodPrice = Food.HoneyVinegarCabbage.ItemPrice;
                    TryBuy("savory snack", foodPrice, player);
                }
                else if (tavernInput == "5")
                {
                    foodPrice = Food.BowlOfFruit.ItemPrice;
                    TryBuy("sweet snack", foodPrice, player);
                }
                else if (tavernInput == "6")
                {
                    foodPrice = Food.RoastedLamb.ItemPrice;
                    TryBuy("savory meal", foodPrice, player);
                }
                else if (tavernInput == "7")
                {
                    foodPrice = Food.HipponaxsPanckaes.ItemPrice;
                    TryBuy("sweet meal", foodPrice, player);
                }

                else if (tavernInput == "e" || tavernInput == "exit")
                {
                    break;
                }
                else if (tavernInput == "" || tavernInput == "")
                {
                    Program.QsCharacterDialog("Please type a number 1 - 7 to select wine or food item you with to purchase.");
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
                //Wine
                if (item == "dry wine")
                {
                    player.playerDrunkness += Wines.Assyrtiko.ItemDrunkBoost;
                    Program.SlowTextAnimation("The tavern keeper pours " + Wines.Assyrtiko.ItemName + " from a jug into a broad, relatively shallow pottery cup. The glossy black slip covering the inside and out, glistens as the wine fills to the brim.");
                    Program.SlowTextAnimation("Sliding the cup over to you, the keeper continues filling orders of the other patrons.");
                    Program.SlowTextAnimation("Cusping your hands around the two horizontal handles, you enjoy your " + Wines.Assyrtiko.ItemName + ". You eye a slave and women talking in the corner.");
                    Program.QsCharacterDialog("\n\"It's nice to see that all kinds of walks of life are welcomed here.\"");
                    Console.ReadKey();
                    Console.Clear();
                }
                    
                else if (item == "sweet wine")
                {
                    player.playerDrunkness += Wines.Limnio.ItemDrunkBoost;
                    Program.SlowTextAnimation("The tavern keeper pours " + Wines.Limnio.ItemName + " from a jug into a broad, relatively shallow pottery cup. The glossy black slip covering the inside and out, glistens as the wine fills to the brim.");
                    Program.SlowTextAnimation("Sliding the cup over to you, the keeper continues filling orders of the other patrons.");
                    Program.SlowTextAnimation("Cusping your hands around the two horizontal handles, you enjoy your " + Wines.Limnio.ItemName + ". You overhear a debate among a group of men, who all seem to be enjoying some figs.");
                    Program.QsCharacterDialog("\n\"I don't know about you, but I love me some figs. Too bad there aren't Fig Newtons in this world.\"");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (item == "sour wine")
                {
                    player.playerDrunkness += Wines.Liatiko.ItemDrunkBoost;
                    Program.SlowTextAnimation("The tavern keeper pours " + Wines.Liatiko.ItemName + " from a jug into a broad, relatively shallow pottery cup. The glossy black slip covering the inside and out, glistens as the wine fills to the brim.");
                    Program.SlowTextAnimation("Sliding the cup over to you, the keeper continues filling orders of the other patrons.");
                    Program.SlowTextAnimation("Cusping your hands around the two horizontal handles, you enjoy your " + Wines.Liatiko.ItemName + ". A couple, who are a bit overly touchy, accidentally bump into you as they add a touch of promiscuity to the atmopshere.");
                    Program.QsCharacterDialog("\n\"Ah, young love. Even as powerful as they are, do you think Gods get lonely?\"");
                    Console.ReadKey();
                    Console.Clear();
                }
                //Food
                else if (item == "savory snack")
                {
                    player.playerHunger += Food.HoneyVinegarCabbage.ItemFoodBoost;
                    Program.SlowTextAnimation("The tavern keeper grabs a plate and places the sliced cabbage leaves in the middle, covering the intricately painted scene of an Amanzonian archer wearing a tight-fitted sleeve coat and a long ear-flapped hat, drawing an arrow from her quiver.");
                    Program.SlowTextAnimation("Placing the plate in front of you the keeper lightly drizzles the honey vingar over the cabbage and grates silphium sap ontop.");
                    Program.SlowTextAnimation("Carefully using your fingers, you enjoy your " + Food.HoneyVinegarCabbage.ItemName + ". A musician plucks at his kithara's strings as those around dance in delight.");
                    Program.QsCharacterDialog("\n\"Sometimes it's nice to stop and take in the small moments of joy like these.\"");
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (item == "sweet snack")
                {
                    player.playerHunger += Food.BowlOfFruit.ItemFoodBoost;
                    Program.SlowTextAnimation("The tavern keeper grabs a shallow bowl and fills it with a variety of pears, apples, and cherries.");
                    Program.SlowTextAnimation("Sliding the bowl over to you, the keeper continues filling orders of the other patrons.");
                    Program.SlowTextAnimation("Plucking out a cherry, you enjoy your " + Food.BowlOfFruit.ItemName + ". A man, who finishes an entire jar of wine, passes out on the reclined seating.");
                    Program.QsCharacterDialog("\n\"I bet that was some fine wine, aye?\"");
                    Console.ReadKey();
                    Console.Clear();
                }

                else if (item == "savory meal")
                {
                    player.playerHunger += Food.RoastedLamb.ItemFoodBoost;
                    Program.SlowTextAnimation("Removing the lamb from the heat, the tavern keeper stacks the " + Food.RoastedLamb.ItemName + " on a plate, decorated with a painting of a man in a two-horse chariot in the middle.");
                    Program.SlowTextAnimation("Sliding the plate over to you, the keeper continues filling orders of the other patrons.");
                    Program.SlowTextAnimation("Holding the end of the bone, you easily remove the meat of the " + Food.RoastedLamb.ItemName + " with your teeth. A large, well-built man enters the tavern and grabs the attention of athletic enthusiasts.");
                    Program.QsCharacterDialog("\n\"Even here, the people love their sports. Be aware though, gladiators are seen as a barbaric and uncivilized.\"\n\"If you want to be discrete about entering in those competitions, you gotta go to the Arena.\"");
                    Console.ReadKey();
                    Console.Clear();
                }

                else if (item == "sweet meal")
                {
                    player.playerHunger += Food.HipponaxsPanckaes.ItemFoodBoost;
                    Program.SlowTextAnimation("The tavern keeper oils the frying-pan resting on a smokeless fire. After mixing the flour with water, pours the bater, flipping until both sides are equally cooked.");
                    Program.SlowTextAnimation("The pancakes, stacked on a plate, are set infront of you. For final touches, the keeper drizzles honey and sprinkles toasted sesame seeds ontop.");
                    Program.SlowTextAnimation("Carefully using your fingers, you enjoy your " + Food.HipponaxsPanckaes.ItemName + ". You can hear the distance clapping from a performance outside.");
                    Program.QsCharacterDialog("\n\"To be or not to be? That is the question.\"\n\"Whether tis' nobler in the mind to suffer the slights and arrows of outrageous fortune, or to take arms against a sea of troubles, and, by opposing, end them?\"");
                    Console.ReadKey();
                    Console.Clear();
                }

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

