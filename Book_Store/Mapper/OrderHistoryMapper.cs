using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.Mapper
{
    public class OrderHistoryMapper
    {
        public static Book_Store.Models.OrderHistory Map(Data.Entities.OrderHistory history)
        {
            return new Book_Store.Models.OrderHistory()
            {
                userid = history.userid,
                Book_Id = history.Book.Book_Detail.Book_Name,
                Quantity = history.Quantity,
                date = history.date,
                Total_Price = history.Total_Price
            };
        }
    }
}