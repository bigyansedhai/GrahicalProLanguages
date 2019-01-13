using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicalProLanguages
{
    public class Rectangle : Shape
    {
        /// <summary>
        /// declear variable 
        /// using system.Drawing adding new namespace(dll file)
        /// </summary>
        Pen myPen = new Pen(Color.Black);
        SolidBrush brush = new SolidBrush(Color.Black);
        public int x, y, width, height;

        public Rectangle():base()
        {
            x = 0;
            y = 0;
        }
        public Rectangle(int x, int y, int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public void draw(Graphics g)
        {
            g.DrawRectangle(myPen, x, y, width, height);
            //g.FillRectangle(brush, x, y, width, height);
            x = x + width;
            y = y + height;

        }
      

      

        public void set(params int[] list)
        {
            // int Rectangle  = x, y, width, heignt;
            this.x = list[0];
            this.y = list[1];
            this.width = list[2];
            this.height = list[3];


            //x = 40;
            //y = 80;
            //width = 60;
            //height = 60;


        }
    }



}  


