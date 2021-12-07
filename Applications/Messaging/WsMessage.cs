namespace ChessApp.Applications.Messaging
{
    public class WsMessage<T> : IWsMessage<T> where T: class
    {
        public WsTag Tag { get;set; }
        public T Data { get; set; }
        public WsMessage(WsTag tag, T data)
        {
            Tag = tag;
            Data = data;
        }
    }
}