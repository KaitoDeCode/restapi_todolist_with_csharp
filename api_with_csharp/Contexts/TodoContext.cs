using api_with_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace api_with_csharp.Contexts
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { 
        }

        public DbSet<TodoModel> TodoModels { get; set; } = null;
    }
}
