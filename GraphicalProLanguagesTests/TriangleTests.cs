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
    public class TriangleTests
    {
        [TestMethod()]
        public void setTest()
        {
            Triangle t = new Triangle();
            int x = 100, y = 100, width = 200, height = 100;

            t.set(x, y, width, height);

            Assert.AreEqual(x,width,t.width);
        }
    }
}