using AdvancedTaskControl.API.Models;
using AdvancedTaskControl.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Insert(User user)
        {
           await _userRepository.Add(user);
            
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }        

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}
