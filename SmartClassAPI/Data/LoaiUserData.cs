using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassAPI.Data
{
    [Table("LoaiUser")]
    public class LoaiUserData
    {
        [Key]
        public int IdLoai { get; set; }
        public string TenLoai { get; set; }
        public string? MotaLoai { get; set; }

    }
}
