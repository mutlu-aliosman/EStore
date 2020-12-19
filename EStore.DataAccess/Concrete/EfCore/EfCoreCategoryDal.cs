using EStore.DataAccess.Abstract;
using EStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EStore.DataAccess.Concrete.EfCore
{
    public class EfCoreCategoryDal : EfCoreGenericRepository<Category,EStoreContex>,ICategoryDal
    {
        
    }
}
