﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests
{
    public class CreateCourseRequest
    {
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
