using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TKWeb.Models
{
    public class GioHang
    {
        public string ID { get; set; }
        public string Ten { get; set; }
        public string Anh { get; set; }
        public int SL { get; set; }
        public double Gia { get; set; }
    }
}