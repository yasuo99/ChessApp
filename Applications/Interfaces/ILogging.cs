namespace ChessApp.Applications.Interfaces
{
    public interface ILogging
    {
        void Print(string content);
        void Info(string content);
        void Warning(string content);
        void Error(string content);
    }
}