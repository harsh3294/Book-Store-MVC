using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.Mapper
{
    public class LocationMapper
    {
        public static Book_Store.Models.Location Map(Data.Entities.Location location)
        {
            return new Book_Store.Models.Location()
            {
                Location_Id = location.Location_Id,
                Location_Name = location.Location_Name
            };
        }
        public static Data.Entities.Location Map(Book_Store.Models.Location location)
        {
            return new Data.Entities.Location()
            {
                Location_Id = location.Location_Id,
                Location_Name = location.Location_Name
            };
        }
    }
}