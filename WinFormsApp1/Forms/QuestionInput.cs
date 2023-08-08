namespace WinFormsApp1.Forms
{
	public partial class QuestionInput : Form
	{

		private string answer;
		public QuestionInput(string question)
		{
			InitializeComponent();
			questionLabel.Text = question;
		}

		private void SubmitButton_Click(object sender, EventArgs e)
		{
			 answer = answerTextBox.Text;

		}

		public string GetSubmittedAnswer()
		{
			return answer;
		}
	}
}
