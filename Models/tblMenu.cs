namespace PrjFresh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMenu")]
    public partial class tblMenu
    {
        public int ID { get; set; }

        public int? Parent_ID { get; set; }

        public int? TypeMenu { get; set; }

        [StringLength(50)]
        public string UserControl { get; set; }

        [Required]
        [StringLength(50)]
        public string MenuName { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(500)]
        public string Url { get; set; }

        public int? Page { get; set; }

        public int? OrderNumber { get; set; }

        [StringLength(500)]
        public string MetaTilte { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
    }
}
