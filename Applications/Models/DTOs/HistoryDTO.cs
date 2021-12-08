using System;

namespace ChessApp.Applications.Models.DTOs
{
    public class HistoryDTO
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public string Opponent { get; set; }
        public MatchResult Result { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
    }
}