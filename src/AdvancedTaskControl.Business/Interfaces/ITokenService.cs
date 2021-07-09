using AdvancedTaskControl.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedTaskControl.Business.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
