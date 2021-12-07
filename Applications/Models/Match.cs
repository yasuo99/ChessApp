using System;
using System.Collections.Generic;
using ChessApp.Applications.Models.Constants;

namespace ChessApp.Applications.Models
{
    public class Match
    {
        private Guid _matchId;
        public Guid MatchId
        {
            get
            {
                return this._matchId;
            }
        }
        private List<ChessPiece> _chesses;
        public List<ChessPiece> Chesses
        {
            get
            {
                return _chesses;
            }
        }
        private Player _host;
        public Player Host
        {
            get
            {
                return this._host;
            }
        }
        private Player _opponent;
        public Player Opponent
        {
            get
            {
                return this._opponent;
            }
        }
        private List<ChessPiece> _hostKilled { get; set; }

        public List<ChessPiece> HostKilled
        {
            get
            {
                return _hostKilled;
            }
        }
        private List<ChessPiece> _opponentKilled { get; set; }
        public List<ChessPiece> OpponentKilled{
            get{
                return _opponentKilled;
            }
        }

        public Match(Player host, Player opponent, List<ChessPiece> chesses)
        {

            _host = host;
            _opponent = opponent;
            _chesses = chesses;
            _matchId = Guid.NewGuid();
            _hostKilled = new List<ChessPiece>();
            _opponentKilled = new List<ChessPiece>();

        }
    }
}