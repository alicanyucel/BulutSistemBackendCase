﻿

namespace BulutSistem.Appllication.Services
{
    public interface IRedisService
    {
        Task SetAsync(string key, string value);
        Task<string> GetAsync(string key);
    }
}
