﻿using AutoMapper;
using Delivery.Management.MVC.Models;
using Delivery.Management.MVC.Services.Base;

namespace Delivery.Management.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateDeliveryAllocationDto, CreateDeliveryAllocationVM>().ReverseMap();
            CreateMap<CreateDeliveryTypeDto, CreateDeliveryTypeVM>().ReverseMap();
            CreateMap<CreateDeliveryRequestDto, CreateDeliveryRequestVM>().ReverseMap();
            CreateMap<DeliveryTypeDto, DeliveryTypeVM>().ReverseMap();
            CreateMap<DeliveryAllocationDto, DeliveryAllocationVM>().ReverseMap();
            CreateMap<DeliveryRequestDto, DeliveryRequestVM>().ReverseMap();
            CreateMap<RegisterVM, RegistrationRequest>().ReverseMap();
            CreateMap<UpdateDeliveryRequestDto, DeliveryRequestVM>().ReverseMap();
        }
    }
}
