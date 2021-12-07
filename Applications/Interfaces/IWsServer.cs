using System.Net;

namespace ChessApp.Applications.Interfaces
{
    public interface IWsServer
    {
        void StartServer();
        void StopServer();
        void RestartServer();
        void SendAll(string template);
    }
}