namespace WinFormsApp1.Selenium
{
	public class SearchQuery
	{
		public string JobSearch { get; set; }
		public string? LocationSearch { get; set; }
		public List<string> LocationChoiceID { get; set; }
		public List<string> ExperianceChoiceID { get; set; }


		public static readonly Dictionary<string, string> locationIDMap = new()
			{
				{ "OnSite", "workplaceType-1" },
				{ "Remote", "workplaceType-2" },
				{ "Hybrid", "workplaceType-3" }
			};

		public static readonly Dictionary<string, string> experianceIDMap = new()
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
