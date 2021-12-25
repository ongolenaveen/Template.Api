using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Template.Domain.Interfaces;
using Template.Domain.Models;

namespace Template.DataProvider
{
    public class HostDataProvider : IHostDataProvider
    {
        private readonly ILogger<HostDataProvider> _logger;
        
        public HostDataProvider(ILogger<HostDataProvider> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(HostDataProvider));
        }
        public async Task<Host> GetHost()
        {
            _logger.LogInformation($"Executing HostService");
            var ipAddressList = new List<string>();
            var hostName = Dns.GetHostName();
            var ipaddress = Dns.GetHostAddresses(hostName);
            ipAddressList.AddRange(from ip in ipaddress
                                   select ip.ToString());
            var host = new Host { Name = hostName, IpAddress = ipAddressList };
            var output = JsonConvert.SerializeObject(host);
            _logger.LogInformation($"Finished Executing HostService. Sending {output}");
            return await Task.FromResult(host);
        }
    }
}
