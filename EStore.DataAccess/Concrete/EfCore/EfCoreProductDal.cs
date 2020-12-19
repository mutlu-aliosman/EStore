using EStore.DataAccess.Abstract;
using EStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EStore.DataAccess.Concrete.EfCore
{
    public class EfCoreProductDal : EfCoreGenericRepository<Product, EStoreContex>, IProductDal
    {
        public IEnumerable<Product> GetPopulerProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductDetails(int id)
        {
            using (var context = new EStoreContex())
            {
                return context.Products
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string category, int page,int pageSize)
        {
           using(var context=new EStoreContex())
            {
                var products = context.Products.AsQueryable();
                if(!string.IsNullOrEmpty(category))
                {
                    products = products
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(x=>x.Category.Name.ToLower()==category.ToLower()));
                }
                return products.Skip((page-1)*pageSize).Take(pageSize).ToList();
            }
        }
    }
}