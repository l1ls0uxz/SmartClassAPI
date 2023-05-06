using SmartClassAPI.Data;
using SmartClassAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace SmartClassAPI.Repository.TKBRepo
{
    public class TkbRepository : ITkbRepository
    {
        private readonly MyDbContext _context;

        public TkbRepository(MyDbContext context)
        {
            _context = context;
        }
        public TkbVM Add(TkbModel tkb)
        {
            var _tkb = new TkbData
            {
                IdLopHoc = tkb.IdLopHoc,
                IdMonHoc = tkb.IdMonHoc,
                IdPhongHoc = tkb.IdPhongHoc,
                IdUser = tkb.IdUser,
                Thu = tkb.Thu,
                NgayThan = tkb.NgayThan,
                TinhTrang = tkb.TinhTrang,
                SangChieu = tkb.SangChieu,
            };
            _context.Add(_tkb);
            _context.SaveChanges();
            var tk = _context.Entry(_tkb);
            tk.Reference(tb => tb.PhongHocData).Load();
            tk.Reference(tb => tb.User).Load();
            tk.Reference(tb => tb.MonHoc).Load();
            tk.Reference(tb => tb.LopHoc).Load();
            return new TkbVM
            {
                IdLopHoc = _tkb.IdLopHoc,
                MaLopHoc = _tkb.LopHoc.MaLopHoc,
                IdMonHoc = _tkb.IdMonHoc,
                TenMonHoc = _tkb.MonHoc.TenMonHoc,
                IdPhongHoc= _tkb.IdPhongHoc,
                TenPhongHoc = _tkb.PhongHocData.TenPhongHoc,
                HoTen = _tkb.User.HoTen,
                NgayThan = _tkb.NgayThan,
                Thu = _tkb.Thu,
            };
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<TkbVM> GetAll()
        {
            var tkb = _context.TkbDatas.Select(t => new TkbVM
            {
                IdLopHoc = t.IdLopHoc,
                IdMonHoc = t.IdMonHoc,
                IdPhongHoc = t.IdPhongHoc,
                TenMonHoc = t.MonHoc.TenMonHoc,
                TenPhongHoc = t.PhongHocData.TenPhongHoc,
                HoTen = t.User.HoTen,
                MaLopHoc = t.LopHoc.MaLopHoc,
                Thu = t.Thu,
                NgayThan = t.NgayThan,
                SangChieu = t.SangChieu,
            });
            return tkb.ToList();
        }

        public List<TkbVM> GetById(int id)
        {
            var tkb = _context.TkbDatas.Select(t => new TkbVM
            {
                IdLopHoc = t.IdLopHoc,
                IdMonHoc = t.IdMonHoc,
                IdPhongHoc = t.IdPhongHoc,
                TenMonHoc = t.MonHoc.TenMonHoc,
                TenPhongHoc = t.PhongHocData.TenPhongHoc,
                HoTen = t.User.HoTen,
                MaLopHoc = t.LopHoc.MaLopHoc,
                Thu = t.Thu,
                NgayThan = t.NgayThan,
                SangChieu = t.SangChieu,
            }).Where(t => t.IdLopHoc == id);
            return tkb.ToList();
            //var tkbName = _context.TkbDatas.Where(n => n.IdLopHoc == id);
            //var tk = _context.Entry(tkbName);
            //tk.Reference(tb => tb.LopHoc).Load();
            //tk.Reference(tb => tb.MonHoc).Load();
            //tk.Reference(tb => tb.PhongHocData).Load();
            //tk.Reference(tb => tb.User).Load();
            //return new TkbVM
            //{
            //    IdLopHoc = tkbName.IdLopHoc,
            //    MaLopHoc = tkbName.LopHoc.MaLopHoc,
            //    IdMonHoc = tkbName.IdMonHoc,
            //    TenMonHoc = tkbName.MonHoc.TenMonHoc,
            //    IdPhongHoc = tkbName.IdPhongHoc,
            //    TenPhongHoc = tkbName.PhongHocData.TenPhongHoc,
            //    HoTen = tkbName.User.HoTen,
            //    NgayThan = tkbName.NgayThan,
            //    Thu = tkbName.Thu,
            //};
        }

        public List<TkbVM> GetByName(string name)
        {
            var lopHoc = _context.LopHocs.FirstOrDefault(lh => lh.MaLopHoc == name);
            if (lopHoc == null)
            {
                return null;
            }
            else
            {
                var tkb = _context.TkbDatas.Select(t => new TkbVM
                {
                    IdLopHoc = t.IdLopHoc,
                    IdMonHoc = t.IdMonHoc,
                    IdPhongHoc = t.IdPhongHoc,
                    TenMonHoc = t.MonHoc.TenMonHoc,
                    TenPhongHoc = t.PhongHocData.TenPhongHoc,
                    HoTen = t.User.HoTen,
                    MaLopHoc = t.LopHoc.MaLopHoc,
                    Thu = t.Thu,
                    NgayThan = t.NgayThan,
                    SangChieu = t.SangChieu,
                }).Where(t => t.IdLopHoc == lopHoc.IdLopHoc);
                return tkb.ToList();
            }
        }

        public void Update(int id, TkbVM tkb)
        {
            throw new System.NotImplementedException();
        }
    }
}
