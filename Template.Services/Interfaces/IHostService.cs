using System.Threading.Tasks;
using Template.Domain.Models;

namespace Template.Services.Interfaces
{
    public interface IHostService
    {
        Task<Host> Get();
    }
}
