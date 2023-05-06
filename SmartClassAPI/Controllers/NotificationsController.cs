using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SmartClassAPI.Data;
using SmartClassAPI.HubConfig;
using SmartClassAPI.Model;
using SmartClassAPI.Repository.UserRepo;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SmartClassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly IUserRepository _userRepo;

        public NotificationsController(MyDbContext context, IHubContext<BroadcastHub, IHubClient> hubContext, IUserRepository userRepo)
        {
            _context = context;
            _hubContext = hubContext;
            _userRepo = userRepo;
        }
        [HttpGet("UserCount")]
        public async Task<ActionResult<NotifiCountResult>> GetUserCount()
        {
            var count = (from not in _context.Notifications select not).CountAsync();
            NotifiCountResult result = new NotifiCountResult
            {
                Count = await count
            };
            return result;
        }

        // GET: api/Notifications/notificationresult  
        [Route("notificationresult")]
        [HttpGet]
        public async Task<ActionResult<List<NotificationResult>>> GetNotificationMessage()
        {
            var results = from message in _context.Notifications
                          orderby message.Id descending
                          select new NotificationResult
                          {
                              HoTen = message.HoTen,
                              TranType = message.TranType
                          };
            return await results.ToListAsync();
        }

        // DELETE: api/Notifications/deletenotifications  
        [HttpDelete]
        [Route("deletenotifications")]
        public async Task<IActionResult> DeleteNotifications()
        {
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Notification");
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();

            return NoContent();
        }
    }
}
