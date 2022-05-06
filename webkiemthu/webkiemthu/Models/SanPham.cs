using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webkiemthu.Models
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string MoTa { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public string MaLoai { get; set; }
        public string Anh { get; set; }
    }
}