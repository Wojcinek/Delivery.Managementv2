using AutoMapper;
using Delivery.Management.MVC.Models;
using Delivery.Management.MVC.Services.Base;

namespace Delivery.Management.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateDeliveryAllocationDto, CreateDeliveryAllocationVM>().ReverseMap();
            CreateMap<DeliveryAllocationDto, DeliveryAllocationVM>().ReverseMap();
            CreateMap<RegisterVM, RegistrationRequest>().ReverseMap();
        }
    }
}
