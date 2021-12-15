using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ChessApp.Applications.Interfaces;
using ChessApp.Applications.Models;

namespace ChessApp.Applications.Handlers
{
    public class MatchManager : IMatchManager
    {
        private ConcurrentDictionary<Guid, Match> _matches { get; set; }
        public MatchManager()
        {
            _matches = new ConcurrentDictionary<Guid, Match>();
        }

        public void AddMatch(Match match)
        {
            if(!ExistMatch(match.MatchId)){
                _matches.TryAdd(match.MatchId, match);
            }
        }

        public void RemoveMatch(Match match)
        {
            RemoveMatch(match.MatchId);
        }
        public void RemoveMatch(Guid matchId)
        {
            var result = _matches.TryRemove(matchId, out var match);
        }

        public Match GetMatch(Guid matchId)
        {
            _matches.TryGetValue(matchId, out var match);
            return match;
        }

        public bool ExistMatch(string hostId)
        {
            return _matches.Any(m => m.Value.Host.SessionId.ToString() == hostId);
        }

        public Match GetMatch(string hostId)
        {
            return _matches.FirstOrDefault(m => m.Value.Host.SessionId.ToString().Equals(hostId)).Value;
        }

        public bool ExistMatch(Guid matchId)
        {
            return _matches.Any(m => m.Key == matchId);
        }

        public IEnumerable<Match> GetMatches()
        {
            return _matches.Select(sel => sel.Value).ToList();
        }

        public Match InitMatch(Guid matchId)
        {
            var result = _matches.TryGetValue(matchId, out var match);
            if(result){
                match.InitMatch();
                _matches[matchId] = match;
                return match;
            }
            return null;
            
        }
    }
}