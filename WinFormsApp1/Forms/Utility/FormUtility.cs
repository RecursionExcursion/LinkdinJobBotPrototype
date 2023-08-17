using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Forms.Utility
{
	public static class FormUtility
	{
		public static void DisableControl(Control control)
		{
			control.Enabled = false;
			control.Visible = false;
		}
	}
}
