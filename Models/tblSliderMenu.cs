namespace PrjFresh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSliderMenu")]
    public partial class tblSliderMenu
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string ImgUrl { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int? Status { get; set; }

        [StringLength(500)]
        public string Description1 { get; set; }
    }
}
