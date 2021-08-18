using AdvancedTaskControl.Business.Models;
using System.Collections.Generic;

namespace AdvancedTaskControl.API.Models
{
    public class User : EntityBase
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public IEnumerable<UserTask> UserTasks { get; set; }


    }
}
