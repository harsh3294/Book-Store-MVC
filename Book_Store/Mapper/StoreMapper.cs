using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.Mapper
{
    public class StoreMapper
    {
        public static Book_Store.Models.Store Map(Data.Entities.Store store)
        {
            return new Book_Store.Models.Store()
            {
                Store_Id = store.Store_Id,
                Location_Id = store.Location.Location_Name,
                Store_Name = store.Store_Name
            };
        }
        public static Data.Entities.Store Map(Book_Store.Models.StoreViewModel store)
        {
            return new Data.Entities.Store()
            {
                Store_Id = store.Store_Id,
                Location_Id = store.Location_Id,
                Store_Name = store.Store_Name
            };
        }
        public static Book_Store.Models.StoreViewModel MapViewModel(Data.Entities.Store store)
        {
            return new Book_Store.Models.StoreViewModel()
            {
                Store_Id = store.Store_Id,
                Location_Id = store.Location_Id,
                Store_Name = store.Store_Name
            };
        }
    }
}