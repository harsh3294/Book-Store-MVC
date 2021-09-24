using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Book_Store.Models
{
    public class Category
    {
        [DisplayName("Id")]

        public int Category_Id { get; set; }
        [DisplayName("Category Name")]

        public string Category_Name { get; set; }
    }
}