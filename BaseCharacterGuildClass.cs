using System;
namespace Another_World_Adventure
{
	public class BaseCharacterGuildClass
	{
		private string? guildName;
		private string? guildDescription;

		//Stats

		private int guildStrengthBoost;
		private int guildKnowledgeBoost;
		private int guildCharmBoost;

		public string GuildName
		{
			get { return guildName; }
			set { guildName = value; }
		}
		public string GuildDescription
		{
			get { return guildDescription; }
			set { guildDescription = value; }
		}
		public int GuildStrengthBoost
		{
			get { return guildStrengthBoost; }
			set { guildStrengthBoost = value; }
		}
        public int GuildKnowledgeBoost
        {
            get { return guildKnowledgeBoost; }
            set { guildKnowledgeBoost = value; }
        }
        public int GuildCharmBoost
        {
            get { return guildCharmBoost; }
            set { guildCharmBoost = value; }
        }
       


        //Story Point- Guild Selection

		public static void GuildSelection()
		{
   
			while (true)
			{
                Console.Clear();
                Console.WriteLine("Join a guild? [y/n]");
                string? joinGuildResponse = Console.ReadLine();
                if (joinGuildResponse == "y" || joinGuildResponse == "Y")
                {
                    Program.QsCharacterDialog("\"How fun!\"\n\"There are a lot of perks with being in a guild.\"");
                    Console.ReadKey();
                    break;
                }
                else if (joinGuildResponse == "n" || joinGuildResponse == "N")
                {
                    Program.QsCharacterDialog("\"My my, you are incredibly boring.\"\n\n");
                    Program.SlowTextAnimation("You were bonked on the head, and sent back to the dark abyss.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else
                {
                    Program.QsCharacterDialog("\"This again? You are either being difficult or just plain dumb. Please type y or n.\"");
                    Console.ReadKey();
                    continue;
                }
            }

            Console.Clear();
            Console.ReadKey();

            Program.QsCharacterDialog("\"Here in the village, there are three guilds to choose from: Fist of Wrath, Owls of the Devoted, and Stellars of Tongue.\"");

            Console.ReadKey();
            Console.Clear();

            AllGuildsDisplayMenu();
            
        }

        public static void AllGuildsDisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("Which guild would you want to select?");

                Console.WriteLine("-----------------------------------");
                Console.WriteLine("|   (F)ist of Wrath               |");
                Console.WriteLine("|                                 |");
                Console.WriteLine("|   (O)wls of the Devoted         |");
                Console.WriteLine("|                                 |");
                Console.WriteLine("|   (S)tellars of Tongue          |");
                Console.WriteLine("|                                 |");
                Console.WriteLine("|   (E)xit                        |");
                Console.WriteLine("-----------------------------------");

                string selectGuildClass = Console.ReadLine().ToLower();

                if (selectGuildClass == "f" || selectGuildClass == "fist of wrath")
                {
                    FistOfWrathClass.FistOfWrathClassMenu();
                }
                else if (selectGuildClass == "o" || selectGuildClass == "owls of the devoted")
                {
                    OwlsOfTheDevotedClass.OwlsOfTheDevotedClassMenu();
                }
                else if (selectGuildClass == "s" || selectGuildClass == "stellars of tongue")
                {
                    StellarsOfTongueClass.StellarsOfTongueClassMenu();
                }
                else if (selectGuildClass == "e" || selectGuildClass == "exit")
                {
                    break;
                }

            }

        }

    }
}

