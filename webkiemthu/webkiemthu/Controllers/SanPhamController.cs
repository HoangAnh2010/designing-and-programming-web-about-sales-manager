using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webkiemthu.Models;
namespace webkiemthu.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        SanPhamModel dbsp = new SanPhamModel();
        LoaiSPModel dblsp = new LoaiSPModel();
        public ActionResult Index()
        {
            List<SanPham> li = dbsp.getAllSP();
            return View(li);
        }
        public ViewResult ProDetail(string id)
        {
            //lấy về danh mục các loại sản phẩm 
            var lsp = dblsp.getAllLSP();
            ViewBag.loaisp = lsp;

            //hiển thị chi tiết sản phẩm
            SanPham sp = dbsp.get1SP(id);

            //lấy về các sptt
            //có sp -->mã loại của sp là sp.MaLoai (1)
            //lấy về các sp theo mã loại (1), trừ đi sản phẩm có mã sp là id
            var ds = dbsp.getSPByLSP(sp.MaLoai).Where(s => s.MaSP != id).ToList();
            ViewBag.sptt = ds;
            return View(sp);
        }
        public ViewResult ProCatagory(string id)
        {
            //lấy về danh mục loại sản phẩm
            var lsp = dblsp.getAllLSP();
            ViewBag.loaisp = lsp;

            //truy vấn lấy ra tên loại sản phẩm, dựa vào id, lấy ra loại sản phẩm có cùng id -->tên loại
            var ten = lsp.FirstOrDefault(s => s.MaLoai.ToString() == id).TenLoai;
            ViewBag.tenloai = ten;

            var ds = dbsp.getSPByLSP(id);
            return View(ds);
        }
    }
}