using SmartClassAPI.Data;
using SmartClassAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace SmartClassAPI.Repository.TaiLieuRepo
{
    public class TaiLieuRepository : ITaiLieuRepository
    {
        private readonly MyDbContext _context;

        public TaiLieuRepository(MyDbContext context)
        {
            _context = context;
        }
        public TaiLieuVM Add(TaiLieuModel taiLieu)
        {
            var _taiLieu = new TaiLieuHocTap
            {
                TenTaiLieu = taiLieu.TenTaiLieu,
                IdMonHoc = taiLieu.IdMonHoc,
                IdUser = taiLieu.IdUser,
                UrlTaiLieu = taiLieu.UrlTaiLieu,
            };
            _context.Add(_taiLieu);
            _context.SaveChanges();
            return new TaiLieuVM
            {
                IdTaiLieu = _taiLieu.IdTaiLieu,
                TenTaiLieu = _taiLieu.TenTaiLieu,
                IdMonHoc = _taiLieu.IdMonHoc,
                IdUser = _taiLieu.IdUser,
                UrlTaiLieu = _taiLieu.UrlTaiLieu,
            };
        }

        public void Delete(int id)
        {
            var taiLieu = _context.TaiLieuHocTaps.SingleOrDefault(tl => tl.IdTaiLieu == id);
            if(taiLieu != null)
            {
                _context.Remove(taiLieu);
                _context.SaveChanges();
            }
        }

        public List<TaiLieuVM> GetAll()
        {
            var taiLieu = _context.TaiLieuHocTaps.Select(tl => new TaiLieuVM
            {
                IdTaiLieu = tl.IdTaiLieu,
                TenTaiLieu = tl.TenTaiLieu,
                TenMonHoc = tl.MonHoc.TenMonHoc,
                IdMonHoc = tl.IdMonHoc,
                IdUser= tl.IdUser,
                HoTen = tl.User.HoTen,
                UrlTaiLieu =tl.UrlTaiLieu,
            });
            return taiLieu.ToList();
        }

        public TaiLieuVM GetById(int id)
        {
            var taiLieu = _context.TaiLieuHocTaps.SingleOrDefault(tl => tl.IdTaiLieu == id);
            if(taiLieu == null)
            {
                return null;
            }
            else
            {
                return new TaiLieuVM
                {
                    TenTaiLieu = taiLieu.TenTaiLieu,
                    IdMonHoc = taiLieu.IdMonHoc,
                    IdUser = taiLieu.IdUser,
                    UrlTaiLieu = taiLieu.UrlTaiLieu,
                };
            }
        }

        public void Update(int id, TaiLieuVM taiLieu)
        {
            var _taiLieu = _context.TaiLieuHocTaps.SingleOrDefault(tl => tl.IdTaiLieu == id);
            if (_taiLieu != null)
            {
                _taiLieu.IdTaiLieu = taiLieu.IdTaiLieu;
                _taiLieu.TenTaiLieu = taiLieu.TenTaiLieu;
                _taiLieu.IdMonHoc = taiLieu.IdMonHoc;
                _taiLieu.IdUser = taiLieu.IdUser;
                _taiLieu.UrlTaiLieu = taiLieu.UrlTaiLieu;
            }
            _context.SaveChanges();
        }
    }
}
