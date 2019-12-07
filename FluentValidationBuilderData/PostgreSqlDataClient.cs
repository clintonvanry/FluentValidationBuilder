using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;

namespace FluentValidationBuilderData
{
    public class PostgreSqlDataClient : IDataClient
    {
        private readonly ConnectionStrings options;

        static PostgreSqlDataClient()
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        // ReSharper disable once UnusedMember.Global
        // Used by IoC Registration
        public PostgreSqlDataClient(IOptions<ConnectionStrings> options)
        {
            this.options = options.Value;
        }

        public async ValueTask<IEnumerable<T>> Query<T>(IDataQuery query, CancellationToken token = default)
        {
            await using var conn = new NpgsqlConnection(options.PostgreSQLMediaServer);
            
            var commandDef = new CommandDefinition(query.CmdText,
                query.Parameters,
                commandTimeout: options.CommandTimeout,
                cancellationToken: token);

            return await conn.QueryAsync<T>(commandDef);
        
        }

        public async ValueTask<T> FirstOrDefault<T>(IDataQuery query, CancellationToken token = default)
        {
            await using var conn = new NpgsqlConnection(options.PostgreSQLMediaServer);
            var commandDef = new CommandDefinition(query.CmdText,
                query.Parameters,
                commandTimeout: options.CommandTimeout,
                cancellationToken: token);

            return (await conn.QueryAsync<T>(commandDef)).FirstOrDefault();
        }

        public async ValueTask<int> Execute(IDataQuery query, CancellationToken token = default)
        {
            await using var conn = new NpgsqlConnection(options.PostgreSQLMediaServer);
            var commandDef = new CommandDefinition(query.CmdText,
                query.Parameters,
                commandTimeout: options.CommandTimeout,
                cancellationToken: token);

            return await conn.ExecuteAsync(commandDef);
        }

        public async ValueTask<T> ExecuteScalar<T>(IDataQuery query, CancellationToken token = default)
        {
            await using var conn = new NpgsqlConnection(options.PostgreSQLMediaServer);
            var commandDef = new CommandDefinition(query.CmdText,
                query.Parameters,
                commandTimeout: options.CommandTimeout,
                cancellationToken: token);

            return await conn.ExecuteScalarAsync<T>(commandDef);
        }
    }
}