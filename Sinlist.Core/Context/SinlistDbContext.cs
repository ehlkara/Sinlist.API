using Microsoft.EntityFrameworkCore;
using Sinlist.Models.Entities.Sinlist;

namespace Sinlist.Core.Context
{
    public class SinlistDbContext : DbContext
    {
        public SinlistDbContext(DbContextOptions<SinlistDbContext> options) : base(options)
        {

        }

        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoListItem> TodoListItems { get; set; }
    }
}
