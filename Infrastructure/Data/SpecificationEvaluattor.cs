using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluattor<TEntitiy> where TEntitiy : BaseEntity
    {
        public static IQueryable<TEntitiy> GetQuery(IQueryable<TEntitiy> inputQuery, ISpecification<TEntitiy> spec)
        {
            var query = inputQuery;
            Console.WriteLine("+++++++++++++++++++++++++"+spec.Criteria);


            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); // p => p.ProductTypeId == id
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            query = spec.Includes.Aggregate(query, (current, incude) =>
            {
                Console.WriteLine(current + "----------------------------");
                Console.WriteLine(incude + "----------------------------");
                return current.Include(incude);
            });

            return query;
        }
    }
}