using BOOSE;
using BOOSEApp;
using System.Diagnostics;

namespace BOOSEapp
{
    public partial class Form1 : Form
    {
        private AppCanvas canvas;
        ///<summary>
        /// Initializes the form and sets up the drawing canvas.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());

            canvas = new AppCanvas(canvasBox.ClientSize.Width, canvasBox.ClientSize.Height);
            canvasBox.Image = (Bitmap)canvas.getBitmap();
        }

        /// <summary>
        /// Click event for the clear button.
        /// </summary>
        private void clearButton_Click(object sender, EventArgs e)
        {
            canvas.Clear();
            canvasBox.Image = (Bitmap)canvas.getBitmap();
        }

        /// <summary>
        /// Click event for the run button.
        /// </summary>
        private void runButton_Click(object sender, EventArgs e)
        {
            canvas.SetColour(255, 0, 0);
            canvas.MoveTo(150, 150);
            canvas.Circle(50, true);

            canvas.SetColour(0, 0, 255);
            canvas.MoveTo(100, 100);
            canvas.DrawTo(200, 200);

            canvas.Reset();
            canvas.MoveTo(50, 250);
            canvas.WriteText("Red Circle, Blue Line");

            canvasBox.Image = (Bitmap)canvas.getBitmap();
        }
    }
}
