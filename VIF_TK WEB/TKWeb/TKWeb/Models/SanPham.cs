namespace TKWeb.Models
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
        [StringLength(10)]
        [DisplayName("Mã sản phẩm")]
        public string MaSP { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string TenSP { get; set; }
        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
        [DisplayName("Số lượng")]
        public int? SoLuong { get; set; }
        [DisplayName("Đơn giá")]
        public double? DonGia { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Mã loại")]
        public string MaLoai { get; set; }

        [StringLength(50)]
        [DisplayName("Ảnh")]
        public string Anh { get; set; }
    }
}
