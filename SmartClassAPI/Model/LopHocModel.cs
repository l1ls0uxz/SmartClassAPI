using SmartClassAPI.Data;
using System;
using System.Collections.Generic;

namespace SmartClassAPI.Model
{    
    public class LopHocVM : LopHocModel
    {
        public int IdLopHoc { get; set; }

        //public int? IdUser { get; set; }

        public virtual ICollection<User> User { get; internal set; }
    }

    public class LopHocModel
    {
        
        public string MaLopHoc { get; set; }
        //public User User { get; set; }
        public DateTime? NgayTao { get; set; }

        public DateTime? NgayBatDau { get; set; }
    }

}
