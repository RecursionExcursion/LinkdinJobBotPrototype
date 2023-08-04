namespace WinFormsApp1.Forms
{
    partial class CaptchaByPassForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            continueButton = new Button();
            SuspendLayout();
            // 
            // continueButton
            // 
            continueButton.Location = new Point(158, 123);
            continueButton.Name = "continueButton";
            continueButton.Size = new Size(75, 23);
            continueButton.TabIndex = 0;
            continueButton.Text = "Continue";
            continueButton.UseVisualStyleBackColor = true;
            continueButton.Click += ContinueButtonClick;
            // 
            // CaptchaByPassForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 263);
            Controls.Add(continueButton);
            Name = "CaptchaByPassForm";
            Text = "Capcha Detected!";
            ResumeLayout(false);
        }

        #endregion

        private Button continueButton;
    }
}