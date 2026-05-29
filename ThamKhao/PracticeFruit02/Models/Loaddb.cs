using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PracticeFruit02.Models
{
    public partial class Loaddb : DbContext
    {
        public Loaddb()
            : base("name=Loaddb")
        {
        }

        public virtual DbSet<HangSanXuat> HangSanXuats { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanPham>()
                .Property(e => e.DonGia)
                .HasPrecision(10, 2);
        }
    }
}
