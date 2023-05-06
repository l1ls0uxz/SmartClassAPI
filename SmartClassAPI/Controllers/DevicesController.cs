using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartClassAPI.Model;
using SmartClassAPI.Repository.DevicesRepo;

namespace SmartClassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceRepository _deRepo;

        public DevicesController(IDeviceRepository deRepo)
        {
            _deRepo = deRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_deRepo.GetAll());
        }
        [HttpPost]
        public IActionResult Add(DevicesModel devices)
        {
            try
            {
                return Ok(_deRepo.Add(devices));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
