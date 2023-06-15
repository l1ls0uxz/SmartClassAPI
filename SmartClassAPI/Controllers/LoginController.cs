using Microsoft.AspNetCore.Mvc;
using SmartClassAPI.Data;
using SmartClassAPI.Repository.UserRepo;
using System.Threading.Tasks;

namespace SmartClassAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userRepository.CheckLogin(request.UserName, request.Password);

            if (user != null)
            {
                return Ok(new LoginResponse
                {
                    ErrType = 1,
                    Message = "Login successful",
                    User = user
                });
            }
            else
            {
                return Ok(new LoginResponse
                {
                    ErrType = 2,
                    Message = "Incorrect username or password"
                });
            }
        }
    }
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public int ErrType { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
    }
}
