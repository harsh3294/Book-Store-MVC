using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    interface ICategory
    {
        IEnumerable<Data.Entities.Category> GetCategories();
        Data.Entities.Category GetCategoryById(int id);
        void AddCategory(Data.Entities.Category category);
        void UpdateCategoryById(int id, Data.Entities.Category category);
        void DeleteCategoryById(int id);
        void save();
    }
}
