using BOOSE;
using System.Drawing.Drawing2D;

namespace BOOSEApp
{
    /// <summary>
    /// Canvas implementation for BOOSE drawing commands.
    /// </summary>
    internal class AppCanvas : ICanvas
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
        public object PenColour
        {
            get => penColour;
            set
            {
                if (value is Color color)
                    penColour = color;
                else
                    throw new InvalidCastException("PenColour must be an actual colour");
            }
        }

        private int xpos;
        private int ypos;
        private Color penColour = Color.Black;
        private Bitmap bitmap;
        private Graphics graphics;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppCanvas"/> class with the specified dimensions.
        /// </summary>
        /// <param name="width">The width of the canvas in pixels.</param>
        /// <param name="height">The height of the canvas in pixels.</param>
        public AppCanvas(int width, int height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Canvas dimensions must be positive.");

            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);
        }

        /// <summary>
        /// Draws a circle at the current pen position.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="filled">Whether the circle should be filled.</param>
        public void Circle(int radius, bool filled)
        {
            if (radius <= 0)
                throw new ArgumentException("Circle radius must be positive.");
            EnsureGraphics();

            var rect = new Rectangle(xpos - radius, ypos - radius, radius * 2, radius * 2);
            try
            {
                if (filled)
                {
                    using var brush = new SolidBrush(penColour);
                    graphics.FillEllipse(brush, rect);
                }
                else
                {
                    using var pen = new Pen(penColour);
                    graphics.DrawEllipse(pen, rect);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to draw circle: " + ex.Message);
            }
        }

        /// <summary>
        /// Clears the canvas to white.
        /// </summary>
        public void Clear()
        {
            EnsureGraphics();
            graphics.Clear(Color.White);
        }

        /// <summary>
        /// Draws a line from the current pen position to the specified coordinates.
        /// </summary>
        /// <param name="x">The X coordinate to draw to.</param>
        /// <param name="y">The Y coordinate to draw to.</param>
        public void DrawTo(int x, int y)
        {
            EnsureGraphics();
            try
            {
                using var pen = new Pen(penColour);
                graphics.DrawLine(pen, xpos, ypos, x, y);
                xpos = x;
                ypos = y;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to draw line: " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the current bitmap.
        /// </summary>
        /// <returns>The bitmap containing all drawn content.</returns>
        public object getBitmap()
        {
            if (bitmap == null)
                throw new InvalidOperationException("Canvas bitmap is not initialized.");
            return bitmap;
        }

        /// <summary>
        /// Moves the pen to a new position without drawing.
        /// </summary>
        /// <param name="x">The new X position.</param>
        /// <param name="y">The new Y position.</param>
        public void MoveTo(int x, int y)
        {
            xpos = x;
            ypos = y;
        }

        /// <summary>
        /// Draws a rectangle at the current pen position.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="filled">Whether the rectangle should be filled.</param>
        public void Rect(int width, int height, bool filled)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Rectangle dimensions must be positive.");
            EnsureGraphics();

            var rect = new Rectangle(xpos, ypos, width, height);
            try
            {
                if (filled)
                {
                    using var brush = new SolidBrush(penColour);
                    graphics.FillRectangle(brush, rect);
                }
                else
                {
                    using var pen = new Pen(penColour);
                    graphics.DrawRectangle(pen, rect);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to draw rectangle: " + ex.Message);
            }
        }

        /// <summary>
        /// Resets the pen position and the pen colour.
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
        /// <param name="width">The new width of the canvas.</param>
        /// <param name="height">The new height of the canvas.</param>
        public void Set(int width, int height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Canvas dimensions must be positive.");

            graphics?.Dispose();
            bitmap?.Dispose();

            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);
        }

        /// <summary>
        /// Sets the pen colour using RGB values.
        /// </summary>
        /// <param name="red">Red component (0–255).</param>
        /// <param name="green">Green component (0–255).</param>
        /// <param name="blue">Blue component (0–255).</param>
        public void SetColour(int red, int green, int blue)
        {
            if (!IsValidRGB(red) || !IsValidRGB(green) || !IsValidRGB(blue))
                throw new ArgumentOutOfRangeException("RGB values must be between 0 and 255.");

            penColour = Color.FromArgb(red, green, blue);
        }

        /// <summary>
        /// Draws a triangle at the current pen position.
        /// </summary>
        /// <param name="width">The width of the triangle base.</param>
        /// <param name="height">The height of the triangle.</param>
        public void Tri(int width, int height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Triangle dimensions must be positive.");
            EnsureGraphics();

            Point[] points = new Point[]
            {
                new Point(xpos, ypos),
                new Point(xpos + width, ypos),
                new Point(xpos + width / 2, ypos - height)
            };

            try
            {
                using var pen = new Pen(penColour);
                graphics.DrawPolygon(pen, points);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to draw triangle: " + ex.Message);
            }
        }

        /// <summary>
        /// Writes text at the current pen position using the current pen colour.
        /// </summary>
        /// <param name="text">The text to write.</param>
        public void WriteText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Text cannot be empty.");
            EnsureGraphics();

            try
            {
                using var font = new Font("Arial", 20);
                using var brush = new SolidBrush(penColour);
                graphics.DrawString(text, font, brush, xpos, ypos);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to write text: " + ex.Message);
            }
        }

        /// <summary>
        /// Ensures the graphics object is initialized before drawing.
        /// </summary>
        private void EnsureGraphics()
        {
            if (graphics == null)
                throw new InvalidOperationException("Canvas graphics are not initialized.");
        }

        /// <summary>
        /// Validates RGB is within the 0–255 range.
        /// </summary>
        private bool IsValidRGB(int value) => value >= 0 && value <= 255;
    }
}
