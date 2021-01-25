namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string DetailImage { get; set; }

        public decimal? Price { get; set; }

        public decimal? SalePrice { get; set; }

        public int? Quantity { get; set; }

        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        public string ProductDetail { get; set; }

        public DateTime? SaleDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeyword { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        public long? Views { get; set; }

        public bool? Status { get; set; }
    }
}
