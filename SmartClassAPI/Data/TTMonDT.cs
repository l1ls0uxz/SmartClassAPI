using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassAPI.Data
{
    [Table("TinhTrangMonHoc")]
    public class TTMonDT
    {
        [Key]
        public int IdTinhTrang { get; set; }
        public string TenTinhTrang { get; set; }
        public string? MoTa { get; set; }
    }
}
