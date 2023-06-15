using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SmartClassAPI.Data;
using SmartClassAPI.HubConfig;
using SmartClassAPI.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SmartClassAPI.Repository.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public UserRepository(MyDbContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        public async Task<User> CheckLogin(string userName, string password)
        {
            var userNameParam = new SqlParameter("@UserName", userName);
            var passwordParam = new SqlParameter("@Password", password);
            var errTypeParam = new SqlParameter("@ErrType", SqlDbType.Int)              { Direction = ParameterDirection.Output };
            var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 100)    { Direction = ParameterDirection.Output };
            var idUserParam = new SqlParameter("@IdUser", SqlDbType.Int)                { Direction = ParameterDirection.Output };
            var hoTenParam = new SqlParameter("@HoTen", SqlDbType.NVarChar, 50)         { Direction = ParameterDirection.Output };
            var idLoaiParam = new SqlParameter("@IdLoai", SqlDbType.Int)                { Direction = ParameterDirection.Output };
            var emailParam = new SqlParameter("@Email", SqlDbType.NVarChar, 50)         { Direction = ParameterDirection.Output };
            var dienThoaiParam = new SqlParameter("@DienThoai", SqlDbType.NVarChar, 20) { Direction = ParameterDirection.Output };
            var diaChiParam = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 100)      { Direction = ParameterDirection.Output };
            var idHocSinhParam = new SqlParameter("@IdHocSinh", SqlDbType.Int)          { Direction = ParameterDirection.Output };
            var idLopHocParam = new SqlParameter("@IdLopHoc", SqlDbType.Int)            { Direction = ParameterDirection.Output };

            var result = await _context.Users.FromSqlRaw("EXECUTE dbo.CheckLogin " +
                "@UserName, " +
                "@Password, " +
                "@ErrType OUTPUT, " +
                "@Message OUTPUT, " +
                "@IdUser OUTPUT, " +
                "@HoTen OUTPUT, " +
                "@IdLoai OUTPUT, " +
                "@Email OUTPUT, " +
                "@DienThoai OUTPUT, " +
                "@DiaChi OUTPUT, " +
                "@IdHocSinh OUTPUT, " +
                "@IdLopHoc OUTPUT",
                userNameParam, passwordParam, errTypeParam, messageParam, idUserParam, hoTenParam, idLoaiParam, emailParam, dienThoaiParam, diaChiParam, idHocSinhParam, idLopHocParam).ToListAsync();

            var errType = (int)errTypeParam.Value;

            if (errType == 1)
            {
                var user = new User
                {
                    IdUser = (int)idUserParam.Value,
                    HoTen = (string)hoTenParam.Value,
                    UserName = userName,
                    MatKhau = password,
                    IdLoai = (int)idLoaiParam.Value,
                    //Email = (string)emailParam.Value,
                    //DienThoai = (string)dienThoaiParam.Value,
                    //DiaChi = (string)diaChiParam.Value,
                    //IdHocSinh = (int?)idHocSinhParam.Value,
                    //IdLopHoc = (int?)idLopHocParam.Value
                };

                return user;
            }
            else
            {
                return null;
            }
        }

        public UserVM Add(UserModel user)
        {
            var _user = new User // gắn trực tiếp vào data
            {
                HoTen = user.HoTen,
                UserName = user.UserName,
                DiaChi = user.DiaChi,
                Email = user.Email,
                DienThoai = user.DienThoai,
                IdLoai = user.IdLoai,
                IdHocSinh = user.IdHocSinh,
                IdLopHoc = user.IdLopHoc,
            };
            _context.Add(_user);
            Notification notification = new Notification()
            {
                //IdUser = IdUser.Name,
                HoTen = _user.HoTen,
                TranType = "Add"
            };
            _context.Notifications.Add(notification);

            _context.SaveChanges();
            _hubContext.Clients.All.BroadcastMessage();

            return new UserVM
            {
                HoTen = _user.HoTen,
                UserName = _user.UserName,
                DiaChi = _user.DiaChi,
                Email = _user.Email,
                DienThoai = _user.DienThoai,
                IdLoai = _user.IdLoai,
                IdHocSinh = _user.IdHocSinh,
                IdLopHoc = _user.IdLopHoc,
                //
            };
        }

        public void Delete(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.IdUser == id);
            if (user != null)
            {
                _context.Remove(user);
                _context.SaveChanges();
            };
        }

        public List<UserVM> GetAll()
        {
            var users = _context.Users.Select(u => new UserVM // đổi về kiểu VM để show ra :V
            {
                IdUser = u.IdUser,
                HoTen = u.HoTen,
                UserName = u.UserName,
                DiaChi = u.DiaChi,
                Email = u.Email,
                DienThoai = u.DienThoai,
                IdLoai = u.IdLoai,
                TenLoai = u.LoaiUserData.TenLoai,
                IdHocSinh = u.IdHocSinh,
                IdLopHoc = u.IdLopHoc,
                MaLopHoc = u.LopHoc.MaLopHoc,
            }); //.Where(u => u.IdLoai <= 4)
            return users.ToList();
        }
        public List<UserVM> GetByName(string search)
        {
            var users = _context.Users.Where(u => u.HoTen.Contains(search));
            var result = users.Select(u => new UserVM
            {
                IdUser = u.IdUser,
                HoTen = u.HoTen,
                UserName = u.UserName,
                DiaChi = u.DiaChi,
                Email = u.Email,
                DienThoai = u.DienThoai,
                IdLoai = u.IdLoai,
                IdHocSinh = u.IdHocSinh,
                IdLopHoc = u.IdLopHoc,
                MaLopHoc = u.LopHoc.MaLopHoc,
                TenLoai = u.LoaiUserData.TenLoai,
            }).Where(u => u.IdLoai <= 5);
            return result.ToList();
        }

        public UserVM GetById(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.IdUser == id);
            var us = _context.Entry(user);
            if (user != null)
            {
                us.Reference(u => u.LoaiUserData).Load();
                if (user.IdLopHoc != null)
                {
                    us.Reference(u => u.LopHoc).Load();

                    return new UserVM
                    {
                        IdUser = user.IdUser,
                        UserName = user.UserName,
                        HoTen = user.HoTen,
                        DiaChi = user.DiaChi,
                        Email = user.Email,
                        DienThoai = user.DienThoai,
                        IdLoai = user.IdLoai,
                        IdHocSinh = user.IdHocSinh,
                        IdLopHoc = user.IdLopHoc,
                        MaLopHoc = user.LopHoc.MaLopHoc,
                        TenLoai = user.LoaiUserData.TenLoai,
                    };
                }
                else if (user.IdHocSinh != null)
                {
                    var use = _context.Users.FirstOrDefault(u => u.IdUser == user.IdHocSinh);
                    return new UserVM
                    {
                        IdUser = user.IdUser,
                        UserName = user.UserName,
                        HoTen = user.HoTen,
                        DiaChi = user.DiaChi,
                        Email = user.Email,
                        IdLoai = user.IdLoai,
                        IdHocSinh = user.IdHocSinh,
                        TenLoai = user.LoaiUserData.TenLoai,
                        //TenHocSinh = use.HoTen
                    };
                }
                else
                {
                    return new UserVM
                    {
                        IdUser = user.IdUser,
                        UserName = user.UserName,
                        HoTen = user.HoTen,
                        DiaChi = user.DiaChi,
                        Email = user.Email,
                        IdLoai = user.IdLoai,
                        TenLoai = user.LoaiUserData.TenLoai,
                    };
                }
            }
            else
            {
                return null;
            }
        }

        public List<UserVM> GetByLoaiUser(int IdLoai)
        {
            if (IdLoai == 0)
            {
                var users = _context.Users.Select(u => new UserVM // đổi về kiểu VM để show ra :V
                {
                    IdUser = u.IdUser,
                    HoTen = u.HoTen,
                    UserName = u.UserName,
                    DiaChi = u.DiaChi,
                    Email = u.Email,
                    DienThoai = u.DienThoai,
                    IdLoai = u.IdLoai,
                    IdHocSinh = u.IdHocSinh,
                    IdLopHoc = u.IdLopHoc,
                    MaLopHoc = u.LopHoc.MaLopHoc,
                    TenLoai = u.LoaiUserData.TenLoai,
                }).Where(u => u.IdLoai <= 4);
                return users.ToList();
            }
            else
            {
                var users = _context.Users.Select(u => new UserVM // đổi về kiểu VM để show ra :V
                {
                    IdUser = u.IdUser,
                    HoTen = u.HoTen,
                    UserName = u.UserName,
                    DiaChi = u.DiaChi,
                    Email = u.Email,
                    DienThoai = u.DienThoai,
                    IdLoai = u.IdLoai,
                    IdHocSinh = u.IdHocSinh,
                    IdLopHoc = u.IdLopHoc,
                    MaLopHoc = u.LopHoc.MaLopHoc,
                    TenLoai = u.LoaiUserData.TenLoai,
                }).Where(u => u.IdLoai == IdLoai);
                return users.ToList();
            }

        }

        public void Update(int id, UserVM user)
        {
            var _user = _context.Users.SingleOrDefault(u => u.IdUser == id);

            _user.UserName = user.UserName;
            _user.HoTen = user.HoTen;
            _user.DiaChi = user.DiaChi;
            _user.DienThoai = user.DienThoai;
            _user.Email = user.Email;
            _user.IdLoai = user.IdLoai;
            _user.IdHocSinh = user.IdHocSinh;
            _user.IdLopHoc = user.IdLopHoc;


            Notification notification = new Notification()
            {
                IdUser = id,
                HoTen = _user.HoTen,
                TranType = "Edit"
            };
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            _hubContext.Clients.All.BroadcastMessage();
        }
        public void UpdateLopHoc(int id)
        {
            var _user = _context.Users.SingleOrDefault(u => u.IdUser == id);
            _user.IdLopHoc = null;
            _context.SaveChanges();
        }
        public void AddLopHoc(int id, int idLopHoc)
        {
            var _user = _context.Users.SingleOrDefault(u => u.IdUser == id);
            _user.IdLopHoc = idLopHoc;
            _context.SaveChanges();
        }
        public void DisableUser(int id)
        {
            var _user = _context.Users.SingleOrDefault(u => u.IdUser == id);
            _user.IdLoai = 5;
            _context.SaveChanges();
        }

        public List<UserVM> GetByLopHoc(int id)
        {
            var users = _context.Users.Select(u => new UserVM // đổi về kiểu VM để show ra :V
            {
                IdUser = u.IdUser,
                HoTen = u.HoTen,
                UserName = u.UserName,
                DiaChi = u.DiaChi,
                Email = u.Email,
                DienThoai = u.DienThoai,
                IdLoai = u.IdLoai,
                IdHocSinh = u.IdHocSinh,
                IdLopHoc = u.IdLopHoc,
                MaLopHoc = u.LopHoc.MaLopHoc,
                TenLoai = u.LoaiUserData.TenLoai,
            }).Where(u => u.IdLopHoc == id && u.IdLoai <= 4);
            return users.ToList();
        }
        public List<UserVM> GetByChuaAdd()
        {
            var users = _context.Users.Select(u => new UserVM // đổi về kiểu VM để show ra :V
            {
                IdUser = u.IdUser,
                HoTen = u.HoTen,
                UserName = u.UserName,
                DiaChi = u.DiaChi,
                Email = u.Email,
                DienThoai = u.DienThoai,
                IdLoai = u.IdLoai,
                IdHocSinh = u.IdHocSinh,
                IdLopHoc = u.IdLopHoc,
                MaLopHoc = u.LopHoc.MaLopHoc,
                TenLoai = u.LoaiUserData.TenLoai,
            }).Where(u => u.IdLopHoc == null && u.IdLoai == 3 && u.IdLoai <= 4);
            return users.ToList();
        }
    }
}
