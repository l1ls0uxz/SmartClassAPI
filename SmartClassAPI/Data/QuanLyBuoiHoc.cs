using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassAPI.Data
{
    [Table("QuanLyBuoiHoc")]
    public class QuanLyBuoiHoc
    {        
        [Key]
        public int IdBuoiHoc { get; set; }
        public int IdMonHoc { get; set; }
        [ForeignKey("IdMonHoc")]
        public MonHoc MonHoc { get; set; }
        public int IdLopHoc { get; set; }
        [ForeignKey("IdLopHoc")]
        public LopHoc LopHoc { get; set; }
        public int IdPhongHoc { get; set; }
        [ForeignKey("IdPhongHoc")]
        public PhongHocData PhongHocDatas { get; set; } 
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User Users { get; set; }
        public DateTime NgayHoc { get; set; }
        public string Buoi { get; set; }
        public int IdTinhTrang { get; set; }
        [ForeignKey("IdTinhTrang")]
        public TinhTrangBuoiHoc TinhTrang { get; set; }

    }
}
