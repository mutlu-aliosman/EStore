using EStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStore.Business.Abstract
{
   public interface IProductService:IVali<Product>
    {
        Product GetById(int id);
        List<Product> GetAll();
        List<Product> GetProductsByCategory(string category,int page,int pageSize);
        bool Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        Product GetProductDetails(int id);
        object GetProductsByCategory(string category);
        Product GetByIdWithCategorys(int id);
        void Update(Product entity, int[] categoryId);
    }
}
