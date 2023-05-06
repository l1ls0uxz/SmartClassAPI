using SmartClassAPI.Data;

namespace SmartClassAPI.Model
{
    public class NhanDienMD
    {
        public int IdNhanDien { get; set; }
        public int IdBuoiHoc { get; set; }
        public QuanLyBuoiHoc QuanLyBuoiHoc { get; set; }
        public int? IdUser { get; set; }
        public User User { get; set; }
        public string HoTen { get; set; }
        public int Connect { get; set; }
        public string NhanDien { get; set; }
        public int IdCanhBao { get; set; }
        public CanhBao CanhBao { get; set; }
        public string TenCanhBao { get; set; }
    }
}
