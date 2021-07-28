using AdvancedTaskControl.API.Models;
using AdvancedTaskControl.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace AdvancedTaskControl.Business.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserService _userService;

        public UserLoginService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Authenticate(User userLogin)
        {
            var users = await _userService.GetAll();
            var user = users.ToList()
                .Where(u => u.Username.ToLower() == userLogin.Username.ToLower())
                .FirstOrDefault();

            if (user == null || !BC.Verify(userLogin.Password, user.Password))
            {
                return null;
            }
            return user;                
        }
    }
}
