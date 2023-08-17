using WinFormsApp1.Forms.Utility;

namespace WinFormsApp1.Forms
{
	public class FormBase : Form
	{
		protected ControlResizer controlResizer;
		protected FormBase()
		{
			FormInitalizer.Initalize(this);
		}

		protected void InitializeControlResizer()
		{
			controlResizer = ControlResizer.ResizeAllControls(this);
		}

	}
}
