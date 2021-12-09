using System;
using ChessApp.Applications.Messaging.Constants;

namespace ChessApp.Applications.Models.DTOs{
    public class LobbyMatchDTO{
        public Guid MatchId { get; set; }
        public string HostUsername { get; set; }
        public int HostWinCount { get; set; }
        public int HostLoseCount { get; set; }
        public int HostDrawCount { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
    }
}