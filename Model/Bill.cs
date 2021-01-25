namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        public long ID { get; set; }

        public long? UserID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public DateTime? CreatedDate { get; set; }

        public double? Discount { get; set; }

        [StringLength(250)]
        public string Payment { get; set; }

        [StringLength(250)]
        public string Detail { get; set; }

        public bool? Status { get; set; }
    }
}
