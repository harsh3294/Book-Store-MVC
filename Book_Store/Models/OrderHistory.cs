using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Book_Store.Models
{
    public class OrderHistory
    {
        public int id { get; set; }

        [DisplayName("User Id")]
        public int userid { get; set; }

        [DisplayName("Book Name")]
        public string Book_Id { get; set; }

        public int Quantity { get; set; }
        [DisplayName("Total Price")]

        public int Total_Price { get; set; }
        [DisplayName("Order Date")]

        public DateTime date { get; set; }

    }
}