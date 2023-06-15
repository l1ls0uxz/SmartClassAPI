using SmartClassAPI.Data;
using SmartClassAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartClassAPI.Repository.UserRepo
{
    public interface IUserRepository
    {
        Task<User> CheckLogin(string userName, string password);
        List<UserVM> GetAll();
        List<UserVM> GetByName(string search);
        UserVM GetById(int id);

        List<UserVM> GetByLopHoc(int id);
        List<UserVM> GetByChuaAdd();

        List<UserVM> GetByLoaiUser(int loaiUser);
        UserVM Add(UserModel user);

        void Update(int id, UserVM user);
        void UpdateLopHoc(int id);

        void AddLopHoc(int id, int idLopHoc);
        void DisableUser(int id);

        void Delete(int id);
    }
}
