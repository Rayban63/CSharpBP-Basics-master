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
            var expected = "Hello Saw (1): 15 inch Steal hand blade, Available on: ";

            //--Act
            var actual = currentProduct.SayHello();

            //--Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SayHello_ParamaterizedConstructor()
        {
            //--Arrange
            var currentProduct = new Product(1, "Saw", "15 inch Steal hand blade");
            var expected = "Hello Saw (1): 15 inch Steal hand blade, Available on: ";

            //--Act
            var actual = currentProduct.SayHello();

            //--Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SayHello_ObjectInitializerTest()
        {
            //--Arrange
            var currentProduct = new Product()
            {
                ProductId = 1,
                ProductName = "Saw",
                ProductDescription = "15 inch Steal hand blade",
            };
            var expected = "Hello Saw (1): 15 inch Steal hand blade, Available on: ";

            //--Act
            var actual = currentProduct.SayHello();


            //--Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Product_Null()
        {
            //--Arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;
            string expected = null;

            //--Act
            var actual = companyName;

            //--Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ConvertInchesToMetersTest()
        {
            //--Arrange
            var expected = 78.74;

            //--Act
            var actual = 2 * Product.InchesPerMeter;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinimumPriceTest_Default()
        {
            //--Arrange
            var currentProduct = new Product();
            var expected = .96m;

            //--Act
            var actual = currentProduct.MinimumPrice;

            //-Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void MinimumPriceTest_Bulk()
        {
            //--Arrange
            var currentProduct = new Product(1, "Bulk Tools", "");
            var expected = 9.91m;

            //--Act
            var actual = currentProduct.MinimumPrice;

            //-Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ProductName_Format()
        {
            //--Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "  Steel Hammer  ";
            var expected = "Steel Hammer";

            //--Act
            var actual = currentProduct.ProductName;

            //-Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ProductName_ToShort()
        {
            //--Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Ha";
            string expected = null;
            string expectedMessage = "Product name must be at least 3 characters";

            //--Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //-Assert

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod()]
        public void ProductName_ToLong()
        {
            //--Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Hammertopoundonbasicsteelobject";
            string expected = null;
            string expectedMessage = "Product name cannot be more than 20 characters";

            //--Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //-Assert

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod()]
        public void ProductName_JustRight()
        {
            //--Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            string expected = "Saw";
            string expectedMessage = null;

            //--Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //-Assert

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod()]
        public void Category_NewValue()
        {
            //--Arrange
            var currentProduct = new Product();
            currentProduct.Category = "Garden";
            var expected = "Garden";

            //--Act
            var actual = currentProduct.Category;

            //-Assert

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Sequence_DefaultValue()
        {
            //--Arrange
            var currentProduct = new Product();
            var expected = 1;

            //--Act
            var actual = currentProduct.SequenceNumber;

            //-Assert

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Sequence_NewValue()
        {
            //--Arrange
            var currentProduct = new Product();
            currentProduct.SequenceNumber = 5;
            var expected = 5;

            //--Act
            var actual = currentProduct.SequenceNumber;

            //-Assert

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ProductCode_DefaultValue()
        {
            //--Arrange
            var currentProduct = new Product();
            var expected = "Tools-1";
            Console.WriteLine(currentProduct.ProductCode);

            //--Act
            var actual = currentProduct.ProductCode;

            //-Assert

            Assert.AreEqual(expected, actual);
        }
    }
}