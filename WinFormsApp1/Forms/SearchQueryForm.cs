using OpenQA.Selenium.DevTools.V113.Profiler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Forms.Utility;
using WinFormsApp1.Models;
using WinFormsApp1.Selenium;
using static System.Windows.Forms.CheckedListBox;

namespace WinFormsApp1.Forms
{
	public partial class SearchQueryForm : Form
	{

		private UserProfile user;
		private ControlResizer controlResizer;

		public SearchQueryForm(UserProfile user)
		{
			InitializeComponent();

			controlResizer = ControlResizer.ResizeAllControls(this);

			FormInitalizer.Initalize(this);

			this.user = user;
		}

		private void OnLoad(object sender, EventArgs e)
		{

		}

		private void OnFormResize(object sender, EventArgs e)
		{
			controlResizer.ResizeAllControls();

		}

		private void StartBotButton_Click(object sender, EventArgs e)
		{

			string jobSearch = jobSearchTextBox.Text;

			if (!string.IsNullOrEmpty(jobSearch))
			{


				CheckedItemCollection checkedLocations = locationListBox.CheckedItems;

				CheckedItemCollection checkedPostitions = positionListBox.CheckedItems;

				string locationSearch = locationSearchTextBox.Text;



				SearchQuery searchQuery = new SearchQuery()
				{
					JobSearch = jobSearch,
					LocationSearch = locationSearch
				};



			}
		}


		//TODO 
		private List<string> CheckedItemToID(CheckedItemCollection checkedItems, Dictionary<string, string> idmap)
																		=> checkedItems.Cast<string>().Select(i => idmap[i]).ToList();





		private static readonly Dictionary<string, string> locationIDMap = new()
			{
				{ "OnSite", "workplaceType-1" },
				{ "Remote", "workplaceType-2" },
				{ "Hybrid", "workplaceType-3" }
			};

		private static readonly Dictionary<string, string> experianceIDMap = new()
			{
				{ "Internship", "experience-1" },
				{ "Entry Level", "experience-2" },
				{ "Associate", "experience-3" },
				{ "Mid-Senior Level", "experience-4" },
				{ "Director", "experience-5" },
				{ "Executive", "experience-6" }
			};
	}
}
