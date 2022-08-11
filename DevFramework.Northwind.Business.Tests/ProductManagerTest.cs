using System;
using DevFramework.Northwind.Business.ConCrete.Manager;
using DevFramework.Northwind.DataAccess.Abstracts;
using DevFramework.Northwind.Entities.ConCrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DevFramework.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTest
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()//veritabanına gitmeden sadece valdation kontrolü
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);
            productManager.Add(new Product());
        }
    }
}
