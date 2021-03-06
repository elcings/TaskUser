using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Domain.Entities;

namespace TaskUser.Infrastructure.Data
{
    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EFDbContext>
    //{
    //    public EFDbContext CreateDbContext(string[] args)
    //    {
    //        var builder = new DbContextOptionsBuilder<EFDbContext>();
    //        builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog=Light;");
    //        return new EFDbContext(builder.Options);
    //    }
    //}
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserLoginAttempt> Attempts { get; set; }
    }
}
