using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;



namespace GraphicalProLanguages
{
  public  class ShapeFactory:AbstractFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns>passing parameter like rectangle,cirle that will return value so on</returns>
       
        public override Shape getShape(string shapeType)
        {
           
            shapeType = shapeType.ToLower().Trim();
            
            if(shapeType == null)
            {
                return null;
            }  

            else if(shapeType =="circle")
            {
                return new Circle();
            }
            else if(shapeType =="rectangle")
            {
                return new Rectangle();
            }
            else if(shapeType=="triangle")
                {
                return new Triangle();
            }
            else if(shapeType =="polygon")
                {
                

                return new Polygon();
            }          
            else
            {
                return null;
            }

        }
      

       
    }
}
