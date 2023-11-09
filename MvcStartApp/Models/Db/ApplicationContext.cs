using Microsoft.EntityFrameworkCore;

namespace MvcStartApp.Models.Db
{
    public sealed class ApplicationContext : DbContext
    {
        /// <summary>
        /// Метод-конструктор.
        /// </summary>
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Данные из таблицы Users.
        /// </summary>
        public DbSet<User> Users { get; set; }
     
        /// <summary>
        /// Данные из таблицы Posts.
        /// </summary>
        public DbSet<UserPost> Posts { get; set; }

        /// <summary>
        /// Данные из таблицы Requests.
        /// </summary>
        public DbSet<Request> Requests { get; set; }
    }
}
