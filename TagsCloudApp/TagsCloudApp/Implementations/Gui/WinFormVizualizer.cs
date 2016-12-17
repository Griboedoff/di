using System;
using System.Drawing;
using System.Windows.Forms;
using TagsCloudApp.Core;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp.Implementations.Gui
{
	public class WinFormVizualizer : IVizualizer
	{
		private readonly CloudCreator creator;
		private readonly IRenderer renderer;
		private readonly TagCloudSettings settings;
		private Image image;
		private readonly Form form;

		public WinFormVizualizer(CloudCreator creator, IRenderer renderer, TagCloudSettings settings)
		{
			this.creator = creator;
			this.renderer = renderer;
			this.settings = settings;
			form = new Form();
			InitForm();
			MessageBox.Show("To change settings press 'n'\nTo save cloud press 's'");
			DrawCloud();
		}

		private void InitForm()
		{
			form.KeyPress += (o, e) =>
			{
				if (e.KeyChar == 'n')
				{
					new SettingsForm<TagCloudSettings>(settings).ShowDialog();
					DrawCloud();
				}
				else if (e.KeyChar == 's')
					renderer.SaveImageTo(settings.PathToSave, image);
			};
			form.Paint += (o, e) => {
				e.Graphics.DrawImage(image, new Point(0, 0));
				form.Size = image.Size;
			};
		}

		private void DrawCloud()
		{
			try
			{
				image = renderer.RenderImage(creator.Create(settings));
				form.Invalidate();
				form.Show();
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void RunVizualizer()
		{
			Application.Run(form);
		}
	}
}