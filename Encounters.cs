using System;


namespace Another_World_Adventure
{
	public class Encounters
	{
		static Random rand = new Random();
		//Encounters Generic


		//Encounters

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
            Program.SlowTextAnimation("Deeper into the cave you go, until you see a massive dragon laying sound asleep.");
			Console.WriteLine();
			Program.QsCharacterDialog("\"So what now? You have your mission or whatever, but the question remains, how will you go about it?\"\n\n\"I hope like an idiot, it would be more entertaining for me.\"");
            Console.ReadKey();
            Combat(false, "Dragon", 100, 1000);
		}

		public static void ArenaEncounter()
		{
			Console.Clear();
            Program.SlowTextAnimation("You step in the ring, while viewers stand around you cheering for the fight.\nThe gate begins to lift, revealing the foe...");
			Console.Read();
			Combat(true, "", 0, 0);
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

        //
        //
		// Post Weapon Obtain Combat Method
        //
        //
        
		public static void Combat(bool random,string name, int power, int health)
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
				Console.WriteLine("Power Level: " + enemyPower + " /" + " Health: "+ enemyHealth);
				Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("| (R)un	  (H)eal   |");
                Console.WriteLine("=====================");
				Console.WriteLine("Available Potions: " + Program.currentPlayer.playerPotion + "  Player Health: " + Program.currentPlayer.playerHealth);

				string encounterInput = Console.ReadLine();
                if(encounterInput.ToLower() == "a" || encounterInput.ToLower() == "attack")
				{
					//Attack

					Program.SlowTextAnimation("You take your " + Program.currentPlayer.playerWeaponType +" and attack.");
					int enemyAttack = enemyPower;
					if (enemyAttack < 0)
						enemyAttack = 0;
					int playerAttack = rand.Next(0, Program.currentPlayer.playerWeaponStrength) + rand.Next(1,7);
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
                    int enemyAttack = (enemyPower/4);
					if (enemyAttack < 0)
						enemyAttack = 0;
                    int playerAttack = rand.Next(0, Program.currentPlayer.CalculatedPlayerStrength)/2;
                    Program.QsCharacterDialog("\"Pretty good defense, but not good enough. You lost " + enemyAttack + " health.\"\n\"I'm not too sure how, but you manage to deal " + playerAttack + " damage on defense.\"");
                    Program.currentPlayer.playerHealth -= enemyAttack;
                    enemyHealth -= playerAttack;
                }
                else if (encounterInput.ToLower() == "r" || encounterInput.ToLower() == "run")
                {
					//Run

					if (rand.Next(0,2) == 0)
					{
                        Program.SlowTextAnimation("As you sprint away from the " + enemyName + " , it manages to cut you, sending a sharp pain in your back.");
						int enemyAttack = enemyPower + rand.Next(1,6);
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

					if(Program.currentPlayer.playerPotion == 0)
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
						int potionHealth = 20;
                        Program.QsCharacterDialog("\"Look who came prepared.\"\n \"You managed to suckle " + potionHealth + " health back.\"");
						Program.currentPlayer.playerHealth += potionHealth;
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
				if(Program.currentPlayer.playerHealth<=0)
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
			Program.QsCharacterDialog("\"Congrats on defeating the " + enemyName + " " + Program.currentPlayer.playerName + ", you must be proud.\"\n\"For your troubles.\"\n");
			int coinsReward = Program.currentPlayer.GetCoins();
            Program.SlowTextAnimation(coinsReward + " gold coins fall on your head.");
			Program.currentPlayer.playerCoins += coinsReward;
			Console.ReadKey();
        }

        //
        //
        // Pre Weapon Obtain Combat Method
        //
        //

        public static void DrunkardGuardCombat(bool random, string name, int power, int health)
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
                Console.WriteLine("Available Potions: " + Program.currentPlayer.playerPotion + "  Player Health: " + Program.currentPlayer.playerHealth);

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
                    int playerAttack = rand.Next(0, Program.currentPlayer.playerWeaponStrength) / 2;
                    Program.QsCharacterDialog("\"Pretty good defense, but not good enough. You lost " + enemyAttack + " health.\"\n\"I'm not too sure how, but you manage to deal " + playerAttack + " damage on defense.\"");
                    Program.currentPlayer.playerHealth -= enemyAttack;
                    enemyHealth -= playerAttack;
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
                        Program.QsCharacterDialog("\"It's not too impressive since you are fighting a drunk, but I didn't think you could get away from the " + enemyName + ".\"\n\".I guess I loose that bet.\"");
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

                    if (Program.currentPlayer.playerPotion == 0)
                    {
                        Program.QsCharacterDialog("\"We haven't even gotten to go to the shop yet, and you think I magically bestowed you a potion this early?\"\n\"The entitlement, ha.\"");
                        Console.WriteLine();
                        int enemyAttack = enemyPower * enemyPower;
                        if (enemyAttack < 0)
                            enemyAttack = 0;
                        Program.SlowTextAnimation("The " + enemyName + " takes the opportunity and strikes you with a mighty blow, and you lose " + enemyAttack + " health!");
                        Program.currentPlayer.playerHealth -= enemyAttack;

                    }
                    else
                    {
                        Program.SlowTextAnimation("You remember you aquired a potion for moments like this.\nScrummaging around in your bag, you find the flask and down the potion.");
                        int potionHealth = 20;
                        Program.QsCharacterDialog("\"Look who came prepared.\"\n\"You managed to suckle " + potionHealth + " health back.\"");
                        Program.currentPlayer.playerHealth += potionHealth;
                        Program.QsCharacterDialog("\"You didn't think the " + enemyName + " would just let you chill and drink some go-go juice in peace did you?\"");
                        Program.SlowTextAnimation("The " + enemyName + "struck the potion out from your hand just after you drank the last drop.\nYou are knocked to the ground.");
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

        public static string GetName()
		{
			switch(rand.Next(0, 4))
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
	}
}

