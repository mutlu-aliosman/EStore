using EStore.DataAccess.Abstract;
using EStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStore.DataAccess.Concrete.EfCore
{
   public class EfCoreOrderDal:EfCoreGenericRepository<Order,EStoreContex>,IOrderDal
    {

    }
}
