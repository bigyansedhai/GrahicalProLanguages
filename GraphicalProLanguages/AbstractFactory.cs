using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProLanguages
{
  public abstract class AbstractFactory
    {
        public abstract Shape getShape(string shapeType);
        

       
    }
}
