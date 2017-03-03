﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;
using System.Linq;
using Moq;

namespace EssentialTools.Tests
{
    [TestClass]
    public class UnitTest2
    {
        private Product[] products = {
                new Product{Name="Kayak", Category="Watersoprts",Price=275M},
                new Product{Name="Lifejacket", Category="Watersoprts",Price=48.95M},
                new Product{Name="Soccer Ball", Category="Soccer",Price=19.50M},
                new Product{Name="Corner Flag",Category="Soccer",Price=34.95M}
            };

        [TestMethod]
        public void Sum_Products_Correctly()
        {
            //arrange
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);

            var target = new LinqValueCalculator(mock.Object);
            var goalTotal = products.Sum(e => e.Price);

            //act
            var result = target.ValueProducts(products);

            //assert
            Assert.AreEqual(goalTotal, result);
        }
    }
}
