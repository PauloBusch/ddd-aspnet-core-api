using Domain.Entities;
using Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class DDDContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DDDContext(DbContextOptions<DDDContext> options) : base(options) {}
    
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(builder);
        }
    }
}
