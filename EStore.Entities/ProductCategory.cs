using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EStore.Entities
{
   public class ProductCategory
    {
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
