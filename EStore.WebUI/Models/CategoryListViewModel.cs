using EStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.WebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category>Categories { get; set; }
        public string SelectedCategory { get; set; }
    }
}
