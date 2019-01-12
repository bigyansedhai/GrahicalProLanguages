using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProLanguages
{
    /// <summary>
    /// Create Interface Shape inside two method 
    /// if you inherit this interface inside other class ,
    /// you should create this   method inside class
    /// </summary>
   public interface Shape
    {
        void draw(Graphics g);
        void set (params int[] list);
      

    }
}
