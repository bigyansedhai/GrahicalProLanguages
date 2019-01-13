using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GraphicalProLanguages
{
    public class Triangle : Shape
    {
        /// <summary>
        /// declear global scope variable
        /// </summary>
        Pen mypen = new Pen(Color.Red);
        SolidBrush brush = new SolidBrush(Color.Red);
      public  int x, y, width, height;
        

        /// <summary>
        /// create constructor
        /// </summary>
        public Triangle():base()
        {
          this.width = 0;
           this.height = 0;
           
        }
        /// <summary>
        /// Create Constructor passing parameter
        /// </summary>
        /// <param name="g"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Triangle (Graphics g,int width,int height)
        {
            this.width = width;
            this.height = height;
           


        }
        /// <summary>
        /// create draw method which is base of Shape Interface
        /// passing Graphics g parameter
        /// create Points
        /// passing global scope x,y,width,height
        /// </summary>
        /// <param name="g"></param>
        public void draw(Graphics g)
        {

            Pen mypen = new Pen(Color.Black, 2);
            Point[] p = new Point[3];
            p[0].X = x;
            p[0].Y = y;

            p[1].X = x + width;
            p[1].Y = y;

            p[2].X = x + width;
            p[2].Y = y - height;
            g.DrawPolygon(mypen, p);
            // g.FillPolygon(brush, p);

           

        }
        /// <summary>
        /// set method passing interger<list type="list"></list>
        /// </summary>
        /// <param name="list"></param>
        public void set (params int[] list)
        {

            this.x = list[0];
            this.y = list[1];
            this.width = list[2];
            this.height = list[3];
         
        }
    }
}
