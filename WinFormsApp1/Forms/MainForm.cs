using WinFormsApp1.Models;
using WinFormsApp1.Selenium;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        private void MainLabelClick(object sender, EventArgs e)
        {

			UserProfile user = new UserProfile("ryan", "rloup7@gmail.com", "walruss7");


			new SeleniumBot(user).Run();
        }
    }
}