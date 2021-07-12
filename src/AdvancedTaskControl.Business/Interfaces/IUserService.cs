using AdvancedTaskControl.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Business.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<bool> Insert(User user);
        Task Update(User user);
        Task Remove(int id);
        Task<User> GetById(int id);
        Task<List<User>> GetAll();
        IQueryable<User> GetAllQueryable();
    }
}
