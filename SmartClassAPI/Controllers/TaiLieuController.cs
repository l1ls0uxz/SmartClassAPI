using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartClassAPI.Model;
using SmartClassAPI.Repository.TaiLieuRepo;

namespace SmartClassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiLieuController : ControllerBase
    {
        private readonly ITaiLieuRepository _taiLieuRepo;

        public TaiLieuController(ITaiLieuRepository taiLieuRepo)
        {
            _taiLieuRepo = taiLieuRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_taiLieuRepo.GetAll());
        }
        [HttpPost]
        public IActionResult Add(TaiLieuModel taiLieu)
        {
            try
            {
                return Ok(_taiLieuRepo.Add(taiLieu));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, TaiLieuVM taiLieu)
        {
            if(taiLieu.IdTaiLieu == id)
            {
                _taiLieuRepo.Update(id, taiLieu);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _taiLieuRepo.Delete(id);
            return NoContent();
        }
    }
}
