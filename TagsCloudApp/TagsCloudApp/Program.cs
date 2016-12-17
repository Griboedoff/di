using System.Reflection;
using Autofac;
using TagsCloudApp.Core;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp
{
	internal static class Program
	{
		public static void Main()
		{
			var builder = new ContainerBuilder();
			var asm = Assembly.GetExecutingAssembly();
			builder.RegisterAssemblyTypes(asm)
				.AsImplementedInterfaces();
			builder.RegisterType<CloudCreator>().AsSelf();
			builder.RegisterInstance(TagCloudSettings.DefaultSettings).As<TagCloudSettings>().SingleInstance();

			var container = builder.Build();

			using (var scope = container.BeginLifetimeScope())
				scope.Resolve<IVizualizer>().RunVizualizer();
		}
	}
}