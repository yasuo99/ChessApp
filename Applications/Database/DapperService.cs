using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ChessApp.Applications.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ChessApp.Applications.Database
{
    public class DapperService : IDapperService, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString = "DefaultConnection";
        public DapperService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Dispose()
        {

        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString(_connectionString)))
            {
                return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
            }
        }
        public IEnumerable<T> GetAll<T>(string storeProcedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure){
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString(_connectionString)))
            {
                return db.Query<T>(storeProcedure, parameters, commandType: commandType).ToList();
            }
        }
        public void Execute<T>(string storeProcedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure){
            using(IDbConnection db = GetConnection()){
                db.Execute(storeProcedure, parameters, commandType: commandType);
            }
        }
        public DbConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString(_connectionString));
        }

        public async Task<T> GetAsync<T>(string storeProcedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using(IDbConnection db = GetConnection()){
                var result = await db.QueryAsync<T>(storeProcedure, parameters, commandType: commandType);
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string storeProcedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using(IDbConnection db = GetConnection()){
                var result = await db.QueryAsync<T>(storeProcedure, parameters, commandType: commandType);
                return result.ToList();
            }
        }

        public async Task ExecuteAsync<T>(string storeProcedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using(IDbConnection db = GetConnection()){
                await db.ExecuteAsync(storeProcedure, parameters, commandType: commandType);
            }
        }
    }
}