using WinFormsApp1.Forms;
using WinFormsApp1.Forms.Utility;
using WinFormsApp1.Models;
using WinFormsApp1.Selenium;

namespace WinFormsApp1
{
	public partial class MainForm : FormBase
	{

		private readonly UserManager userManager = UserManager.Instance;

		public MainForm()
		{
			InitializeComponent();
			InitializeControlResizer();	

			InitializeListView(userListView);
		}


		/* Events */

		private void StartBotButton_Click(object sender, EventArgs e)
		{

			SearchQueryForm queryForm = new SearchQueryForm(GetSelection());
			queryForm.ShowDialog();
		}


		private void OnFormLoad(object sender, EventArgs e)
		{
			if (userListView.Items.Count > 0)
			{
				userListView.Items[0].Selected = true;
			}
		}

		private void OnFormResize(object sender, EventArgs e)
		{
			controlResizer.ResizeControlsOnFormResize();
		}

		private void AddUserButton_Click(object sender, EventArgs e)
		{
			UserForm addUserForm = new UserForm();
			addUserForm.ShowDialog();

			UserProfile? newUser = addUserForm.NewUser;

			if (newUser != null)
			{
				userManager.AddUser(newUser);
				InitializeListView(userListView);

				//Clear and select newest entry
				userListView.SelectedItems.Clear();
				userListView.Items[userListView.Items.Count - 1].Selected = true;
			}
		}

		private UserProfile GetSelection() => (UserProfile) userListView.SelectedItems[0].Tag;

		private void EditUserButton_Click(object sender, EventArgs e)
		{
			UserForm addUserForm = new UserForm(GetSelection());

			addUserForm.ShowDialog();

			userManager.SyncData();

			InitializeListView(userListView);
		}

		private void UserListViewSelectedIndexChanged(object sender, EventArgs e)
		{
			startBotButton.Enabled = userListView.SelectedItems.Count > 0;
		}

		/* Helpers */

		public void InitializeListView(ListView listView)
		{
			listView.Clear();
			listView.MultiSelect = false;
			listView.FullRowSelect = true;
			listView.View = View.Tile;

			listView.TileSize = new Size(listView.Width - 4, 50);

			int w = listView.Width;
			listView.Columns.Add("Name");
			listView.Columns.Add("Email");

			List<UserProfile> userProfiles = userManager.GetUsers().ToList();

			userProfiles.ForEach(user => AddListItem(user));
		}

		private void AddListItem(UserProfile user)
		{
			ListViewItem item = new ListViewItem(user.ProfileName);
			item.SubItems.Add(user.Email);
			item.Tag = user;
			userListView.Items.Add(item);
		}
	}
}
