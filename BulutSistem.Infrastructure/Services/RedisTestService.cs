using StackExchange.Redis;
namespace BulutSistem.Infrastructure.Services
{
    public class RedisTestService
    {
        private readonly IConnectionMultiplexer _redisConnection;

        public RedisTestService(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
        }

        public void TestConnection()
        {
            try
            {
                var db = _redisConnection.GetDatabase();
                var pong = db.Ping();  // Redis'e ping atıyoruz
                Console.WriteLine($"Redis connection successful. Response: {pong}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Redis connection failed. Error: {ex.Message}");
            }
        }
    }

}
