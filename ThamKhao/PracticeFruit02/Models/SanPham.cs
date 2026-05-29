namespace PracticeFruit02.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Mã Sản Phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập mã sản phẩm")]
        public int MaSP { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên Sản Phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string TenSP { get; set; }

        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Vui lòng nhập số lượng")]

        public int? SoLuong { get; set; }

        [Display(Name = "Đơn giá")]
        [Required(ErrorMessage = "Vui lòng nhập đơn giá")]

        public decimal? DonGia { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }


        [Display(Name = "Mã Hãng")]
        [Required(ErrorMessage = "Vui lòng nhập mã hãng")]

        public int? MaHang { get; set; }

        public virtual HangSanXuat HangSanXuat { get; set; }
    }
}
