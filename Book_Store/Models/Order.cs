using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Book_Store.Models
{
    public class Order
    {
        [DisplayName("Id")]

        public int OrderId { get; set; }

        [DisplayName("Order Detail")]

        public int OrderDetailsid { get; set; }
        [DisplayName("Book Id")]

        public int bookid { get; set; }
        [DisplayName("Image")]

        public string ImageUrl { get; set; }
        [DisplayName("Book Name")]

        public string BookName { get; set; }
        [DisplayName("Store Name")]

        public int Quantity { get; set; }
        [DisplayName("Price")]

        public int price { get; set; }
        [DisplayName("Total Price")]

        public int totalPrice { get; set; }
    }
}