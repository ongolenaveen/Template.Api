using System.Threading.Tasks;
using Template.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Template.Domain.Models;
using Template.Domain.Interfaces;
using System;

namespace Template.Services
{
    public class HostService : IHostService
    {
        private readonly ILogger<HostService> _logger;
        private readonly IHostDataProvider _hostDataProvider;
        public HostService(ILogger<HostService> logger, IHostDataProvider hostDataProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _hostDataProvider = hostDataProvider ?? throw new ArgumentNullException(nameof(hostDataProvider));
        }
        public async Task<Host> Get()
        {
            _logger.LogInformation($"Executing HostService");
            var response = await _hostDataProvider.GetHost();
            _logger.LogInformation($"Finished Executing HostService. Sending {response}");
            return response;
        }
    }
}
