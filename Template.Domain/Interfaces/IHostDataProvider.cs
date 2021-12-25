using System.Threading.Tasks;
using Template.Domain.Models;

namespace Template.Domain.Interfaces
{
    public interface IHostDataProvider
    {
        Task<Host> GetHost();
    }
}
