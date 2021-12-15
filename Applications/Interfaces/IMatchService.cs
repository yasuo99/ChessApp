using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChessApp.Applications.Models;

namespace ChessApp.Applications.Interfaces
{
    public interface IMatchService
    {
        IEnumerable<Match> GetMatches();
        Match GetMatch(Guid matchId);
        Match InitMatch(Guid matchId);
        void CreateMatch(Match match);
        /// <summary>
        /// Check if match exist with the given matchId
        /// </summary>
        /// <param name="matchId">matchId</param>
        /// <returns>boolean</returns>
        bool MatchExistAsync(Guid matchId);
        bool PlayerMatchExistAsync(Guid hostId);
        bool CancelMatch(Guid hostId);
        bool StartMatch(Guid hostId, Guid opponentId);
        bool StartMatch(Guid matchId);
    }
}