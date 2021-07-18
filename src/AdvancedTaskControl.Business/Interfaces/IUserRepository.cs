﻿using AdvancedTaskControl.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Business.Interfaces
{
    public interface IUserRepository : IRepository<User>
    { 
        Task<bool> ExistsUsername(string username);
    }
}
