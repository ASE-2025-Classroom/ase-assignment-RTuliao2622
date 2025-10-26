using BOOSE;
using System.Drawing;

namespace BOOSEApp
{
    public class AppCanvas : ICanvas
    {
        public int Xpos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Ypos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object PenColour { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private int xpos;
        private int ypos;
        private Color penColour = Color.Black;
        private Bitmap bitmap;
        private Graphics graphics;

        public AppCanvas(int width, int height) 
        {
            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
        }


        public void Circle(int radius, bool filled)
        {
            var rect = new Rectangle(xpos - radius, ypos - radius, radius * 2, radius * 2);
            if (filled)
                graphics.FillEllipse(new SolidBrush(penColour), rect);
            else
                graphics.DrawEllipse(new Pen(penColour), rect);
        }

        public void Clear()
        {
            graphics.Clear(Color.White);
        }

        public void DrawTo(int x, int y)
        {
            graphics.DrawLine(new Pen(penColour), xpos, ypos, x, y);
            xpos = x;
            ypos = y;
        }

        public object getBitmap()
        {
            return bitmap;
        }

        public void MoveTo(int x, int y)
        {
            xpos = x;
            ypos = y;
        }

        public void Rect(int width, int height, bool filled)
        {
            var rect = new Rectangle(xpos, ypos, width, height);
            if (filled)
                graphics.FillRectangle(new SolidBrush(penColour), rect);
            else
                graphics.DrawRectangle(new Pen(penColour), rect);
        }

        public void Reset()
        {
            xpos = 0;
            ypos = 0;
            penColour = Color.Black;
        }

        public void Set(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
        }

        public void SetColour(int red, int green, int blue)
        {
            penColour = Color.FromArgb(red, green, blue);
        }

        public void Tri(int width, int height)
        {
            Point[] points = new Point[]
            {
                new Point(xpos, ypos),
                new Point(xpos + width, ypos),
                new Point(xpos + width / 2, ypos - height)
            };
            graphics.DrawPolygon(new Pen(penColour), points);
        }

        public void WriteText(string text)
        {
            graphics.DrawString(text, new Font("Arial", 12), new SolidBrush(penColour), xpos, ypos);
        }
    }
}
