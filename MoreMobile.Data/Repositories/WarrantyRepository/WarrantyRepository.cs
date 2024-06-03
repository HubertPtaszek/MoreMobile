using MoreMobile.Data.Context;
using MoreMobile.Domain.Entities;

namespace MoreMobile.Data.Repositories
{
    public class WarrantyRepository : Repository<Warranty, DatabaseContext>, IWarrantyRepository
    {
        public WarrantyRepository(DatabaseContext context) : base(context)
        { }
    }
}