using EStore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.WebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Ürün ismi giriniz")]
        [StringLength(50,MinimumLength =10,ErrorMessage ="Ürün ismi en az 10 karakter en fazla 50 karakter olmalıdır !")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Ürün resmi belirtiniz")]
        public string ImageUrl { get; set; }

        [Range(1,1000)]
        [Required(ErrorMessage ="1-1000 Arası fiyat giriniz")]
        public decimal? Price { get; set; }


        [Required(ErrorMessage = "Ürün açıklaması en az 20 karakter en fazla 120 karakter olmalıdır!")]
        [StringLength(120, MinimumLength = 20, ErrorMessage = "Ürün açıklaması en az 20 karakter en fazla 120 karakter olmalıdır !")]
        public string Description { get; set; }



        public List<Category>SelectCategorys { get; set; }
    }
}
