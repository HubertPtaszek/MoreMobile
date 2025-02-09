using MoreMobile.Data.Context;
using MoreMobile.Domain.Entities;

namespace MoreMobile.Data.Repositories
{
    public class CompanyRepository : Repository<Company, DatabaseContext>, ICompanyRepository
    {
        public CompanyRepository(DatabaseContext context) : base(context)
        { }
    }
}