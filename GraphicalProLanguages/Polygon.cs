using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicalProLanguages
{
   public class Polygon:Shape
    {

        /// <summary>
        /// declear variable
        /// create constructor
        /// </summary>
        Pen mypen = new Pen(Color.Beige);
        SolidBrush brush = new SolidBrush(Color.Black);
      public  int x, y, width, height;
        /// <summary>
        /// Constructyor Create Polygon
        /// </summary>
        
 public Polygon()
        {
            this.x = 0;
            this.y = 0;
           


           
        }

        /// <summary>
        /// passing parameter inside global scope variable
        /// </summary>
        /// <param name="g"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Polygon(Graphics g, int width, int height)
        {
            this.width = width;
            this.height = height;
        }


        public void draw(Graphics g)
        {
            Pen mypen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Yellow);
            // g.Clear(Color.Black);
            // Create points that define polygon.
            Point point1 = new Point(x, y - (height / 2));
            Point point2 = new Point(x - width, y + (height / 2));
            Point point3 = new Point(x + (width / 2), y + (height / 2));

            Point point4 = new Point(x + (width), y - (height * 4));



            Point[] curvePoints =
                     {
                 point1,
                 point2,
                 point3,
                 point4,




             };
            g.DrawPolygon(mypen, curvePoints);
            g.FillPolygon(brush, curvePoints);

        }
        /// <summary>
        /// set parameter command passing value inside x,y,width,height
        /// </summary>
        /// <param name="command"></param>
        public void set(params int[]  command)
        {

            this.x = command[0];
            this.y = command[1];
            this.width = command[1];
            this.height = command[2];
            
        }

    }
}
