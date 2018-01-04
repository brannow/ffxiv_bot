using System;
using System.Drawing;
using System.Windows.Forms;

namespace FFXIV_netBot.Controls
{
    public class ImageButton : Control
    {
        Image backgroundImage, pressedImage;
        bool pressed = false;

        public override Image BackgroundImage
        {
            get
            {
                return this.backgroundImage;
            }
            set
            {
                this.backgroundImage = value;
            }
        }

        // Property for the background image to be drawn behind the button text when 
        // the button is pressed. 
        public Image PressedImage
        {
            get
            {
                return this.pressedImage;
            }
            set
            {
                this.pressedImage = value;
            }
        }

        // When the mouse button is pressed, set the "pressed" flag to true  
        // and invalidate the form to cause a repaint.  The .NET Compact Framework  
        // sets the mouse capture automatically. 
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.pressed = true;
            this.Invalidate();
            base.OnMouseDown (e);
        }

        // When the mouse is released, reset the "pressed" flag 
        // and invalidate to redraw the button in the unpressed state. 
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.pressed = false;
            this.Invalidate();
            base.OnMouseUp (e);
        }

        // Override the OnPaint method to draw the background image and the text. 
        protected override void OnPaint(PaintEventArgs e)
        {
            if(this.pressed && this.pressedImage != null)
                e.Graphics.DrawImage(this.pressedImage, 0, 0);
            else if (this.backgroundImage != null)
                e.Graphics.DrawImage(this.backgroundImage, 0, 0);
            else
                e.Graphics.DrawImage(global::FFXIV_netBot.Properties.Resources.closeBtn, 0, 0);

            base.OnPaint(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
