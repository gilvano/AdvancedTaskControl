using System.Collections.Generic;

namespace AdvancedTaskControl.Business.Models
{
    public class Category : EntityBase
    {
        public int Id { get; set; }
        public string CategoryDescription { get; set; }
        public IEnumerable<UserTask> UserTasks { get; set; }
    }
}
