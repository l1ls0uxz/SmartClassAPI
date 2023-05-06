using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassAPI.Data
{
    [Table("CanhBao")]
    public class CanhBao
    {
        [Key]
        public int IdCanhBao { get; set; }
        public string TenCanhBao { get; set; }
    }
}
