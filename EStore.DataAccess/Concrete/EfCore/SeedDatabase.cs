using EStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EStore.DataAccess.Concrete.EfCore
{
  public static  class SeedDatabase
    {
        public static void Seed()
        {
            var db = new EStoreContex();
            if(db.Database.GetPendingMigrations().Count()==0)
            {
                if(db.Categories.Count()==0)
                {
                    db.Categories.AddRange(categories);
                }
                if(db.Products.Count()==0)
                {
                    db.Products.AddRange(Products);
                    db.AddRange(ProductCategories);
                }
                db.SaveChanges();
            }
        }
        private static Category[] categories =
        {
            new Category(){ Name="Erkek Giyim"},
            new Category(){ Name="Kadın Giyim"}
        };
        private static Product[] Products =
       {
            new Product(){ Name="Pantalon", ImageUrl="1.jpg", Price=100, Description="deneme" },
            new Product(){ Name="Gömlek", ImageUrl="2.jpg", Price=200 , Description="deneme"},
            new Product(){ Name="Ceket", ImageUrl="3.jpg", Price=300 , Description="deneme"},
            new Product(){ Name="T-Shirt", ImageUrl="4.jpg", Price=50 , Description="deneme"}
       };
        private static ProductCategory[] ProductCategories =
        {
            new ProductCategory(){Product=Products[0],Category=categories[0]},
            new ProductCategory(){Product=Products[1],Category=categories[0]},
            new ProductCategory(){Product=Products[2],Category=categories[1]},
            new ProductCategory(){Product=Products[3],Category=categories[1]}
        };
    }
}
