using AdvancedTaskControl.API.Models;
using AdvancedTaskControl.Business.Interfaces;
using AdvancedTaskControl.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MeuDbContext context): base(context) { }

        public async Task<bool> ExistsUsername(string username)
        {
            var dbSet = _context.Set<User>();
            return await dbSet.AsNoTracking().AnyAsync(u => u.Username == username);
        }
    }
}
