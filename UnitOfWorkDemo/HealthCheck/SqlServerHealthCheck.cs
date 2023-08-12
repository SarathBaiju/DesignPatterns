using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.CodeDom;
using UnitOfWorkDemo.UnitOfWork;

namespace UnitOfWorkDemo.HealthCheck
{
    public class SqlServerHealthCheck : IHealthCheck
    {
        private readonly IUnitOfWork _unitOfWork;

        public SqlServerHealthCheck(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                _unitOfWork.CheckStatus();
                return HealthCheckResult.Healthy("Working Fine");
            }catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy(ex.Message);
            }
        }
    }
}
