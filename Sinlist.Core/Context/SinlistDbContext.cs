using Microsoft.EntityFrameworkCore;
using Sinlist.Models.Entities.Sinlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
