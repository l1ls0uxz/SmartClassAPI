using SmartClassAPI.Data;
using SmartClassAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartClassAPI.Repository.LopHocRepo
{
    public class LopHocRepository : ILopHocRepository
    {
        private readonly MyDbContext _context;

        public LopHocRepository(MyDbContext context)
        {
            _context = context;
        }
        public LopHocVM Add(LopHocModel lopHoc)
        {
            var _lopHoc = new LopHoc
            {
                MaLopHoc = lopHoc.MaLopHoc,
                NgayTao = DateTime.UtcNow,
                NgayBatDau = lopHoc.NgayBatDau
            };
            _context.Add(_lopHoc);
            _context.SaveChanges();
            return new LopHocVM
            {
                //IdLopHoc = _lopHoc.IdLopHoc,
                MaLopHoc = _lopHoc.MaLopHoc,
            };
        }

        public void Delete(int id)
        {
            var lopHoc = _context.LopHocs.SingleOrDefault(lh => lh.IdLopHoc == id);
            if (lopHoc != null)
            {
                _context.Remove(lopHoc);
                _context.SaveChanges();
            };
        }

        public List<LopHocVM> GetAll()
        {
            var lopHocs = _context.LopHocs.Select(lh => new LopHocVM
            {
                IdLopHoc = lh.IdLopHoc,
                MaLopHoc = lh.MaLopHoc,
                NgayTao = (DateTime)lh.NgayTao,
                NgayBatDau = (DateTime)lh.NgayBatDau,
                User = lh.Users.ToList()
            });
            return lopHocs.ToList();
        }

        public LopHocVM GetById(int id)
        {
            var _lopHoc = _context.LopHocs.FirstOrDefault(lh => lh.IdLopHoc == id);
            //var us = _context.Entry(_lopHoc);
            if (_lopHoc != null)
            {
                return new LopHocVM
                {
                    IdLopHoc = _lopHoc.IdLopHoc,
                    MaLopHoc = _lopHoc.MaLopHoc,
                    NgayBatDau = (DateTime)_lopHoc.NgayBatDau,
                    NgayTao = (DateTime)_lopHoc.NgayTao,
                    //User = _lopHoc.Users.ToList()
                };
            }
            return null;
        }

        public void Update(int id, LopHocVM lophoc)
        {
            var NgayTao = DateTime.Now;
            var _lopHoc = _context.LopHocs.SingleOrDefault(lh => lh.IdLopHoc == id);

            _lopHoc.IdLopHoc = id;
            _lopHoc.MaLopHoc = lophoc.MaLopHoc;
            _lopHoc.NgayTao = NgayTao;
            _lopHoc.NgayBatDau = lophoc.NgayBatDau;
            _context.SaveChanges();
        }

    }
}
