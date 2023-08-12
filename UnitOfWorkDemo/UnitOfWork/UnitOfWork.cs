using Microsoft.EntityFrameworkCore;
using UnitOfWorkDemo.Repository;
using UnitOfWorkDemo.Repository.Context;
using UnitOfWorkDemo.Repository.Contracts;

namespace UnitOfWorkDemo.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UnitOfWorkDbContext dbContext;
        public IEmployeeRepository EmployeeRepository { get; }

        public IManagerRepository ManagerRepository { get; }

        public UnitOfWork(UnitOfWorkDbContext context)
        {
            dbContext = context;
            EmployeeRepository = new EmployeeRepository(context);
            ManagerRepository = new ManagerRepository(context);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public bool CheckStatus()
        {
           var result = dbContext.Employee.First();
            return true;
        }
    }
}
