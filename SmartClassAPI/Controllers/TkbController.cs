using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartClassAPI.Model;
using SmartClassAPI.Repository;
using SmartClassAPI.Repository.TKBRepo;

namespace SmartClassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TkbController : ControllerBase
    {
        private readonly ITkbRepository _tkbRepo;

        public TkbController(ITkbRepository tkbRepo)
        {
            _tkbRepo = tkbRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_tkbRepo.GetAll());
        }
        [HttpPost]
        public IActionResult Add(TkbModel tkb)
        {
            try
            {
                return Ok(_tkbRepo.Add(tkb));
            }
            catch
            {
                return BadRequest();
            }
        }
        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var byId = _tkbRepo.GetById(id);
        //    if(byId == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(byId);
        //    }
        //}
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var byName = _tkbRepo.GetByName(name);
            if(byName == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(byName);
            }
        }
    }
}
