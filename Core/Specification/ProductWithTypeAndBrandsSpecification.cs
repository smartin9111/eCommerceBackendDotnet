using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ProductWithTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypeAndBrandsSpecification(string? sort, int? brandId, int? typeId)
         : base(x =>
                (!brandId.HasValue || x.ProductBrandId == brandId) &&
                (!typeId.HasValue || x.ProductTypeId == typeId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);

            switch (sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(n => n.Name);
                    break;
            }
        }

        public ProductWithTypeAndBrandsSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}