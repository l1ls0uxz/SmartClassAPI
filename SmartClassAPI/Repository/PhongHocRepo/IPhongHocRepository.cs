using SmartClassAPI.Model;
using System.Collections.Generic;

namespace SmartClassAPI.Repository.PhongHocRepo
{
    public interface IPhongHocRepository
    {
        List<PhongHocVM> GetAll();
        PhongHocVM GetById(int id);
        PhongHocVM Add(PhongHocModel phongHoc);

        void Update(int id, PhongHocVM phongHoc);
        void Delete(int id);

    }
}
