using SmartClassAPI.Model;
using System.Collections.Generic;

namespace SmartClassAPI.Repository.TaiLieuRepo
{
    public interface ITaiLieuRepository
    {
        List<TaiLieuVM> GetAll();
        TaiLieuVM GetById(int id);
        TaiLieuVM Add(TaiLieuModel taiLieu);
        void Update(int id, TaiLieuVM taiLieu);
        void Delete(int id);
    }
}
