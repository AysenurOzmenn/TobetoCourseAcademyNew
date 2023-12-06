using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Course : Entity<Guid>
    {
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
