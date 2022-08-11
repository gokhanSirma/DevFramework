using DevFramework.Northwind.Entities.ConCrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.urunAd).NotEmpty().WithMessage("Ürün adını doldurunuz.");
            RuleFor(p => p.urunFiyat).GreaterThan(0);
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.urunAd).Length(2, 20);
            RuleFor(p => p.urunFiyat).GreaterThan(20).When(p => p.CategoryId == 2);
            //RuleFor(p => p.urunAd).Must(AylaBasla);
        }
        private bool AylaBasla(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
