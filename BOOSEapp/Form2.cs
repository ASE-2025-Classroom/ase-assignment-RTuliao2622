using BOOSE;
using BOOSEApp;

namespace BOOSEapp
{
    public partial class Form2 : Form
    {
        private AppCanvas canvas;
        ///<summary>
        /// Initializes the form and sets up the drawing canvas.
        /// </summary>
        public Form2()
        {
            InitializeComponent();

            canvas = new AppCanvas(canvasBox.Width, canvasBox.Height);
            canvasBox.Image = (Bitmap)canvas.getBitmap();
        }
        /// <summary>
        /// Click event for the run button. Allows user to input valid boose commands which is then outputted onto the picture box.
        /// </summary>
        private void runButton_Click(object sender, EventArgs e)
        {
            try
            {
                string commands = textBox.Text;

                var program = new StoredProgram(canvas);
                var factory = new CommandFactory();
                var parser = new Parser(factory, program);

                parser.ParseProgram(commands);
                program.Run();

                canvasBox.Image = (Bitmap)canvas.getBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
