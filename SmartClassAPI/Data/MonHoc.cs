using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassAPI.Data
{
    [Table("MonHoc")]
    public class MonHoc
    {
        [Key]
        public int IdMonHoc { get; set; }
        [Required]
        public string TenMonHoc { get; set; }
        public DateTime NgayBatDau { get; set; }
        public int SoTiet { get; set; }
        public int? IdLopHoc { get; set; }
        [ForeignKey("IdLopHoc")]
        public LopHoc LopHoc { get; set; }        
        public int? IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }          
        public int? IdPhongHoc { get; set; }
        [ForeignKey("IdPhongHoc")]
        public PhongHocData PhongHoc { get; set; }
        //public string HoTen { get; set; }
        public int? IdTinhTrang { get; set; }
        [ForeignKey("IdTinhTrang")]
        public TTMonDT TinhTrangMH { get; set; }
        public ICollection<TkbData> TkbDatas { get; set; }
        public MonHoc()
        {
            TkbDatas = new HashSet<TkbData>(); // khi khởi tạo truyền về 1 list rỗng trước
        }
        
    }
}
