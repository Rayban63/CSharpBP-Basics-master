using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            //--Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            currentProduct.ProductId = 1;
            currentProduct.ProductDescription = "15 inch Steal hand blade";
            var expected = "Hello Saw (1): 15 inch Steal hand blade";

            //--Act
            var actual = currentProduct.SayHello();

            //--Assert
            Assert.AreEqual(expected, actual);
        }
    }
}