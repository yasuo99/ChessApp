using System;
using System.Collections.Generic;

namespace ChessApp.Applications.Models.DTOs
{
    public class MatchInitDTO
    {
        public Guid MatchId { get; set; }
        public List<ChessPiece> Pieces { get; set; }
    }
}