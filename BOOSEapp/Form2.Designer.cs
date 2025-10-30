namespace BOOSEapp
{
    partial class Form2
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
            canvasBox = new PictureBox();
            runButton = new Button();
            textBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)canvasBox).BeginInit();
            SuspendLayout();
            // 
            // canvasBox
            // 
            canvasBox.Location = new Point(398, 22);
            canvasBox.Name = "canvasBox";
            canvasBox.Size = new Size(378, 399);
            canvasBox.TabIndex = 0;
            canvasBox.TabStop = false;
            // 
            // runButton
            // 
            runButton.Location = new Point(130, 383);
            runButton.Name = "runButton";
            runButton.Size = new Size(113, 38);
            runButton.TabIndex = 1;
            runButton.Text = "RUN";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += runButton_Click;
            // 
            // textBox
            // 
            textBox.Location = new Point(25, 22);
            textBox.Multiline = true;
            textBox.Name = "textBox";
            textBox.Size = new Size(345, 339);
            textBox.TabIndex = 2;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox);
            Controls.Add(runButton);
            Controls.Add(canvasBox);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)canvasBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox canvasBox;
        private Button runButton;
        private TextBox textBox;
    }
}