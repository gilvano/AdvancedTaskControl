using AdvancedTaskControl.API.Models;
using AdvancedTaskControl.Business.Interfaces;
using AdvancedTaskControl.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MeuDbContext _context;

        public UserRepository(MeuDbContext context)
        {
            _context = context;
        }
        public async Task Add(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();           
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
