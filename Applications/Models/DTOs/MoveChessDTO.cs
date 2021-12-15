using System;

namespace ChessApp.Applications.Models.DTOs
{
    public class MoveChessDTO
    {
        public Guid MatchId { get; set; }
        public ChessPiece CurrentChess { get; set; }
        public ChessPiece MovedChess { get; set; }
    }
}