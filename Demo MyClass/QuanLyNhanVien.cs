using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MyClass
{
        public class NhanVien
        {
            public string MSNV { get; set; } // Mã số nhân viên
            public string TenNV { get; set; } // Tên nhân viên
            public decimal LuongCB { get; set; } // Lương cơ bản

            public NhanVien(string msnv, string tenNV, decimal luongCB)
            {
                MSNV = msnv;
                TenNV = tenNV;
                LuongCB = luongCB;
            }

            public override string ToString()
            {
                return $"{MSNV} - {TenNV} - {LuongCB:C}";
            }
        }
    }
