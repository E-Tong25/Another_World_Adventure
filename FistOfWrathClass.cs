using System;
namespace Another_World_Adventure
{
    public class FistOfWrathClass : BaseCharacterGuildClass
    {
        public static BaseCharacterGuildClass fistOfWrath;

        public static void FistOfWrathClassMenu()
        {
            BaseCharacterGuildClass fistOfWrath = new BaseCharacterGuildClass();

            fistOfWrath.GuildName = "Fist of Wrath";
            fistOfWrath.GuildDescription = "\"There is never too much punching, they say. As a member of the Fist of Wrath Guild, you are surrounded by the strongest in the valley, always hungry for a good fight\".\n|    \"While you feel yourself increasing in strength, I doubt you will be reguarded as the Valley's Next Top Model.\"";
            fistOfWrath.GuildStrengthBoost = 90;
            fistOfWrath.GuildKnowledgeBoost = 50;
            fistOfWrath.GuildCharmBoost = 30;

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("|   ");
            Console.WriteLine("|   Name of Guild: " + fistOfWrath.GuildName +                "");
            Console.WriteLine("|                                                              ");
            Console.WriteLine("|   Guild Description:      ");
            Console.WriteLine("|                                                              ");
            Console.WriteLine("|    "+ fistOfWrath.GuildDescription +                        "");
            Console.WriteLine("|                                 ");
            Console.WriteLine("|   (J)oin Guild                  ");
            Console.WriteLine("|                                 ");
            Console.WriteLine("|   (G)o Back                     ");
            Console.WriteLine("----------------------------------------------");

            while (true)
            {
                string fistOfWrathClassMenuInput = Console.ReadLine().ToLower();
                if (fistOfWrathClassMenuInput == "j" || fistOfWrathClassMenuInput == "join guild")
                {
                    Program.SlowTextAnimation("Congrats! You now joined " + fistOfWrath.GuildName + ".");
                    Console.WriteLine();
                    Program.QsCharacterDialog("\"I would like to think there's not much going on up there. Just creatine and podcasts from Joe Rogan.\"");

                    Program.currentPlayer.PlayerGuild = new FistOfWrathClass();
                    FistOfWrathGuildPlayerStatUpdate();
                    Console.WriteLine();
                    
                    Program.SlowTextAnimation("Please exit to continue story.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else if (fistOfWrathClassMenuInput == "g" || fistOfWrathClassMenuInput == "go back")
                {
                    Console.Clear();
                    BaseCharacterGuildClass.AllGuildsDisplayMenu();
                }
                else if (fistOfWrathClassMenuInput == "" || fistOfWrathClassMenuInput == "")
                {
                    Program.QsCharacterDialog("\"You are really giving me mixed signals here. Do you want to join the guild or go back?\"");
                }

            }
        }

        public static void FistOfWrathGuildPlayerStatUpdate()
        {
            Program.currentPlayer.playerStrength = (Program.currentPlayer.playerStrength + fistOfWrath.GuildStrengthBoost);
            Program.currentPlayer.playerKnowledge = (Program.currentPlayer.playerKnowledge + fistOfWrath.GuildKnowledgeBoost);
            Program.currentPlayer.playerCharm = (Program.currentPlayer.playerCharm + fistOfWrath.GuildCharmBoost);
            Program.currentPlayer.playerGuildName = (Program.currentPlayer.playerGuildName + fistOfWrath.GuildName);

        }
    }
}