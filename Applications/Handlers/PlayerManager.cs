using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ChessApp.Applications.Interfaces;
using ChessApp.Applications.Models;

namespace ChessApp.Applications.Handlers
{
    public class PlayerManager : IPlayerManager
    {
        public ConcurrentDictionary<string, User> OnlinePlayers { get; set; }
        private readonly ILogging _logging;
        public PlayerManager(ILogging logging)
        {
            _logging = logging;
            OnlinePlayers = new ConcurrentDictionary<string, User>();
        }

        public List<User> GetPlayers()
        {
            return OnlinePlayers.Select(sel => sel.Value).ToList();
        }

        public void AddPlayer(User user)
        {
            if (!ExistPlayer(user.SessionId))
            {
                var result = OnlinePlayers.TryAdd(user.SessionId, user);
                if (result)
                {
                    _logging.Info($"New user connected");
                }
                else
                {
                    _logging.Error("Add user error");
                }
            }
        }

        public User GetPlayer(string clientId)
        {
            if (ExistPlayer(clientId))
            {
                var result = OnlinePlayers.TryGetValue(clientId, out var user);
                if(result){
                    return user;
                }
                return null;
            }
            return null;
        }

        public void RemovePlayer(string clientId)
        {
            if(ExistPlayer(clientId)){
                var result = OnlinePlayers.TryRemove(clientId, out var player);
                if(result){
                    _logging.Info("User removed");
                }
                else{
                    _logging.Error("Remove user error");
                }
            }
        }

        public void RemovePlayer(User user)
        {
            RemovePlayer(user.SessionId);
        }

        public bool ExistPlayer(string clientId)
        {
            return OnlinePlayers.Any(player => player.Key.Equals(clientId));
        }
    }
}