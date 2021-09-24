using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Book_Store.Models
{
    public class Store
    {
        [DisplayName("Id")]

        public int Store_Id { get; set; }

        [DisplayName("Location Name")]
        public string Location_Id { get; set; }

        [DisplayName("Store Name")]
        public string Store_Name { get; set; }
    }
}