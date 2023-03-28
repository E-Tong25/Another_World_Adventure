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
            Console.WriteLine("Help them? y/n");

            while (true)
            {
                string? helpCloakedFigureInput = Console.ReadLine();

                if (helpCloakedFigureInput == "y" || helpCloakedFigureInput == "Y")
                {
                    Program.SlowTextAnimation("As you regain your footing, you help the cloaked figure gather their bags.");
                    Console.WriteLine();
                    Program.CynosCharacterDialog("\"Why, thank you very much.\"");
                    break;
                }
                else if (helpCloakedFigureInput == "n" || helpCloakedFigureInput == "N")
                {
                    Program.SlowTextAnimation("Villagers walk past as the cloaked figure gathers their bags by themselves.");
                    Console.WriteLine();
                    break;
                }
            }
            Console.ReadKey();
            Console.Clear();

            Program.SlowTextAnimation("The cloaked figure flings the heavy baggage over their shoulder, and you are able to snag a peak of their face behind the hood.");
            Program.SlowTextAnimation("The facial structure isn't like a normal human, but rather resembles a dog or a jackle.\nA scar connects the forehead to their right eye, perhaps a reminder of a war from long ago.");
            Console.WriteLine();
            Program.CynosCharacterDialog("\"Apologies again, friend. I had just traveled here from the mountains to trade some supplies I had in my possession.\"");
            Program.CynosCharacterDialog("\"My name is Cyno.\"\n\"I can't see like I used to in my younger years, so I've gotten a bit clumsier in my old age.\"");
            Console.WriteLine();
            Program.SlowTextAnimation("He shines a friendly smile, but you can't help but see fatigue and sadness in their eyes.");
            Console.ReadKey();
            Console.Clear();
            Program.CynosCharacterDialog("\"You know, to show my sincere apologies, you can take a look at some of my wares to see if there's something you like.\"\n\"I was going to get rid of them anyways.\"");
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
                    Console.ReadKey();
                    break;
                }
                else if (lookInBagInput == "n" || lookInBagInput == "N")
                {
                    Program.CynosCharacterDialog("\"Ah, no worries. If you change your mind, I'm sure the shop keeper will be able to give you a deal.\"");
                    Console.WriteLine();
                    Program.CynosCharacterDialog("\"I hope we meet again!\"");
                    break;
                }
            }



        }

        public static void CynosBagDisplay()
        {
            Console.WriteLine("         Cynos Bag Display          ");

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|                                ");
            Console.WriteLine("|                                  ");
            Console.WriteLine("|  Description: " + Weapons.HephaestusSword.ItemName + "          ");
            Console.WriteLine("|                                 ");
            Console.WriteLine("|   (S)tellars of Tongue          ");
            Console.WriteLine("|                                 ");
            Console.WriteLine("|   (E)xit                        ");
            Console.WriteLine("-----------------------------------");

        }

    }
}

