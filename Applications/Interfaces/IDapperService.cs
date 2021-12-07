using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;

namespace ChessApp.Applications.Interfaces
{
    public interface IDapperService
    {
        DbConnection GetConnection();
        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<T> GetAsync<T>(string storeProcedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        IEnumerable<T> GetAll<T>(string storeProcedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<T>> GetAllAsync<T>(string storeProcedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        void Execute<T>(string storeProcedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        Task ExecuteAsync<T>(string storeProcedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
      
    }
}