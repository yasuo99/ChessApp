using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessApp.Applications.Models
{
    public class MatchHistory
    {
        [Key]
        public int Id { get; set; }
        public Guid HostId { get; set; }
        [ForeignKey(nameof(HostId))]
        public virtual Player Host { get; set; }
        public Guid OpponentId { get; set; }
        [ForeignKey(nameof(OpponentId))]
        public virtual Player Opponent { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public MatchResult MatchResult { get; set; }
    }
    public enum MatchResult{
        Win = 1,
        Draw = 2,
        Lose = 3
    }
}