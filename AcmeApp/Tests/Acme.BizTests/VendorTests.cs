﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorTests
    {
        [TestMethod()]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "ABC Corp";
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "";
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PlaceOrderTest()
        {
            //--Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "Hacksaw");
            var expected = new OperationResult(true, "Order from Acme.com\r\nProduct: Tools-1\r\nQuantity: 12" +
                "\r\nInstructions: standard delivery");

            //--Act
            var actual = vendor.PlaceOrder(product, 12);

            //--Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }
        [TestMethod()]
        public void PlaceOrderTest_NoDeliveryDate()
        {
            //--Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "Hacksaw");
            var expected = new OperationResult(true, "Order from Acme.com\r\nProduct: Tools-1\r\nQuantity: 12" +
                "\r\nInstructions: Delivery to suite 24");

            //--Act
            var actual = vendor.PlaceOrder(product, 12,
                instructions: " Delivery to suite 24");

            //--Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }
        [TestMethod()]
        public void PlaceOrder_3ParamerterTest()
        {
            //--Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "Hacksaw");
            var expected = new OperationResult(true, "Order from Acme.com\r\nProduct: Tools-1\r\nQuantity: 12" +
                "\r\nDeliver By: 25-10-2019" +
                "\r\nInstructions: standard delivery");

            //--Act
            var actual = vendor.PlaceOrder(product, 12, new DateTimeOffset(2019, 10, 25, 0, 0, 0, new TimeSpan(-7, 0, 0)));

            //--Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrder_NullProduct_Exeption()
        {
            //--Arrange
            var vendor = new Vendor();

            //--Act
            var actual = vendor.PlaceOrder(null, 12);

            //--assert
            //Expected Exception

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlaceOrder_SmallerThenOneQuntity_Exeption()
        {
            //--Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "Hacksaw");

            //--Act
            var actual = vendor.PlaceOrder(product, 0);

            //--assert
            //Expected Exception

        }

        [TestMethod()]
        public void PlaceorderTest_WithAddress()
        {
            //--Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "Hacksaw");
            var expected = new OperationResult(true, "Test With Address");

            //--Act
            var actual = vendor.PlaceOrder(product, 12,
                                           Vendor.IncludeAddress.Yes,
                                           Vendor.SendCopy.No);

            //--Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }
        [TestMethod()]
        public void PlaceorderTest_WithSendCopy()
        {
            //--Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "Hacksaw");
            var expected = new OperationResult(true, "Test With Copy");

            //--Act
            var actual = vendor.PlaceOrder(product, 12,
                                           Vendor.IncludeAddress.No,
                                           Vendor.SendCopy.Yes);

            //--Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            //--Arrange
            var vendor = new Vendor();
            vendor.VendorId = 1;
            vendor.CompanyName = " ABC Corp";
            var expected = "Vendor: ABC Corp";

            //--Act
            var actual = vendor.ToString();

            //--Assert
            Assert.AreEqual(expected, actual);
        }
    }
}