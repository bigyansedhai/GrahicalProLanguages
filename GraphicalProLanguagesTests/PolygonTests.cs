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
    public class PolygonTests
    {
        [TestMethod()]
        public void setTest()
        {
            Polygon p = new Polygon();
            int x = 100, y = 100, width = 200, height = 100;

            p.set(x, y, width, height);

            Assert.AreEqual(x, width, p.width);
        }
    }
}