using DevFramwork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Entities.ConCrete
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryAdi { get; set; }
    }
}
