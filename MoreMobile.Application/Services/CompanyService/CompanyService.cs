using MoreMobile.Application.Models;
using MoreMobile.Data.Repositories;
using MoreMobile.Domain.Entities;

namespace MoreMobile.Application.Services
{
    public class CompanyService : ICompanyService
    {
        public ICompanyRepository CompanyRepository { get; set; }

        public CompanyService(ICompanyRepository companyRepository)
        {
            CompanyRepository = companyRepository;
        }

        public async Task<List<CompanyDTO>> GetAll()
        {
            var companies = await CompanyRepository.GetAllAsync();

            return companies.Select(x => new CompanyDTO()
            {
                Email = x.Email,
                CompanyName = x.CompanyName,
            }).ToList();
        }

        public async Task<CompanyDTO?> Get(string email)
        {
            Company company = await CompanyRepository.GetSingleAsync(x => x.Email == email);

            if (company == null)
                return null;

            return new CompanyDTO
            {
                Email = company.Email,
                CompanyName = company.CompanyName,
                Warranties = company.Warranties.Select(z => new WarrantyDTO
                {
                    Id = z.Id,
                    CarModel = z.CarModel,
                    RegistrationNumber = z.RegistrationNumber,
                    VIN = z.VIN,
                    ServiceTypeId = z.ServiceTypeId,
                    ServiceDate = z.ServiceDate,
                    UserId = z.UserId,
                    LostWarranty = z.LostWarranty,
                    LossWarrantyReason = z.LossWarrantyReason,
                }).ToList(),
            };
        }

        public async Task<CompanyDTO?> Update(CompanyDTO request)
        {
            Company company = await CompanyRepository.GetSingleAsync(x => x.Email == request.Email);

            if (company is null)
                return null;

            company.CompanyName = request.CompanyName;

            CompanyRepository.Edit(company);
            await CompanyRepository.SaveAsync();

            return request;
        }

        public async Task Delete(string email)
        {
            Company Company = await CompanyRepository.GetSingleAsync(x => x.Email == email);
            if (Company is null)
                return;

            CompanyRepository.Delete(Company);
            await CompanyRepository.SaveAsync();

            return;
        }
    }
}