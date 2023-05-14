using Microsoft.AspNetCore.SignalR;

namespace SignalRBasics.Hubs
{
    public class DeathlyHallowsHub : Hub
    {
        public Dictionary<string, int> GetRaceStatus()
        {
            return StaticDetails.DealthyHallowRace;
        }
    }
}
