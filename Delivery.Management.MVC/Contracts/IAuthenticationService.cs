using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Delivery.Management.MVC.Models;

namespace Delivery.Management.MVC.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);

        Task<bool> Register(RegisterVM registration);

        Task Logout();

        
    }
}
