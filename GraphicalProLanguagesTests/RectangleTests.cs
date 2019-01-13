﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProLanguages.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        

      
        [TestMethod()]
        public void setTest()
        {
            Rectangle r = new Rectangle();
            int x = 100, y = 100, width = 200, height = 100;

            r.set(x, y, width, height);

            Assert.AreEqual(x, r.x);
        }
    }
}