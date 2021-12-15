using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ChessApp.Applications.Models;

namespace ChessApp.Applications.Interfaces
{
    public interface IMatchManager
    {
        IEnumerable<Match> GetMatches();
        Match InitMatch(Guid matchId);
        Match GetMatch(string hostId);
        Match GetMatch(Guid matchId);
        bool ExistMatch(Guid matchId);
        bool ExistMatch(string hostId);
        void AddMatch(Match match);
        void RemoveMatch(Match match);
        void RemoveMatch(Guid matchId);
    }
}