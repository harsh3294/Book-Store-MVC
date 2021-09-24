namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderHistory")]
    public partial class OrderHistory
    {
        public int id { get; set; }

        public int userid { get; set; }

        public int Book_Id { get; set; }

        public int Quantity { get; set; }

        public int Total_Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public virtual Book Book { get; set; }
    }
}
