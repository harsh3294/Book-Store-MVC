using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class Category : ICategory
    {
        private BookStoreModel db;
        public Category(BookStoreModel db)
        {
            this.db = db;
        }
        public IEnumerable<Data.Entities.Category> GetCategories()
        {
            return db.Categories
                .ToList();
        }
        public Data.Entities.Category GetCategoryById(int id)
        {
            if (id > 0)
            {
                var category = db.Categories
                    .Where(c => c.Category_Id == id)
                    .FirstOrDefault();
                if (category != null)
                    return category;
                else
                {
                    return null;
                }
            }
            else
            {
                throw new ArgumentException("Id cannot be less than 0");
            }
        }
        public void AddCategory(Data.Entities.Category category)
        {
            db.Categories.Add(category);
            save();
        }
        public void UpdateCategoryById(int id, Data.Entities.Category category)
        {
            var getCategory = db.Categories.Where<Data.Entities.Category>(u => u.Category_Id == id).First();
            if (getCategory != null)
            {
                getCategory.Category_Name = category.Category_Name;
                save();
                return;
            }
            else
            {
                throw new ArgumentException($"No Category Found With the id : {id}");
            }
            throw new ArgumentException("Id cannot be less than 0");
        }
        public void DeleteCategoryById(int id)
        {
            var category = db.Categories.Where<Data.Entities.Category>(u => u.Category_Id == id).First();
            if (category != null)
            {
                db.Categories.Remove(category);
                save();
                return;
            }
            else
            {
                throw new ArgumentException($"No Category Found With the id : {id}");
            }
            throw new ArgumentException("Id cannot be less than 0");
        }
        public void save()
        {
            db.SaveChanges();
        }
    }
}
