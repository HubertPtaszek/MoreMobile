using MoreMobile.Application.Models;

namespace MoreMobile.Application.Services
{
    public interface ICompanyService
    {
        Task<List<CompanyDTO>> GetAll();

        Task<CompanyDTO?> Get(string email);

        Task<CompanyDTO?> Update(CompanyDTO user);

        Task Delete(string email);
    }
}