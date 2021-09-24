using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Book_Store.Models
{
    public class StoreViewModel
    {
        [DisplayName("Id")]

        public int Store_Id { get; set; }

        [DisplayName("Location Name")]
        public int Location_Id { get; set; }

        [DisplayName("Store Name")]
        public string Store_Name { get; set; }
    }
}