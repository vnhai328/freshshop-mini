namespace PrjFresh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProduct")]
    public partial class tblProduct
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? ProductType { get; set; }

        [StringLength(50)]
        public string Manufacture { get; set; }

        [StringLength(50)]
        public string MadeIn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public int? Status { get; set; }

        [Column(TypeName = "text")]
        public string Review { get; set; }
    }
}
