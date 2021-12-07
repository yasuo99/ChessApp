using ChessApp.Applications.Models.Interfaces;

namespace ChessApp.Applications.Models
{
    public class Move
    {
        public int NextRow { get; set; }
        public int NextColumn { get; set; }
        public IChessPiece Chess { get; set; }
    }
}