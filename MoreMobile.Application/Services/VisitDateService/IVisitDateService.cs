using MoreMobile.Application.Models;

namespace MoreMobile.Application.Services
{
    public interface IVisitDateService
    {
        Task<List<VisitDateDTO>> GetAll();

        Task<List<VisitDateDTO>> GetUserAll(Guid userId);

        Task<VisitDateDTO?> Get(Guid id);

        Task<Guid?> Add(VisitDateDTO reques);

        Task<VisitDateDTO?> Update(VisitDateDTO request);

        Task Delete(Guid id);
    }
}