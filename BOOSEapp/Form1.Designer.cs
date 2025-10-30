namespace BOOSEapp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            canvasBox = new PictureBox();
            runButton = new Button();
            mainTextBox = new TextBox();
            clearButton = new Button();
            ((System.ComponentModel.ISupportInitialize)canvasBox).BeginInit();
            SuspendLayout();
            // 
            // canvasBox
            // 
            canvasBox.Location = new Point(445, 34);
            canvasBox.Name = "canvasBox";
            canvasBox.Size = new Size(600, 500);
            canvasBox.TabIndex = 0;
            canvasBox.TabStop = false;
            // 
            // runButton
            // 
            runButton.Location = new Point(47, 479);
            runButton.Name = "runButton";
            runButton.Size = new Size(138, 55);
            runButton.TabIndex = 1;
            runButton.Text = "RUN";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += runButton_Click;
            // 
            // mainTextBox
            // 
            mainTextBox.Location = new Point(21, 34);
            mainTextBox.Multiline = true;
            mainTextBox.Name = "mainTextBox";
            mainTextBox.Size = new Size(393, 415);
            mainTextBox.TabIndex = 2;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(233, 479);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(138, 55);
            clearButton.TabIndex = 3;
            clearButton.Text = "CLEAR";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1074, 573);
            Controls.Add(clearButton);
            Controls.Add(mainTextBox);
            Controls.Add(runButton);
            Controls.Add(canvasBox);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)canvasBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox canvasBox;
        private Button runButton;
        private TextBox mainTextBox;
        private Button clearButton;
    }
}
