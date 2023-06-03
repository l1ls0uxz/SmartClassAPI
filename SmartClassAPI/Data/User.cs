using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassAPI.Data
{
    [Table("User")]
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [Required, MaxLength(200)]
        [Column(TypeName = "Nvarchar")]
        public string HoTen { get; set; }

        [Required, Column(TypeName = "varchar"), MaxLength(50)]
        public string UserName { get; set; }
        public string MatKhau { get; set; }
        public int? IdLoai { get; set; }
        [ForeignKey("IdLoai")]
        public LoaiUserData LoaiUserData { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public int? IdHocSinh { get; set; }
        public int? IdLopHoc { get; set; }
        [ForeignKey("IdLopHoc")]
        public LopHoc LopHoc { get; set; }
        //public ICollection<User> Users { get; set; }
    }

}
