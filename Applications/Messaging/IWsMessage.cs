namespace ChessApp.Applications.Messaging
{
    public interface IWsMessage<T>
    {
        WsTag Tag{get;set;}
        T Data {get;set;}
    }
}