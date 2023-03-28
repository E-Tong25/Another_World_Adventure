using System;
namespace Another_World_Adventure
{
	public class StellarsOfTongueClass : BaseCharacterGuildClass
	{
        public static BaseCharacterGuildClass stellarsOfTongue;

        public static void StellarsOfTongueClassMenu()
        {
            BaseCharacterGuildClass stellarsOfTongue = new BaseCharacterGuildClass();

            stellarsOfTongue.GuildName = "Stellars Of Tongue";
            stellarsOfTongue.GuildDescription = "\"Beauty and charm is everything in this world. As a memeber of the Stellars Of Tongue Guild, festivitees formed by the valley's most beautiful and lusted are an everyday occurrence.\"\n|   \"Others around you flock to admire your beauty, but I doubt they'd come to you for stock advice.\"";
            stellarsOfTongue.GuildStrengthBoost = 50;
            stellarsOfTongue.GuildKnowledgeBoost = 30;
            stellarsOfTongue.GuildCharmBoost = 90;

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("|      ");
            Console.WriteLine("|   Name of Guild: " + stellarsOfTongue.GuildName + "   ");
            Console.WriteLine("|                                 ");
            Console.WriteLine("|   Guild Description: ");
            Console.WriteLine("|                                                              ");
            Console.WriteLine("|   " + stellarsOfTongue.GuildDescription + "   ");
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
                    Program.SlowTextAnimation("Congrats! You now joined " + stellarsOfTongue.GuildName + ".");
                    Console.WriteLine();
                    Program.QsCharacterDialog("\"I can't see this guild being too useful, unless you were going to simply seduce every enemy. Ha! Can you imagine?\"");

                    Program.currentPlayer.PlayerGuild = new StellarsOfTongueClass();
                    Console.WriteLine();

                    Program.SlowTextAnimation("Please go back and exit to continue story.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else if (stellarsOfTongueClassMenuInput == "g" || stellarsOfTongueClassMenuInput == "go back")
                {
                    Console.Clear();
                    BaseCharacterGuildClass.AllGuildsDisplayMenu();
                }
                else if (stellarsOfTongueClassMenuInput == "" || stellarsOfTongueClassMenuInput == "")
                {
                    Program.QsCharacterDialog("\"You are really giving me mixed signals here. Do you want to join the guild or go back?\"");
                }
            }
        }
        public static void StellarsOfTongueGuildPlayerStatUpdate()
        {
            Program.currentPlayer.playerStrength = (Program.currentPlayer.playerStrength + stellarsOfTongue.GuildStrengthBoost);
            Program.currentPlayer.playerKnowledge = (Program.currentPlayer.playerKnowledge + stellarsOfTongue.GuildKnowledgeBoost);
            Program.currentPlayer.playerCharm = (Program.currentPlayer.playerCharm + stellarsOfTongue.GuildCharmBoost);
            Program.currentPlayer.playerGuildName = (Program.currentPlayer.playerGuildName + stellarsOfTongue.GuildName);

        }
    }
}

