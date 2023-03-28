using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Media;

namespace Another_World_Adventure
{
    class Program
    {
        public static Random rand = new Random();

        public static Player currentPlayer = new Player();

        public static bool mainLoop = true;

        static void Main(string[] args)
        {


            if (!Directory.Exists("saves"))
            {
                GameTitle();

                Directory.CreateDirectory("saves");
            }
            currentPlayer = Load(out bool newP);
            if (newP)
                Encounters.DrunkardGuardEncounter();
                BaseWeapon.ObtainingOriginalWeapon();
                BaseCharacterGuildClass.GuildSelection();
            while (mainLoop)
            {
                Encounters.ArenaEncounter();
            }
            Locations.LoadAllLocationsMenu();
        }

        static Player NewStart(int i)
        {
            //Start of Game

            Console.Clear();
            GameTitle();
            Console.WriteLine("By: Elizabeth Tong");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Hit ENTER to start game...");
            Console.ReadKey();

            Console.Clear();
            
            while (true)
            {
                Console.WriteLine("Wake up? [y/n]");
                string? wakeUpResponse = Console.ReadLine();
                if (wakeUpResponse == "y" || wakeUpResponse == "Y" || wakeUpResponse == "Yes" || wakeUpResponse == "yes")
                {
                    Console.Clear();
                    SoundEffects.CreatedCharacterSound();
                    QsCharacterDialog("\"Welcome to being reborn in a new world, a new you!\"\n\"In case you're wondering, you died a horrible, horrific death.\"\n\"Anyways...I should introduce myself.\"\n\"I'm Q, your guide to this another world.\"");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else if (wakeUpResponse == "n" || wakeUpResponse == "N" || wakeUpResponse == "No" || wakeUpResponse == "no")
                {
                    Console.Clear();
                    QsCharacterDialog("\"Ah, I see... Well, perhaps some other time.\"");
                    Console.WriteLine();
                    SlowTextAnimation("You were bonked on the head, and sent back to the dark abyss.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else
                {
                    QsCharacterDialog("\"Perhaps, I wasn't clear enough.\"\n\n\"Please type y or n.\"");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
            }

            Console.Clear();
            Console.ReadKey();

            //Naming Player

            Player createdPlayer = new Player();
            QsCharacterDialog("\"So, what should I call you?\"");
            createdPlayer.playerName = Console.ReadLine();
            if (createdPlayer.playerName == "")
            {
                Console.Clear();
                createdPlayer.playerName = "Steve";
                QsCharacterDialog("\"A quiet one, huh?\"");
                QsCharacterDialog("\"I'll just call you Steve.\"\n\"See, that has a nice ring to it.\"\n\"STEEEEEEEEEEEEEVVVVVVVVVVVEEEEEEEEE!\"");
                createdPlayer.playerId = i;

            }
            else
            {
                QsCharacterDialog("\"That is an...interesting name.\"\n\"You could've picked something cooler like Aquarius or Elizabeth, but sure... " + createdPlayer.playerName + " is fine.\"");
                createdPlayer.playerId = i;

            }
            Console.ReadKey();
            Console.Clear();

            // Environment - Room

            SlowTextAnimation("You awaken in a sunlit room, laying on a bed that seems to be padded with straw.\nSitting up, you hear the not so distant voices of others outside.");
            Console.WriteLine();
            QsCharacterDialog("\"Ah, what could be more peaceful than a village full of wide-eyed, naive, village idiots?\"");
            Console.WriteLine();
            Console.ReadKey();
            return createdPlayer;

            // Guild Selection
            //May not need
            //BaseCharacterGuildClass.GuildSelection();
        }

        // Saving and Retreiving Player Data

        public static void Quit()
        {
            Save();
            AudioFileEngine.Instance.Dispose();
            Environment.Exit(0);
        }
        // Updated BinaryFormatter to XmlSerialization Standards 
        public static void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Player));
            string path = "saves/" + currentPlayer.playerId.ToString() + ".player";
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            serializer.Serialize(file, currentPlayer);
            file.Close();
        }

        public static Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount = 0;

            XmlSerializer serializer = new XmlSerializer(typeof(Player));
            foreach (string p in paths)
            {
                FileStream file = File.Open(p, FileMode.Open);
                Player player = (Player)serializer.Deserialize(file);
                file.Close();
                players.Add(player);
            }

            idCount = players.Count;

            while (true)
            {
                Console.Clear();
                GameTitle();
                Console.WriteLine("By: Elizabeth Tong");
                Console.WriteLine();
                Console.WriteLine("Choose your player\n");

                foreach (Player p in players)
                {
                    Console.WriteLine(p.playerId + ": " + p.playerName + " " + p.playerGuildName);
                    Console.WriteLine();
                }

                Console.WriteLine("Please input player name or id (id:# or playername).\n\nIf you want to start a new game, 'create' will start a new save.");
                string[] data = Console.ReadLine().Split(':');

                try
                {
                    if(data[0] == "id")
                    {
                        if (int.TryParse(data[1], out int id))
                        {
                            foreach (Player player in players)
                            {
                                if(player.playerId == id)
                                {
                                    return player;
                                }
                            }
                            Console.WriteLine("There is not a player with that id.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Your id needs to be a number. Press any key to continue.");
                            Console.ReadKey();
                        }
                    }
                    else if (data[0] == "create")
                    {
                        Player newPlayer = NewStart(idCount);
                        newP = true;
                        return newPlayer;
                    }
                    else
                    {
                        foreach (Player player in players)
                        {
                            if(player.playerName == data[0])
                            {
                                return player;
                            }
                        }
                        Console.WriteLine("There is not a player with that id.");
                        Console.ReadKey();
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Your id needs to be a number. Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }

        //Slow-Print Text Animation

        public static void SlowTextAnimation(string text, int textSpeed = 60)
        {
            foreach (char letter in text)
            {
                Console.Write(letter);
                System.Threading.Thread.Sleep(textSpeed);
            }
            Console.WriteLine();

        }


        // Character Speaking Color Text w/ Animation - based on specific characters 

        public static void QsCharacterDialog(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            SlowTextAnimation(text);
            Console.ResetColor();
        }

        public static void GenericEnemyCharacterDialog(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            SlowTextAnimation(text);
            Console.ResetColor();
        }

        public static void CynosCharacterDialog(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            SlowTextAnimation(text);
            Console.ResetColor();
        }


        // Game Title

        public static void GameTitle()
        {
            Console.Title = "Another World Adventure";
            string title = @"
  ___              _   _                  _    _            _     _      ___      _                 _                  
 / _ \            | | | |                | |  | |          | |   | |    / _ \    | |               | |                 
/ /_\ \_ __   ___ | |_| |__   ___ _ __   | |  | | ___  _ __| | __| |   / /_\ \ __| |_   _____ _ __ | |_ _   _ _ __ ___ 
|  _  | '_ \ / _ \| __| '_ \ / _ \ '__|  | |/\| |/ _ \| '__| |/ _` |   |  _  |/ _` \ \ / / _ \ '_ \| __| | | | '__/ _ \
| | | | | | | (_) | |_| | | |  __/ |     \  /\  / (_) | |  | | (_| |   | | | | (_| |\ V /  __/ | | | |_| |_| | | |  __/
\_| |_/_| |_|\___/ \__|_| |_|\___|_|      \/  \/ \___/|_|  |_|\__,_|   \_| |_/\__,_| \_/ \___|_| |_|\__|\__,_|_|  \___|
                                                                                                                                                                                                                                    
";
            Console.WriteLine(title);
        }

       
    }

}


