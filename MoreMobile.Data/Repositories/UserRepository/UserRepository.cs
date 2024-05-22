using MoreMobile.Data.Context;
using MoreMobile.Domain.Entities;

namespace MoreMobile.Data.Repositories
{
    public class UserRepository : Repository<User, DatabaseContext>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        { }
    }
}