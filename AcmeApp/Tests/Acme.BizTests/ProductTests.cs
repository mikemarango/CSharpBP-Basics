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
        public void SayHello_SetPropertyTest()
        {
            // Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            currentProduct.ProductId = 1;
            currentProduct.ProductVendor.CompanyName = "ABC Corp";
            currentProduct.ProductDescription = "15-inch steel blade hand saw";

            var expected = "Hello Saw (1): 15-inch steel blade hand saw" + " Available on: ";

            // Act
            var actual = currentProduct.SayHello();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SayHello_ParameterizedConstructorTest()
        {
            // Arrange
            var currentProduct = new Product(1, "Saw", "15-inch steel blade hand saw");

            var expected = "Hello Saw (1): 15-inch steel blade hand saw" + " Available on: ";

            // Act
            var actual = currentProduct.SayHello();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SayHello_ObjectInitializer()
        {
            // Arrange
            var currentProduct = new Product
            {
                ProductId = 1,
                ProductName = "Saw",
                ProductDescription = "15-inch steel blade hand saw"
            };

            var expected = "Hello Saw (1): 15-inch steel blade hand saw" + " Available on: ";

            // Act
            var actual = currentProduct.SayHello();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Product_Null()
        {
            // Arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;

            string expected = null;

            // Act
            var actual = companyName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}