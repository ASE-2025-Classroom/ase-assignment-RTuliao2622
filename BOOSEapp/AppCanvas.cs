using BOOSE;
using System.Drawing.Drawing2D;

namespace BOOSEApp
{
    /// <summary>
    /// Canvas implementation for BOOSE drawing commands.
    /// </summary>
    public class AppCanvas : ICanvas
    {
        /// <summary>
        /// Gets or sets the current X position of the pen.
        /// </summary>
        public int Xpos { get => xpos; set => xpos = value; }

        /// <summary>
        /// Gets or sets the current Y position of the pen.
        /// </summary>
        public int Ypos { get => ypos; set => ypos = value; }

        /// <summary>
        /// Gets or sets the current pen colour.
        /// </summary>
        public object PenColour { get => penColour; set => penColour = (Color)value; }

        private int xpos;
        private int ypos;
        private Color penColour = Color.Black;
        private Bitmap bitmap;
        private Graphics graphics;

        /// <summary>
        /// Initializes a new canvas with the specified dimensions.
        /// </summary>
        public AppCanvas(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);
        }

        /// <summary>
        /// Draws a circle at the current position.
        /// </summary>
        public void Circle(int radius, bool filled)
        {
            var rect = new Rectangle(xpos - radius, ypos - radius, radius * 2, radius * 2);
            if (filled)
            {
                using (var brush = new SolidBrush(penColour))
                {
                    graphics.FillEllipse(brush, rect);
                }
            }
            else
            {
                using (var pen = new Pen(penColour))
                {
                    graphics.DrawEllipse(pen, rect);
                }
            }
        }

        /// <summary>
        /// Clears the canvas to white.
        /// </summary>
        public void Clear()
        {
            graphics.Clear(Color.White);
        }

        /// <summary>
        /// Draws a line from the current position to the specified coordinates.
        /// </summary>
        public void DrawTo(int x, int y)
        {
            using (var pen = new Pen(penColour))
            {
                graphics.DrawLine(pen, xpos, ypos, x, y);
            }
            xpos = x;
            ypos = y;
        }

        /// <summary>
        /// Gets the current bitmap.
        /// </summary>
        public object getBitmap()
        {
            return bitmap;
        }

        /// <summary>
        /// Moves the pen to a new position without drawing.
        /// </summary>
        public void MoveTo(int x, int y)
        {
            xpos = x;
            ypos = y;
        }

        /// <summary>
        /// Draws a rectangle at the current position.
        /// </summary>
        public void Rect(int width, int height, bool filled)
        {
            var rect = new Rectangle(xpos, ypos, width, height);
            if (filled)
            {
                using (var brush = new SolidBrush(penColour))
                {
                    graphics.FillRectangle(brush, rect);
                }
            }
            else
            {
                using (var pen = new Pen(penColour))
                {
                    graphics.DrawRectangle(pen, rect);
                }
            }
        }

        /// <summary>
        /// Resets the pen position and colour.
        /// </summary>
        public void Reset()
        {
            xpos = 0;
            ypos = 0;
            penColour = Color.Black;
        }

        /// <summary>
        /// Resizes the canvas.
        /// </summary>
        public void Set(int width, int height)
        {
            graphics.Dispose();
            bitmap.Dispose();

            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);
        }

        /// <summary>
        /// Sets the pen colour using RGB values.
        /// </summary>
        public void SetColour(int red, int green, int blue)
        {
            penColour = Color.FromArgb(red, green, blue);
        }

        /// <summary>
        /// Draws a triangle at the current position.
        /// </summary>
        public void Tri(int width, int height)
        {
            Point[] points = new Point[]
            {
                new Point(xpos, ypos),
                new Point(xpos + width, ypos),
                new Point(xpos + width / 2, ypos - height)
            };
            using (var pen = new Pen(penColour))
            {
                graphics.DrawPolygon(pen, points);
            }
        }

        /// <summary>
        /// Writes text at the current position.
        /// </summary>
        public void WriteText(string text)
        {
            using (var font = new Font("Arial", 20))
            using (var brush = new SolidBrush(penColour))
            {
                graphics.DrawString(text, font, brush, xpos, ypos);
            }
        }
    }
}
