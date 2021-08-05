using AdvancedTaskControl.Business.Interfaces;
using AdvancedTaskControl.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Business.Services
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IUserTaskRepository _userTaskRepository;
        private readonly IUserTaskAllocatorService _userTaskAllocatorService;

        public UserTaskService(IUserTaskRepository userTaskRepository, IUserTaskAllocatorService userTaskAllocatorService)
        {
            _userTaskRepository = userTaskRepository;
            _userTaskAllocatorService = userTaskAllocatorService;
        }

        public async Task Insert(UserTask userTask)
        {
            userTask = _userTaskAllocatorService.AllocateUserTaskToUser(userTask);
            await _userTaskRepository.Add(userTask);
        }

        public async Task<List<UserTask>> GetAll()
        {
            return await _userTaskRepository.GetAll();
        }

        public async Task<UserTask> GetById(int id)
        {
            return await _userTaskRepository.GetById(id);
        }        

        public async Task Remove(int id)
        {
            await _userTaskRepository.Remove(id);
        }

        public async Task Update(UserTask userTask)
        {
            await _userTaskRepository.Update(userTask);
        }

        public void Dispose()
        {
            _userTaskRepository?.Dispose();
        }
    }
}
