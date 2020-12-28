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
    public class EfCoreCategoryDal : EfCoreGenericRepository<Category, EStoreContex>, ICategoryDal
    {
        public void DeleteFromCategory(int cateId, int productId)
        {
           using (var db=new EStoreContex())
            {
                var komut = @"delete from ProductCategory where ProductID=@p0 And CategoryID=@p1";
                db.Database.ExecuteSqlCommand(komut, cateId, productId);
            }
        }

        public Category GetByWithProducts(int id)
        {
           using(var db=new EStoreContex())
            {
                    return db.Categories
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault();
            }
        }
    }
}
