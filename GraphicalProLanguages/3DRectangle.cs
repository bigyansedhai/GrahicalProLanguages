using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProLanguages
{
    public class _3DRectangle:Shape
    {
        Pen myPen = new Pen(Color.Black);
        SolidBrush brush = new SolidBrush(Color.Black);
        int x, y, width, height;
        public _3DRectangle():base()
        {
            this.x = 0;
            this.y = 0;
        }
        public _3DRectangle(Graphics g, int width,int height)
        {
            this.width = width;
            this.height = height;
        }
       public void draw(Graphics g)
        {
            g.DrawRectangle(myPen, x - width, y - height, width * 2, height * 2);
            Brush bgBrush = new SolidBrush(Color.Black);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //Fill the background using Solid brush and then apply a white wash 
            RectangleF rec = new RectangleF(x - width, y - height, width * 2, height * 2);
            g.FillRectangle(bgBrush, x - width, y - height, width * 2, height * 2);
            g.FillRectangle(new SolidBrush(Color.FromArgb(180, Color.Red)), x - width, y - height, width * 2, height * 2);
            System.Windows.Forms.ControlPaint.DrawBorder3D(g, x - width, y - height, width * 2, height * 2, System.Windows.Forms.Border3DStyle.Raised);



        }
        public void set(params int[] list)
        {
            this.x = list[0];
            this.y = list[1];
            this.width = list[2];
            this.height = list[3];

        }
    }
}
