using SmartClassAPI.Model;
using System.Collections.Generic;

namespace SmartClassAPI.Repository.LopHocRepo
{
    public interface ILopHocRepository
    {
        List<LopHocVM> GetAll();
        LopHocVM GetById(int id);
        LopHocVM Add(LopHocModel lophoc);
        void Update(int id, LopHocVM lophoc);
        void Delete(int id);
    }
}
