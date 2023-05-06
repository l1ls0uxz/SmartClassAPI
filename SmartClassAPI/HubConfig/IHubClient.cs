using System.Threading.Tasks;

namespace SmartClassAPI.HubConfig
{
    public interface IHubClient
    {
        Task BroadcastMessage();
    }
}
