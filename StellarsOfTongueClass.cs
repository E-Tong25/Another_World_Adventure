using System;
namespace Another_World_Adventure
{
	public static class StellarsOfTongueClass
	{
        public static BaseCharacterGuildClass StellarsOfTongue = new BaseCharacterGuildClass("Stellars Of Tongue", "\"Beauty and charm is everything in this world. As a member of the Stellars Of Tongue Guild, festivities formed by the valley's most beautiful and lusted are an everyday occurrence.\"\n|   \"Others around you flock to admire your beauty, but I doubt they'd come to you for stock advice.\"", 50, 30, 90);

        public static void StellarsOfTongueGuildPlayerStatUpdate()
        {
            Program.currentPlayer.playerStrength += StellarsOfTongue.GuildStrengthBoost;
            Program.currentPlayer.playerKnowledge += StellarsOfTongue.GuildKnowledgeBoost;
            Program.currentPlayer.playerCharm += StellarsOfTongue.GuildCharmBoost;
            Program.currentPlayer.playerGuildName += StellarsOfTongue.GuildName;
        }

        public static void StellarsOfTongueClassMenu()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("|      ");
            Console.WriteLine("|   Name of Guild: " + StellarsOfTongue.GuildName + "   ");
            Console.WriteLine("|                                 ");
            Console.WriteLine("|   Guild Description: ");
            Console.WriteLine("|                                                              ");
            Console.WriteLine("|   " + StellarsOfTongue.GuildDescription + "   ");
            Console.WriteLine("|                                 ");
            Console.WriteLine("|   (J)oin Guild                  ");
            Console.WriteLine("|                                 ");
            Console.WriteLine("|   (G)o Back                     ");
            Console.WriteLine("-----------------------------------------------");

            while (true)
            {
                string stellarsOfTongueClassMenuInput = Console.ReadLine().ToLower();
                if (stellarsOfTongueClassMenuInput == "j" || stellarsOfTongueClassMenuInput == "join guild")
                {
                    Program.SlowTextAnimation("Congrats! You now joined " + StellarsOfTongue.GuildName + ".");
                    Console.WriteLine();
                    Program.QsCharacterDialog("\"I can't see this guild being too useful, unless you were going to simply seduce every enemy. Ha! Can you imagine?\"");
                    StellarsOfTongueGuildPlayerStatUpdate();
                    Console.ReadKey();
                    Console.Clear();
                    Program.SlowTextAnimation("Your stats have been updated with your guilds skillsets!");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else if (stellarsOfTongueClassMenuInput == "g" || stellarsOfTongueClassMenuInput == "go back")
                {
                    Console.Clear();
                    break;
                }
                else if (stellarsOfTongueClassMenuInput == "" || stellarsOfTongueClassMenuInput == "")
                {
                    Program.QsCharacterDialog("\"You are really giving me mixed signals here. Do you want to join the guild or go back?\"");
                    continue;
                }
            }
        }
    }
}

