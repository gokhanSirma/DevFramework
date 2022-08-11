using DevFramework.Northwind.Entities.ConCrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.ConCrete.EntityFramework.Mapping
{
    public class ProductMap:EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Products", "dbo");//şema adı dbo
            HasKey(x => x.ProductId);
            Property(x => x.ProductId).HasColumnName("ProductID");
            Property(x => x.CategoryId).HasColumnName("CategoryID");
            Property(x => x.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            Property(x => x.urunAd).HasColumnName("ProductName");
            Property(x => x.urunFiyat).HasColumnName("UnitPrice");


        }
    }
}
