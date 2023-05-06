using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassAPI.Data
{
    [Table("NhanDien")]
    public class NhanDienData
    {
        [Key]
        public int IdNhanDien { get; set; }
        public int IdBuoiHoc { get; set; }
        [ForeignKey("IdBuoiHoc")]
        public QuanLyBuoiHoc QuanLyBuoiHoc { get; set; }
        public int? IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }
        public int Connect { get; set; }
        [Required, Column(TypeName = "Text"), MaxLengthAttribute]
        public string NhanDien { get; set; }
        public int IdCanhBao { get; set; }
        [ForeignKey("IdCanhBao")]
        public CanhBao CanhBao { get; set; }
    }
}
