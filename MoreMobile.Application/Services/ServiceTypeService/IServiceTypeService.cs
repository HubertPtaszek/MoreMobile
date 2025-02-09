using MoreMobile.Application.Models;

namespace MoreMobile.Application.Services
{
    public interface IServiceTypeService
    {
        Task<List<ServiceTypeDTO>> GetAll();

        Task<List<ServiceTypeDTO>> GetAll(Guid companyId);

        Task<ServiceTypeDTO?> Get(Guid id);

        Task<Guid?> Add(ServiceTypeDTO reques);

        Task<ServiceTypeDTO?> Update(ServiceTypeDTO request);

        Task Delete(Guid id);
    }
}