using AdvancedTaskControl.API.Models;

namespace AdvancedTaskControl.Business.Models
{
    public class UserTask : EntityBase
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Resume { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
