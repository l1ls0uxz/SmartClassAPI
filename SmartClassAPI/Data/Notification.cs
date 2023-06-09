using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassAPI.Data
{
    [Table("Notification")]
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public int? IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }
        public string HoTen { get; set; }
        public string TranType { get; set; }
    }
}
