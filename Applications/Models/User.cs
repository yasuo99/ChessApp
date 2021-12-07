using System;
using System.Text;
using ChessApp.Applications.Handlers;
using ChessApp.Applications.Helpers;
using ChessApp.Applications.Interfaces;
using ChessApp.Applications.Messaging;
using ChessApp.Applications.Models.Interfaces;
using NetCoreServer;

namespace ChessApp.Applications.Models
{
    public class User : WsSession, IUser
    {
        public string SessionId;
        public bool IsDisconnected;
        private readonly ILogging _logger;
        public User(WsServer server, ILogging logger) : base(server)
        {
            SessionId = this.Id.ToString();
            _logger = logger;
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
            ((WsGameServer)Server).SendAll($"{this.SessionId} send message {msg}");
            switch (parsedMessage.Tag)
            {
                case WsTag.Login:
                    break;
                case WsTag.Register:
                    var player = GameHelper.ParseObject<Player>(parsedMessage.Data.ToString());
                    
                    break;
                case WsTag.GetLobbies:
                    break;
                case WsTag.InitBoard:
                    break;
                case WsTag.StartMatch:
                    break;
                case WsTag.MoveChess:
                    break;
                default:
                    break;
            }
        }

        public void SendMessage(string msg)
        {
            this.SendTextAsync(msg);
        }

        public void SetConnectStatus(bool value)
        {
            throw new System.NotImplementedException();
        }
        public void OnDisconnect() // User disconnected
        {
            System.Console.WriteLine("Player has disconnect");
        }
    }
}