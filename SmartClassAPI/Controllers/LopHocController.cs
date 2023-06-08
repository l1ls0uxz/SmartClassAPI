using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartClassAPI.Model;
using SmartClassAPI.Repository.LopHocRepo;

namespace SmartClassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopHocController : ControllerBase
    {
        private readonly ILopHocRepository _lopHocRepo;

        public LopHocController(ILopHocRepository lopHocRepo)
        {
            _lopHocRepo = lopHocRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_lopHocRepo.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var lopHoc = _lopHocRepo.GetById(id);
            if (lopHoc == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lopHoc);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, LopHocVM lopHoc)
        {
            try
            {
                _lopHocRepo.Update(id, lopHoc);
                return new JsonResult("Chỉnh sửa thành công");
            }
            catch
            {
                return new JsonResult("Chỉnh sửa Không thành công");
            }
        }
        [HttpPost]
        public JsonResult Add(LopHocModel lopHoc)
        {
            try
            {
                _lopHocRepo.Add(lopHoc);
                return new JsonResult("Thêm Thành Công");
            }
            catch
            {
                return new JsonResult("Thêm Thất Bại");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _lopHocRepo.Delete(id);
                return new JsonResult("Đã xóa Lớp Học");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
