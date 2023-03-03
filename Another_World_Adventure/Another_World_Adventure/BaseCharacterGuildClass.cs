using System;
namespace Another_World_Adventure
{
	public class BaseCharacterGuildClass
	{
		private string characterGuildName;
		private string characterGuildDescription;

		//Stats

		private int strength;
		private int knowledge;
		private int charm;
		private int health;

		public string CharacterGuildName
		{
			get { return characterGuildName; }
			set { characterGuildName = value; }
		}
		public string CharacterGuildDescription
		{
			get { return characterGuildDescription; }
			set { characterGuildDescription = value; }
		}
		public int Strength
		{
			get { return strength; }
			set { strength = value; }
		}
        public int Knowledge
        {
            get { return knowledge; }
            set { knowledge = value; }
        }
        public int Charm
        {
            get { return charm; }
            set { charm = value; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        //Story Point- Guild Selection

		public static void GuildSelection()
		{
   
			while (true)
			{
                Console.WriteLine("Join a guild? [y/n]");
                string joinGuildResponse = Console.ReadLine();
                if (joinGuildResponse == "y" || joinGuildResponse == "Y")
                {
                    Console.WriteLine("\"How fun!\"\n \"There are a lot of perks with being in a guild.\"\n \"In the village, there are three to choose from:Fist of Wrath, Owls of the Devoted, and Stellars of Tongue.\"");
                    break;
                }
                else if (joinGuildResponse == "n" || joinGuildResponse == "N")
                {
                    Console.WriteLine(" \"My me, you are incredibly boring.\" You were bonked on the head, and sent back to the dark abyss.");
                    continue;
                }
                else
                {
                    Console.WriteLine("This again? You are either being difficult or just plain dumb. Please type y or n.");
                    continue;
                }
            }

            Console.Clear();
            Console.ReadKey();

            Console.WriteLine("\"Here in this village, there are three guilds to choose from: \"");
		}

    }
}

