using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SmartClassAPI.Data;
using SmartClassAPI.HubConfig;
using SmartClassAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartClassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLBuoiHocController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public QLBuoiHocController(MyDbContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        [HttpGet]
        public List<QuanLyBuoiHocMD> GetAllBuoiHoc()
        {
            //.Where(bh => bh.MonHoc.IdTinhTrang == 1)
            var buoiHocs = _context.QuanLyBuoiHoc.Select(bh => new QuanLyBuoiHocMD
            {
                IdBuoiHoc = bh.IdBuoiHoc,
                IdLopHoc = bh.IdLopHoc,
                MaLopHoc = bh.LopHoc.MaLopHoc,
                IdMonHoc = bh.IdMonHoc,
                TenMonHoc = bh.MonHoc.TenMonHoc,
                IdPhongHoc = bh.IdPhongHoc,
                TenPhongHoc = bh.PhongHocDatas.TenPhongHoc,
                IdUser = bh.IdUser,
                HoTen = bh.Users.HoTen,
                NgayHoc = bh.NgayHoc,
                Buoi = bh.Buoi,
                IdTinhTrang = bh.IdTinhTrang,
                TenTinhTrang = bh.TinhTrang.TenTinhTrang,
            });
            return buoiHocs.ToList();
        }
        [HttpGet("{id}")]
        //public async Task<ActionResult<QuanLyBuoiHoc>> GetById(int id)
        //{
        //    var buoiHoc = await _context.QuanLyBuoiHoc.FirstOrDefaultAsync(b => b.IdBuoiHoc == id);
        //    var bho = _context.Entry(buoiHoc); // truy vấn đến khóa ngoại
        //    await bho.Reference(mh => mh.Users).LoadAsync();
        //    await bho.Reference(mh => mh.LopHoc).LoadAsync();
        //    await bho.Reference(mh => mh.MonHoc).LoadAsync();
        //    await bho.Reference(mh => mh.PhongHocData).LoadAsync();
        //    await bho.Reference(mh => mh.TinhTrang).LoadAsync();

        //    return buoiHoc;
        //}
        public QuanLyBuoiHocMD getById(int id)
        {
            var buoiHoc = _context.QuanLyBuoiHoc.FirstOrDefault(bh => bh.IdBuoiHoc == id);
            var us = _context.Entry(buoiHoc);
            us.Reference(bh => bh.Users).Load();
            us.Reference(bh => bh.LopHoc).Load();
            us.Reference(bh => bh.MonHoc).Load();
            us.Reference(bh => bh.PhongHocDatas).Load();
            us.Reference(bh => bh.TinhTrang).Load();
            return new QuanLyBuoiHocMD
            {
                IdBuoiHoc = buoiHoc.IdBuoiHoc,
                IdLopHoc = buoiHoc.IdLopHoc,
                MaLopHoc = buoiHoc.LopHoc.MaLopHoc,
                IdMonHoc = buoiHoc.IdMonHoc,
                TenMonHoc = buoiHoc.MonHoc.TenMonHoc,
                IdPhongHoc = buoiHoc.IdPhongHoc,
                TenPhongHoc = buoiHoc.PhongHocDatas.TenPhongHoc,
                IdUser = buoiHoc.IdUser,
                HoTen = buoiHoc.Users.HoTen,
                NgayHoc = buoiHoc.NgayHoc,
                Buoi = buoiHoc.Buoi,
                IdTinhTrang = buoiHoc.IdTinhTrang,
                TenTinhTrang = buoiHoc.TinhTrang.TenTinhTrang,
            };
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBuoiHoc(int id, QuanLyBuoiHocMD qlBuoi)
        {
            var buoi = _context.QuanLyBuoiHoc.SingleOrDefault(b => b.IdBuoiHoc == id);

            buoi.IdLopHoc = qlBuoi.IdLopHoc;
            buoi.IdPhongHoc = qlBuoi.IdPhongHoc;
            buoi.IdMonHoc = qlBuoi.IdMonHoc;
            buoi.IdUser = qlBuoi.IdUser;
            buoi.IdTinhTrang = qlBuoi.IdTinhTrang;
            buoi.NgayHoc = qlBuoi.NgayHoc;
            buoi.Buoi = qlBuoi.Buoi;

            _context.SaveChanges();

            return new JsonResult("Update thành công");

        }
        [HttpPost]
        public async Task<ActionResult<QuanLyBuoiHoc>> PostBuoiHoc(QuanLyBuoiHoc quanLyBuoiHoc)
        {
            _context.QuanLyBuoiHoc.Add(quanLyBuoiHoc);
            await _context.SaveChangesAsync();
            return new JsonResult("Thêm Thành Công");
        }
        private bool QlLopExists(int id)
        {
            return _context.QuanLyBuoiHoc.Any(b => b.IdBuoiHoc == id);
        }
    }
}
