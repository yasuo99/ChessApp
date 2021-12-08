using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChessApp.Applications.Models;

namespace ChessApp.Applications.Interfaces
{
    public interface IMatchService
    {
        IEnumerable<Match> GetMatches();
        void CreateMatch(Match match);
        bool MatchExistAsync(Guid matchId);
        bool PlayerMatchExistAsync(Guid hostId);
        bool CancelMatch(Guid hostId);
        bool StartMatch(Guid hostId, Guid opponentId);
    }
}