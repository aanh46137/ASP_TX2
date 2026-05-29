namespace LuyenTapTX2_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Mã sản phẩm")]
        public int MaSP { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Tên sản phẩm")]
        public string TenSP { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Số lượng sản phẩm")]
        public int? SoLuong { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Đơn giá sản phẩm")]
        public decimal? DonGia { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        public int? MaHang { get; set; }

        public virtual HangSanXuat HangSanXuat { get; set; }
    }
}
