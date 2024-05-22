using Azure.Core;
using MoreMobile.Application.Models;
using MoreMobile.Data.Repositories;
using MoreMobile.Domain.Entities;

namespace MoreMobile.Application.Services
{
    public class ServiceTypeService : IServiceTypeService
    {
        public IServiceTypeRepository ServiceTypeRepository { get; set; }

        public ServiceTypeService(IServiceTypeRepository serviceTypeRepository)
        {
            ServiceTypeRepository = serviceTypeRepository;
        }

        public async Task<List<ServiceTypeDTO>> GetAll()
        {
            var items = await ServiceTypeRepository.GetAllAsync();

            return items.Select(x => new ServiceTypeDTO()
            {
                Id = x.Id,
                Name = x.Name,
                NetPrice = x.NetPrice,
                GrossPrice = x.GrossPrice,
                VATRate = x.VATRate,
                WarrantyLengthInMonths = x.WarrantyLengthInMonths
            }).ToList();
        }

        public async Task<ServiceTypeDTO?> Get(Guid id)
        {
            ServiceType item = await ServiceTypeRepository.GetSingleAsync(x => x.Id == id);

            if (item == null)
                return null;

            return new ServiceTypeDTO
            {
                Id = item.Id,
                Name = item.Name,
                WarrantyLengthInMonths = item.WarrantyLengthInMonths,
                NetPrice = item.NetPrice,
                GrossPrice = item.GrossPrice,
                VATRate = item.VATRate
            };
        }

        public async Task<Guid?> Add(ServiceTypeDTO request)
        {
            ServiceType item = new ServiceType
            {
                Id = request.Id,
                Name = request.Name,
                WarrantyLengthInMonths = request.WarrantyLengthInMonths,
                NetPrice = request.NetPrice,
                GrossPrice = request.GrossPrice,
                VATRate = request.VATRate
            };

            ServiceTypeRepository.Add(item);
            await ServiceTypeRepository.SaveAsync();

            return item.Id;
        }

        public async Task<ServiceTypeDTO?> Update(ServiceTypeDTO request)
        {
            ServiceType item = await ServiceTypeRepository.GetSingleAsync(x => x.Id == request.Id);

            if (item is null)
                return null;

            item.Name = request.Name;
            item.WarrantyLengthInMonths = request.WarrantyLengthInMonths;
            item.NetPrice = request.NetPrice;
            item.GrossPrice = request.GrossPrice;
            item.VATRate = request.VATRate;

            ServiceTypeRepository.Edit(item);
            await ServiceTypeRepository.SaveAsync();

            return request;
        }

        public async Task Delete(Guid id)
        {
            ServiceType item = await ServiceTypeRepository.GetSingleAsync(x => x.Id == id);

            if (item is null)
                return;

            ServiceTypeRepository.Delete(item);
            await ServiceTypeRepository.SaveAsync();

            return;
        }
    }
}