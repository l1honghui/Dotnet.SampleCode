using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aop.AspnetCore.Demo
{
    public interface IAopService
    {
        [DefaultAspect]
        public string Handle(string request);

        [DefaultAspect]
        public void Handle();


        [DefaultAspect]
        [Stopwatch]
        public Task<string> HandleAsync(string request);

    }

    public class AopService : IAopService
    {
        private ILogger<AopService> _logger;

        public AopService(ILogger<AopService> logger)
        {
            _logger = logger;
        }

        public string Handle( string request)
        {
            return "handle request";
        }

        public void Handle()
        {
        }

        public Task<string> HandleAsync(string request)
        {
            return Task.FromResult("handle async request");
        }
    }
}
