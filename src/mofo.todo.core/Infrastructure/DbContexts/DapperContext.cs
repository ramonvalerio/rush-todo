using Dapper;
using mofo.todo.common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace mofo.todo.core.Infrastructure.DbContexts
{
    public class DapperContext : IDapperContext
    {
        protected string _connectionString;

        public DapperContext()
        {
            _connectionString = @"Server=db;Database=master;User=sa;Password=mofo@123;";
        }

        public async Task<IEnumerable<T>> ExecuteManyAsync<T>(string sql) where T : AggregateRoot
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    return await connection.QueryAsync<T>(sql);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<T> ExecuteSingleAsync<T>(string sql) where T : AggregateRoot
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    return await connection.QuerySingleAsync<T>(sql);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task ExecuteAsync(string sql)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    await connection.ExecuteAsync(sql);
                    return;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}