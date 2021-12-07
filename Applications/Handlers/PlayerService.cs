using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ChessApp.Applications.Interfaces;
using ChessApp.Applications.Models;
using Dapper;

namespace ChessApp.Applications.Handlers
{
    public class PlayerService : IPlayerService
    {
        private readonly IDapperService _dapperService;
        private const string CREATE_PROCEDURE = "CreatePlayer";
        private const string EXIST_PROCEDURE = "ExistPlayer";
        public PlayerService(IDapperService dapperService)
        {
            this._dapperService = dapperService;

        }
        public async Task<Player> CreatePlayerAsync(Player player)
        {
            if (await ExistPlayerAsync(player))
            {
                return null;
            }
            var parameters = new DynamicParameters();
            parameters.Add("@username", player.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("@password", player.Password, DbType.String, ParameterDirection.Input);
            await _dapperService.ExecuteAsync<Player>(CREATE_PROCEDURE, parameters);
            return player;
        }

        public Task DeletePlayerAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeletePlayerAsync(Player player)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistPlayerAsync(Player player)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@username", player.Username, DbType.String, ParameterDirection.Input);
            parameter.Add("@exist",dbType: DbType.Int32,direction:ParameterDirection.ReturnValue);
            await _dapperService.GetAsync<int>(EXIST_PROCEDURE, parameter);
            int exist = parameter.Get<int>("@exist");
            return exist == 1 ? true : false;
        }

        public async Task<Player> GetPlayerAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Player> UpdatePlayerAsync(Guid id, Player player)
        {
            throw new NotImplementedException();
        }
    }
}