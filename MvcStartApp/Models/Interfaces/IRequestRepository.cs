using MvcStartApp.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Interfaces
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
        Task<IEnumerable<Request>> GetRequestsAsync();
    }
}
