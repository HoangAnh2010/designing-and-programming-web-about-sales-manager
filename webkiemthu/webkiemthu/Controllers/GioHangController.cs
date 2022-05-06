using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webkiemthu.Models;
namespace webkiemthu.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        SanPhamModel dbsp = new SanPhamModel();
        public ActionResult Index()
        {
            return View();
        }
        //pt hành động thực hiện thao tác đưa sản phẩm vào trong giỏ hàng
        public JsonResult MuaHang(string id)
        {
            //khi giỏ hàng chưa có sản phẩm nào
            //kbao một danh sách giỏ hàng
            List<GioHang> gh = null;
           
            int tongtien = 0;
            int soluong = 0;
            if (Session["giohang"] == null) //chưa có sản phẩm
            {
                //thêm mới sản phẩm vào
                GioHang a = new GioHang();
                var sp = dbsp.get1SP(id);
                //đưa thông tin sản phẩm vào giỏ hàng
                a.ID = sp.MaSP;
                a.Ten = sp.TenSP;
                a.Anh = sp.Anh;
                a.SL = 1;//mặc định mỗi lần mua 1 SP
                a.Gia = sp.DonGia;
                gh = new List<GioHang>();
                gh.Add(a);//thêm sản phẩm a vào giỏ hàng
                Session["giohang"] = gh;
            }
            //khi giỏ hàng có sản phẩm rồi: sản phẩm đã có --> tăng số lượng, nếu sp chưa có --> thêm
            else
            {
                //đưa dữ liệu có sẵn trong biến session vào giỏ hàng
                gh = Session["giohang"] as List<GioHang>;
                //kiểm tra sản phẩm có trùng nhau không
                var test = gh.Find(s => s.ID == id);
                if (test == null)//không trùng nhau -->thêm mới
                {
                    GioHang a = new GioHang();
                    var sp = dbsp.get1SP(id);
                    a.ID = sp.MaSP;
                    a.Ten = sp.TenSP;
                    a.Anh = sp.Anh;
                    a.SL = 1;
                    a.Gia = sp.DonGia;
                    gh.Add(a);
                }
                else
                {
                    //trùng nhau -->tăng số lượng
                    test.SL = test.SL + 1;
                }
                //lưu lại biến session
                Session["giohang"] = gh;
            }   
                //tính tổng tiền và số lượng các sản phẩm có trong giỏ hàng
                //duyệt lần lượt từng sản phẩm trong giỏ hàng
                foreach(GioHang x in gh)
                {
                    tongtien += (x.SL * x.Gia);
                }
            //số lượng
            soluong = gh.Sum(s => s.SL);
              
            return Json(new { giohang = gh, tongtien = tongtien, soluong = soluong }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult loadgiohang()
        {
            List<GioHang> gh = null;
            int tongtien = 0;
            int soluong = 0;
            if(Session["giohang"]!=null)
            {
                gh = Session["giohang"] as List<GioHang>;
            }
            if (gh != null)
            {
                foreach(GioHang x in gh)
                {
                    tongtien += x.SL * x.Gia;
                }
                soluong = gh.Sum(s=>s.SL);
            }
            return Json(new { giohang = gh, tongtien = tongtien, soluong = soluong }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult tang1sp(string id)
        {
            List<GioHang> gh = Session["giohang"] as List<GioHang>;
            var sp = dbsp.get1SP(id);
            var test = gh.Find(s => s.ID.ToString().Trim() == id.Trim());
            if (test.SL<sp.SoLuong)
            {
                test.SL = test.SL + 1;
            }
            Session["giohang"] = gh;
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult giam1sp(string id)
        {
            List<GioHang> gh = null;
            gh = Session["giohang"] as List<GioHang>;
            var test = gh.Find(s => s.ID == id);
            if (test.SL>1)
            {
                test.SL = test.SL - 1;
            }
            else
            {
                gh.Remove(test);//xóa sản phẩm ra khỏi giỏ hàng khi số lượng sản phẩm <1
            }
            Session["giohang"] = gh;
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult xoa1sp(string id)
        {
            List<GioHang> gh = Session["giohang"] as List<GioHang>;
            var test = gh.Find(s => s.ID == id);
            if (test != null)
                gh.Remove(test);
            Session["giohang"] = gh;
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        //action hiển thị trang giỏ hàng
        public ViewResult ShoppingCart()
        {
            int tongtien = 0;
            int soluong = 0;
            List<GioHang> gh = null;
            if(Session["giohang"]!=null)
            {
                gh = Session["giohang"] as List<GioHang>;
                foreach(GioHang a in gh)
                {
                    tongtien += a.SL * a.Gia;
                }
                soluong = gh.Sum(s => s.SL);
            }
            ViewBag.totalprice = tongtien;
            ViewBag.count = soluong;
            return View(gh);
        }
    }
}