using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkDemo.Repository.Contracts;
using UnitOfWorkDemo.Repository.Entities;
using UnitOfWorkDemo.UnitOfWork;

namespace UnitOfWorkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            this._unitOfWork.EmployeeRepository.Add(new Repository.Entities.Employee { Id=3, Name="nandu", Age=26});

            this._unitOfWork.ManagerRepository.Add(new Manager() { Id = 1, Name = "test" });
            this._unitOfWork.SaveChanges();
            return Ok();
        }
    }
}
