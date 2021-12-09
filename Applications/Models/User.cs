using System;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Applications.Handlers;
using ChessApp.Applications.Helpers;
using ChessApp.Applications.Interfaces;
using ChessApp.Applications.Messaging;
using ChessApp.Applications.Models.DTOs;
using ChessApp.Applications.Models.Interfaces;
using NetCoreServer;

namespace ChessApp.Applications.Models
{
    public class User : WsSession, IUser
    {
        public string SessionId;
        private Guid _sessionId;
        public bool IsDisconnected;
        private Player _player;
        public Player Player
        {
            get
            {
                return _player;
            }
        }
        private readonly ILogging _logger;
        private readonly IMatchService _matchService;
        private readonly IPlayerManager _playerManager;
        public User(WsServer server, ILogging logger, IMatchService matchService, IPlayerManager playerManager) : base(server)
        {
            SessionId = this.Id.ToString();
            _sessionId = this.Id;
            _logger = logger;
            _matchService = matchService;
            _playerManager = playerManager;
        }
        public override void OnWsConnected(HttpRequest request)
        {
            _logger.Print("User connected");
            IsDisconnected = false;
        }
        public override void OnWsDisconnected()
        {
            OnDisconnect();
            base.OnWsDisconnected();
        }
        public override void OnWsReceived(byte[] buffer, long offset, long size)
        {
            var msg = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            var parsedMessage = GameHelper.ParseObject<WsMessage<object>>(msg);
            switch (parsedMessage.Tag)
            {
                case WsTag.Login:
                    var loginData = GameHelper.ParseObject<LoginDTO>(parsedMessage.Data.ToString());
                    if (this._player == null)
                    {
                        var loginPlayer = _playerManager.LoginPlayer(loginData.Username, loginData.Password);
                        if (loginPlayer != null)
                        {
                            this._player = loginPlayer;
                            this.SendMessage(GameHelper.SerializedObject(WsResponse.Success<string>($"{loginPlayer.Username} logged in", null)));
                        }
                        else
                        {
                            this.SendMessage(GameHelper.SerializedObject(WsResponse.Fail<string>($"Can't find player with username {loginData.Username}", null)));
                        }
                    }
                    else
                    {
                          this.SendMessage(GameHelper.SerializedObject(WsResponse.Success<string>($"{this._player.Username} already logged in", null)));
                    }
                    break;
                case WsTag.Register:
                    var player = GameHelper.ParseObject<Player>(parsedMessage.Data.ToString());

                    break;
                case WsTag.CreateMatch:
                    var matchDto = GameHelper.ParseObject<MatchDTO>(parsedMessage.Data.ToString());
                    if (!_matchService.MatchExistAsync(_sessionId))
                    {
                        var host = _playerManager.GetPlayer(this.SessionId);
                        var match = new Match(host);
                        _matchService.CreateMatch(match);
                    }
                    break;
                case WsTag.CancelMatch:
                    break;
                case WsTag.GetLobbies:
                    var matches = _matchService.GetMatches();
                    break;
                case WsTag.InitBoard:
                    break;
                case WsTag.StartMatch:

                    break;
                case WsTag.MoveChess:

                    break;
                case WsTag.PauseMatch:
                    break;
                default:
                    break;
            }
        }

        public bool SendMessage(string msg)
        {
            return this.SendTextAsync(msg);
        }

        public void SetConnectStatus(bool value)
        {
            throw new System.NotImplementedException();
        }
        public void OnDisconnect() // User disconnected
        {
            System.Console.WriteLine("Player has disconnect");
        }

        public bool SendMessage<T>(WsMessage<T> wsMessage)
        {
            var mes = GameHelper.SerializedObject(wsMessage);
            return this.SendMessage(mes);
        }
    }
}