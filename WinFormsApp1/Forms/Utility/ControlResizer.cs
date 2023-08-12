namespace WinFormsApp1.Forms.Utility
{
	public class ControlResizer
	{
		private readonly Form form;
		private Rectangle orignalFormSize;

		private readonly Dictionary<Control, Rectangle> originalControlSizeMap = new();



		public static ControlResizer ResizeAllControls(Form mainForm)
		{
			Control[] controlsArray = mainForm.Controls.Cast<Control>().ToArray();
			return new ControlResizer(mainForm, controlsArray);
		}

		public static ControlResizer ResizeControls(Form form, params Control[] controls)
		{
			return new ControlResizer(form, controls);
		}


		private ControlResizer(Form mainForm, params Control[] controls)
		{
			form = mainForm;
			orignalFormSize = GetRectangle(form);

			foreach (var c in controls)
			{
				originalControlSizeMap.Add(c, GetRectangle(c));
			}
		}

		//Place in Form resize event handler
		public void ResizeAllControls()
		{
			foreach (KeyValuePair<Control, Rectangle> pair in originalControlSizeMap)
			{
				ResizeControl(pair.Key, pair.Value);
			}
		}

		private static Rectangle GetRectangle(Control con) => new(con.Location.X, con.Location.Y, con.Size.Width, con.Size.Height);

		private void ResizeControl(Control control, Rectangle rect)
		{
			float xRatio = (float) form.Size.Width / (float) orignalFormSize.Width;
			float yRatio = (float) form.Size.Height / (float) orignalFormSize.Height;

			int newX = (int) (rect.Location.X * xRatio);
			int newY = (int) (rect.Location.Y * yRatio);

			int newWidth = (int) (rect.Width * xRatio);
			int newHeight = (int) (rect.Height * yRatio);

			control.Location = new Point(newX, newY);
			control.Size = new Size(newWidth, newHeight);
		}
	}
}