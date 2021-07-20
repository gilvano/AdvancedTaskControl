using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Business.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryDescription { get; set; }
        public IEnumerable<UserTask> UserTasks { get; set; }
    }
}
