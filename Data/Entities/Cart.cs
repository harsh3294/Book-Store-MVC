namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        [Key]
        public int Cart_Id { get; set; }

        public int Book_Id { get; set; }

        public int Quantity { get; set; }

        public int User_Id { get; set; }

        public virtual Book Book { get; set; }

        public virtual User User { get; set; }
    }
}
