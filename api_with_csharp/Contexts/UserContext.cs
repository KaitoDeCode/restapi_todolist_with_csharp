using api_with_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace api_with_csharp.Contexts
{
    public class UserContext : DbContext
    {
        public DbSet<UserModel> User { get; set; } // Hapus inisialisasi null

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
    }
}
