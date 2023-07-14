using AutoMapper;
using Delivery.Management.MVC.Contracts;
using Delivery.Management.MVC.Models;
using Delivery.Management.MVC.Services.Base;

namespace Delivery.Management.MVC.Services
{
    public class DeliveryTypeService : BaseHttpService, IDeliveryTypeService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httClient;

        public DeliveryTypeService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httClient = httpClient;
        }

        public async Task<Response<int>> CreateDeliveryType(CreateDeliveryTypeVM deliveryType)
        {
            try
            {
                var response = new Response<int>();
                CreateDeliveryTypeDto createDeliveryType = _mapper.Map<CreateDeliveryTypeDto>(deliveryType);
                AddBearerToken();
                var apiResponse = await _client.DeliveryTypesPOSTAsync(createDeliveryType);
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

        public async Task<Response<int>> DeleteDeliveryType(int id)
        {
            try
            {
                AddBearerToken();
                await _client.DeliveryTypesDELETEAsync(id);
                return new Response<int>() { Success = true};
            }
            catch (ApiException ex) 
            {
                return ConvertApiException<int>(ex);
            }
        }

        public async Task<DeliveryTypeVM> GetDeliveryTypesDetails(int id)
        {
           AddBearerToken() ;
           var deliveryType = await _client.DeliveryTypesGETAsync(id);
           return _mapper.Map<DeliveryTypeVM>(deliveryType);
        }

        public async Task<List<DeliveryTypeVM>> GetDeliveryTypes()
        {
            AddBearerToken();
            var deliveryTypes = await _client.DeliveryTypesAllAsync();
            return _mapper.Map<List<DeliveryTypeVM>>(deliveryTypes);
        }

        public async Task<Response<int>> UpdateDeliveryType(int id, DeliveryTypeVM deliveryType)
        {
            try
            {
                DeliveryTypeDto deliveryTypeDto = _mapper.Map<DeliveryTypeDto>(deliveryType);
                AddBearerToken();
                await _client.DeliveryTypesPUTAsync(id.ToString(), deliveryTypeDto);
                return new Response<int>() { Success= true };
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }
    }
}
