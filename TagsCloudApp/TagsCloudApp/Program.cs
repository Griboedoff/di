using System.Drawing;
using System.Linq;
using TagsCloudApp.Implementations;

namespace TagsCloudApp
{
	internal class Program
	{
		public static void Main(string[] args)
		{
//			var builder = new ContainerBuilder();
//			builder.RegisterInstance(new TxtReader()).As<IFileReader>();
//			builder.RegisterInstance(new PngRenderer()).As<IRenderer>();
//			builder.RegisterInstance(new CircularCloudBuilder(new Point(500,500))).As<ICloudBuilder>();
//			builder.RegisterInstance(new SamePriorityGiver()).As<IPriorityGiver>();
//			builder.RegisterInstance(new SimpleTextPreprocessor()).As<ITextPreprocessor>();
//
//			var container = builder.Build();
			var reader = new TxtReader();
			var renderer = new PngRenderer();
			renderer.RenderImage(
				new CircularCloudBuilder(new Point(500, 500))
					.BuildCloud(new SamePriorityGiver()
						.SetPriorities(new SimpleTextPreprocessor()
							.ProcessWords(new TxtReader().GetFileContetByWords("./test")).ToList())
						.ToList()));
			renderer.SaveImageTo("./test_res.png");
		}
	}
}