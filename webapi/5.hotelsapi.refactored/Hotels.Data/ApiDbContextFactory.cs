using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Hotels.Data
{
    public class ApiDbContextFactory : IDesignTimeDbContextFactory<ApiDbContext>
    {
        public ApiDbContext CreateDbContext(string[] args)
        {
            // todo, this should be as configuration
            var connectionString =
                "Server=.;Initial Catalog=Hotels;;Trusted_Connection=True;MultipleActiveResultSets=true";

            var builder = new DbContextOptionsBuilder<ApiDbContext>();

            builder.UseSqlServer(connectionString);

            return new ApiDbContext(builder.Options);
        }
    }
}