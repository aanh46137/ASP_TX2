namespace LuyenTapTX2_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        [Required(ErrorMessage = "Không được bỏ trống")]
        [Display(Name = "Mã Sản Phẩm")]
        public int Pid { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống")]
        [Display(Name = "Mã Danh mục")]
        public int Categoryid { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống")]
        [Display(Name = "Tên sản phẩm")]
        [StringLength(250)]
        public string ProdName { get; set; }

        [StringLength(50)]
        [Display(Name = "Tiêu đề")]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [StringLength(550)]
        [Required(ErrorMessage = "Không được bỏ trống")]
        [Display(Name = "Hình Ảnh")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống")]
        [Display(Name = "Giá Sản Phẩm")]
        public decimal Price { get; set; }
    }
}
