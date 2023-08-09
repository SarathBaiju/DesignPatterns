using UnitOfWorkDemo.Repository.Context;
using UnitOfWorkDemo.Repository.Contracts;
using UnitOfWorkDemo.Repository.Entities;

namespace UnitOfWorkDemo.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly UnitOfWorkDbContext _dbContext;

        public ManagerRepository(UnitOfWorkDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Add(Manager manager)
        {
            this._dbContext.Manager.Add(manager);
            return true;
        }

        public bool Update(Manager manager)
        {
           this._dbContext.Manager.Update(manager);
            return true;
        }
    }
}
