using Azure.Core;
using MoreMobile.Application.Models;
using MoreMobile.Data.Repositories;
using MoreMobile.Domain.Entities;
using System.Security.Claims;

namespace MoreMobile.Application.Services
{
    public class VisitDateService : IVisitDateService
    {
        public IVisitDateRepository VisitDateRepository { get; set; }

        public VisitDateService(IVisitDateRepository visitDateRepository)
        {
            VisitDateRepository = visitDateRepository;
        }

        public async Task<List<VisitDateDTO>> GetAll()
        {
            var items = await VisitDateRepository.GetAllAsync();

            return items.Select(x => new VisitDateDTO()
            {
                Id = x.Id,
                FirstVisit = x.FirstVisit,
                InspectionDate = x.InspectionDate,
                InspectionDone = x.InspectionDone,
                WarrantyId = x.WarrantyId,
            }).ToList();
        }

        public async Task<List<VisitDateDTO>> GetUserAll(Guid userId)
        {
            var items = await VisitDateRepository.GetAllAsync(x => x.Warranty.UserId == userId && (x.Warranty.User.CompanyId == null || x.Warranty.CompanyId == x.Warranty.User.CompanyId));

            return items.Select(x => new VisitDateDTO()
            {
                Id = x.Id,
                FirstVisit = x.FirstVisit,
                InspectionDate = x.InspectionDate,
                InspectionDone = x.InspectionDone,
                WarrantyId = x.WarrantyId,
            }).ToList();
        }

        public async Task<VisitDateDTO?> Get(Guid id)
        {
            VisitDate item = await VisitDateRepository.GetSingleAsync(x => x.Id == id);

            if (item == null)
                return null;

            return new VisitDateDTO
            {
                Id = item.Id,
                FirstVisit = item.FirstVisit,
                InspectionDate = item.InspectionDate,
                InspectionDone = item.InspectionDone,
                WarrantyId = item.WarrantyId,
            };
        }

        public async Task<Guid?> Add(VisitDateDTO request)
        {
            VisitDate item = new VisitDate
            {
                FirstVisit = request.FirstVisit,
                InspectionDate = request.InspectionDate,
                InspectionDone = request.InspectionDone,
                WarrantyId = request.WarrantyId,
            };

            VisitDateRepository.Add(item);
            await VisitDateRepository.SaveAsync();

            return item.Id;
        }

        public async Task<VisitDateDTO?> Update(VisitDateDTO request)
        {
            VisitDate visit = await VisitDateRepository.GetSingleAsync(x => x.Id == request.Id);

            if (visit is null)
                return null;

            visit.FirstVisit = request.FirstVisit;
            visit.InspectionDate = request.InspectionDate;
            visit.InspectionDone = request.InspectionDone;

            VisitDateRepository.Edit(visit);

            await VisitDateRepository.SaveAsync();

            return request;
        }

        public async Task Delete(Guid id)
        {
            VisitDate item = await VisitDateRepository.GetSingleAsync(x => x.Id == id);

            if (item is null)
                return;

            VisitDateRepository.Delete(item);
            await VisitDateRepository.SaveAsync();

            return;
        }
    }
}