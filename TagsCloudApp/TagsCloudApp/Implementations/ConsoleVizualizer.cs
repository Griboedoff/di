using System;
using TagsCloudApp.Core;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp.Implementations
{
	public class ConsoleVizualizer : IVizualizer
	{
		private readonly CloudCreator creator;
		private readonly TagCloudSettings settings;
		private string cmd;

		public ConsoleVizualizer(CloudCreator creator, TagCloudSettings settings)
		{
			this.creator = creator;
			this.settings = settings;
			cmd = "";
		}

		private void DrawCloud()
		{
			var cloud = creator.Create(settings);
			foreach (var cloudItem in cloud.Items)
				Console.WriteLine($"\"{cloudItem.WordInfo.Word}\" count = {cloudItem.WordInfo.Frequency}");
		}

		public void RunVizualizer()
		{
			while (cmd != "exit")
			{
				Console.Clear();
				if (cmd == "draw")
					DrawCloud();
				else if (cmd == "help")
					Console.WriteLine("Type 'draw' to draw cloud");
				cmd = Console.ReadLine();
			}
		}
	}
}