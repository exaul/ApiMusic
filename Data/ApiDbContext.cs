using ApiMusic.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMusic.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        { 
        }

        public DbSet<Song> Songs { get; set; }
    }
}
