using System.Collections.Generic;

namespace ChessApp.Applications.Models.Constants
{
    public class PlayGround
    {
        public static List<ChessPiece> InitPlayGround()
        {
            List<ChessPiece> DefaultPlayGround = new List<ChessPiece>();
            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 8; x++)
                {
                    var chessPiece = new ChessPiece();
                    chessPiece.Y = y;
                    if (y == 1)
                    {
                        chessPiece.Type = ChessType.Pawn;
                        chessPiece.Side = ChessSide.Black;
                    }
                    else if (y == 6)
                    {
                        chessPiece.Type = ChessType.Pawn;
                        chessPiece.Side = ChessSide.White;
                    }
                    else if (y == 0 || y == 7)
                    {
                        chessPiece.Side = y == 0 ? ChessSide.Black : ChessSide.White;
                        if (x == 0 || x == 7)
                        {
                            chessPiece.Type = ChessType.Rook;
                        }
                        if (x == 1 || x == 6)
                        {
                            chessPiece.Type = ChessType.Knight;
                        }
                        if (x == 2 || x == 5)
                        {
                            chessPiece.Type = ChessType.Bishop;
                        }
                        if (x == 3)
                        {
                            chessPiece.Type = ChessType.Queen;
                        }
                        if (x == 4)
                        {
                            chessPiece.Type = ChessType.King;
                        }
                    }else{
                        chessPiece.Type = ChessType.Empty;
                        chessPiece.Side = ChessSide.None;
                    }
                    chessPiece.X = x;
                    DefaultPlayGround.Add(chessPiece);
                }
            }
            return DefaultPlayGround;
        }
    }
}