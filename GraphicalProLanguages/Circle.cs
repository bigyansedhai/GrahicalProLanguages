using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace GraphicalProLanguages
{
    /// <summary>
    /// Create Class Of Circle and Inherit Interface of Shape
    /// </summary>
   public class Circle:Shape
    {
        Pen myPen = new Pen(System.Drawing.Color.Black);
        SolidBrush brush = new SolidBrush(Color.Blue);
       public int x, y, radius;

        /// <summary>
        /// Create Constructor passing No parameter
        /// </summary>

        public Circle():base()
        {
            x = 0;
            y = 0;
        }
        /// <summary>
        /// Create Constructor Passing Parameter
        /// </summary>
        /// <param name="radius"></param>
        public Circle(int radius)
        {
            this.radius = radius;
        }

        /// <summary>
        /// passing Graphics g parameter
        /// g create draw circle
        /// </summary>
        /// <param name="g"></param>
        public void draw(Graphics g)
        {
            g.DrawEllipse(myPen, x-radius, y-radius, radius * 2,radius * 2);
           // g.FillEllipse(brush, x, y, radius, radius);


            
            
        }

        /// <summary>
        /// set parameter listing like list,arraylist
        /// </summary>
        /// <param name="list"></param>
        public void set (params int[] list)
        {
            this.x = list[0];
            this.y = list[1];
            this.radius = list[2];
        }

        private Graphics CreateGraphics()
        {
            throw new NotImplementedException();
        }
    }
}
