using System;

namespace SmartClassAPI.Model
{
    public class ChiTietNhanDienUser
    {
        public int LoaiCB { get; set; }
        public int SoLan { get; set; }
        public string Time { get; set; }
        public string TongTime { get; set; }

        //public static implicit operator ChiTietNhanDienUser(ChiTietNhanDienUser v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
