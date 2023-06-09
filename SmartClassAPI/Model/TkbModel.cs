using SmartClassAPI.Data;
using System;

namespace SmartClassAPI.Model
{
    public class TkbModel
    {
        public int IdLopHoc { get; set; }
        public int IdMonHoc { get; set; }
        public int IdPhongHoc { get; set; }
        public int? IdUser { get; set; }
        public string HoTen { get; set; }
        public string TenMonHoc { get; set; }
        public string MaLopHoc { get; set; }
        public string TenPhongHoc { get; set; }
        public string Thu { get; set; }
        public SangChieu SangChieu { get; set; }
        public int? TinhTrang { get; set; }
        public DateTime NgayThan { get; set; }
    }
    public class TkbVM : TkbModel
    {
        public User User { get; set; }
        // relationship
        public PhongHocData PhongHocData { get; set; }
        public MonHoc MonHoc { get; set; }
        public LopHoc LopHoc { get; set; }
    }
}
