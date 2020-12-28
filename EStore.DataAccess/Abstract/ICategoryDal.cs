using EStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EStore.DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        Category GetByWithProducts(int id);
        void DeleteFromCategory(int cateId, int productId);
    }
}
