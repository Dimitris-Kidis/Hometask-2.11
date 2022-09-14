using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_2._11.Entities
{
    public class Client : BaseEntity
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }

    }
}
