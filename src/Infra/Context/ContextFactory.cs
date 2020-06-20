using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<DDDContext>
    {
        public DDDContext CreateDbContext(string[] args)
        {
            var connectionString = "server=locahost;port=3306;database=ddd;uid=root;pwd=123456";
            var builder = new DbContextOptionsBuilder<DDDContext>();
            builder.UseMySql(connectionString);
            return new DDDContext(builder.Options);
        }
    }
}
