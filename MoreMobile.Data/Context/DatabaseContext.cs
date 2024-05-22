using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoreMobile.Domain.Entities;

namespace MoreMobile.Data.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions options): base(options)
        {
            
        }

        //Add-Migration -Context DatabaseContext -o ".\Migrations\" <Nazwa migracji>
        //Update-Database -Context DatabaseContext
        //Remove-Migration -Context DatabaseContext

    }
}
