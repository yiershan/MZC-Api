using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MZC.EntityFrameworkCore
{
    public static class MZCDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MZCDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MZCDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}