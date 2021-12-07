
namespace ChessApp.Applications.Models.Interfaces
{
    public interface IUser
    {
         void SendMessage(string smg);
         void SetConnectStatus(bool value);
    }
}