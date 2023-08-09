using UnitOfWorkDemo.Repository.Contracts;

namespace UnitOfWorkDemo.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IManagerRepository ManagerRepository { get; }
        void SaveChanges();
    }
}
