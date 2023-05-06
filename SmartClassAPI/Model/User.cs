using SmartClassAPI.Data;

namespace SmartClassAPI.Model
{
    public class UserVM : UserModel
    {
        public int IdUser { get; set; }
        public LopHoc LopHoc { get; set; }
        public LoaiUserData LoaiUserData { get; set; }
        //public User User { get; set; }
        public string TenHocSinh { get; set; }
        public string MaLopHoc { get; set; }
        public string MatKhau { get; set; }
        public string TenLoai { get; set; }
    }
    public class UserModel  
    {
        public string HoTen { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public int? IdLoai { get; set; }        
        public int? IdHocSinh { get; set; }
        public int? IdLopHoc { get; set; }

    }
}
