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

        public UserTaskService(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }

        public async Task<bool> Insert(UserTask userTask)
        {
            try
            {
                await _userTaskRepository.Add(userTask);
                return true;
            }
            catch
            {
                return false;
            }
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
