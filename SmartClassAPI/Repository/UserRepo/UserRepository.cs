using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SmartClassAPI.Data;
using SmartClassAPI.HubConfig;
using SmartClassAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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
