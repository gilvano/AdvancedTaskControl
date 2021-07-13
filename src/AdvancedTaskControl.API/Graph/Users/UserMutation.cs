using AdvancedTaskControl.API.Models;
using AdvancedTaskControl.API.ViewModels;
using AdvancedTaskControl.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedTaskControl.API.Graph.Users
{
    public class UserMutation
    {
        private readonly IUserService _userService;

        public UserMutation(IUserService userService)
        {
            _userService = userService;            
        }

        public async Task<User> Create(User user)
        {
            await _userService.Insert(user);

            return user;
        }
        public async Task<bool> Delete(User user)
        {
            await _userService.Remove(user.Id);

            return true;
        }
    }
}
