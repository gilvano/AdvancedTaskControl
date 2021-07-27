using AdvancedTaskControl.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Business.Interfaces
{
    public interface IUserTaskService : IDisposable
    {
        Task Insert(UserTask userTask);
        Task Update(UserTask userTask);
        Task Remove(int id);
        Task<UserTask> GetById(int id);
        Task<List<UserTask>> GetAll();
    }
}
