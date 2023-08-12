using WinFormsApp1.Forms;
using WinFormsApp1.Forms.Utility;
using WinFormsApp1.Models;
using WinFormsApp1.Selenium;

namespace WinFormsApp1
{
	public partial class MainForm : Form
	{

		private ControlResizer controlResizer;
		private readonly UserManager userManager = UserManager.Instance;

		private UserProfile? selectedUserProfile;

		public MainForm()
		{
			InitializeComponent();
			FormInitalizer.Initalize(this);


			InitializeListView(userListView);

			controlResizer = ControlResizer.ResizeAllControls(this);
		}


		/* Events */

		private void StartBotButton_Click(object sender, EventArgs e)
		{
			//UserProfile user = new UserProfile("ryan", "rloup7@gmail.com", "walruss7");

			//new SeleniumBot(user).Run();
		}


		private void OnFormLoad(object sender, EventArgs e)
		{

		}

		private void OnFormResize(object sender, EventArgs e)
		{
			controlResizer.ResizeAllControls();
		}

		private void AddUserButton_Click(object sender, EventArgs e)
		{
			UserForm addUserForm = new UserForm();
			addUserForm.ShowDialog();
			UserProfile newUser = addUserForm.NewUser;
			userManager.AddUser(newUser);
			InitializeListView(userListView);

		}

		private void SetSelection(object sender, EventArgs e)
		{
			selectedUserProfile = (UserProfile) userListView.SelectedItems[0].Tag;
		}

		private void EditUserButton_Click(object sender, EventArgs e)
		{
			UserForm addUserForm = new UserForm(selectedUserProfile);
			addUserForm.ShowDialog();
			userManager.SyncData();
			InitializeListView(userListView);
		}

		/* Helpers */


		public void InitializeListView(ListView listView)
		{
			listView.Clear();
			listView.MultiSelect = false;
			listView.FullRowSelect = true;
			listView.View = View.Details;

			int w = listView.Width;
			listView.Columns.Add("Name", w / 2);
			listView.Columns.Add("Email", w / 2);

			List<UserProfile> userProfiles = userManager.GetUsers();
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
