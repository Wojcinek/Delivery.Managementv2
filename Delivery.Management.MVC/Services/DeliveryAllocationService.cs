using AutoMapper;
using Delivery.Management.MVC.Contracts;
using Delivery.Management.MVC.Models;
using Delivery.Management.MVC.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.Management.MVC.Services
{
    public class DeliveryAllocationService : BaseHttpService, IDeliveryAllocationService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httClient;

        public DeliveryAllocationService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httClient = httpClient;
        }

        public async Task<Response<int>> CreateDeliveryAllocation(CreateDeliveryAllocationVM deliveryAllocation)
        {
            try
            {
                var response = new Response<int>();
                CreateDeliveryAllocationDto createDeliveryAllocation = _mapper.Map<CreateDeliveryAllocationDto>(deliveryAllocation);
                var apiResponse = await _client.DeliveryAllocationsPOSTAsync(createDeliveryAllocation);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteDeliveryAllocation(int id)
        {
            try
            {
                await _client.DeliveryAllocationsDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex) 
            {
                return ConvertApiException<int>(ex);
            }
        }

        public async Task<DeliveryAllocationVM> GetDeliveryAllocationDetails(int id)
        {
            var deliveryAllocation = await _client.DeliveryAllocationsGETAsync(id);
            return _mapper.Map<DeliveryAllocationVM>(deliveryAllocation);
        }

        public async Task<List<DeliveryAllocationVM>> GetDeliveryAllocations()
        {
            var deliveryAllocations = await _client.DeliveryAllocationsAllAsync();
            return _mapper.Map<List<DeliveryAllocationVM>>(deliveryAllocations);
        }

        public async Task<Response<int>> UpdateDeliveryAllocation(int id, DeliveryAllocationVM deliveryAllocation)
        {
            try
            {
                DeliveryAllocationDto deliveryAllocationDto = _mapper.Map<DeliveryAllocationDto>(deliveryAllocation);
                await _client.DeliveryAllocationsPUTAsync(id.ToString(), deliveryAllocationDto);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex) 
            {
                return ConvertApiException<int>(ex);
            }
        }
    }
} 
