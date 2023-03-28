using System;
namespace Another_World_Adventure
{
	public class OwlsOfTheDevotedClass : BaseCharacterGuildClass
	{
        public static BaseCharacterGuildClass owlsOfTheDevoted;

        public static void OwlsOfTheDevotedClassMenu()
        {
            BaseCharacterGuildClass owlsOfTheDevoted = new BaseCharacterGuildClass();

            owlsOfTheDevoted.GuildName = "Owls Of The Devoted";
            owlsOfTheDevoted.GuildDescription = "\"To know or not to know, that is the question. As a member of The Owls Of The Devoted Guild, debates among the brightest and the sounds of pages in books turning surround you.\"\n|    \"You feel yourself understanding more about this world and the wisdom that comes with it, however I wouldn't be betting on you in a hand-to-hand fight.\"";
            owlsOfTheDevoted.GuildStrengthBoost = 30;
            owlsOfTheDevoted.GuildKnowledgeBoost = 90;
            owlsOfTheDevoted.GuildCharmBoost = 50;

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("|    ");
            Console.WriteLine("|   Name of Guild: " + owlsOfTheDevoted.GuildName + "   ");
            Console.WriteLine("|                                 ");
            Console.WriteLine("|   Guild Description:    ");
            Console.WriteLine("|                                                              ");
            Console.WriteLine("|    " + owlsOfTheDevoted.GuildDescription + "   ");
            Console.WriteLine("|                                 ");
            Console.WriteLine("|   (J)oin Guild                  ");
            Console.WriteLine("|                                 ");
            Console.WriteLine("|   (G)o Back                     ");
            Console.WriteLine("-----------------------------------------------");

            while (true)
            {
                string owlsOfTheDevotedClassMenuInput = Console.ReadLine().ToLower();
                if (owlsOfTheDevotedClassMenuInput == "j" || owlsOfTheDevotedClassMenuInput == "join guild")
                {
                    Program.SlowTextAnimation("Congrats! You now joined " + owlsOfTheDevoted.GuildName + ".");
                    Console.WriteLine();
                    Program.QsCharacterDialog("\"Books are cool... I guess. Nah. Good luck trying to debate your way out of a fight, nerd!\"");

                    Program.currentPlayer.PlayerGuild = new OwlsOfTheDevotedClass();
                    Console.WriteLine();
                    
                    Program.SlowTextAnimation("Please go back and exit to continue story.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else if (owlsOfTheDevotedClassMenuInput == "g" || owlsOfTheDevotedClassMenuInput == "go back")
                {
                    Console.Clear();
                    BaseCharacterGuildClass.AllGuildsDisplayMenu();
                }
                else if (owlsOfTheDevotedClassMenuInput == "" || owlsOfTheDevotedClassMenuInput == "")
                {
                    Program.QsCharacterDialog("\"You are really giving me mixed signals here. Do you want to join the guild or go back?\"");
                }
            }


        }

        public static void OwlsOfTheDevotedPlayerStatUpdate()
        {
            Program.currentPlayer.playerStrength = (Program.currentPlayer.playerStrength + owlsOfTheDevoted.GuildStrengthBoost);
            Program.currentPlayer.playerKnowledge = (Program.currentPlayer.playerKnowledge + owlsOfTheDevoted.GuildKnowledgeBoost);
            Program.currentPlayer.playerCharm = (Program.currentPlayer.playerCharm + owlsOfTheDevoted.GuildCharmBoost);
            Program.currentPlayer.playerGuildName = (Program.currentPlayer.playerGuildName + owlsOfTheDevoted.GuildName);

        }
    }
}

