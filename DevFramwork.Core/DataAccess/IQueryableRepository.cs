using DevFramwork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramwork.Core.DataAccess
{
    public interface IQueryableRepository<T> where T:class,IEntity,new()
    {
       IQueryable<T> Table { get; }
    }
}
