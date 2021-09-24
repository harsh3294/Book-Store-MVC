namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Key]
        public int Order_Id { get; set; }

        public int OrderDetails_Id { get; set; }

        public int User_Id { get; set; }

        public int Total_Price { get; set; }

        public virtual Order_Details Order_Details { get; set; }

        public virtual User User { get; set; }
    }
}
