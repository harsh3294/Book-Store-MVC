using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Entities;
using Data.Repository;

namespace Book_Store.Controllers
{
    public class CategoryController : Controller
    {
        Data.Repository.Category category;
        public CategoryController()
        {
            category = new Data.Repository.Category(new BookStoreModel());
        }
        public ActionResult Index()
        {
            var categories = category.GetCategories();
            var data = new List<Book_Store.Models.Category>();
            foreach (var c in categories)
            {
                data.Add(Book_Store.Mapper.CategoryMapper.Map(c));
            }
            return View(data);
        }
        public ActionResult GetCategoryById(int id)
        {

            var findCategory = category.GetCategoryById(id);
            return View(Book_Store.Mapper.CategoryMapper.Map(findCategory));
        }
        public string UpdateCategoryById(int id, Data.Entities.Category categoryData)
        {
            category.UpdateCategoryById(id, categoryData);
            return "Category updated successfully";
        }
        public string DeleteCategoryById(int id)
        {
            category.DeleteCategoryById(id);
            return "Category is successfully deleted";
        }
    }
}