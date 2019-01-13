using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProLanguages
{
    /// <summary>
    /// create abstract Class 
    /// </summary><param>getShap</param>
    public abstract class AbstractFactory
    {
        /// <summary>
        /// passing string type parameter in gettShape Method inherit Shape Interface
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        public abstract Shape getShape(string shapeType);
        

       
    }
}
