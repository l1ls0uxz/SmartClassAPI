using SmartClassAPI.Data;
using System;

namespace SmartClassAPI.Model
{
    public class QuanLyBuoiHocMD
    {
        public int IdBuoiHoc { get; set; }
        public int IdMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public MonHoc MonHoc { get; set; }
        public int IdLopHoc { get; set; }
        public string MaLopHoc { get; set; }
        public LopHoc LopHoc { get; set; }
        public int IdPhongHoc { get; set; }
        public PhongHocData PhongHocData { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public string HoTen { get; set; }
        public string TenPhongHoc { get; set; }
        public DateTime NgayHoc { get; set; }
        public string Buoi { get; set; }
        public int IdTinhTrang { get; set; }
        public TinhTrangBuoiHoc TinhTrang { get; set; }
        public string TenTinhTrang { get; set; }
    }
}
