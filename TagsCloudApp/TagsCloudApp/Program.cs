﻿using Autofac;
using TagsCloudApp.Core;
using TagsCloudApp.Core.Interfaces;
using TagsCloudApp.Implementations;
using TagsCloudApp.Implementations.Gui;

namespace TagsCloudApp
{
	internal static class Program
	{
		public static void Main()
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<TxtReader>().As<IFileReader>();
			builder.RegisterType<PngRenderer>().As<IRenderer>();
			builder.RegisterType<CircularCloudBuilder>().As<ICloudBuilder>();
			builder.RegisterType<SamePrioritySetter>().As<IPrioritySetter>();
			builder.RegisterType<SimpleTextPreprocessor>().As<ITextPreprocessor>();
			builder.RegisterType<CloudCreator>().AsSelf();
			builder.RegisterInstance(TagCloudSettings.DefaultSettings).As<TagCloudSettings>().SingleInstance();
			builder.RegisterType<WinFormVizualizer>().As<IVizualizer>();
			builder.RegisterType<ConsoleVizualizer>().As<IVizualizer>();

			var container = builder.Build();

			using (var scope = container.BeginLifetimeScope())
				scope.Resolve<IVizualizer>().RunVizualizer();
		}
	}
}