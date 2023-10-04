using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AbpBookApp.EntityFrameworkCore
{
    public static class AbpBookAppDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AbpBookAppDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AbpBookAppDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
