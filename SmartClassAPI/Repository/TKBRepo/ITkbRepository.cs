using SmartClassAPI.Model;
using System.Collections.Generic;

namespace SmartClassAPI.Repository
{
    public interface ITkbRepository
    {
        List<TkbVM> GetAll();
        //List<TkbVM> GetById(int id);
        List<TkbVM> GetByName(string name);
        TkbVM Add(TkbModel tkb);
        void Update(int id, TkbVM tkb);
        void Delete(int id);
    }
}
