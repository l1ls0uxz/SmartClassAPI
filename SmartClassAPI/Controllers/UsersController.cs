using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SmartClassAPI.HubConfig;
using SmartClassAPI.Model;
using SmartClassAPI.Repository.UserRepo;

namespace SmartClassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public UsersController(IUserRepository userRepo, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _userRepo = userRepo; 
            _hubContext = hubContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepo.GetAll());
        }
        [HttpGet("/api/Users/NullLop")]
        public IActionResult GetGetByChuaAddAll()
        {
            return Ok(_userRepo.GetByChuaAdd());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userRepo.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }
        [HttpGet("/api/Users/loaiUser/{loaiUser}")]
        public IActionResult GetByLoaiUser(int loaiUser)
        {
            var user = _userRepo.GetByLoaiUser(loaiUser);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }

        }
        [HttpGet("/api/Users/lopHoc/{idLopHoc}")]
        public IActionResult GetByLopHoc(int idLopHoc)
        {
            var user = _userRepo.GetByLopHoc(idLopHoc);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, UserVM user)
        {
            //if (id != user.IdUser)
            //{
            //    return BadRequest();
            //}
            try
            {
                _userRepo.Update(id, user);
                return new JsonResult("Sửa Thành Công");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("/api/Users/updateLop/{id}")]
        public IActionResult UpdateLopHoc(int id)
        {
            //if (id != user.IdUser)
            //{
            //    return BadRequest();
            //}
            try
            {
                _userRepo.UpdateLopHoc(id);
                return new JsonResult("Sửa Thành Công");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("/api/Users/AddLop/{id}/{idLopHoc}")]
        public IActionResult AddLopHoc(int id, int idLopHoc)
        {
            try
            {
                _userRepo.AddLopHoc(id, idLopHoc);
                return new JsonResult("Thêm Thành Công");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("/api/Users/disableUser/{id}")]
        public IActionResult DisableUser(int id)
        {
            try
            {
                _userRepo.DisableUser(id);
                return new JsonResult("Đã thực hiện");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult Add(UserModel user)
        {
            try
            {
                _userRepo.Add(user);
                return new JsonResult("Thêm Thành Công");
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userRepo.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
