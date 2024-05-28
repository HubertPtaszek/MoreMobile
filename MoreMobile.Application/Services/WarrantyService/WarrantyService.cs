using Azure.Core;
using MoreMobile.Application.Models;
using MoreMobile.Data.Repositories;
using MoreMobile.Domain.Entities;
using System.Security.Claims;

namespace MoreMobile.Application.Services
{
    public class WarrantyService : IWarrantyService
    {
        public IWarrantyRepository WarrantyRepository { get; set; }
        public IVisitDateRepository VisitDateRepository { get; set; }

        public WarrantyService(IWarrantyRepository warrantyRepository, IVisitDateRepository visitDateRepository)
        {
            WarrantyRepository = warrantyRepository;
            VisitDateRepository = visitDateRepository;
        }

        public async Task<List<WarrantyDTO>> GetAll()
        {
            var items = await WarrantyRepository.GetAllAsync();

            return items.Select(x => new WarrantyDTO()
            {
                Id = x.Id,
                CarModel = x.CarModel,
                RegistrationNumber = x.RegistrationNumber,
                VIN = x.VIN,
                ServiceTypeId = x.ServiceTypeId,
                ServiceDate = x.ServiceDate,
                UserId = x.UserId,
                LostWarranty = x.LostWarranty,
                LossWarrantyReason = x.LossWarrantyReason,
                VisitDates = x.VisitDates.Select(z => new VisitDateDTO
                {
                    Id = z.Id,
                    FirstVisit = z.FirstVisit,
                    InspectionDate = z.InspectionDate,
                    InspectionDone = z.InspectionDone,
                }),
            }).ToList();
        }

        public async Task<List<WarrantyDTO>> GetUserAll(Guid userId)
        {
            var items = await WarrantyRepository.GetAllAsync(x => x.UserId == userId);

            return items.Select(x => new WarrantyDTO()
            {
                Id = x.Id,
                CarModel = x.CarModel,
                RegistrationNumber = x.RegistrationNumber,
                VIN = x.VIN,
                ServiceTypeId = x.ServiceTypeId,
                ServiceDate = x.ServiceDate,
                UserId = x.UserId,
                LostWarranty = x.LostWarranty,
                LossWarrantyReason = x.LossWarrantyReason,
                VisitDates = x.VisitDates.Select(z => new VisitDateDTO
                {
                    Id = z.Id,
                    FirstVisit = z.FirstVisit,
                    InspectionDate = z.InspectionDate,
                    InspectionDone = z.InspectionDone,
                }),
            }).ToList();
        }

        public async Task<WarrantyDTO?> Get(Guid id)
        {
            Warranty item = await WarrantyRepository.GetSingleAsync(x => x.Id == id);

            if (item == null)
                return null;

            return new WarrantyDTO
            {
                Id = item.Id,
                CarModel = item.CarModel,
                RegistrationNumber = item.RegistrationNumber,
                VIN = item.VIN,
                ServiceTypeId = item.ServiceTypeId,
                ServiceDate = item.ServiceDate,
                UserId = item.UserId,
                LostWarranty = item.LostWarranty,
                LossWarrantyReason = item.LossWarrantyReason,
                VisitDates = item.VisitDates.Select(z => new VisitDateDTO
                {
                    Id = z.Id,
                    FirstVisit = z.FirstVisit,
                    InspectionDate = z.InspectionDate,
                    InspectionDone = z.InspectionDone,
                }),
            };
        }

        public async Task<Guid?> Add(WarrantyDTO request)
        {
            Warranty item = new Warranty
            {
                CarModel = request.CarModel,
                RegistrationNumber = request.RegistrationNumber,
                VIN = request.VIN,
                ServiceTypeId = request.ServiceTypeId,
                ServiceDate = request.ServiceDate,
                UserId = request.UserId,
                LostWarranty = request.LostWarranty,
                LossWarrantyReason = request.LossWarrantyReason,
            };

            WarrantyRepository.Add(item);
            await WarrantyRepository.SaveAsync();

            foreach (var visitDate in request.VisitDates)
            {
                VisitDate visit = new VisitDate
                {
                    Id = visitDate.Id,
                    FirstVisit = visitDate.FirstVisit,
                    InspectionDate = visitDate.InspectionDate,
                    InspectionDone = visitDate.InspectionDone,
                    WarrantyId = item.Id,
                    Warranty = item
                };

                VisitDateRepository.Add(visit);
            }

            await VisitDateRepository.SaveAsync();

            return item.Id;
        }

        public async Task<WarrantyDTO?> Update(WarrantyDTO request)
        {
            Warranty item = await WarrantyRepository.GetSingleAsync(x => x.Id == request.Id);

            if (item is null)
                return null;

            item.CarModel = request.CarModel;
            item.RegistrationNumber = request.RegistrationNumber;
            item.VIN = request.VIN;
            item.ServiceTypeId = request.ServiceTypeId;
            item.ServiceDate = request.ServiceDate;
            item.UserId = request.UserId;
            item.LostWarranty = request.LostWarranty;
            item.LossWarrantyReason = request.LossWarrantyReason;

            WarrantyRepository.Edit(item);
            await WarrantyRepository.SaveAsync();

            foreach (var visitDate in request.VisitDates)
            {
                VisitDate visit = await VisitDateRepository.GetSingleAsync(x => x.Id == visitDate.Id);

                if (visit is null)
                    continue;

                visit.FirstVisit = visitDate.FirstVisit;
                visit.InspectionDate = visitDate.InspectionDate;
                visit.InspectionDone = visitDate.InspectionDone;

                VisitDateRepository.Edit(visit);
            }

            await VisitDateRepository.SaveAsync();

            return request;
        }

        public async Task Delete(Guid id)
        {
            Warranty item = await WarrantyRepository.GetSingleAsync(x => x.Id == id);

            if (item is null)
                return;

            foreach (var visitDate in item.VisitDates)
                VisitDateRepository.Delete(visitDate);

            await VisitDateRepository.SaveAsync();

            WarrantyRepository.Delete(item);
            await WarrantyRepository.SaveAsync();

            return;
        }
    }
}