namespace PrjFresh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    [Table("tblProducts")]
    public class tblProductPrImg
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
        public int Price_ID { get; set; }

        public int ProductID { get; set; }

        public decimal Price { get; set; }

        public decimal? PriceSale { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateIssued { get; set; }

        public int? IsDate { get; set; }
        public int Image_ID { get; set; }

        public int Image_ProductID { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        public int? Image_Status { get; set; }

        public int? OderNumber { get; set; }
    }
}