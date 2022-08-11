using DevFramework.Northwind.DataAccess.ConCrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevFramework.Northwind.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFramworkTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList();
            int gerceklesen = result.Count;
            Assert.AreEqual(77, gerceklesen);
            
        }
        [TestMethod]
        public void Get_all_returns_all_products_include_ab()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList(p=>p.urunAd.Contains("ab"));
            int gerceklesen = result.Count;
            Assert.AreEqual(4, gerceklesen);

        }
    }
}
