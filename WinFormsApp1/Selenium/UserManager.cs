using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1.Selenium
{
	public class UserManager
	{

		private readonly HashSet<UserProfile> users;
		private readonly DataManager dataManager;

		private static readonly Lazy<UserManager> lazyUserManager = new Lazy<UserManager>(() => new UserManager());

		public static UserManager Instance => lazyUserManager.Value;

		private UserManager()
		{
			dataManager = DataManager.Instance;
			users = dataManager.LoadUsers()?.ToHashSet() ?? new HashSet<UserProfile>();
		}

		public HashSet<UserProfile> GetUsers() => users;

		public void AddUser(UserProfile user)
		{
			ModifySet(set => set.Add(user));
		}

		public void DeleteUser(UserProfile user)
		{
			ModifySet(set => set.Remove(user));
		}

		private void ModifySet(Action<HashSet<UserProfile>> modification)
		{
			modification(users);
			SaveUsers();
		}

		public void SyncData() => SaveUsers();

		private void SaveUsers() => dataManager.SaveUsers(users.ToList());
	}
}