using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empleats.Models
{
    public class EmpleatItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Job { get; set; }
        public float Salary { get; set; }
    }
}
