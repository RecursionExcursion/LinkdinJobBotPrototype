using WinFormsApp1.Forms.Utility;

namespace WinFormsApp1.Forms
{
	public partial class QuestionInput : FormBase
	{

		private string answer;
		private ControlResizer controlResizer;


		public QuestionInput(string question)
		{
			InitializeComponent();
			InitializeControlResizer();

			this.TopMost = true;
			questionLabel.Text = question;
			FormUtility.DisableControl(answerCheckList);
		}

		public QuestionInput(string question, List<string> answerList)
		{
			InitializeComponent();
			InitializeControlResizer();

			this.TopMost = true;
			questionLabel.Text = question;
			FormUtility.DisableControl(answerTextBox);

			answerList.ForEach(a => answerCheckList.Items.Add(a));
			answerCheckList.ItemCheck += EnsureOnlyOneElementSelected;
		}

		/* Event handlers */

		private void EnsureOnlyOneElementSelected(object sender, ItemCheckEventArgs e)
		{
			CheckedListBox checkedListBox = (CheckedListBox) sender;

			for (int i = 0; i < checkedListBox.Items.Count; i++)
			{
				if (i != e.Index && checkedListBox.GetItemChecked(i))
				{
					checkedListBox.SetItemChecked(i, false);
				}
			}
		}

		private void SubmitButton_Click(object sender, EventArgs e)
		{
			if (answerTextBox.Enabled)
			{
				answer = answerTextBox.Text;
			}
			else if (answerCheckList.Enabled)
			{
				answer = (string) answerCheckList.SelectedItem;
			}
			this.Close();
		}

		/* Helpers */

		public string GetSubmittedAnswer()
		{
			return answer;
		}

		private void OnFormResize(object sender, EventArgs e)
		{
			controlResizer.ResizeControlsOnFormResize();
		}
	}
}
