using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms; //importing form library
using System.Drawing; //importing drawing library
using System.Drawing.Drawing2D;
using System.ComponentModel; //importing drawing library for 2D

namespace PHCM_last_na_to.Custom_Button_ni_Catana
{
    public class Catana_Button : Button
    {
        //Fields
        private int borderSize = 0; // Size of the border around the button
        private int borderRadius = 0; // Radius for rounded corners
        private Color borderColor = SystemColors.MenuHighlight; // Color of the button border

        //Properties
        [Category("Catana Button")] // Custom category for property grouping in the designer
        public int BorderSize
        {
            get { return borderSize; } // Get the current border size
            set
            {
                borderSize = value; // Set the border size
                this.Invalidate(); // Redraw the control when the value changes
            }
        }

        [Category("Catana Button")]
        public int BorderRadius
        {
            get { return borderRadius; } // Get the current border radius
            set
            {
                borderRadius = value; // Set the border radius
                this.Invalidate(); // Redraw the control when the value changes
            }
        }

        [Category("Catana Button")]
        public Color BorderColor
        {
            get { return borderColor; } // Get the current border color
            set
            {
                borderColor = value; // Set the border color
                this.Invalidate(); // Redraw the control when the value changes
            }
        }

        [Category("Catana Button")]
        public Color BackgroundColor
        {
            get { return this.BackColor; } // Get the background color of the button
            set { this.BackColor = value; } // Set the background color of the button
        }

        [Category("Catana Button")]
        public Color TextColor
        {
            get { return this.ForeColor; } // Get the text color of the button
            set { this.ForeColor = value; } // Set the text color of the button
        }

        //Constructor
        public Catana_Button()
        {
            this.FlatStyle = FlatStyle.Flat; // Set the button style to flat
            this.FlatAppearance.BorderSize = 0; // Remove default border size
            this.Size = new Size(150, 40); // Set the default size of the button
            this.BackColor = SystemColors.MenuHighlight; // Set the default background color
            this.ForeColor = Color.White; // Set the default text color
            this.Font = new Font("Nirmala UI", 12, FontStyle.Regular); // Set the default font and size
            this.Resize += new EventHandler(Button_Resize); // Attach an event handler for resizing
        }

        //Methods
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath(); // Create a new graphics path for rounded corners
            float curveSize = radius * 2F; // Calculate the curve size based on the radius

            path.StartFigure(); // Begin drawing the shape
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90); // Add top-left arc
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90); // Add top-right arc
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90); // Add bottom-right arc
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90); // Add bottom-left arc
            path.CloseFigure(); // Close the shape
            return path; // Return the completed path
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent); // Call the base class OnPaint method

            Rectangle rectSurface = this.ClientRectangle; // Get the button's drawing area
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize); // Calculate the border rectangle
            int smoothSize = 2; // Default smooth size
            if (borderSize > 0)
                smoothSize = borderSize; // Use the border size for smoothing if it is greater than 0

            if (borderRadius > 2) // If the button has rounded corners
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius)) // Create a path for the button surface
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize)) // Create a path for the border
                using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize)) // Create a pen for the surface
                using (Pen penBorder = new Pen(borderColor, borderSize)) // Create a pen for the border
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // Enable anti-aliasing for smooth edges
                    this.Region = new Region(pathSurface); // Set the button's region for the rounded shape
                    pevent.Graphics.DrawPath(penSurface, pathSurface); // Draw the button's surface

                    if (borderSize >= 1)
                        pevent.Graphics.DrawPath(penBorder, pathBorder); // Draw the button's border
                }
            }
            else // If the button has no rounded corners
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None; // Disable anti-aliasing
                this.Region = new Region(rectSurface); // Set the button's region for a rectangular shape
                if (borderSize >= 1) // If a border is specified
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize)) // Create a pen for the border
                    {
                        penBorder.Alignment = PenAlignment.Inset; // Align the pen inside the border
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1); // Draw the rectangle border
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e); // Call the base class OnHandleCreated method
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged); // Attach an event handler for when the parent's background color changes
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate(); // Redraw the button when the parent's background color changes
        }

        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height) // Ensure the border radius does not exceed the button's height
                borderRadius = this.Height; // Adjust the border radius to fit the button
        }
    }
}
