using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PHCM_last_na_to
{
    public class CatanaPanel : System.Windows.Forms.Panel
    {
        // Fields
        private int borderRadius = 30; // Radius for the rounded corners of the panel
        private float gradientAngle = 90F; // Angle for the gradient background
        private Color gradientTopColor = Color.DodgerBlue; // Top color of the gradient background
        private Color gradientBottomColor = Color.CadetBlue; // Bottom color of the gradient background

        // Constructor
        public CatanaPanel()
        {
            // Set default background and foreground colors for the panel
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
        }

        // Property for BorderRadius
        [Category("Panel ni Catana")]
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                borderRadius = value; // Update the radius value
                this.Invalidate();  // Redraw the panel when the property changes
            }
        }

        [Category("Panel ni Catana")]
        // Property for GradientAngle
        public float GradientAngle
        {
            get
            {
                return gradientAngle;
            }
            set
            {
                gradientAngle = value; // Update the gradient angle
                this.Invalidate();  // Redraw the panel when the property changes
            }
        }

        [Category("Panel ni Catana")]
        // Property for GradientTopColor
        public Color GradientTopColor
        {
            get
            {
                return gradientTopColor;
            }
            set
            {
                gradientTopColor = value; // Update the top color of the gradient
                this.Invalidate();  // Redraw the panel when the property changes
            }
        }

        [Category("Panel ni Catana")]
        // Property for GradientBottomColor
        public Color GradientBottomColor
        {
            get
            {
                return gradientBottomColor;
            }
            set
            {
                gradientBottomColor = value; // Update the bottom color of the gradient
                this.Invalidate();  // Redraw the panel when the property changes
            }
        }

        // Helper method to create a rounded rectangle GraphicsPath
        private GraphicsPath GetGraphicsPath(RectangleF rectangle, float radius)
        {
            // Create a GraphicsPath for the rounded rectangle
            GraphicsPath graphicsPath = new GraphicsPath();

            // Start the path
            graphicsPath.StartFigure();

            // Add arcs for each corner and connect them
            graphicsPath.AddArc(rectangle.Width - radius, rectangle.Height - radius, radius, radius, 0, 90); // Bottom-right
            graphicsPath.AddArc(rectangle.X, rectangle.Height - radius, radius, radius, 90, 90); // Bottom-left
            graphicsPath.AddArc(rectangle.X, rectangle.Y, radius, radius, 180, 90); // Top-left
            graphicsPath.AddArc(rectangle.Width - radius, rectangle.Y, radius, radius, 270, 90); // Top-right
            graphicsPath.CloseFigure();
            // Return the completed path
            return graphicsPath;
        }

        // Overriding the OnPaint method to customize the drawing of the panel
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Enable anti-aliasing for smoother edges
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Create a LinearGradientBrush to fill the background with a gradient
            LinearGradientBrush brushPanel = new LinearGradientBrush(
                this.ClientRectangle, // Rectangle to fill
                this.GradientTopColor, // Top color of the gradient
                this.GradientBottomColor, // Bottom color of the gradient
                this.GradientAngle // Angle of the gradient
            );

            // Fill the panel with the gradient
            Graphics graphicsCatana = e.Graphics;
            graphicsCatana.FillRectangle(brushPanel, ClientRectangle);

            // Define the rectangle area for the panel
            RectangleF rectangleF = new RectangleF(0, 0, this.Width, this.Height);

            // Apply rounded corners if the BorderRadius is greater than 2
            if (borderRadius > 2)
            {
                // Create a rounded rectangle GraphicsPath
                using (GraphicsPath graphicsPath = GetGraphicsPath(rectangleF, borderRadius))
                // Create a pen to draw the border
                using (Pen pen = new Pen(this.Parent.BackColor, 2))
                {
                    // Set the Region of the panel to match the rounded rectangle
                    this.Region = new Region(graphicsPath);

                    // Draw the border around the panel
                    e.Graphics.DrawPath(pen, graphicsPath);
                }
            }
            else
            {
                // If BorderRadius is not greater than 2, use a rectangular region
                this.Region = new Region(rectangleF);
            }
        }
    }
}
