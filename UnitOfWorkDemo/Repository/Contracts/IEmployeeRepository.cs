using UnitOfWorkDemo.Repository.Entities;

namespace UnitOfWorkDemo.Repository.Contracts
{
    public interface IEmployeeRepository
    {
        bool Add(Employee employee);
        bool Update(Employee employee);
        void SaveChanges();

    }
}
