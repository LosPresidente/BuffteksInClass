using Microsoft.EntityFrameworkCore;

namespace Buffteks.Models
{
    public class BuffteksContext : DbContext
    {
        public BuffteksContext (DbContextOptions<BuffteksContext> options)
            : base(options)
        {
        }

        public DbSet<Buffteks.Models.BuffMember> Member { get; set; }
        public DbSet<Buffteks.Models.BuffClient> Client { get; set; }
        public DbSet<Buffteks.Models.BuffProject> Project { get; set; }
    }
}