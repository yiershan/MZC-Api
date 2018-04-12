using MZC.Configuration;
using MZC.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MZC.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MZCDbContextFactory : IDesignTimeDbContextFactory<MZCDbContext>
    {
        public MZCDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MZCDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MZCDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MZCConsts.ConnectionStringName));

            return new MZCDbContext(builder.Options);
        }
    }
}