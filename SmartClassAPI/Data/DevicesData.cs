using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClassAPI.Data
{
    //public enum 
    //{
    //    GiaoVien = 0, SinhVien = 1
    //}
    public enum DeviceTpye
    {
        GiaoVien = 0, SinhVien = 1
    }
    [Table("Devices")]
    public class DevicesData
    {
        [Key]
        public int IdDevice { get; set; }
        //[Required]

        public string DeviceName { get; set; }

        public string MieuTaCongDung { get; set; }
        //public DeviceTpye DeviceType { get; set; }
        //public DeviceTpye DeviceType { get; set; }
        public DeviceTpye DeviceTpye { get; set; }
        public int? IdPhongHoc { get; set; }
        [ForeignKey("IdPhongHoc")]
        public PhongHocData PhongHocData { get; set; }
        public int? IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}
