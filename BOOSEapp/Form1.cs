using BOOSE;
using BOOSEApp;
using System.Diagnostics;

namespace BOOSEapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());

            var canvas = new AppCanvas(this.ClientSize.Width, this.ClientSize.Height);

            canvas.SetColour(255, 0, 0); 
            canvas.MoveTo(150, 150);
            canvas.Circle(50, true);

            canvas.SetColour(0, 0, 255);
            canvas.MoveTo(100, 100);
            canvas.DrawTo(200, 200);

            canvas.Reset();
            canvas.MoveTo(50, 250);
            canvas.WriteText("Red Circle, Blue Line");

            this.BackgroundImage = (Bitmap)canvas.getBitmap();
        }
    }
}
