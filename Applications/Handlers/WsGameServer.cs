using System.Net;
using ChessApp.Applications.Interfaces;
using ChessApp.Applications.Models;
using NetCoreServer;

namespace ChessApp.Applications.Handlers
{
    public class WsGameServer : WsServer, IWsServer
    {
        private int _port;
        private IPAddress _address;
        private readonly ILogging _logging;
        private readonly IPlayerManager _playerManager;
        public WsGameServer(IPAddress address, int port, ILogging logging, IPlayerManager playerManager) : base(address, port)
        {
            _port = port;
            _logging = logging;
            _playerManager = playerManager;
        }
        protected override TcpSession CreateSession()
        {
            _logging.Info($"New connected {this.Id}");
            User user = new User(this, _logging);
            _playerManager.AddPlayer(user);
            return user;
        }

        protected override void OnDisconnected(TcpSession session)
        {
            _logging.Info($"Client disconnected {session.Id}");
        }
        public void RestartServer()
        {
            base.Restart();
            _logging.Info("Server restarted");
        }

        public void StartServer()
        {
            _logging.Info($"Server started at port {this._port}");
            base.Start();
        }

        public void StopServer()
        {
            base.Stop();
            _logging.Info("Server stopped");
        }

        public void SendAll(string template)
        {
            base.MulticastText(template);
        }
    }
}