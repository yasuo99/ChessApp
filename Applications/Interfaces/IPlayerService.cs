using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChessApp.Applications.Models;

namespace ChessApp.Applications.Interfaces
{
    public interface IPlayerService
    {
         Task<IEnumerable<Player>> GetPlayersAsync();
         Task<Player> GetPlayerAsync(Guid id);
         Task<Player> CreatePlayerAsync(Player player);
         Task<Player> UpdatePlayerAsync(Guid id, Player player);
         Task DeletePlayerAsync(Guid id);
         Task DeletePlayerAsync(Player player);
         Task<bool> ExistPlayerAsync(Player player);
    }
}