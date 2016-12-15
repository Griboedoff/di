using System;
using System.Drawing;
using System.Windows.Forms;
using TagsCloudApp.Core;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp.Implementations.Gui
{
	public class WinFormVizualizer : Form, IVizualizer
	{
		private readonly CloudCreator creator;
		private readonly IRenderer renderer;
		private readonly TagCloudSettings settings;
		private Image image;

		public WinFormVizualizer(CloudCreator creator, IRenderer renderer, TagCloudSettings settings)
		{
			this.creator = creator;
			this.renderer = renderer;
			this.settings = settings;
			MessageBox.Show("To change settings press 'n'\nTo save cloud press 's'");
			DrawCloud();
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (e.KeyChar == 'n')
			{
				new SettingsForm<TagCloudSettings>(settings).ShowDialog();
				DrawCloud();
			}
			else if (e.KeyChar == 's')
				renderer.SaveImageTo(settings.PathToSave, image);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.DrawImage(image, new Point(0, 0));
			Size = image.Size;
		}

		public void DrawCloud()
		{
			try
			{
				image = renderer.RenderImage(creator.Create(settings));
				Invalidate();
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}