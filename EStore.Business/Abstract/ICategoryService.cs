using EStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStore.Business.Abstract
{
   public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        Category GetByWithProducts(int id);
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        void DeleteFromCategory(int cateId, int productId);
    }
}
