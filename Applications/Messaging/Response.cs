namespace ChessApp.Applications.Messaging
{
    public static class WsResponse
    {
        public static WsResponse<T> Success<T>(string message, T data) => new WsResponse<T>(message, data, ResponseTag.Success);
        public static WsResponse<T> Fail<T>(string message, T data) => new WsResponse<T>(message, data, ResponseTag.Fail);
        public static WsResponse<T> ServerResponse<T>(string message, T data, ResponseTag tag) => new WsResponse<T>(message, data, tag);
    }
    public class WsResponse<T>{
        public string Tag;
        public T Data;
        public string Message;

        public WsResponse(string message, T data, ResponseTag tag)
        {
            Message = message;
            Data = data;
            Tag = tag.ToString();
        }
    }
    public enum ResponseTag{
        Invalid,
        Valid,
        Success,
        Fail,
        Unauthorized,
        BadRequest
    }
}