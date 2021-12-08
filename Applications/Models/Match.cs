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
        public List<ChessPiece> OpponentKilled{
            get{
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
            get { return IsPause; }
        }
        private MatchStatus _status;
        public string Status{
            get{
                return _status.ToString();
            }
        }
        public Match(User host, string title = null, User opponent = null)
        {

            _host = host;
            _opponent = opponent;
            _matchId = Guid.NewGuid();
            _hostKilled = new List<ChessPiece>();
            _opponentKilled = new List<ChessPiece>();
            _title = title ?? $"Match of {host.Player.Username}";
        }
        public void InitChesses(){

        }
        public void SetTitle(Guid hostId ,string title){
            if(_host.Id == hostId){
                this._title = title;
            }
        }
        public void SetPause(bool value){
            this._isPause = value;
        }
    }
}