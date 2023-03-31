using System;
namespace Another_World_Adventure
{
    public class OwlsOfTheDevotedClass
    {
        public static BaseCharacterGuildClass OwlsOfTheDevoted = new BaseCharacterGuildClass("Owls Of The Devoted", "\"To know or not to know, that is the question. As a member of The Owls Of The Devoted Guild, debates among the brightest and the sounds of turning pages in books surround you.\"\n|    \"You feel yourself understanding more about this world and the wisdom that comes with it, however I wouldn't be betting on you in a hand-to-hand fight.\"", 30, 90, 50);

        public static void OwlsOfTheDevotedPlayerStatUpdate()
        {
            Program.currentPlayer.playerStrength += OwlsOfTheDevoted.GuildStrengthBoost;
            Program.currentPlayer.playerKnowledge += OwlsOfTheDevoted.GuildKnowledgeBoost;
            Program.currentPlayer.playerCharm += OwlsOfTheDevoted.GuildCharmBoost;
            Program.currentPlayer.playerGuildName += OwlsOfTheDevoted.GuildName;
        }

        public static void OwlsOfTheDevotedClassMenu()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("|    ");
            Console.WriteLine("|   Name of Guild: " + OwlsOfTheDevoted.GuildName + "   ");
            Console.WriteLine("|                                 ");
            Console.WriteLine("|   Guild Description:    ");
            Console.WriteLine("|                                                              ");
            Console.WriteLine("|    " + OwlsOfTheDevoted.GuildDescription + "   ");
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
                    Program.SlowTextAnimation("Congrats! You now joined " + OwlsOfTheDevoted.GuildName + ".");
                    Console.WriteLine();
                    Program.QsCharacterDialog("\"Books are cool... I guess. Nah. Good luck trying to debate your way out of a fight, nerd!\"");
                    OwlsOfTheDevotedPlayerStatUpdate();
                    Console.ReadKey();
                    Console.Clear();
                    Program.SlowTextAnimation("Your stats have been updated with your guilds skillsets!");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else if (owlsOfTheDevotedClassMenuInput == "g" || owlsOfTheDevotedClassMenuInput == "go back")
                {
                    Console.Clear();
                    break;
                }
                else if (owlsOfTheDevotedClassMenuInput == "" || owlsOfTheDevotedClassMenuInput == "")
                {
                    Program.QsCharacterDialog("\"You are really giving me mixed signals here. Do you want to join the guild or go back?\"");
                    continue;
                }
            }
        }
    }
}

