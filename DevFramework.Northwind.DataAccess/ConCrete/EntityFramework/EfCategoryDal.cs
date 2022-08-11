using DevFramework.Northwind.DataAccess.Abstracts;
using DevFramework.Northwind.Entities.ConCrete;
using DevFramwork.Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.ConCrete.EntityFramework
{
    public class EfCategoryDal: EfRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {
    }
}
