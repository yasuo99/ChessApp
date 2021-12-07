using System.Collections.Generic;

namespace ChessApp.Applications.Models.Interfaces
{
    public interface IChessPiece
    {
        List<IChessPiece> Attacked{get;set;}
        int CurrentRow { get; set; }
        int CurrentColumn { get; set; }
        bool Available { get; set; }
        bool IsAlly{get;set;}
        bool Move();
        bool Attack(IChessPiece opponentChesspiece);
    }
}