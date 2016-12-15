using System.Drawing;
using System.IO;
using Autofac;
using TagsCloudApp.Core;
using TagsCloudApp.Core.Interfaces;
using TagsCloudApp.Implementations;

namespace TagsCloudApp
{
	internal static class Program
	{
		public static void Main(string[] args)
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<TxtReader>().As<IFileReader>();
			builder.RegisterType<PngRenderer>().As<IRenderer>();
			builder.RegisterType<CircularCloudBuilder>().As<ICloudBuilder>();
			builder.RegisterType<SamePrioritySetter>().As<IPrioritySetter>();
			builder.RegisterType<SimpleTextPreprocessor>().As<ITextPreprocessor>();
			builder.RegisterType<TagCloud>().AsSelf();

			var container = builder.Build();

			using (var scope = container.BeginLifetimeScope())
			{
				var cloud = scope.Resolve<TagCloud>();
				cloud.Build(Path.Combine(".", "test.txt"), new Size(1000, 1000));
				cloud.RenderCloud();
				cloud.Save("test");
			}
		}
	}
}