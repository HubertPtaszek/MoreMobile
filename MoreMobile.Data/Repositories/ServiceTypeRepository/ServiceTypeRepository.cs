using MoreMobile.Data.Context;
using MoreMobile.Domain.Entities;

namespace MoreMobile.Data.Repositories
{
    public class ServiceTypeRepository : Repository<ServiceType, DatabaseContext>, IServiceTypeRepository
    {
        public ServiceTypeRepository(DatabaseContext context) : base(context)
        { }
    }
}