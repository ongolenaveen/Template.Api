using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Template.Domain.Models;
using Template.Services.Interfaces;

namespace Template.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class HostController: ControllerBase
    {
        private readonly IHostService _hostService;
        public HostController(IHostService hostService)
        {
            _hostService = hostService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Host), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Host>> Get()
        {
            return await _hostService.Get();
        }
    }
}
