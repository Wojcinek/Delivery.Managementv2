using System.Net.Http;

namespace Delivery.Management.MVC.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
