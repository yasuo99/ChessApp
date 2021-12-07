using System.Collections.Concurrent;
using System.Collections.Generic;
using ChessApp.Applications.Models;

namespace ChessApp.Applications.Interfaces
{
    public interface IPlayerManager
    {
         ConcurrentDictionary<string,User> OnlinePlayers{get;set;}
         List<User> GetPlayers();
         void AddPlayer(User player);
         bool ExistPlayer(string clientId);
         User GetPlayer(string clientId);
         void RemovePlayer(string clientId);
         void RemovePlayer(User player);

    }
}