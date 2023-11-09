using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;
using MvcStartApp.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationContext _context;
        public RequestRepository(ApplicationContext context) 
        {
            _context = context;
        }

        public async Task AddRequest(Request request)
        {
            var entry = _context.Entry(request);

            if (entry.State == EntityState.Detached)
            {
                await _context.Requests.AddAsync(request);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Request>> GetRequestsAsync()
        {
            return await _context.Requests.ToListAsync();
        }
    }
}
