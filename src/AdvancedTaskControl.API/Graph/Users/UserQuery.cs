using AdvancedTaskControl.Business.Interfaces;
using AdvancedTaskControl.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedTaskControl.API.Graph.Users
{
    public class UserQuery
    {
        private readonly IUserService _userService;

        public UserQuery(IUserService userService)
        {
            this._userService = userService;
        }

        public IQueryable<User> Users => _userService.GetAllQueryable();
    }
}
