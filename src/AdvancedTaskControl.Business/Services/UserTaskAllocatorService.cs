using AdvancedTaskControl.API.Models;
using AdvancedTaskControl.Business.Interfaces;
using AdvancedTaskControl.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Business.Services
{
    public class UserTaskAllocatorService : IUserTaskAllocatorService
    {
        private readonly IUserRepository _userRepository;

        public UserTaskAllocatorService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserTask AllocateUserTaskToUser(UserTask userTask)
        {
            var users = _userRepository.GetAllQueryable();
            var rand = new Random();
            var user = users.Skip(rand.Next(users.Count())).FirstOrDefault();
            userTask.UserId = user.Id;
            return userTask;
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }

    }
}
