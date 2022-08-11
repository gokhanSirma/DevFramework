using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.ConCrete;
using DevFramwork.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Abstracts
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetails();
    }
}
