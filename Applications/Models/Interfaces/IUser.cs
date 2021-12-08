
using ChessApp.Applications.Messaging;

namespace ChessApp.Applications.Models.Interfaces
{
    public interface IUser
    {
        bool SendMessage(string smg);
        void SetConnectStatus(bool value);
        bool SendMessage<T>(WsMessage<T> wsMessage);
    }
}