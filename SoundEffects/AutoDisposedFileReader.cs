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
	public class AutoDisposeFileReader : ISampleProvider
	{
		private readonly AudioFileReader reader;
		private bool isDisposed;

		public AutoDisposeFileReader(AudioFileReader reader)
		{
			this.reader = reader;
			this.WaveFormat = reader.WaveFormat;
		}

		public int Read(float[] buffer, int offset, int count)
		{
			if (isDisposed)
				return 0;
			int read = reader.Read(buffer, offset, count);
			if (read == 0)
			{
				reader.Dispose();
				isDisposed = true;
			}
			return read;
		}

		public WaveFormat WaveFormat { get; private set; }
	}
}

