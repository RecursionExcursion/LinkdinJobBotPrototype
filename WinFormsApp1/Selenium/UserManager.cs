using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1.Selenium
{
	public class UserManager
	{

		private readonly List<UserProfile> users;
		private readonly DataManager dataManager;

		private static readonly Lazy<UserManager> lazyUserManager = new Lazy<UserManager>(() => new UserManager());

		public static UserManager Instance => lazyUserManager.Value;

		private UserManager()
		{
			dataManager = DataManager.Instance;
			users = dataManager.LoadUsers() ?? new List<UserProfile>();
		}

		public List<UserProfile> GetUsers() => users;

		public void AddUser(UserProfile user)
		{
			if (!users.Contains(user))
			{
				users.Add(user);
				SaveUsers();
			}
		}

		public void SyncData() => SaveUsers();

		private void SaveUsers() => dataManager.SaveUsers(users);
	}
}