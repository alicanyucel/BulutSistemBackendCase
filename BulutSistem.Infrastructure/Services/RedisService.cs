using BulutSistem.Appllication.Services;
using StackExchange.Redis;


namespace BulutSistem.Infrastructure.Services
{
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;

        public RedisService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _database = _connectionMultiplexer.GetDatabase();
        }

        public async Task SetAsync(string key, string value)
        {
            await _database.StringSetAsync(key, value);
        }

        public async Task<string> GetAsync(string key)
        {
            return await _database.StringGetAsync(key);
        }
    }
}