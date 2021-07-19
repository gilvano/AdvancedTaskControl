using AdvancedTaskControl.Business.Interfaces;
using AdvancedTaskControl.Business.Models;
using AdvancedTaskControl.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Data.Repository
{
    public class UserTaskRepository : Repository<UserTask>, IUserTaskRepository
    {
        public UserTaskRepository(MeuDbContext context) : base(context) { }
    }
}
