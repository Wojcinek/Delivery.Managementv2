using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Application.Contracts.Identity;
using Delivery.Management.Application.Models.Identity;
using Delivery.Management.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Delivery.Management.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            return employees.Select(q => new Employee
            {
                Id = q.Id,
                Email = q.Email,
                FirstName = q.FirstName,
                LastName = q.LastName,
            }).ToList();
        }
    
    }
}
