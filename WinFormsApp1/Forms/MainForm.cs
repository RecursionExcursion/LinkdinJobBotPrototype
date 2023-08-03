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
            new SeleniumBot().Run();
        }
    }
}