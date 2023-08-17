using System.Data;
using WinFormsApp1.Forms.Utility;
using WinFormsApp1.Models;
using WinFormsApp1.Selenium;
using static System.Windows.Forms.CheckedListBox;

namespace WinFormsApp1.Forms
{
	public partial class SearchQueryForm : FormBase
	{

		private UserProfile user;

		public SearchQueryForm(UserProfile user)
		{
			InitializeComponent();
			InitializeControlResizer();

			this.user = user;

			InitializeListBoxes();
		}

		/* Event Handlers */

		private void OnFormResize(object sender, EventArgs e)
		{
			controlResizer.ResizeControlsOnFormResize();
		}

		private void StartBotButton_Click(object sender, EventArgs e)
		{

			string jobSearch = jobSearchTextBox.Text;

			if (!string.IsNullOrEmpty(jobSearch))
			{
				string locationSearch = locationSearchTextBox.Text;

				List<string> locationList = CheckedItemToID(locationListBox.CheckedItems, SearchQuery.locationIDMap);
				List<string> experianceList = CheckedItemToID(experianceListBox.CheckedItems, SearchQuery.experianceIDMap);

				SearchQuery searchQuery = new SearchQuery()
				{
					JobSearch = jobSearch,
					LocationSearch = locationSearch,
					LocationChoiceID = locationList,
					ExperianceChoiceID = experianceList
				};

				new SeleniumBot(user, searchQuery).Run();
			}
		}

		/* Helper */

		private void InitializeListBoxes()
		{
			void fillListBoxWithIds(CheckedListBox listBox, Dictionary<string, string> idmap)
			{
				listBox.Items.Clear();
				idmap.Keys.ToList().ForEach(k => listBox.Items.Add(k));
			}
			fillListBoxWithIds(locationListBox, SearchQuery.locationIDMap);
			fillListBoxWithIds(experianceListBox, SearchQuery.experianceIDMap);
		}

		private static List<string> CheckedItemToID(CheckedItemCollection checkedItems, Dictionary<string, string> idmap)
		{
			return checkedItems.Cast<string>().Select(i => idmap[i]).ToList();
		}
	}
}
