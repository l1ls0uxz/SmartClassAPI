using SmartClassAPI.Data;

namespace SmartClassAPI.Model
{
    public class TaiLieuModel
    {
        public string TenTaiLieu { get; set; }
        public string UrlTaiLieu { get; set; }
        public int? IdMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int? IdUser { get; set; }
        public string HoTen { get; set; }
    }
    public class TaiLieuVM : TaiLieuModel
    {
        public int IdTaiLieu { get; set; }
        public User User { get; set; }
    }
}
