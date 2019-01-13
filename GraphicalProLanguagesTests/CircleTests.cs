using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProLanguages.Tests
{
    [TestClass()]
    public class CircleTests
    {
        [TestMethod()]
      
    
        public void setTest()
        {
            int x= 0, y =0, radius= 100;
            Circle c = new Circle();
            c.set(x, y, radius);
            Assert.AreEqual(x, radius, c.radius);

        }
    }
}