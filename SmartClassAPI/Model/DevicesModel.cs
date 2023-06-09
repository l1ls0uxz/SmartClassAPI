using SmartClassAPI.Data;

namespace SmartClassAPI.Model
{
    public class DevicesModel
    {
        public string DeviceName { get; set; }
        public DeviceTpye DeviceTpye { get; set; }
        public string MieuTaCongDung { get; set; }
        public int? IdPhongHoc { get; set; }
        public int? IdUser { get; set; }
        //public int IdDevice { get; set; }
    }
    public class DevicesVM : DevicesModel
    {
        public int IdDevice { get; set; }
        public string TenPhongHoc { get; set; }
        public string HoTen { get; set; }
        //public LoaiUser LoaiUser { get; set; }
        public PhongHocData PhongHocData { get; set; }
        public User User { get; set; }
    }
}
