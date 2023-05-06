using SmartClassAPI.Data;
using SmartClassAPI.Model;
using System.Collections.Generic;

namespace SmartClassAPI.Repository.MonHocRepo
{
    public interface IMonHocRepository
    {
        List<MonHocVM> GetAll();
        List<MonHocVM> GetTinhTrang(int id);
        MonHocVM GetById(int id);
        MonHocVM Add(MonHocModel monHoc);
        void Update(int id, MonHocVM monHoc);
        void Delete(int id);
    }
}
