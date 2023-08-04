namespace WinFormsApp1.Forms
{
    public partial class CaptchaByPassForm : Form
    {
        public CaptchaByPassForm()
        {
            InitializeComponent();
            this.TopMost = true;
            this.BackColor = Color.Yellow;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void ContinueButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
