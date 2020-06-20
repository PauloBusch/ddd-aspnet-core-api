using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class DDDContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DDDContext(DbContextOptions<DDDContext> options) : base(options) {}
    
        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
        }
    }
}
