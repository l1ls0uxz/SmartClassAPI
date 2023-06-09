using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassAPI.Data
{
    [Table("LopHoc")]
    public class LopHoc
    {
        [Key]
        public int IdLopHoc { get; set; }
        [Required]
        public string MaLopHoc { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayBatDau { get; set; }

        public virtual ICollection<User> Users { get; set; } // Một lớp có nhiều học sinh

        //public List<User> Users { get; set; }
        public virtual ICollection<MonHoc> MonHocs { get; set; } // Một lớp có nhiều môn

        public ICollection<TkbData> TkbDatas { get; set; }
        //public LopHoc()
        //{
        //    TkbDatas = new HashSet<TkbData>(); // khi khởi tạo truyền về 1 list rỗng trước
        //}
    }
}
