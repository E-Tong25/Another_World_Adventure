using System;
using System.Media;
using System.Windows;
using Microsoft.VisualBasic;
using NAudio;
using NAudio.Wave;
using NAudio.MediaFoundation;

namespace Another_World_Adventure
{
	public class SoundEffects
	{
        public static void CreatedCharacterSound()
        {
            try
            {
                var newCharacter = new CachedSound("newCharacter.mp3");

                if (OperatingSystem.IsWindows())
                {
                    //const string SoundLocation = @"c:Users\elizabethtong\Projects\Another_World_Adventure\Another_World_Adventure\bin\Debug\Sounds\newCharacter.mp3";

                    SoundPlayer createdCharacterSound = new SoundPlayer("newCharacter.mp3");
                    createdCharacterSound.Load();
                    createdCharacterSound.Play();
                    //createdCharacterSound.PlayLooping();
                }
                else  
                {
                    AudioFileEngine.Instance.PlaySound(newCharacter);
                    //WaveOutEvent wavePlayer1;
                    //AudioFileReader file1;

                    //wavePlayer1 = new WaveOutEvent();
                    //file1 = new AudioFileReader("/Users/elizabethtong/Projects/Another_World_Adventure/Another_World_Adventure/SoundEffects/newCharacter.mp3");
                    //wavePlayer1.Init(file1);
                    //wavePlayer1.Play();



                    //using (var output = new WaveOutEvent())
                    //using (var player = new AudioFilePlayer())
                    //{
                    //    output.Init(player);
                    //    output.Play();
                    //    while (output.PlaybackState == PlaybackState.Playing)
                    //    {
                    //        Thread.Sleep(1000);
                    //    }
                    //}
                }
            
            }

            catch
            {
                Console.WriteLine("Attempted to add sound.");
                Console.ReadKey();
                Console.Clear();
            }

        }

        //Sounds Effect Format 

        //SoundPlayer s = new SoundPlayer("Sounds/coinReward.mp3");
        //soundPlayer.PlayLooping();
        //soundPlayer.Stop();
    }
}

