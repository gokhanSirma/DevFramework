using DevFramework.Northwind.DataAccess.Abstracts;
using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.ConCrete;
using DevFramwork.Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.ConCrete.EntityFramework
{
    public class EfProductDal : EfRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetail> GetProductDetails()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.categories on p.CategoryId equals c.CategoryId
                             select new ProductDetail
                             {
                                 CategoryName = c.CategoryAdi,
                                 ProductName = p.urunAd,
                                 ProudctID = p.ProductId
                             };
                return result.ToList();
            }
            
        }
    }
}
