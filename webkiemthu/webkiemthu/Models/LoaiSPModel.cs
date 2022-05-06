using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using webkiemthu.Models;
namespace webkiemthu.Models
{
    public class LoaiSPModel
    {
        DataContext dc = new DataContext();
        public List<LoaiSP> getAllLSP()
        {
            DataTable dt = dc.readData("Select * from LoaiSP");
            List<LoaiSP> li = new List<LoaiSP>();
            foreach (DataRow dr in dt.Rows)
            {
                LoaiSP sp = new LoaiSP();
                sp.MaLoai= dr[0].ToString();
                sp.TenLoai = dr[1].ToString();
                ///sp.GhiChu = dr[2].ToString();
               
                li.Add(sp);
            }
            return li;
        }
    }
}