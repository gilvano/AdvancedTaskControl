using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedTaskControl.Business.Models
{
    public abstract class EntityBase
    {
        public DateTime? CreatedDate { get; set; } = null;
        public DateTime? ModifiedDate { get; set; } = null;
    }
}
