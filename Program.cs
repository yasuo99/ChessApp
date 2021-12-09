using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Threading.Tasks;
using ChessApp.Applications.Database;
using ChessApp.Applications.Handlers;
using ChessApp.Applications.Interfaces;
using ChessApp.Applications.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChessApp
{
    class Program
    {
        public const string ConnectionString = "Server=DESKTOP-6D89894;Database=Chess;Trusted_Connection=True";
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
            {
                services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(ConnectionString));
                services.AddSingleton<ILogging, Logging>();
                services.AddSingleton<IMatchManager, MatchManager>();
                services.AddScoped<IMatchService, MatchService>();
                services.AddScoped<IDapperService, DapperService>();
                services.AddScoped<IPlayerService, PlayerService>();
                services.AddScoped<IPlayerManager, PlayerManager>();
                
            });
            return host;
        }
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.StartAsync();
            var loggingService = host.Services.GetRequiredService<ILogging>();

            var dapperService = host.Services.GetRequiredService<IDapperService>();

            var playerService = host.Services.GetRequiredService<IPlayerService>();

            var playerManagerService = host.Services.GetRequiredService<IPlayerManager>();

            var matchService = host.Services.GetRequiredService<IMatchService>();

            WsGameServer wsGameServer = new WsGameServer(IPAddress.Any, 8080,
            loggingService, playerManagerService, matchService, playerService);
            wsGameServer.StartServer();
            for (; ; )
            {
                var cmd = Console.ReadLine();
                if (cmd == "stop")
                {
                    wsGameServer.StopServer();
                    await host.StopAsync();
                    host.Dispose();
                    break;
                }
                if (cmd == "restart")
                {
                    wsGameServer.RestartServer();
                }
                if (cmd == "get players")
                {
                    var result = await Task.FromResult(dapperService.GetAll<Player>($"GetPlayers", null, commandType: CommandType.StoredProcedure));
                }
                if (cmd == "create player")
                {
                    var player = new Player
                    {
                        Id = Guid.NewGuid(),
                        Username = "Thanhpro1233",
                        Password = "Thanhpro1@",
                    };
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@id", player.Id, DbType.Guid);
                    parameter.Add("@username", player.Username, DbType.String);
                    parameter.Add("@password", player.Password, DbType.String);
                    dapperService.Execute<Player>($"Insert into player(id, username,password, wincount, losecount, drawcount) values(@id,@username, @password, 0, 0, 0)", parameter, commandType: CommandType.Text);
                }
                if(cmd == "ping"){
                    wsGameServer.SendAll("This is message from server");
                }
                if (cmd == "check")
                {
                    var player = new Player
                    {
                        Id = Guid.NewGuid(),
                        Username = "Thanhpro12",
                        Password = "Thanhpro1@",
                    };
                    var result = await playerService.ExistPlayerAsync(player);
                }
            }
        }

    }
}
