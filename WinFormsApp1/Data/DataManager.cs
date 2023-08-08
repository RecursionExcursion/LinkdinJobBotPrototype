using System.Text.Json;
using WinFormsApp1.Models;

namespace WinFormsApp1.Data
{
	public class DataManager
	{
		private static readonly string UserDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		private static readonly string DocumentFolder = "VSFoofInc";
		private static readonly string SubFolder = "LinkdinBot";
		private static readonly string FileName = "users.json";

		private static readonly Lazy<DataManager> lazyInstance = new Lazy<DataManager>(() => new DataManager());

		private static DataManager Instance => lazyInstance.Value;

		private DataManager()
		{
			//Creates Folder structure if it does not exist
			CreateFilePathIfAbsent();
		}

		public void SaveUsers(List<UserProfile> users)
		{
			//Create Json
			var usersJson = JsonSerializer.Serialize(users);

			// Write the content to the file
			File.WriteAllText(GetFilePath(), usersJson);
		}

		public List<UserProfile>? LoadUsers()
		{

			string[] lines = File.ReadAllLines(GetFilePath());

			string usersJson = string.Join(Environment.NewLine, lines);

			List<UserProfile>? userProfiles = JsonSerializer.Deserialize<List<UserProfile>>(usersJson);

			return userProfiles;
		}

		private static void CreateFilePathIfAbsent() => Directory.CreateDirectory(GetFolderPath());

		private static string GetFolderPath() => Path.Combine(UserDocuments, DocumentFolder, SubFolder);

		private static string GetFilePath() => Path.Combine(GetFolderPath(), FileName);
	}
}
