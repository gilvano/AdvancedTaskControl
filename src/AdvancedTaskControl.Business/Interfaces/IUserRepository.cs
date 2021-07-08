﻿using AdvancedTaskControl.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Business.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        Task Add(User user);
        Task<User> GetById(int id);
        Task<List<User>> GetAll();
        Task Update(User user);
        Task Remove(int id);
        Task<int> SaveChanges();
    }
}