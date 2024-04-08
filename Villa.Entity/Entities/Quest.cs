using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Villa.Entity.Entities
{
    public class Quest : BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }

    }
}