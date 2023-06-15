using SmartClassAPI.Data;
using System;

namespace SmartClassAPI.Model
{
    public class MonHocModel
    {
        public string TenMonHoc { get; set; }
        public DateTime NgayBatDau { get; set; }
        public int SoTiet { get; set; }
        public int? IdLopHoc { get; set; }
        public int? IdUser { get; set; }
        public int? IdPhongHoc { get; set; }
        public string TenPhongHoc { get; set; }
        public int? IdTinhTrang { get; set; }
    }
    public class MonHocVM : MonHocModel
    {
        public int IdMonHoc { get; set; }
        public string MaLopHoc { get; set; }
        public string HoTen { get; set; }

        public string TenTinhTrang { get; set; }
        public User User { get; set; }
        public LopHoc LopHoc { get; set; }
        public PhongHocData PhongHocData { get; set; }
        public TTMonDT TinhTrangMH { get; set; }
    }

}
