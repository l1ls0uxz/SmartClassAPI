using SmartClassAPI.Data;
using SmartClassAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace SmartClassAPI.Repository.PhongHocRepo
{
    public class PhongHocRepository : IPhongHocRepository
    {
        private readonly MyDbContext _context;

        public PhongHocRepository(MyDbContext context)
        {
            _context = context;
        }
        public PhongHocVM Add(PhongHocModel phongHoc)
        {
            var _phonghoc = new PhongHocData
            {
                TenPhongHoc = phongHoc.TenPhongHoc,
            };
            _context.Add(_phonghoc);
            _context.SaveChanges();
            return new PhongHocVM
            {
                TenPhongHoc = _phonghoc.TenPhongHoc
            };

        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<PhongHocVM> GetAll()
        {
            var phongHocs = _context.PhongHocDatas.Select(ph => new PhongHocVM
            {
                IdPhongHoc = ph.IdPhongHoc,
                TenPhongHoc = ph.TenPhongHoc,
                MonHocs = ph.MonHocs.ToList(),
            });
            return phongHocs.ToList();
        }

        public PhongHocVM GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, PhongHocVM phongHoc)
        {
            throw new System.NotImplementedException();
        }
    }
}
