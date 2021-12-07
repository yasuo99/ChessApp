using System.IO;
using ChessApp.Applications.Interfaces;
using Serilog;

namespace ChessApp.Applications.Handlers
{
    public class Logging: ILogging
    {
        private readonly ILogger _logger;
        public Logging()
        {
            System.Console.WriteLine("Create by host");
            _logger = new LoggerConfiguration()
            .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .WriteTo.File(Path.Combine(@"E:\",@"Logging\log~.txt"), Serilog.Events.LogEventLevel.Error, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();
        }

        public void Error(string content)
        {

            _logger.Error(content);
        }

        public void Info(string content)
        {
            _logger.Information($">>>>>>>>>>>>>>> {content}");
        }

        public void Print(string content)
        {
            _logger.Information($">>>>>>>>>>>>>>> {content}");
        }

        public void Warning(string content)
        {
            _logger.Warning(content);
        }
    }
}