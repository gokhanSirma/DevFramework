using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ConCrete.Manager;
using DevFramework.Northwind.DataAccess.Abstracts;
using DevFramework.Northwind.DataAccess.ConCrete.EntityFramework;
using DevFramwork.Core.DataAccess;
using DevFramwork.Core.DataAccess.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();//singleton performans arttırımı sağlar
            Bind<IProductDal>().To<EfProductDal>();
            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
        }
    }
}
