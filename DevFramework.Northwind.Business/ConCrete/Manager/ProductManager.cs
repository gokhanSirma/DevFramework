using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstracts;
using DevFramework.Northwind.Entities.ConCrete;
using DevFramwork.Core.Aspects.Postsharp;
using DevFramwork.Core.Aspects.Postsharp.CacheAspects;
using DevFramwork.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramwork.Core.CrossCuttingConcerns.Validation.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Caching.Hosting;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace DevFramework.Northwind.Business.ConCrete.Manager
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        //[CacheRemoveAspect("",typeof(MemoryCacheManager))] ya da böyle namespace ve class adresi verip de çalıştırabiliriz(pattern)
        public Product Add(Product product)
        {
            // ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Add(product);
        }
        [CacheAspect(typeof(MemoryCacheManager),120)]//time default değeri 60 ama istersek buraya ekleyede biliriz
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetByID(int productID)
        {
            return _productDal.Get(p => p.ProductId == productID);
        }
           

      //  [TransactionScopeAspect]
      
        public void TransactionalOperation(Product product1, Product product2)
        {
            using (var scope = new System.Transactions.TransactionScope())
            {

            }

            _productDal.Add(product1);
            //businessCode
            _productDal.Update(product2);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Update(product);
        }
    }
}
