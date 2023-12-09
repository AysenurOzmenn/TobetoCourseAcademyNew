using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses
{
    public class CreatedInstructorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
