namespace DoDucAnh_614.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [DisplayName("Mã rượu")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Tên rượu không được để trống")]
        [StringLength(50)]
        [DisplayName("Tên Rượu")]
        public string ProductName { get; set; }

        [Column(TypeName = "text")]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Giá nhập không được để trống!")]
        [Column(TypeName = "numeric")]
        [DisplayName("Giá nhập ")]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "Giá bán không được để trống!")]
        [Column(TypeName = "numeric")]
        [DisplayName("Giá bán")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống!")]
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }

        [StringLength(20)]
        [DisplayName("Năm sản xuất")]
        public string Vintage { get; set; }

        [Required(ErrorMessage = "Danh mục không được để trống!")]
        [StringLength(10)]
        public string CatalogyID { get; set; }

        [Column(TypeName = "text")]
        [DisplayName("Hình ảnh")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Vùng không được để trống!")]
        [StringLength(100)]
        [DisplayName("Vùng")]
        public string Region { get; set; }

        public virtual Catalogy Catalogy { get; set; }
    }
}
