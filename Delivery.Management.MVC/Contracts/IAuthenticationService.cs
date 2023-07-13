using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Delivery.Management.MVC.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);

        Task<bool> Register(string firstName, string lastName, string userName, string email, string password);

        Task Logout();

        
    }
}
