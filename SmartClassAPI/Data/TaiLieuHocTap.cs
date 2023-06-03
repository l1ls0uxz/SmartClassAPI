using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassAPI.Data
{
    [Table("TaiLieuHocTap")]
    public class TaiLieuHocTap
    {
        [Key]
        public int IdTaiLieu { get; set; }
        [Required]
        public string TenTaiLieu { get; set; }
        public string UrlTaiLieu { get; set; }
        public int? IdMonHoc { get; set; }
        [ForeignKey("IdMonHoc")]
        public MonHoc MonHoc { get; set; }
        //public string TenMonHoc { get; set; }
        public int? IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }
        // public string HoTen { get; set; }
    }
}
