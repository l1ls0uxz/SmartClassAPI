using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassAPI.Data
{
    public enum SangChieu
    {
        Sáng = 0, Chiều = 1, Tối = 2
    }

    public class TkbData
    {
        public int IdLopHoc { get; set; }
        public int IdMonHoc { get; set; }
        public int IdPhongHoc { get; set; }
        public int? IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }
        public string Thu { get; set; }
        public DateTime NgayThan { get; set; }
        public SangChieu SangChieu { get; set; }
        public int? TinhTrang { get; set; }

        // relationship
        public PhongHocData PhongHocData { get; set; }
        public MonHoc MonHoc { get; set; }
        public LopHoc LopHoc { get; set; }

    }
}
