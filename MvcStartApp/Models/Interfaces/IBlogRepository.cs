using MvcStartApp.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Interfaces
{
    public interface IBlogRepository
    {
        Task AddUserAsync(User user);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
