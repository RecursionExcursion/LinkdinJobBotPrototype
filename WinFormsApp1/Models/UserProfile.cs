using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Models
{
    public class UserProfile
    {
        public string ProfileName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Dictionary<string, string> Q_A { get; set; }

        public UserProfile(string profileName, string email, string password)
        {
            ProfileName = profileName;
            Email = email;
            Password = password;
            Q_A = new();
        }
    }
}
