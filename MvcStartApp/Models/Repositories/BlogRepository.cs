using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;
using MvcStartApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationContext _context;
        public BlogRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddUserAsync(User user)
        {
                user.JoinTime = DateTime.Now;
                user.Id = Guid.NewGuid();

                var entry = _context.Entry(user);

                if (entry.State == EntityState.Detached)
                {
                    await _context.Users.AddAsync(user);
                }

                await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
