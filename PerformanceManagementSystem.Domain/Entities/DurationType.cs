﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Domain.Entities
{
    public class DurationType : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Duration> Durations{ get; set; }
    }
}
