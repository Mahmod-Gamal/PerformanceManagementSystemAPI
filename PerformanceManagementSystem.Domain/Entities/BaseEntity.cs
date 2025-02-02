using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Domain.Entities
{
    public abstract class BaseEntity<T>
    {
        public T ID { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }



}
