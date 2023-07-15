using AutoMapper;
using Delivery.Management.MVC.Contracts;
using Delivery.Management.MVC.Models;
using Delivery.Management.MVC.Services.Base;

namespace Delivery.Management.MVC.Services
{
    public class DeliveryRequestService : BaseHttpService, IDeliveryRequestService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public DeliveryRequestService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<Response<int>> CreateDeliveryRequest(CreateDeliveryRequestVM deliveryRequest)
        {
            try
            {
                var response = new Response<int>();
                CreateDeliveryRequestDto createDeliveryRequest = _mapper.Map<CreateDeliveryRequestDto>(deliveryRequest);
                var apiResponse = await _client.DeliveryRequestsPOSTAsync(createDeliveryRequest);
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

        public async Task<Response<int>> DeleteDeliveryRequest(int id)
        {
            try
            {
                AddBearerToken();
                await _client.DeliveryRequestsDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }

        public async Task<List<DeliveryRequestVM>> GetDeliveryRequests()
        {
            AddBearerToken();
            var deliveryRequests = await _client.DeliveryRequestsAllAsync();
            return _mapper.Map<List<DeliveryRequestVM>>(deliveryRequests);
        }

        public async Task<DeliveryRequestVM> GetDeliveryRequestsDetails(int id)
        {
            AddBearerToken();
            var deliveryRequests = await _client.DeliveryRequestsGETAsync(id);
            return _mapper.Map<DeliveryRequestVM>(deliveryRequests);
        }

        public async Task<Response<int>> UpdateDeliveryRequest(int id, DeliveryRequestVM deliveryRequest)
        {
            try
            {
                DeliveryRequestDto deliveryRequestDto = _mapper.Map<DeliveryRequestDto>(deliveryRequest);
                AddBearerToken();
                await _client.DeliveryRequestsPUTAsync(id, deliveryRequestDto);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }
    }
}
