using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PrjFresh.Models
{
    public partial class FreshDBContex : DbContext
    {
        public FreshDBContex()
            : base("name=FreshDBContex2")
        {
        }

        public virtual DbSet<tblHeader> tblHeaders { get; set; }
        public virtual DbSet<tblMenu> tblMenus { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblProductImage> tblProductImages { get; set; }
        public virtual DbSet<tblProductPrice> tblProductPrices { get; set; }
        public virtual DbSet<tblSliderMenu> tblSliderMenus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblProduct>()
                .Property(e => e.Review)
                .IsUnicode(false);

            modelBuilder.Entity<tblProductPrice>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblProductPrice>()
                .Property(e => e.PriceSale)
                .HasPrecision(18, 0);
        }

        public System.Data.Entity.DbSet<PrjFresh.Models.tblProductPrImg> tblProductPrImgs { get; set; }
    }
}
