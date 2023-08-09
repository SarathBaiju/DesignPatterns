using UnitOfWorkDemo.Repository.Entities;

namespace UnitOfWorkDemo.Repository.Contracts
{
    public interface IManagerRepository
    {
        bool Add(Manager manager);
        bool Update(Manager manager);

    }
}
