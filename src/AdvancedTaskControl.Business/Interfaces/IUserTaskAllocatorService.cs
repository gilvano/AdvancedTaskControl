using AdvancedTaskControl.Business.Models;
using System;

namespace AdvancedTaskControl.Business.Interfaces
{
    public interface IUserTaskAllocatorService : IDisposable
    {
        public UserTask AllocateUserTaskToUser(UserTask userTask);
    }
}
