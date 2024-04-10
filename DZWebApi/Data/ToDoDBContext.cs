using DZWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace DZWebApi.Data
{
    public class ToDoDBContext:DbContext
    {
        public ToDoDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Todo> Todos { get; set; }

    }
}
