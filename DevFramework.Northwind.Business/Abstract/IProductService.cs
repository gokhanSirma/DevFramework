using DevFramework.Northwind.Entities.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetByID(int productID);
        Product Add(Product product);
        Product Update(Product product);
        void TransactionalOperation(Product product1,Product product2);

    }
}
