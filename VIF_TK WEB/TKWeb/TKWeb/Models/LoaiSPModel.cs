using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace TKWeb.Models
{
    public class LoaiSPModel
    {
        DataContext dc = new DataContext();
        public List<LoaiSP> getAllLSP()
        {
            DataTable dt = dc.readData("select * from LoaiSP");
            List<LoaiSP> li = new List<LoaiSP>();
            foreach (DataRow dr in dt.Rows)
            {
                LoaiSP lsp = new LoaiSP();
                lsp.MaLoai = dr[0].ToString();
                lsp.TenLoai = dr[1].ToString();
                li.Add(lsp);
            }
            return li;
        }
    }
}