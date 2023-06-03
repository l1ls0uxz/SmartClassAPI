using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartClassAPI.Model;
using SmartClassAPI.Repository.MonHocRepo;

namespace SmartClassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocController : ControllerBase
    {
        private readonly IMonHocRepository _monHocRepo;

        public MonHocController(IMonHocRepository monHocRepo)
        {
            _monHocRepo = monHocRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_monHocRepo.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var monHoc = _monHocRepo.GetById(id);
            if (monHoc == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(monHoc);
            }
        }
        [HttpGet("/api/TinhTrang/{id}")]
        public IActionResult GetTinhTrang(int id)
        {
            var monHoc = _monHocRepo.GetTinhTrang(id);
            if (monHoc == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(monHoc);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, MonHocVM monHoc)
        {
            try
            {
                _monHocRepo.Update(id, monHoc);
                return new JsonResult("Đã Cập Nhật");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult Add(MonHocModel monHoc)
        {
            _monHocRepo.Add(monHoc);
            return new JsonResult("Đã Thêm Môn Học");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _monHocRepo.Delete(id);
            return NoContent();
        }
    }
}
