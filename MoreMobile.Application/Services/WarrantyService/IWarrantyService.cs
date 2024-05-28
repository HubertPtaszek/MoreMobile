using MoreMobile.Application.Models;

namespace MoreMobile.Application.Services
{
    public interface IWarrantyService
    {
        Task<List<WarrantyDTO>> GetAll();

        Task<List<WarrantyDTO>> GetUserAll(Guid userId);

        Task<WarrantyDTO?> Get(Guid id);

        Task<Guid?> Add(WarrantyDTO reques);

        Task<WarrantyDTO?> Update(WarrantyDTO request);

        Task Delete(Guid id);
    }
}