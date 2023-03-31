using System;
namespace Another_World_Adventure
{
    public static class FistOfWrathClass
    {
        public static BaseCharacterGuildClass FistOfWrath = new BaseCharacterGuildClass("Fist of Wrath", "\"There is never too much punching, they say. As a member of the Fist of Wrath Guild, you are surrounded by the strongest in the valley, always hungry for a good fight\".\n|    \"While you feel yourself increasing in strength, I doubt you will be reguarded as the Valley's Next Top Model.\"", 90, 50, 30);

        public static void FistOfWrathGuildPlayerStatUpdate()
        {
            Program.currentPlayer.playerStrength += FistOfWrath.GuildStrengthBoost;
            Program.currentPlayer.playerKnowledge += FistOfWrath.GuildKnowledgeBoost;
            Program.currentPlayer.playerCharm += FistOfWrath.GuildCharmBoost;
            Program.currentPlayer.playerGuildName += FistOfWrath.GuildName;

        }

        public static void FistOfWrathClassMenu()
        { 
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("|   ");
            Console.WriteLine("|   Name of Guild: " + FistOfWrath.GuildName +                "");
            Console.WriteLine("|                                                              ");
            Console.WriteLine("|   Guild Description:      ");
            Console.WriteLine("|                                                              ");
            Console.WriteLine("|    "+ FistOfWrath.GuildDescription +                        "");
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
                    Program.SlowTextAnimation("Congrats! You now joined " + FistOfWrath.GuildName + ".");
                    Console.WriteLine();
                    Program.QsCharacterDialog("\"I would like to think there's not much going on up there. Just creatine and podcasts from Joe Rogan.\"");
                    FistOfWrathGuildPlayerStatUpdate();
                    Console.ReadKey();
                    Console.Clear();
                    Program.SlowTextAnimation("Your stats have been updated with your guilds skillsets!");
                    Console.WriteLine();
                    Program.SlowTextAnimation("Please go back and exit to continue story.");
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
    }
}