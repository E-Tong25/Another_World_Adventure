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
	public class CachedSoundSampleProvider : ISampleProvider
	{
		private readonly CachedSound cachedSound;
		private long position;

		public CachedSoundSampleProvider(CachedSound cachedSound)
		{
			this.cachedSound = cachedSound;
		}

		public int Read(float[] buffer, int offset, int count)
		{
			var availableSamples = cachedSound.AudioData.Length - position;
			var samplesToCopy = Math.Min(availableSamples, count);
			Array.Copy(cachedSound.AudioData, position, buffer, offset, samplesToCopy);
			position += samplesToCopy;
			return (int)samplesToCopy;
		}

		public WaveFormat WaveFormat { get { return cachedSound.WaveFormat; } }
	}
}

