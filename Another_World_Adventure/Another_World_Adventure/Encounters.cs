using System;
namespace Another_World_Adventure
{
	public class Encounters
	{
		static Random rand = new Random();
		//Encounters Generic



		//Encounters

		public static void GuardEncounter()
		{
			Console.WriteLine("You walk outside your little abode, becoming struck with all the excitment around the village square. \n Villagers, bustling about their day, seem full of energy and excitment.");
			Console.WriteLine("A guard, who is way too drunk for this time of day, stumbles over to you.\n\"What are you looking at?\", he slurs.");
			Console.ReadKey();
			// Name of enemy, power level, and health
			Combat(false, "Drunkard Guard", 20, 60);
		}

		public static void DragonEncounter()
		{
			Console.WriteLine("Deeper into the cave you go, until you see a massive dragon laying sound asleep.");
			Console.WriteLine("\"So what now? You have your mission or whatever, but the question remains, how will you go about it?\"\n\"I hope like an idiot, it would be more entertaining for me.\"");
			Combat(false, "Dragon", 100, 1000);
		}

		public static void ArenaEncounter()
		{
			Console.Clear();
			Console.WriteLine("You step in the ring, while viewers stand around you cheering for the fight.\nThe gate begins to lift, revealing the foe...");
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

		public static void Combat(bool random,string name, int power, int health)
		{
			string n = "";
			int p = 0;
			int h = 0;
			if (random)
			{
				n = GetName();
				p = rand.Next(5, 80);
				// Other option
				// p = Program.currentPlayer.GetPower();
				h = rand.Next(5, 100);
				//Other Option
				// h = Program.currentPlayer.GetHealth();
			}
			else
			{
				n = name;
				p = power;
				h = health;

			}
			while (h > 0)
			{
				Console.Clear();
				Console.WriteLine(n);
				Console.WriteLine(p + "/" + h);
				Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("| (R)un	  (H)eal   |");
                Console.WriteLine("=====================");
				Console.WriteLine("Potions: " + Program.currentPlayer.potion + "  Health: " + Program.currentPlayer.health);
				string input = Console.ReadLine();
                if(input.ToLower() == "a" || input.ToLower() == "attack")
				{
					//Attack
					Console.WriteLine("You take your " + Program.currentPlayer.weaponType +" and attack.");
					int enemyAttack = p - Program.currentPlayer.health;
					if (enemyAttack < 0)
						enemyAttack = 0;
					int playerAttack = rand.Next(0, Program.currentPlayer.weaponStrength) + rand.Next(1,7);  
					Console.WriteLine(" \"Yikes, looks like you lost " + enemyAttack + " health.\"\n \"On the brightside, you dealt " + n + playerAttack + " damage.\"");
					Program.currentPlayer.health -= enemyAttack;
					h -= playerAttack;
                }
				else if (input.ToLower() == "d" || input.ToLower() == "defend")
				{
                    //Defend
                    Console.WriteLine("As the " + n + " begins to attack, you brace yourself for impact.");
                    int enemyAttack = (p/4) - Program.currentPlayer.health;
					if (enemyAttack < 0)
						enemyAttack = 0;
                    int playerAttack = rand.Next(0, Program.currentPlayer.weaponStrength)/2;
                    Console.WriteLine(" \"Pretty good defense, but not good enough. You lost " + enemyAttack + " health.\"\n \"I'm not too sure how, but you manage to deal " + playerAttack + " damage on defense.\"");
                    Program.currentPlayer.health -= enemyAttack;
                    h -= playerAttack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
					//Run
					if (rand.Next(0,2) == 0)
					{
						Console.WriteLine("As you sprint away from the " + n + " , it manages to cut you, sending a sharp pain in your back.");
						int enemyAttack = p - Program.currentPlayer.health;
						if (enemyAttack < 0)
							enemyAttack = 0;
						Console.WriteLine("You lose " + enemyAttack + " health and are unable to escape.");
						Console.ReadKey();
					}
					else
					{
						Console.WriteLine("\"Wow, look at those serpertine moves.\" \n \"Didn't think you could get away from" + n + " . I guess I loose that bet.\"");
						Console.ReadKey();
						//May want to change later to make it village or navigator to choose location
                        Shop.LoadShop(Program.currentPlayer);

                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
					//Heal
					if(Program.currentPlayer.potion == 0)
					{
						Console.WriteLine("\"Oh sweety, bless your heart. You have no potion to help you.\" \n \"Have fun dying, see you soon.\" *mwah*");
						int enemyAttack = p - Program.currentPlayer.health;
						if (enemyAttack < 0)
							enemyAttack = 0;
						Console.WriteLine("The " + n + " takes the opportunity and strikes you with a mighty blow, and you lose " + enemyAttack + " health!");
					}
					else
					{
						Console.WriteLine("You remember you aquired a potion for moments like this. \n Scrummaging around in your bag, you find the flask and down the potion.");
						int potionHealth = 20;
						Console.WriteLine("\"Look who came prepared.\"\n \"You managed to suckle " + potionHealth + " health back.\"");
						Program.currentPlayer.health += potionHealth;
						Console.WriteLine("\"You didn't think the " + n + " would just let you chill and drink some go-go juice in peace did you?\"");
						Console.WriteLine("The " + n + "struck the potion out from your hand just after you drank the last drop. \n You are knocked to the ground.");
						int enemyAttack = (p / 2) - Program.currentPlayer.health;
						if (enemyAttack < 0)
							enemyAttack = 0;
						Console.WriteLine("You lose " + enemyAttack + "health.");
					}
					Console.ReadKey();
                }
				if(Program.currentPlayer.health<=0)
				{
					//Death
					Console.WriteLine("\"Hey, you're not looking so well. I think we should take you to the Asclepius.\"\n\"You have insurance, right? It's fine, I'll put it on your tab.\"");
					Console.WriteLine("The " + n + " towers over you, as you begin to fade from consciousness. You died.");
					Console.ReadKey();
					System.Environment.Exit(0);
				}
				Console.ReadKey();
            }
			//coins

			Console.WriteLine("\"Congrats on defeating " + n + " " + Program.currentPlayer.name + " you must be proud.\"\n \"For your troubles.\"");
			int coinsReward = Program.currentPlayer.GetCoins();
			Console.WriteLine(coinsReward + " gold coins fall on your head.");
			Program.currentPlayer.coins += coinsReward;
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

