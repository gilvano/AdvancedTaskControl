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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Insert(User user)
        {
            if(await _userRepository.ExistsUsername(user.Username)) 
                return false;

            user.Password = BC.HashPassword(user.Password);

            await _userRepository.Add(user);
            return true;
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public IQueryable<User> GetAllQueryable()
        {
            return _userRepository.GetAllQueryable();
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
