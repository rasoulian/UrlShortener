using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging; 

namespace UrlShortener.Web.Services
{
    public interface IShortensService
    {
        IEnumerable<string> FindAll();

        string Find(string code);
    }

    public class ShortensService : IShortensService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ShortensService> _logger;
        
        public ShortensService(IConfiguration configuration, ILogger<ShortensService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public IEnumerable<string> FindAll()
        {
            _logger.LogDebug("{method} called", nameof(FindAll));

            return new[] { "value1", "value2" };
        }

        public string Find(string code)
        {
            _logger.LogDebug("{method} called with {id}", nameof(Find), code);
            var url = _configuration.GetSection("Urls")[code];

            return url;
        }
    }
}
