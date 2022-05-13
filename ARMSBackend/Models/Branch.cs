﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMSBackend.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public Organization Organization { get; set; }
    }
}
