using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Media;
using NAudio;
using NAudio.Wave;
using NAudio.MediaFoundation;
using NAudio.Wave.SampleProviders;

namespace Another_World_Adventure
{
	public class AudioFileEngine : IDisposable
	{
		private readonly IWavePlayer outputDevice;
		private readonly MixingSampleProvider mixer;

		public AudioFileEngine(int sampleRate = 4, int channelCount = 2)
		{
			outputDevice = new WaveOutEvent();
			mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount));
			mixer.ReadFully = true;
			outputDevice.Init(mixer);
			outputDevice.Play();
		}

		public void PlaySound (string fileName)
		{
			var input = new AudioFileReader(fileName);
			AddMixerInput(new AutoDisposeFileReader(input));
		}

		private ISampleProvider ConvertToRightChannelCount(ISampleProvider input)
		{
			if (input.WaveFormat.Channels == mixer.WaveFormat.Channels)
			{
				return input;
			}
            if (input.WaveFormat.Channels == 1 && mixer.WaveFormat.Channels ==2)
			{
				return new MonoToStereoSampleProvider(input);
			}
			throw new NotImplementedException("Not yet implemented this chanel count conversion");
        }

		public void PlaySound(CachedSound sound)
		{
			AddMixerInput(new CachedSoundSampleProvider(sound));
		}
		private void AddMixerInput(ISampleProvider input)
		{
			mixer.AddMixerInput(ConvertToRightChannelCount(input));
		}

		public void Dispose()
		{
			outputDevice.Dispose();
		}

		public static readonly AudioFileEngine Instance = new AudioFileEngine(4, 2);
    }
}

