using System;
using System.Collections.Generic;
using ChessApp.Applications.Messaging.Constants;
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
        private User _host;
        public User Host
        {
            get
            {
                return this._host;
            }
        }
        private User _opponent;
        public User Opponent
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
        public List<ChessPiece> OpponentKilled
        {
            get
            {
                return _opponentKilled;
            }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
        }
        private bool _isPause;
        public bool IsPause
        {
            get { return _isPause; }
        }
        private MatchStatus _status;
        public string Status
        {
            get
            {
                return _status.ToString();
            }
        }
        private bool _initFlag = false;
        public Match(User host, string title = null, User opponent = null)
        {

            _host = host;
            _opponent = opponent;
            _matchId = Guid.NewGuid();
            _hostKilled = new List<ChessPiece>();
            _opponentKilled = new List<ChessPiece>();
            _title = title ?? $"Match of {host.Player.Username}";
            _status = MatchStatus.Waiting;
        }
        public void InitChesses(List<ChessPiece> chessPieces)
        {

        }
        public void SetTitle(Guid hostId, string title)
        {
            if (_host.Id == hostId)
            {
                this._title = title;
            }
        }
        public void SetPause(bool value)
        {
            this._isPause = value;
        }
        public void InitMatch()
        {
            if (!_initFlag)
            {
                // White chess init 
                this._chesses = PlayGround.InitPlayGround();
                this._initFlag = true;
            }
        }
        public void MoveChess(ChessPiece current, ChessPiece move)
        {
            var currentIndex = this._chesses.FindIndex(chess => chess == current);
            var newIndex = this._chesses.FindIndex(chess => chess.X == move.X && chess.Y == move.Y);
            if (currentIndex != -1 && newIndex != -1)
            {
                this._chesses[currentIndex].Type = ChessType.Empty;
                this._chesses[newIndex].Type = current.Type;
            }
        }
        public void Attack(User player,ChessPiece current, ChessPiece attack)
        {
            var currentIndex = this._chesses.FindIndex(chess => chess == current);
            var attackIndex = this._chesses.FindIndex(chess => chess.X == attack.X && chess.Y == attack.Y);
            if(currentIndex != -1 && attackIndex != -1){
                this._chesses[currentIndex].Type = ChessType.Empty;
                this._chesses[attackIndex].Type = current.Type;
                if(attack.Type != ChessType.Empty){
                    if(player == Host){
                        HostKilled.Add(attack);
                    }else{
                        OpponentKilled.Add(attack);
                    }
                }
            }
        }
    }
}