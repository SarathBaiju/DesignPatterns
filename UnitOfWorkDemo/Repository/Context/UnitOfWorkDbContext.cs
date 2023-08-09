
using Microsoft.EntityFrameworkCore;
using UnitOfWorkDemo.Repository.Entities;

namespace UnitOfWorkDemo.Repository.Context
{
    public class UnitOfWorkDbContext : DbContext
    {
        public UnitOfWorkDbContext(DbContextOptions<UnitOfWorkDbContext> options) :base(options)
        {
                
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Manager> Manager { get; set; }
    }
}
