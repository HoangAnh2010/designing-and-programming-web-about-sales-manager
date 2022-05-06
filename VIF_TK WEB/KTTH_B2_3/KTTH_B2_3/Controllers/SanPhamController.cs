using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KTTH_B2_3.Models;

namespace KTTH_B2_3.Controllers
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
            //lay ve danh muc loai san pham
            var lsp = dblsp.getAllLSP();
            ViewBag.loaisp = lsp;

            //hien thi chi tiet sp
            SanPham sp = dbsp.get1SP(id);

            //lay ve cac sp cung loai sp
            var ds = dbsp.getSPByLSP(sp.MaLoai).Where(s => s.MaSP != id).ToList();
            ViewBag.sptt = ds;

            return View(sp);
        }
        public ViewResult ProCategory(string id)
        {
            //lay ve danh muc loai sp
            var lsp = dblsp.getAllLSP();
            ViewBag.loaisp = lsp;

            //truy van ten loai sp dua vao id: lay ra lsp co cung id -->ten lsp
            var ten = lsp.FirstOrDefault(s => s.MaLoai.ToString() == id).TenLoai;
            ViewBag.tenloai = ten;

            var ds = dbsp.getSPByLSP(id);
            return View(ds);
        }
    }
}