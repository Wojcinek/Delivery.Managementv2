using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Delivery.Management.Application.DTOs.DeliveryAllocation;
using Delivery.Management.Application.DTOs.DeliveryRequest;
using Delivery.Management.Application.DTOs.DeliveryType;
using Delivery.Management.Domain;

namespace Delivery.Management.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DeliveryRequest, DeliveryRequestDto>().ReverseMap();
            CreateMap<DeliveryAllocation, DeliveryAllocationDto>().ReverseMap();
            CreateMap<DeliveryType, DeliveryTypeDto>().ReverseMap();

            CreateMap<DeliveryRequest, CreateDeliveryRequestDto>().ReverseMap();
            CreateMap<DeliveryAllocation, CreateDeliveryAllocationDto>().ReverseMap();
            CreateMap<DeliveryType, CreateDeliveryTypeDto>().ReverseMap();
        }
    }
}
