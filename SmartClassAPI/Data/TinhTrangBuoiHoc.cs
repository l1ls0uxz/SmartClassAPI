using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassAPI.Data
{
    [Table("TinhTrangBuoiHoc")]
    public class TinhTrangBuoiHoc
    {
        [Key]
        public int IdTinhTrang { get; set; }
        public string TenTinhTrang { get; set; }
    }
}
