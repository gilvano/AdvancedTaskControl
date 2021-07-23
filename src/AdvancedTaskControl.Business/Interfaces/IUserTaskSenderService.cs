using AdvancedTaskControl.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedTaskControl.Business.Interfaces
{
    public interface IUserTaskSenderService
    {
        public void SendMessage(UserTask userTask);
    }
}
