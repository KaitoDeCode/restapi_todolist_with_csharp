using api_with_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace api_with_csharp.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options): base(options) { 
        }
        public DbSet<UserModel> UserModels { get; set; } = null;
    }
}
