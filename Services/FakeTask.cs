using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FakeTask
    {
        public string Owner { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
        public int TaskId { get; set; }
    }
}
