using AdvancedTaskControl.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Business.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Resume { get; set; }        

    }
}
