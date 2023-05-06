using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SmartClassAPI.Data;
using SmartClassAPI.HubConfig;
using SmartClassAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartClassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanDiensController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public NhanDiensController(MyDbContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        
        [HttpGet("{id}")]
        public List<NhanDienMD> GetAllNhanDien(int id)
        {
            var nhanDiens = _context.NhanDienDatas.Where(bh => bh.IdBuoiHoc == id).Select(bh => new NhanDienMD
            {
                IdNhanDien = bh.IdNhanDien,
                IdBuoiHoc = id,
                IdUser = bh.IdUser,
                HoTen = bh.User.HoTen,
                Connect = bh.Connect,
                NhanDien = bh.NhanDien,
                IdCanhBao = bh.IdCanhBao,
                TenCanhBao = bh.CanhBao.TenCanhBao,
            });
            //_hubContext.Clients.All.BroadcastMessage();
            return nhanDiens.ToList();
        }
        [HttpPut("{id}/{idUser}")]
        public IActionResult UpdateNhanDien(int id, int idUser, NhanDienMD nhanDien)
        {
            var nd = _context.NhanDienDatas.SingleOrDefault(b => b.IdBuoiHoc == id && b.IdUser == idUser);
            nd.IdBuoiHoc = nhanDien.IdBuoiHoc;
            nd.IdUser = nhanDien.IdUser;
            nd.Connect = nhanDien.Connect;
            nd.NhanDien = nhanDien.NhanDien;
            nd.IdCanhBao = nhanDien.IdCanhBao;
            _context.SaveChanges();
            _hubContext.Clients.All.BroadcastMessage();
            return new JsonResult("Update thành công");
        }
        [HttpPost]
        public async Task<ActionResult<NhanDienData>> PostBuoiHoc(NhanDienData nhanDien)
        {
            var nh = _context.NhanDienDatas.SingleOrDefault(b => b.IdBuoiHoc == nhanDien.IdBuoiHoc && b.IdUser == nhanDien.IdUser);
            if(nh == null)
            {
                _context.NhanDienDatas.Add(nhanDien);
                await _context.SaveChangesAsync();
                await _hubContext.Clients.All.BroadcastMessage();
                return new JsonResult("Thêm Thành Công");
            }
            return BadRequest();
        }
        [HttpGet("/api/NhanDiens/ChiTiet/{id}/{idUser}")]
        public async Task<ActionResult<NhanDienData>> GetById(int id, int idUser)
        {
            var nhandien = await _context.NhanDienDatas.FirstOrDefaultAsync(b => b.IdBuoiHoc == id && b.IdUser == idUser);
            return nhandien;
        }
        
    }
}
