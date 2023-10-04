using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AbpBookApp.Authorization.Roles;
using AbpBookApp.Authorization.Users;
using AbpBookApp.MultiTenancy;
using AbpBookApp.Models;

namespace AbpBookApp.EntityFrameworkCore
{
    public class AbpBookAppDbContext : AbpZeroDbContext<Tenant, Role, User, AbpBookAppDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Book> Books { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<University> Universities { get; set; }
        public AbpBookAppDbContext(DbContextOptions<AbpBookAppDbContext> options)
            : base(options)
        {
        }
    }
}
