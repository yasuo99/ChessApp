using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessApp.Applications.Interfaces;
using ChessApp.Applications.Messaging.Constants;
using ChessApp.Applications.Models;

namespace ChessApp.Applications.Handlers
{
    public class MatchService : IMatchService
    {
        private readonly IDapperService _dapperService;
        private readonly IMatchManager _matchManager;
        public MatchService(IDapperService dapperService, IMatchManager matchManager)
        {
            _dapperService = dapperService;
            _matchManager = matchManager;
        }
        public bool CancelMatch(Guid hostId)
        {
            var match = _matchManager.GetMatch(hostId);
            _matchManager.RemoveMatch(match);
            return true;
        }

        public void CreateMatch(Match match)
        {
            _matchManager.AddMatch(match);
        }

        public Match GetMatch(Guid matchId)
        {
            return _matchManager.GetMatch(matchId);
        }

        public IEnumerable<Match> GetMatches()
        {
            return _matchManager.GetMatches();
        }

        public Match InitMatch(Guid matchId)
        {
            return _matchManager.InitMatch(matchId);
        }

        public bool MatchExistAsync(Guid matchId)
        {
            return _matchManager.ExistMatch(matchId);
        }

        public bool PlayerMatchExistAsync(Guid hostId)
        {
            return _matchManager.ExistMatch(hostId.ToString());
        }

        public bool StartMatch(Guid hostId, Guid opponentId)
        {
            throw new NotImplementedException();
        }
    }
}