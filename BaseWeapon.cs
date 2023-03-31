using System;
using System.Collections.Generic;

namespace Another_World_Adventure
{

    public class BaseWeapon : BaseStatItem
	{
		public enum WeaponTypes
		{
			Sword, Bow, Spear,
		}
		private WeaponTypes weaponType;


        public WeaponTypes WeaponType
		{
			get { return weaponType; }
			set { weaponType = value; }
		}

        public BaseWeapon(string weaponName, string weaponDescription, int weaponStrengthBoost, WeaponTypes typeOfWeapon, int weaponID)
        {
            ItemName = weaponName;
            ItemDescription = weaponDescription;
            ItemStrengthBoost = weaponStrengthBoost;
            WeaponType = typeOfWeapon;
            ItemID = weaponID;
        }

        public static void ObtainingOriginalWeapon()
		{
			Console.Clear();
			Program.SlowTextAnimation("Turning around, not many people seem too phased by your recent brawl on the street. Perhaps, everyone just hated that guy.");
			Console.WriteLine();
			Program.SlowTextAnimation("Merchant displays aligned the edges of the square along with marble-cut buildings. A large temple, with columns carved with intricate patterns, sits off to the side.");
			Console.WriteLine();
            Program.QsCharacterDialog("\"I guess you could call this the Agora\"");
            Program.QsCharacterDialog("\"But my eyes, are always on that tavern over there.\"");
			Console.ReadKey();
			Console.Clear();
            while (true)
            {
                Program.SlowTextAnimation("Where would you like to go?");
                Console.WriteLine();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("|    (S)hop                       |");
                Console.WriteLine("|                                 |");
                Console.WriteLine("|    (T)avern                     |");
                Console.WriteLine("|                                 |");
                Console.WriteLine("|                                 |");
                Console.WriteLine("|    (D)ie                        |");
                Console.WriteLine("-----------------------------------");

                string? obtainingOriginalWeaponLocationInput = Console.ReadLine();

                if (obtainingOriginalWeaponLocationInput == "s" || obtainingOriginalWeaponLocationInput == "S" || obtainingOriginalWeaponLocationInput == "shop" || obtainingOriginalWeaponLocationInput == "Shop")
                {
                    Console.Clear();
                    Program.SlowTextAnimation("As you begin to walk to the shop, a cloaked figure collides with you and you both fall to the ground.");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                }
                else if (obtainingOriginalWeaponLocationInput == "t" || obtainingOriginalWeaponLocationInput == "T" || obtainingOriginalWeaponLocationInput == "tavern" || obtainingOriginalWeaponLocationInput == "Tavern")
                {
                    Console.Clear();
                    Program.SlowTextAnimation("As you begin to walk to the tavern, a cloaked figure collides with you and you both fall to the ground.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else if (obtainingOriginalWeaponLocationInput == "d" || obtainingOriginalWeaponLocationInput == "D" || obtainingOriginalWeaponLocationInput == "die" || obtainingOriginalWeaponLocationInput == "Die")
                {
                    Console.Clear();
                    Program.QsCharacterDialog("\"Well that's dark\".\n\"After a single run in with a drunk dude, you want to call it quits? How sad.\"");
                    Console.WriteLine();
                    Program.SlowTextAnimation("Before you could respond, a cloaked figure collides with you and you both fall to the ground.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else
                {
                    Program.QsCharacterDialog("\"Perhaps, I wasn't clear enough.\"\n\nPlease type s, t. or d.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
            }

            Console.Clear();
            Program.SlowTextAnimation("The cloaked figure's bags scatter everywhere, and he seems out of breath.");
            Console.WriteLine();
            Program.CynosCharacterDialog("\"Oh, so sorry. I didn't see you there.\"");
            Console.WriteLine();
            Console.WriteLine("Help him? y/n");

            while (true)
            {
                string? helpCloakedFigureInput = Console.ReadLine();

                if (helpCloakedFigureInput == "y" || helpCloakedFigureInput == "Y")
                {
                    Program.SlowTextAnimation("As you regain your footing, you help the cloaked figure gather his bags.");
                    Console.WriteLine();
                    Program.CynosCharacterDialog("\"Why, thank you very much.\"");
                    break;
                }
                else if (helpCloakedFigureInput == "n" || helpCloakedFigureInput == "N")
                {
                    Program.SlowTextAnimation("Villagers walk past as the cloaked figure gathers his bags by himself.");
                    Console.WriteLine();
                    break;
                }
            }
            Console.ReadKey();
            Console.Clear();

            Program.SlowTextAnimation("The cloaked figure flings the heavy baggage over his shoulder, and you are able to snag a peak of his face.");
            Program.SlowTextAnimation("The facial structure isn't like a normal human, but rather resembles a dog or a jackle.\nA scar connects the forehead to his right eye, perhaps a reminder of a war from long ago.");
            Console.WriteLine();
            Program.CynosCharacterDialog("\"Apologies again, friend. I had just traveled here from the mountains to trade some supplies I had in my possession.\"");
            Program.CynosCharacterDialog("\"My name is Cyno.\"\n\"I can't see like I used to in my younger years, so I've gotten a bit clumsier in my old age.\"");
            Console.WriteLine();
            Program.SlowTextAnimation("He shines a friendly smile, but you can't help but see fatigue and sadness in his eyes.");
            Console.ReadKey();
            Console.Clear();
            Program.CynosCharacterDialog("\"You know, to show my sincerest apologies, you can take a look at some of my wares to see if there's something you like.\"\n\"I was going to get rid of them anyways.\"");
            Console.WriteLine();
            Program.SlowTextAnimation("Take a look? y/n");
            Console.WriteLine();
            while (true)
            {
                string? lookInBagInput = Console.ReadLine();

                if (lookInBagInput == "y" || lookInBagInput == "Y")
                {
                    Program.CynosCharacterDialog("\"Perfect! Don't be shy, these are some of my prized possessions, so treat them well.\"");
                    Console.WriteLine();
                    CynosBagDisplay();
                    Console.Clear();
                    Program.CynosCharacterDialog("\"That's a good one. I hope it serves you when you most need it.\"");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else if (lookInBagInput == "n" || lookInBagInput == "N")
                {
                    Program.CynosCharacterDialog("\"No please, I insist.\"");
                    Console.WriteLine();
                    CynosBagDisplay();
                    Console.Clear();
                    Program.CynosCharacterDialog("\"That's a good one. I hope it serves you when you most need it.\"");
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            }

            Program.SlowTextAnimation("Cyno reties his bag and continues to the shop. As he walks away, he waves goodbye.");
            Console.WriteLine();
            Program.CynosCharacterDialog("\"I hope we meet again!\"");
            Console.ReadKey();
            Console.Clear();
        }

        public static void CynosBagDisplay()
        {
            Console.WriteLine("                       Cynos Bag Display          ");

            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("|  Weapons:                        ");
            Console.WriteLine("|                                  ");
            Console.WriteLine("|  " + Weapons.HephaestusSword.ItemName);
            Console.WriteLine("|  " + Weapons.HephaestusSword.WeaponType+" Description: "+ Weapons.HephaestusSword.ItemDescription);
            Console.WriteLine("|                                  ");
            Console.WriteLine("|  " + Weapons.ApollosBow.ItemName);
            Console.WriteLine("|  " + Weapons.ApollosBow.WeaponType+" Description: "+ Weapons.ApollosBow.ItemDescription);
            Console.WriteLine("|                                  ");
            Console.WriteLine("|  " + Weapons.SpearOfAthena.ItemName);
            Console.WriteLine("|  " + Weapons.SpearOfAthena.WeaponType+" Description: "+ Weapons.SpearOfAthena.ItemDescription);
            Console.WriteLine("|                                  ");
            Console.WriteLine("|  Potions:                        ");
            Console.WriteLine("|                                  ");
            Console.WriteLine("|  " + Potions.Ambrosia.ItemName);
            Console.WriteLine("|  " + Potions.Ambrosia.PotionType+" Description: "+ Potions.Ambrosia.ItemDescription);
            Console.WriteLine("|                                  ");
            Console.WriteLine("----------------------------------------------------------------");


            while (true)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Which item from Cyno's bag do you want to add to your inventory?");
                string? obtainingOriginalWeaponInput = Console.ReadLine();

                if (obtainingOriginalWeaponInput == "sword" || obtainingOriginalWeaponInput == "Sword" || obtainingOriginalWeaponInput == "Hephaestus' Sword" || obtainingOriginalWeaponInput == "hephaestus' sword")
                {
                    Console.Clear();
                    Program.SlowTextAnimation("You pull " + Weapons.HephaestusSword.ItemName + " out of the bag and holster it to your waist.");
                    SwordWeaponPlayerStatUpdate();
                    Console.ReadKey();
                    Console.Clear();
                    break;

                }
                else if (obtainingOriginalWeaponInput == "bow" || obtainingOriginalWeaponInput == "Bow" || obtainingOriginalWeaponInput == "Apollo's Bow" || obtainingOriginalWeaponInput == "apollo's bow")
                {
                    Console.Clear();
                    Program.SlowTextAnimation("You pull " + Weapons.ApollosBow.ItemName + " out of the bag and sling it across your back.");
                    BowWeaponPlayerStatUpdate();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else if (obtainingOriginalWeaponInput == "spear" || obtainingOriginalWeaponInput == "Spear" || obtainingOriginalWeaponInput == "Athena's Spear" || obtainingOriginalWeaponInput == "athena's spear")
                {
                    Console.Clear();
                    Program.SlowTextAnimation("You pull the " + Weapons.SpearOfAthena.ItemName + " out of the bag and sling it to across your back.");
                    SpearWeaponPlayerStatUpdate();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else if (obtainingOriginalWeaponInput == "potion" || obtainingOriginalWeaponInput == "Potion" || obtainingOriginalWeaponInput == "ambrosia" || obtainingOriginalWeaponInput == "Ambrosia")
                {
                    Console.Clear();
                    Program.SlowTextAnimation("You pull the " + Potions.Ambrosia.ItemName + " out of the bag and into your small pouch.");
                    AmbrosiaPotionPlayerStatUpdate();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else
                {
                    Program.QsCharacterDialog("Please type sword, bow, spear, or potion.");
                    Console.ReadKey();
                    continue;
                }
            }
        }

        public static void SwordWeaponPlayerStatUpdate()
        {
            string swordWeaponType = Weapons.HephaestusSword.WeaponType.ToString();

            Program.currentPlayer.playerWeaponName = Weapons.HephaestusSword.ItemName;
            Program.currentPlayer.playerWeaponType = swordWeaponType;
            Program.currentPlayer.playerWeaponStrength = Weapons.HephaestusSword.ItemStrengthBoost;
        }
        public static void BowWeaponPlayerStatUpdate()
        {
            string bowWeaponType = Weapons.ApollosBow.WeaponType.ToString();

            Program.currentPlayer.playerWeaponName = Weapons.ApollosBow.ItemName;
            Program.currentPlayer.playerWeaponType = bowWeaponType;
            Program.currentPlayer.playerWeaponStrength = Weapons.ApollosBow.ItemStrengthBoost;
        }
        public static void SpearWeaponPlayerStatUpdate()
        {
            string spearWeaponType = Weapons.SpearOfAthena.WeaponType.ToString();

            Program.currentPlayer.playerWeaponName = Weapons.SpearOfAthena.ItemName;
            Program.currentPlayer.playerWeaponType = spearWeaponType;
            Program.currentPlayer.playerWeaponStrength = Weapons.SpearOfAthena.ItemStrengthBoost;
        }
        public static void AmbrosiaPotionPlayerStatUpdate()
        {
            Program.currentPlayer.playerHealthPotion++;
        }


    }
}

