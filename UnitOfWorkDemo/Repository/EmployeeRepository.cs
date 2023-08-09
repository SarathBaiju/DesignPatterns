using System.Data.Entity;
using UnitOfWorkDemo.Repository.Context;
using UnitOfWorkDemo.Repository.Contracts;
using UnitOfWorkDemo.Repository.Entities;

namespace UnitOfWorkDemo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly UnitOfWorkDbContext context;

        public EmployeeRepository(UnitOfWorkDbContext context)
        {
            this.context = context;
        }
        public bool Add(Employee employee)
        {
            this.context.Employee.Add(employee);
            return true;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public bool Update(Employee employee)
        {
            this.context.Employee.Update(employee);
            return true;
        }
    }
}
