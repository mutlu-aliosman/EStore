using System;
using System.Collections.Generic;
using System.Text;

namespace EStore.Business.Abstract
{
  public  interface IVali<T>
    {
        string ErorMesaage { get; set; }
        bool Validate(T entity);
    }
}
