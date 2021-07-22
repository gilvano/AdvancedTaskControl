using AdvancedTaskControl.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.API.ViewModels
{
    public class UserTaskViewModel
    {
        public string Description { get; set; }
        public string Resume { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
