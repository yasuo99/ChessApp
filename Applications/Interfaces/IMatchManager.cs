using System;
using System.Collections.Concurrent;
using ChessApp.Applications.Models;

namespace ChessApp.Applications.Interfaces
{
    public interface IMatchManager
    {
        ConcurrentDictionary<Guid, Match> matches{get;set;}
        void AddMatch(Match match);
        void RemoveMatch(Match match);
        void RemoveMatch(Guid matchId);
    }
}