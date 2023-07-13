using System.Net.Http;

namespace Delivery.Management.MVC.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
            
        }
    }
}
