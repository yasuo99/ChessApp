using System;
using System.Collections.Concurrent;
using ChessApp.Applications.Interfaces;
using ChessApp.Applications.Models;

namespace ChessApp.Applications.Handlers
{
    public class MatchManager : IMatchManager
    {
        public ConcurrentDictionary<Guid, Match> matches{get;set;}
        public MatchManager()
        {
            matches = new ConcurrentDictionary<Guid, Match>();
        }

        public void AddMatch(Match match)
        {
            throw new NotImplementedException();
        }

        public void RemoveMatch(Match match)
        {
            throw new NotImplementedException();
        }

        public void RemoveMatch(Guid matchId)
        {
            throw new NotImplementedException();
        }
    }
}