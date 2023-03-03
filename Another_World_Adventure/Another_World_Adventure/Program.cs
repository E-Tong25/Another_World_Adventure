using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
                Directory.CreateDirectory("saves");
            }
            currentPlayer = Load(out bool newP);
            if (newP)
                Encounters.GuardEncounter();
            BaseCharacterGuildClass.GuildSelection();
            while (mainLoop)
            {
                Encounters.ArenaEncounter();
            }
        }

        static Player NewStart(int i)
        {
            //Start of Game

            Console.Clear();
            
            while (true)
            {
                Console.WriteLine("Wake up? [y/n]");
                string wakeUpResponse = Console.ReadLine();
                if (wakeUpResponse == "y" || wakeUpResponse == "Y")
                {
                    Console.WriteLine("\"Welcome to being reborn in a new world, a new you!\"\n \"In case you're wondering, you died a horrible, horrific death.\"\n \"Anyways...\"\n \"I should introduce myself.\"\n \"I'm your guide to this another world.\"\n \"For now, you can call me Q!\"");
                    break;
                }
                else if (wakeUpResponse == "n" || wakeUpResponse == "N")
                {
                    Console.WriteLine(" \"Ah, I see. Well, perhaps some other time.\" You were bonked on the head, and sent back to the dark abyss.");
                    continue;
                }
                else
                {
                    Console.WriteLine("Perhaps, I wasn't clear enough. Please type y or n.");
                    continue;
                }


            }
            Console.Clear();
            Console.ReadKey();

            //Naming Player

            Player p = new Player();
            Console.WriteLine("\"So, what should I call you?\"");
            p.name = Console.ReadLine();
            if (p.name == "")
            {
                currentPlayer.name = "Steve";
                Console.WriteLine("\"A quiet one, huh?\" \n \"I'll just call you Steve.\"\n\"See, that has a nice ring to it.\"\n\"STEEEEEEEEEEEEEVVVVVVVVVVVEEEEEEEEE!\"");
            }
            else
                Console.WriteLine(" \"That is an...interesting name.\"\n \"You could've picked something cooler like Aquarius or Elizabeth, but sure.." + p.name + "is fine.\"");
            p.id = i;
            Console.Clear();
            Console.ReadKey();

            // Environment - Room

            Console.WriteLine("You awaken in a sunlit room, laying on a bed that seems to be padded with straw.\n Sitting up, you hear the not so distant voices of others outside.");
            Console.WriteLine("\"Ah, what could more peaceful than a village full of wide-eyed, innocent, dumb villagers?\"");
            return p;

            // Guild Selection

            BaseCharacterGuildClass.GuildSelection();
        }

        // Saving and Retreiving Player Data

        public static void Quit()
        {
            Save();
            Environment.Exit(0);
        }

        public static void Save()
        {
            BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/" + currentPlayer.id.ToString() + ".player";
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            binForm.Serialize(file, currentPlayer);
            file.Close();
        }

        public static Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount = 0;

            BinaryFormatter binForm = new BinaryFormatter();
            foreach (string p in paths)
            {
                FileStream file = File.Open(p, FileMode.Open);
                Player player = (Player)binForm.Deserialize(file);
                file.Close();
                players.Add(player);
            }

            idCount = players.Count;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose your player");

                foreach (Player p in players)
                {
                    Console.WriteLine(p.id + ": " + p.name + " " + p.guildName);
                }

                Console.WriteLine("Please input player name or id (id:# or playername). Additionally, 'create' will start a new save.");
                string[] data = Console.ReadLine().Split(':');

                try
                {
                    if(data[0] == "id")
                    {
                        if (int.TryParse(data[1], out int id))
                        {
                            foreach (Player player in players)
                            {
                                if(player.id == id)
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
                            if(player.name == data[0])
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

        public static void Print(string text, int speed = 60)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
            Console.WriteLine();
        }

        //Sounds Effect Format 

        SoundPlayer soundPlayer = new SoundPlayer("Sounds/coinReward.mp3");
        soundPlayer.PlayLooping();
        soundPlayer.Stop();


    }
}


