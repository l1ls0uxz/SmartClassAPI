using SmartClassAPI.Data;
using SmartClassAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace SmartClassAPI.Repository.MonHocRepo
{
    public class MonHocRepository : IMonHocRepository
    {
        private readonly MyDbContext _context;

        public MonHocRepository(MyDbContext context)
        {
            _context = context;
        }
        public MonHocVM Add(MonHocModel monHoc)
        {
            var _monHoc = new MonHoc
            {
                TenMonHoc = monHoc.TenMonHoc,
                NgayBatDau = monHoc.NgayBatDau,
                SoTiet = monHoc.SoTiet,
                IdUser = monHoc.IdUser,
                IdLopHoc = monHoc.IdLopHoc,
                IdPhongHoc = monHoc.IdPhongHoc,
                IdTinhTrang = monHoc.IdTinhTrang,
            };
            _context.Add(_monHoc);
            _context.SaveChanges();
            var mh = _context.Entry(_monHoc);
            mh.Reference(mh => mh.LopHoc).Load();
            return new MonHocVM
            {
                IdMonHoc = _monHoc.IdMonHoc,
                TenMonHoc = _monHoc.TenMonHoc,
                NgayBatDau = _monHoc.NgayBatDau,
                SoTiet = _monHoc.SoTiet,
                IdUser = _monHoc.IdUser,
                IdLopHoc = _monHoc.IdLopHoc,
                MaLopHoc = _monHoc.LopHoc.MaLopHoc,
                IdPhongHoc = _monHoc.IdPhongHoc,
            };
        }

        public void Delete(int id)
        {
            var monHoc = _context.MonHocs.SingleOrDefault(x => x.IdMonHoc == id);
            if (monHoc != null)
            {
                _context.Remove(monHoc);
                _context.SaveChanges();
            }
        }

        public List<MonHocVM> GetAll()
        {
            var monHoc = _context.MonHocs.Select(mh => new MonHocVM
            {
                IdMonHoc = mh.IdMonHoc,
                TenMonHoc = mh.TenMonHoc,
                NgayBatDau = mh.NgayBatDau,
                SoTiet = mh.SoTiet,
                IdLopHoc = mh.IdLopHoc,
                MaLopHoc = mh.LopHoc.MaLopHoc,
                IdUser = mh.IdUser,
                HoTen = mh.User.HoTen,
                IdPhongHoc = mh.IdPhongHoc,
                TenPhongHoc = mh.PhongHoc.TenPhongHoc,
                IdTinhTrang = mh.IdTinhTrang,
                TenTinhTrang = mh.TinhTrangMH.TenTinhTrang,
                //LopHoc = mh.LopHocs.First()
            });
            return monHoc.ToList();
        }
        public List<MonHocVM> GetTinhTrang(int id)
        {
            var monHoc = _context.MonHocs.Select(mh => new MonHocVM
            {
                IdMonHoc = mh.IdMonHoc,
                TenMonHoc = mh.TenMonHoc,
                NgayBatDau = mh.NgayBatDau,
                SoTiet = mh.SoTiet,
                IdLopHoc = mh.IdLopHoc,
                MaLopHoc = mh.LopHoc.MaLopHoc,
                IdUser = mh.IdUser,
                HoTen = mh.User.HoTen,
                IdPhongHoc = mh.IdPhongHoc,
                TenPhongHoc = mh.PhongHoc.TenPhongHoc,
                IdTinhTrang = mh.IdTinhTrang,
                TenTinhTrang = mh.TinhTrangMH.TenTinhTrang,
            }).Where(mh => mh.IdTinhTrang == id);
            return monHoc.ToList();
        }
        public MonHocVM GetById(int id)
        {
            var monHoc = _context.MonHocs.SingleOrDefault(mh => mh.IdMonHoc == id);
            var moh = _context.Entry(monHoc); // truy vấn đến khóa ngoại
            moh.Reference(mh => mh.LopHoc).Load();
            moh.Reference(mh => mh.User).Load();
            if (monHoc != null)
            {
                return new MonHocVM
                {
                    IdMonHoc = monHoc.IdMonHoc,
                    TenMonHoc = monHoc.TenMonHoc,
                    NgayBatDau = monHoc.NgayBatDau,
                    SoTiet = monHoc.SoTiet,
                    IdLopHoc = monHoc.IdLopHoc,
                    IdUser = monHoc.IdUser,
                    //MaLopHoc = monHoc.LopHoc.MaLopHoc,
                    HoTen = monHoc.User.HoTen,
                    //TenTinhTrang = monHoc.TinhTrangMH.TenTinhTrang,
                };
            }
            return null;
        }

        public void Update(int id, MonHocVM monHoc)
        {
            var _monHoc = _context.MonHocs.SingleOrDefault(mh => mh.IdMonHoc == id);
            if (_monHoc != null)
            {
                _monHoc.IdMonHoc = id;
                _monHoc.TenMonHoc = monHoc.TenMonHoc;
                _monHoc.NgayBatDau = monHoc.NgayBatDau;
                _monHoc.SoTiet = monHoc.SoTiet;
                _monHoc.IdUser = monHoc.IdUser;
                _monHoc.IdLopHoc = monHoc.IdLopHoc;
                _monHoc.IdPhongHoc = monHoc.IdPhongHoc;
                _monHoc.IdTinhTrang = monHoc.IdTinhTrang;
                _context.SaveChanges();
            }
        }
    }
}
