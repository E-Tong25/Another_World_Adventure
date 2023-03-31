using System;
using System.Numerics;


namespace Another_World_Adventure
{
    public class Encounters
    {
        static Random rand = new Random();

        public static void DrunkardGuardEncounter()
        {
            Program.SlowTextAnimation("You walk outside your little abode, becoming struck with all the excitment around the village square.\nVillagers, bustling about their day, seem full of energy and delight.");
            Console.WriteLine();
            Program.SlowTextAnimation("A guard, who is way too drunk for this time of day, stumbles over to you.\n\n");
            Program.GenericEnemyCharacterDialog("\"What are you looking at?\"");
            Console.ReadKey();
            // Name of enemy, power level, and health
            DrunkardGuardCombat(false, "Drunkard Guard", 5, 20);
        }

        public static void DragonEncounter()
        {
            TakingTheDragonQuest();
            Console.Clear();
            Program.SlowTextAnimation("As you got closer, you come to the large, ancient tree where a giant serpent-like dragon is wrapped around it.\n");
            Program.LadonsCharacterDialog("\"A human? Ladon the Dragon, the protector of the Golden Apple Tree, has not seen a human here for quite some time. What do you want child?\"\n");
            Program.QsCharacterDialog("\"So what now? I would suggest choosing carefully.\"\n\n\"Although, I hope you choose the wrong one like an idiot, it would be more entertaining for me.\n\n\"");
            FightingChoiceDragonEncounter(Program.currentPlayer);
            CompletingDragonQuest();
        }
        public static void ArenaEncounter()
        {
            Console.Clear();
            Program.SlowTextAnimation("You step in the ring, while viewers stand around you cheering for the fight.\nThe gate begins to lift, revealing the foe...");
            Console.Read();
            Combat(true, "", 0, 0);
            ArenaContinueMenu();
        }

        //Encounters Tools

        public static void RandomArenaEncounter()
        {
            switch (rand.Next(0, 1))
            {
                case 0:
                    ArenaEncounter();
                    break;
            }
        }

        // Post Weapon Obtain Combat Method

        public static void Combat(bool random, string name, int power, int health)
        {
            string enemyName = "";
            int enemyPower = 0;
            int enemyHealth = 0;
            if (random)
            {
                enemyName = GetName();
                enemyPower = rand.Next(5, 80);
                // Other option
                // p = Program.currentPlayer.GetPower();
                enemyHealth = rand.Next(5, 100);
                //Other Option
                // h = Program.currentPlayer.GetHealth();
            }
            else
            {
                enemyName = name;
                enemyPower = power;
                enemyHealth = health;

            }
            while (enemyHealth > 0)
            {
                Console.Clear();
                Console.WriteLine(enemyName);
                Console.WriteLine("Power Level: " + enemyPower + " /" + " Health: " + enemyHealth);
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("| (R)un	  (H)eal   |");
                Console.WriteLine("=====================");
                Console.WriteLine("Available Potions: " + Program.currentPlayer.playerHealthPotion + "  Player Health: " + Program.currentPlayer.playerHealth);

                string encounterInput = Console.ReadLine();
                if (encounterInput.ToLower() == "a" || encounterInput.ToLower() == "attack")
                {
                    //Attack

                    Program.SlowTextAnimation("You take your " + Program.currentPlayer.playerWeaponType + " and attack.");
                    int enemyAttack = enemyPower;
                    if (enemyAttack < 0)
                        enemyAttack = 0;
                    int playerAttack = rand.Next(0, Program.currentPlayer.playerWeaponStrength) + rand.Next(1, 7);
                    Console.WriteLine();
                    Program.QsCharacterDialog("\"Yikes, looks like you lost " + enemyAttack + " health.\"\n\n\"On the brightside, you dealt " + enemyName + " " + playerAttack + " damage.\"");
                    Program.currentPlayer.playerHealth -= enemyAttack;
                    enemyHealth -= playerAttack;
                }
                else if (encounterInput.ToLower() == "d" || encounterInput.ToLower() == "defend")
                {
                    //Defend

                    Program.SlowTextAnimation("As the " + enemyName + " begins to attack, you brace yourself for impact.");
                    Console.WriteLine();
                    int enemyAttack = (enemyPower / 4);
                    if (enemyAttack < 0)
                        enemyAttack = 0;
                    int playerAttack = rand.Next(0, Program.currentPlayer.playerStrength) / 2;
                    Program.QsCharacterDialog("\"Pretty good defense, but not good enough. You lost " + enemyAttack + " health.\"\n\"I'm not too sure how, but you manage to deal " + playerAttack + " damage on defense.\"");
                    Program.currentPlayer.playerHealth -= enemyAttack;
                    enemyHealth -= playerAttack;
                }
                else if (encounterInput.ToLower() == "r" || encounterInput.ToLower() == "run")
                {
                    //Run

                    if (rand.Next(0, 2) == 0)
                    {
                        Program.SlowTextAnimation("As you sprint away from the " + enemyName + " , it manages to cut you, sending a sharp pain in your back.");
                        int enemyAttack = enemyPower + rand.Next(1, 6);
                        if (enemyAttack < 0)
                            enemyAttack = 0;
                        Program.SlowTextAnimation("You lose " + enemyAttack + " health and are unable to escape.");
                        Program.currentPlayer.playerHealth -= enemyAttack;

                        Console.ReadKey();
                    }
                    else
                    {
                        Program.QsCharacterDialog("\"Wow, look at those serpertine moves.\"\n\"Didn't think you could get away from the " + enemyName + ". I guess I loose that bet.\"");
                        Console.ReadKey();
                        //May want to change later to make it village or navigator to choose location
                        Console.WriteLine();
                        Console.WriteLine();
                        Shop.LoadShop(Program.currentPlayer);

                    }
                }
                else if (encounterInput.ToLower() == "h" || encounterInput.ToLower() == "heal")
                {
                    //Heal

                    if (Program.currentPlayer.playerHealthPotion == 0)
                    {
                        Program.QsCharacterDialog("\"Oh sweety, bless your heart. You have no potion to help you.\"\n\"Have fun dying, see you soon.\" *mwah*");
                        Console.WriteLine();
                        int enemyAttack = enemyPower * enemyPower;
                        if (enemyAttack < 0)
                            enemyAttack = 0;
                        Program.SlowTextAnimation("The " + enemyName + " takes the opportunity and strikes you with a mighty blow, and you lose " + enemyAttack + " health!");
                        Program.currentPlayer.playerHealth -= enemyAttack;

                    }
                    else
                    {
                        Program.SlowTextAnimation("You remember you aquired a potion for moments like this. \n Scrummaging around in your bag, you find the flask and down the potion.");
                        Program.QsCharacterDialog("\"Look who came prepared.\"\n \"You managed to suckle " + Potions.Ambrosia.ItemHealthBoost + " health back.\"");
                        Program.currentPlayer.playerHealth += Potions.Ambrosia.ItemHealthBoost;
                        Program.QsCharacterDialog("\"You didn't think the " + enemyName + " would just let you chill and drink some go-go juice in peace did you?\"");
                        Program.SlowTextAnimation("The " + enemyName + "struck the potion out from your hand just after you drank the last drop. \n You are knocked to the ground.");
                        int enemyAttack = (enemyPower / 2) - Program.currentPlayer.playerHealth;
                        if (enemyAttack < 0)
                            enemyAttack = 0;
                        Program.SlowTextAnimation("You lose " + enemyAttack + "health.");
                        Program.currentPlayer.playerHealth -= enemyAttack;

                    }
                    Console.ReadKey();
                }
                if (Program.currentPlayer.playerHealth <= 0)
                {
                    //Death

                    Program.QsCharacterDialog("\"Hey, you're not looking so well. I think we should take you to the Asclepius.\"\n\"You have insurance, right? It's fine, I'll put it on your tab.\"");
                    Program.SlowTextAnimation("The " + enemyName + " towers over you, as you begin to fade from consciousness. You died.");
                    Console.ReadKey();
                    Program.Quit();
                    //System.Environment.Exit(0);
                }
                Console.ReadKey();
            }

            //coins

            Console.Clear();
            Program.QsCharacterDialog("\"Congrats on defeating the " + enemyName + " " + Program.currentPlayer.playerName + ", you must be proud.\"\n\"For your troubles.\"\n");
            int coinsReward = Program.currentPlayer.GetCoins();
            Program.SlowTextAnimation(coinsReward + " gold coins fall on your head.");
            Program.currentPlayer.playerCoins += coinsReward;
            Console.ReadKey();

        }

        // Pre Weapon Obtain - Combat Method

        public static void DrunkardGuardCombat(bool random, string name, int power, int health)
        {
            string enemyName = "";
            int enemyPower = 0;
            int enemyHealth = 0;

            enemyName = name;
            enemyPower = power;
            enemyHealth = health;

            while (enemyHealth > 0)
            {
                Console.Clear();
                Console.WriteLine(enemyName);
                Console.WriteLine("Power Level: " + enemyPower + " /" + " Health: " + enemyHealth);
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("| (R)un	  (H)eal   |");
                Console.WriteLine("=====================");
                Console.WriteLine("Available Potions: " + Program.currentPlayer.playerHealthPotion + "  Player Health: " + Program.currentPlayer.playerHealth);

                string encounterInput = Console.ReadLine();
                if (encounterInput.ToLower() == "a" || encounterInput.ToLower() == "attack")
                {
                    //Attack

                    Program.SlowTextAnimation("Raising your fists, you attack.");
                    int enemyAttack = enemyPower;
                    if (enemyAttack < 0)
                        enemyAttack = 0;
                    int playerAttack = rand.Next(0, Program.currentPlayer.playerWeaponStrength) + rand.Next(1, 7);
                    Console.WriteLine();
                    Program.QsCharacterDialog("\"Yikes, looks like you lost " + enemyAttack + " health.\"\n\n\"On the brightside, you dealt " + enemyName + " " + playerAttack + " damage.\"");
                    Program.currentPlayer.playerHealth -= enemyAttack;
                    enemyHealth -= playerAttack;
                }

                else if (encounterInput.ToLower() == "d" || encounterInput.ToLower() == "defend")
                {
                    //Defend

                    Program.SlowTextAnimation("As the " + enemyName + " begins to attack, you brace yourself for impact.");
                    Console.WriteLine();
                    int enemyAttack = (enemyPower / 4);
                    if (enemyAttack < 0)
                        enemyAttack = 0;
                    Program.QsCharacterDialog("\"Pretty good defense, but not good enough. You lost " + enemyAttack + " health.\"");
                    Program.currentPlayer.playerHealth -= enemyAttack;
                }

                else if (encounterInput.ToLower() == "r" || encounterInput.ToLower() == "run")
                {
                    //Run

                    if (rand.Next(0, 2) == 0)
                    {
                        Program.SlowTextAnimation("As you sprint away from the " + enemyName + " , you trip and twist your ankle, sending a sharp pain in your leg.");
                        int enemyAttack = enemyPower + rand.Next(1, 6);
                        if (enemyAttack < 0)
                            enemyAttack = 0;
                        Program.SlowTextAnimation("You lose " + enemyAttack + " health and are unable to escape.");
                        Program.currentPlayer.playerHealth -= enemyAttack;

                        Console.ReadKey();
                    }
                    else
                    {
                        Program.SlowTextAnimation("You try to reason your way out of the fight, but it doesn't seem your words got through to the " + enemyName + ".");
                        Console.ReadKey();
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
                else if (encounterInput.ToLower() == "h" || encounterInput.ToLower() == "heal")
                {
                    //Heal

                    if (Program.currentPlayer.playerHealthPotion == 0)
                    {
                        Program.QsCharacterDialog("\"We haven't even gotten to go to the shop yet, and you think I magically bestowed you a potion this early?\"\n\"The entitlement, ha.\"");
                        Console.WriteLine();
                        int enemyAttack = enemyPower * enemyPower;
                        if (enemyAttack < 0)
                            enemyAttack = 0;
                        Program.SlowTextAnimation("The " + enemyName + " takes the opportunity and strikes you with a mighty blow, and you lose " + enemyAttack + " health!");
                        Program.currentPlayer.playerHealth -= enemyAttack;
                    }
                    Console.ReadKey();
                }

                if (Program.currentPlayer.playerHealth <= 0)
                {
                    //Death

                    Program.QsCharacterDialog("\"Hey, you're not looking so well. I think we should take you to the Asclepius.\"\n\"You have insurance, right? It's fine, I'll put it on your tab.\"");
                    Program.SlowTextAnimation("The " + enemyName + " towers over you, as you begin to fade from consciousness. You died.");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            }

            //coins

            Console.Clear();
            Program.QsCharacterDialog("\"Oof, he's going to have a massive headache later.\"\n\"I can't tell whether you slapping him around or the booze would be the main culprit\"\n\"Oh well, good job on defeating the " + enemyName + " " + Program.currentPlayer.playerName + ", you must be proud.\"\n");
            int coinsReward = Program.currentPlayer.GetCoins();
            Program.SlowTextAnimation(coinsReward + " gold coins fall on your head.");
            Program.currentPlayer.playerCoins += coinsReward;
            Console.ReadKey();
        }

        public static void DragonCombat(bool random, string name, int power, int health)
        {
            string enemyName = "";
            int enemyPower = 0;
            int enemyHealth = 0;

            enemyName = name;
            enemyPower = power;
            enemyHealth = health;


            while (enemyHealth > 0)
            {
                Console.Clear();
                Console.WriteLine(enemyName);
                Console.WriteLine("Power Level: " + enemyPower + " /" + " Health: " + enemyHealth);
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("| (R)un	  (H)eal   |");
                Console.WriteLine("=====================");
                Console.WriteLine("Available Potions: " + Program.currentPlayer.playerHealthPotion + "  Player Health: " + Program.currentPlayer.playerHealth);

                string encounterInput = Console.ReadLine();
                if (encounterInput.ToLower() == "a" || encounterInput.ToLower() == "attack")
                {
                    //Attack

                    Program.SlowTextAnimation("You take your " + Program.currentPlayer.playerWeaponType + " and attack.");
                    int enemyAttack = enemyPower;
                    if (enemyAttack < 0)
                        enemyAttack = 0;
                    int playerAttack = rand.Next(0, Program.currentPlayer.playerWeaponStrength) + rand.Next(1, 7);
                    Console.WriteLine();
                    Program.QsCharacterDialog("\"Yikes, looks like you lost " + enemyAttack + " health.\"\n\n\"On the brightside, you dealt " + enemyName + " " + playerAttack + " damage.\"");
                    Program.currentPlayer.playerHealth -= enemyAttack;
                    enemyHealth -= playerAttack;
                }
                else if (encounterInput.ToLower() == "d" || encounterInput.ToLower() == "defend")
                {
                    //Defend

                    Program.SlowTextAnimation("As the " + enemyName + " begins to attack, you brace yourself for impact.");
                    Console.WriteLine();
                    int enemyAttack = (enemyPower / 4);
                    if (enemyAttack < 0)
                        enemyAttack = 0;
                    int playerAttack = rand.Next(0, Program.currentPlayer.playerStrength) / 2;
                    Program.QsCharacterDialog("\"Pretty good defense, but not good enough. You lost " + enemyAttack + " health.\"\n\"I'm not too sure how, but you manage to deal " + playerAttack + " damage on defense.\"");
                    Program.currentPlayer.playerHealth -= enemyAttack;
                    enemyHealth -= playerAttack;
                }
                else if (encounterInput.ToLower() == "r" || encounterInput.ToLower() == "run")
                {
                    //Run

                    if (rand.Next(0, 2) == 0)
                    {
                        Program.SlowTextAnimation("As you sprint away from the " + enemyName + " , it manages to cut you, sending a sharp pain in your back.");
                        int enemyAttack = enemyPower + rand.Next(1, 6);
                        if (enemyAttack < 0)
                            enemyAttack = 0;
                        Program.SlowTextAnimation("You lose " + enemyAttack + " health and are unable to escape.");
                        Program.currentPlayer.playerHealth -= enemyAttack;

                        Console.ReadKey();
                    }
                    else
                    {
                        Program.QsCharacterDialog("\"Wow, look at those serpertine moves.\"\n\"Didn't think you could get away from the " + enemyName + ". I guess I loose that bet.\"");
                        Console.ReadKey();
                        //May want to change later to make it village or navigator to choose location
                        Console.WriteLine();
                        Console.WriteLine();
                        Shop.LoadShop(Program.currentPlayer);

                    }
                }
                else if (encounterInput.ToLower() == "h" || encounterInput.ToLower() == "heal")
                {
                    //Heal

                    if (Program.currentPlayer.playerHealthPotion == 0)
                    {
                        Program.QsCharacterDialog("\"Oh sweety, bless your heart. You have no potion to help you.\"\n\"Have fun dying, see you soon.\" *mwah*");
                        Console.WriteLine();
                        int enemyAttack = enemyPower * enemyPower;
                        if (enemyAttack < 0)
                            enemyAttack = 0;
                        Program.SlowTextAnimation("The " + enemyName + " takes the opportunity and strikes you with a mighty blow, and you lose " + enemyAttack + " health!");
                        Program.currentPlayer.playerHealth -= enemyAttack;

                    }
                    else
                    {
                        Program.SlowTextAnimation("You remember you aquired a potion for moments like this. \n Scrummaging around in your bag, you find the flask and down the potion.");
                        Program.QsCharacterDialog("\"Look who came prepared.\"\n \"You managed to suckle " + Potions.Ambrosia.ItemHealthBoost + " health back.\"");
                        Program.currentPlayer.playerHealth += Potions.Ambrosia.ItemHealthBoost;
                        Program.QsCharacterDialog("\"You didn't think the " + enemyName + " would just let you chill and drink some go-go juice in peace did you?\"");
                        Program.SlowTextAnimation("The " + enemyName + "struck the potion out from your hand just after you drank the last drop. \n You are knocked to the ground.");
                        int enemyAttack = (enemyPower / 2) - Program.currentPlayer.playerHealth;
                        if (enemyAttack < 0)
                            enemyAttack = 0;
                        Program.SlowTextAnimation("You lose " + enemyAttack + "health.");
                        Program.currentPlayer.playerHealth -= enemyAttack;

                    }
                    Console.ReadKey();
                }
                if (Program.currentPlayer.playerHealth <= 0)
                {
                    //Death

                    Program.QsCharacterDialog("\"Hey, you're not looking so well. I think we should take you to the Asclepius.\"\n\"You have insurance, right? It's fine, I'll put it on your tab.\"");
                    Program.SlowTextAnimation("The " + enemyName + " towers over you, as you begin to fade from consciousness. You died.");
                    Console.ReadKey();
                    Program.Quit();
                    //System.Environment.Exit(0);
                }
                Console.ReadKey();
            }
        }

        public static string GetName()
        {
            switch (rand.Next(0, 4))
            {
                case 0:
                    return "Guard";
                case 1:
                    return "Cyclops";
                case 2:
                    return "Harpy";
                case 3:
                    return "Lion";

            }
            return "Gladiator";
        }

        public static void ArenaContinueMenu()
        {
            Console.Clear();
            Console.WriteLine("Would you like to go another round?");
            Console.WriteLine("===================================");
            Console.WriteLine("|       (Y)es        (N)o         |");
            Console.WriteLine("===================================");
            Console.WriteLine("\n");

            while (true)
            {
                string arenaContinueInput = Console.ReadLine();
                if (arenaContinueInput == "y" || arenaContinueInput == "Y" || arenaContinueInput == "yes" || arenaContinueInput == "Yes")
                {
                    ArenaEncounter();
                }
                else if (arenaContinueInput == "n" || arenaContinueInput == "N" || arenaContinueInput == "no" || arenaContinueInput == "No")
                {
                    Locations.LoadAllLocationsMenu();
                }
                else if (arenaContinueInput == "")
                {
                    Program.SlowTextAnimation("Please type y continue fighting in the arena and n to go back to the Village Square.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
            }
        }

        public static void TakingTheDragonQuest()
        {
            Program.SlowTextAnimation("As you exit from the guild, you notice a job posting on the wall.\n");
            Console.WriteLine("Wanted: Adventurer");
            Console.WriteLine("--------------------");
            Console.WriteLine("Task:");
            Console.WriteLine("Out in the forest within a vast garden, there resides a single Golden Apple Tree. Find and retreieve an apple from this tree for a reward.\n");
            Console.WriteLine("Reward: 200 gold coins\n");
            Console.WriteLine("FYI: ");
            Console.WriteLine("There is totally no danger in this job. Yep, none wahtsoever.\n");
            Program.QsCharacterDialog("\"Sounds promising, I think you should do it.\"\n\"It can raise your cool score, which you desperately need.\"");
            Console.ReadKey();
            Console.Clear();
            Program.SlowTextAnimation("You set off, walking in the countryside, searching for information about this mysterious garden.");
            Program.SlowTextAnimation("For days, you had not been successful. Higher in the mountains, you decided to climb to perhaps find a better view of the forest.");
            Program.SlowTextAnimation("The mountains, a natural wall and boundary to other far off lands seemed to hold many mysteries and life.");
            Program.SlowTextAnimation("The sun started to set, and you needed to find a place to make camp. You notice not too far off, a line of smoke rises in the sky.\n");
            Program.QsCharacterDialog("\"Oh goodie, a small camp fire! A sign of civilization, at last!\"");
            Console.ReadKey();
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Go to the smoke source? [y/n]");

                string? goToCampfireInput = Console.ReadLine();
                if (goToCampfireInput == "y" || goToCampfireInput == "Y" || goToCampfireInput == "yes" || goToCampfireInput == "Yes")
                {
                    Console.Clear();
                    Program.SlowTextAnimation("Using the smoke as your guiding light, you venture closer to the source.");
                    Program.SlowTextAnimation("Peaking out of the trees, you see an small opening of grass, currently home to a small campsite. A makeshift tent is weighed down and offered structured by various baggage and boxes, and a cooking pot assembled over the burning fire illuminates a figure.");
                    Program.SlowTextAnimation("The cloaked figure pokes at the fire with a long branch, feeding the flames to engulf the bottom of the pot more.");
                    Program.SlowTextAnimation("While the figure hasn't noticed you yet, you overhear the figure softly hum and sing a ballad to themselves.\n");
                    Program.CynosCharacterDialog("\"Hó-son   zēis  phaí-nou\"n\"mē-dén hó-lōs   su   lu-poû\"\n\"pros o - lí - gon és -ti    to zên\"\"to té -los ho  chró-nos a - pai-teî\"\n");
                    Program.SlowTextAnimation("That voice, it sounds familiar.\n");
                    Program.CynosCharacterDialog("\"While you live, shine bright:\"\n\"Don't let sorrow you benight;\"\n\"We don't have life for long, my friend:\"\"To everything Time demands an end.\"");
                    Program.SlowTextAnimation("Moving closer, you step onto a branch, breaking it.");
                    Program.SlowTextAnimation("The figure freezes and lifts their head into the air.");
                    Program.CynosCharacterDialog("\"While I may be old, my nose still remains accurate. That scent, we have met before.\"\n");
                    Program.SlowTextAnimation("Turning he flashes the warmest smile.\n");
                    Program.CynosCharacterDialog("\"Hello, my friend.\"\n");
                    Program.SlowTextAnimation("After a long night of catching up and telling Cyno about your quest, he offered to help you since he has been to the secret garden before.");
                    Program.SlowTextAnimation("You both get some sleep, awaiting the day ahead.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else if (goToCampfireInput == "n" || goToCampfireInput == "N" || goToCampfireInput == "no" || goToCampfireInput == "No")
                {
                    Console.Clear();
                    Program.SlowTextAnimation("You reroute your climb and sway away from the smoke in the sky.");
                    Program.SlowTextAnimation("You manage to find a small cave to make camp for the evening.");
                    Program.SlowTextAnimation("In the middle of the night, you are awoken by a large spider crawling over you. In a panic, you grab your " + Program.currentPlayer.playerWeaponName + " and fight off the spider.");
                    Program.SlowTextAnimation("While you are victorious fending off the beast, the spider had bitten you and you were hurt in the process.");
                    Program.SlowTextAnimation("You took 15 damage.");
                    Program.currentPlayer.playerHealth -= 15;
                    Program.SlowTextAnimation("In the morning, you headed back down the mountain to a nearby stream to wash your clothes from the late-night spider encounter.\n");
                    Program.QsCharacterDialog("\"Who knew killing spiders would be that messy? I just cringe everytime I think about it.\"\n");
                    Program.SlowTextAnimation("All the day's worth of climbing, wasted due to a vexing spider.");
                    Program.SlowTextAnimation("Feeling defeated and lost on what to do now, you lay on the grass and look to the sky. The clouds slowly float by as the sunbeams purify their fluffy, white masses.\n");
                    Program.CynosCharacterDialog("\"Well, by the Gods, we meet again, my friend.\"\n");
                    Program.SlowTextAnimation("That voice, it sounds familiar.");
                    Program.SlowTextAnimation("Turning, you see a cloaked figure standing over you, smiling from ear to ear. Cyno.");
                    Program.SlowTextAnimation("Cyno helps you to you feet and gives you a large hug.");
                    Program.SlowTextAnimation("For someone as old as he, he still has incredible strength. You begin to feel squished.");
                    Program.SlowTextAnimation("\"Apologies, I forget how fragile humans are.\"\n");
                    Program.SlowTextAnimation("Light heartedly chuckling, he releases you as you gasp for air.\n");
                    Program.SlowTextAnimation("\"What brings you this far out from the village, " + Program.currentPlayer.playerName + "?\"\n");
                    Program.SlowTextAnimation("After a long conversation of catching up and telling Cyno about your quest, he offered to help you since he has been to the secret garden before.");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                }
                else
                {
                    Program.QsCharacterDialog("\"Come on, hurry up! It's getting cold out here.\"\n\n\"Please type y or n.\"");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
            }
            Program.SlowTextAnimation("Following Cyno through the forest, you both come to a mystic fog, as if it were the edge of the world.\n");
            Program.CynosCharacterDialog("\"No need to fear, the fog acts as a boundary to keep demons or ill-of-heart away.\"\n\"As you continue forward, you will find the garden. The nymphs shouldn't bother you at this time of the day, so you should find the Golden Apple Tree in the middle of the garden without interference.\"\n");
            Program.SlowTextAnimation("Cyno starts to head back the way you came and waves goodbye once more.\n");
            Program.CynosCharacterDialog("\"I'm positive we will meet again soon. Good luck!\"\n");
            Program.SlowTextAnimation("You walk through the mist, and are greeted by a warm and sweet smell. Flowers bloom all around, it seems like an endless field of flowers, plants, and grasses in all directions.");
            Program.SlowTextAnimation("A marble path leads further into the field, where you can see a bright, golden glare.");
        }

        public static void CompletingDragonQuest()
        {
            Program.SlowTextAnimation("Ladon has been subdued and you are able to approach the Gold Apple Tree.");
            Program.SlowTextAnimation("You reach for one on a lower branch and you manage to pluck it off. The apple is a rather large, the gold exterior makes it a beauty to behold.\n");
            Program.QsCharacterDialog("\"Congrats on accomplishing the quest! How exciting. I guess the only thing now is to return it to the one who requested the task\"\n");
            Program.SlowTextAnimation("Suddenly the apple vanishes in thin air.\n");
            Program.QsCharacterDialog("\"Surprise, surprise, I was the one who requested the apple and posted the quest. While I know it was very mischievous of me, look at how far you've come, " + Program.currentPlayer.playerName + "!\"\n\"Ah! So proud.\"");
            Program.QsCharacterDialog("\"The legends behind these apples are that they hold a great power of immortality. Something only belonging to the Gods.\"\n\"Me, I just like the taste. Yum! Nothing better than an golden apple that was fought for by a brave adventurer, yes! I can't get enough.\"\n\"As promised, here is your reward.\"");
            int coinsReward = 200;
            Program.SlowTextAnimation(coinsReward + " gold coins fall on your head.");
            Program.currentPlayer.playerCoins += coinsReward;
            Console.ReadKey();
            Console.Clear();
            Program.SlowTextAnimation("")
        }

        public static void FightingChoiceDragonEncounter(Player player)
        {


            while (true)
            {
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack          |");
                Console.WriteLine("| (O)utwit	       |");
                Console.WriteLine("| (S)educe	       |");
                Console.WriteLine("=====================");

                string dragonEncounterInput = Console.ReadLine();

                if (dragonEncounterInput == "a" || dragonEncounterInput == "A" || dragonEncounterInput == "attack" || dragonEncounterInput == "Attack")
                {
                    int skillLevel = Program.currentPlayer.playerStrength;
                    TryToDefeatWithGuildSkill("strength", skillLevel, player);
                    break;
                }
                if (dragonEncounterInput == "o" || dragonEncounterInput == "O" || dragonEncounterInput == "outwit" || dragonEncounterInput == "OutWit")
                {
                    int skillLevel = Program.currentPlayer.playerKnowledge;
                    TryToDefeatWithGuildSkill("knowledge", skillLevel, player);
                    break;
                }
                if (dragonEncounterInput == "s" || dragonEncounterInput == "S" || dragonEncounterInput == "seduce" || dragonEncounterInput == "Seduce")
                {
                    int skilllevel = Program.currentPlayer.playerCharm;
                    TryToDefeatWithGuildSkill("charm", skilllevel, player);
                    break;
                }
                if (dragonEncounterInput == "")
                {
                    Program.QsCharacterDialog("\"You can't freeze up now, come on. We are just getting to the good part!\"\n");
                    Console.WriteLine("Please type a to attempt to attack, o to attempt to outwit, or s to attempt to seduce Ladon the Serpent Dragon.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
            }
        }

        static void TryToDefeatWithGuildSkill(string guildSkill, int skillLevel, Player player)
        {
            if (skillLevel >= 50)
            {
                if (guildSkill == "strength")
                {
                    Program.SlowTextAnimation("Without much hesitation, you use your uncanny strength and your " + Program.currentPlayer.playerWeaponName + " to quickly defeat Ladon.\n");
                    Program.QsCharacterDialog("\"Well damn, you didn't give him much time did you? Things to do, people to see, I get it, but still.\"");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (guildSkill == "knowledge")
                {
                    Program.SlowTextAnimation("Using you high intellect, you successfully debated with Ladon to let you pass so that you could retrieve an apple.");
                    Program.SlowTextAnimation("You now have earned respect from Ladon, and have arranged monthly friednly, debating visits.\n");
                    Program.QsCharacterDialog("\"How cute. Looks like we have two boring, wisdom fanatics. Beggers can't be chooser for entertainment purposes, I guess.\"");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (guildSkill == "charm")
                {
                    Program.SlowTextAnimation("Doing your best seduction walk, you make you way over to Ladon. You offer compliments on his mightyness and high-intellect.");
                    Program.SlowTextAnimation("Overly flattered, Ladon begins to blush and lets his guard down enough for you to have an opportunity to grab an apple.\n");
                    Program.QsCharacterDialog("\"Wow... um, I'm speechless, honestly. Just *coughs* wow...\"");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                Console.Clear();
                Program.QsCharacterDialog("\"It looks like you didn't choose the best choice for you and your skill set. Good luck on fullout fighting!\"\n");
                Program.SlowTextAnimation("Ladon, enraged at your attempt to best him, prepares to attack.\n");
                DragonCombat(false, "Dragon", 100, 1000);
            }
        }
    }
}


