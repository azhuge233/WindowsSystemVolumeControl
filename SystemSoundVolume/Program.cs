using System;
using AudioSwitcher.AudioApi.CoreAudio;

namespace SystemSoundVolume {
	class Program {
		private static readonly CoreAudioDevice defaultDevice = new CoreAudioController().DefaultPlaybackDevice;

		public static void Set(double vol) {
			defaultDevice.Volume = vol;
		}

		public static double Get() {
			return defaultDevice.Volume;
		}

		private static void Usage() {
			Console.WriteLine("set/get the default playback device's volume\n\nUsage:");
			Console.WriteLine("- set [0-100]\tset system volume to the given value");
			Console.WriteLine("- get\tget current volume");
		}

		static void Main(string[] args) {
			if (args.Length > 2 || args.Length < 1) {
				Usage();
				return;
			}

			switch (args[0]) {
				case "set":
					if (args.Length == 1) goto default;
					try {
						var vol = Convert.ToDouble(args[1]);
						if (vol < 0 || vol > 100) goto default;
						Set(vol);
					} catch (Exception ex) {
						Console.WriteLine(ex.Message.ToString());
					}
					break;
				case "get":
					if (args.Length == 2) goto default;
					Console.WriteLine(Get());
					break;
				default:
					Usage();
					break;
			}
		}
	}
}
