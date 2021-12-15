using System.Collections.Generic;
using ChessApp.Applications.Models.Interfaces;

namespace ChessApp.Applications.Models
{
    public class ChessPiece
    {
        public ChessType Type { get; set; }
        public ChessSide Side { get; set; }
        public int X {get;set;}
        public int Y {get;set;}
        public void Move(int x, int y){
            this.X = x;
            this.Y = y;
        }
    }
    public enum ChessSide{
        None = 0,
        Black = 1,
        White = 2
    }
    public enum ChessType
    {
        Empty = 0,
        Pawn = 1,
        Bishop = 2,
        Knight = 3,
        Rook = 4,
        Queen = 5,
        King = 6
    }
}