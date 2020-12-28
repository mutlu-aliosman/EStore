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
        public Product GetByIdWithCategorys(int id)
        {
            using (var db =new EStoreContex())
            {
                return db.Products
                      .Where(i => i.Id == id)
                      .Include(i => i.ProductCategories)
                      .ThenInclude(i => i.Category)
                      .FirstOrDefault();
            }
        }

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

        public void Update(Product entity, int[] categoryId)
        {
            using (var context = new EStoreContex())
            {
                var product = context.Products
                                   .Include(i => i.ProductCategories)
                                   .FirstOrDefault(i => i.Id == entity.Id);

                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Description = entity.Description;
                    product.ImageUrl = entity.ImageUrl;
                    product.Price = entity.Price;

                    product.ProductCategories = categoryId.Select(catid => new ProductCategory()
                    {
                        CategoryID = catid,
                        ProductID = entity.Id
                    }).ToList();
                    context.SaveChanges();
                }
            }

        }
    }
}