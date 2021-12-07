namespace ChessApp.Applications.Messaging
{
    public interface IWsMessage<T> where T: class
    {
        WsTag Tag{get;set;}
        T Data {get;set;}
    }
}