using MoreMobile.Data.Context;
using MoreMobile.Domain.Entities;

namespace MoreMobile.Data.Repositories
{
    public class VisitDateRepository : Repository<VisitDate, DatabaseContext>, IVisitDateRepository
    {
        public VisitDateRepository(DatabaseContext context) : base(context)
        { }
    }
}