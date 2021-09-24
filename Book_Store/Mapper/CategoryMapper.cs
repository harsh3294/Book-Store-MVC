using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.Mapper
{
    public class CategoryMapper
    {
        public static Book_Store.Models.Category Map(Data.Entities.Category category)
        {
            return new Book_Store.Models.Category()
            {
                Category_Id = category.Category_Id,
                Category_Name = category.Category_Name
            };
        }
        public static Data.Entities.Category Map(Book_Store.Models.Category category)
        {
            return new Data.Entities.Category()
            {
                Category_Id = category.Category_Id,
                Category_Name = category.Category_Name
            };
        }
    }
}