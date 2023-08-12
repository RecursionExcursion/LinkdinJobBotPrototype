using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Selenium
{
	public class SearchQuery
	{
		public string JobSearch { get; set; }
		public string? LocationSearch { get; set; }
		public List<string> LocationChoiceID { get; } = new List<string>();
		public List<string> PostitionChoiceID { get; } = new List<string>();
	}
}
